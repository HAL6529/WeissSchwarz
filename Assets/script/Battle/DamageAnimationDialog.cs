using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAnimationDialog : MonoBehaviour
{
    [SerializeField] BattleModeCardList m_BattleModeCardList;
    [SerializeField] List<DamageCardAnimation> DamageCardAnimationList = new List<DamageCardAnimation>();
    [SerializeField] GameManager m_GameManager;

    private EnumController.DamageAnimation m_DamageAnimation = EnumController.DamageAnimation.VOID;

    /// <summary>
    /// ダメージとして受けるカードリスト
    /// </summary>
    private List<BattleModeCard> tempList = new List<BattleModeCard>();

    private int place = -1;

    public void SetBattleModeCard(List<BattleModeCard> list, int place)
    {
        m_GameManager.isDamageAnimation = true;
        m_DamageAnimation = EnumController.DamageAnimation.VOID;
        this.place = place;
        tempList = list;
        if (list.Count == 0)
        {
            m_DamageAnimation = EnumController.DamageAnimation.DAMAGE_ZERO;
            NextAction();
            return;
        }

        /// キャンセルの場合、ステータスをキャンセルに変更
        if (list[list.Count - 1].type == EnumController.Type.CLIMAX)
        {
            m_DamageAnimation = EnumController.DamageAnimation.CANCEL;
        }
        else
        {
            m_DamageAnimation = EnumController.DamageAnimation.DAMAGED;
        }

        this.gameObject.SetActive(true);
        for (int i = 0; i < DamageCardAnimationList.Count; i++)
        {
            if (i < list.Count - 1)
            {
                DamageCardAnimationList[i].AnimationStart(i, list[i], false);
            }
            else if (i == list.Count - 1)
            {
                DamageCardAnimationList[i].AnimationStart(i, list[i], true);
            }
            else
            {
                DamageCardAnimationList[i].NotAnimation();
            }
        }
    }

    /// <summary>
    /// このメソッドはターンプレイヤーが呼び出用
    /// </summary>
    /// <param name="list"></param>
    public void SetBattleModeCardForTurnPlayer(List<BattleModeCardTemp> cardList)
    {
        List<BattleModeCard> list = new List<BattleModeCard>();
        for (int i = 0; i < cardList.Count; i++)
        {
            BattleModeCard b = m_BattleModeCardList.ConvertCardNoToBattleModeCard(cardList[i].cardNo);
            list.Add(b);
        }

        m_GameManager.isDamageAnimation = true;
        m_DamageAnimation = EnumController.DamageAnimation.VOID;
        place = -1;
        tempList = list;
        if (list.Count == 0)
        {
            return;
        }

        this.gameObject.SetActive(true);
        for (int i = 0; i < DamageCardAnimationList.Count; i++)
        {
            if (i < list.Count - 1)
            {
                DamageCardAnimationList[i].AnimationStart(i, list[i], false);
            }
            else if (i == list.Count - 1)
            {
                DamageCardAnimationList[i].AnimationStart(i, list[i], true);
            }
            else
            {
                DamageCardAnimationList[i].NotAnimation();
            }
        }
    }

    public void OffDialog()
    {
        m_GameManager.isDamageAnimation = false;
        for (int i = 0; i < DamageCardAnimationList.Count; i++)
        {
            DamageCardAnimationList[i].NotAnimation();
        }
        this.gameObject.SetActive(false);
    }

    public void NextAction()
    {
        switch (m_DamageAnimation)
        {
            case EnumController.DamageAnimation.CANCEL:
                m_GameManager.DamageForFrontAttack2ForCancel(tempList, place);
                return;
            case EnumController.DamageAnimation.DAMAGE_ZERO:
            case EnumController.DamageAnimation.DAMAGED:
                m_GameManager.DamageForFrontAttack2ForDamaged(tempList, place);
                return;
            default:
                return;
        }
    }
}
