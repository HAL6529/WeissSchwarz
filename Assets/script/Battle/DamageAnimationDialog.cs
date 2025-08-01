using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAnimationDialog : MonoBehaviour
{
    [SerializeField] BattleModeCardList m_BattleModeCardList;
    [SerializeField] List<DamageCardAnimation> DamageCardAnimationList = new List<DamageCardAnimation>();
    [SerializeField] GameManager m_GameManager;
    [SerializeField] BattleStrix m_BattleStrix;

    private EnumController.DamageAnimation m_DamageAnimation = EnumController.DamageAnimation.VOID;

    /// <summary>
    /// ダメージとして受けるカードリスト
    /// </summary>
    private List<BattleModeCard> tempList = new List<BattleModeCard>();

    private int place = -1;

    private int handNum = -1;

    public void SetBattleModeCardForEffect(List<BattleModeCard> list, int handNum)
    {
        m_GameManager.isDamageAnimation = true;
        m_DamageAnimation = EnumController.DamageAnimation.EFFECT;
        this.handNum = handNum;
        this.place = place;
        tempList = list;

        if (list.Count == 0)
        {
            NextAction();
            return;
        }

        this.gameObject.SetActive(true);

        if (list[list.Count - 1].type == EnumController.Type.CLIMAX)
        {
            m_DamageAnimation = EnumController.DamageAnimation.EFFECT_CANCEL;
        }

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

    public void SetBattleModeCard(List<BattleModeCard> list, int place)
    {
        m_GameManager.isDamageAnimation = true;
        m_DamageAnimation = EnumController.DamageAnimation.VOID;
        this.place = place;
        this.handNum = -1;
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
        this.handNum = -1;
        tempList = list;
        if (list.Count == 0)
        {
            m_GameManager.isDamageAnimation = false;
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
            case EnumController.DamageAnimation.EFFECT:
                EFFECT();
                return;
            case EnumController.DamageAnimation.EFFECT_CANCEL:
                EFFECT_CANCEL();
                return;
            default:
                return;
        }
    }

    private void EFFECT()
    {
        for (int n = 0; n < tempList.Count; n++)
        {
            m_GameManager.myClockList.Add(tempList[n]);
        }
        m_GameManager.Syncronize();
        m_BattleStrix.RpcToAll("RemoveHand", handNum, m_GameManager.isFirstAttacker);

        if (m_GameManager.LevelUpCheck())
        {
            return;
        }

        if (m_GameManager.myDeckList.Count == 0)
        {
            m_GameManager.Refresh();
            return;
        }
        m_GameManager.ExecuteActionList();
    }

    private void EFFECT_CANCEL()
    {
        for (int n = 0; n < tempList.Count; n++)
        {
            m_GameManager.GraveYardList.Add(tempList[n]);
        }
        m_GameManager.Syncronize();
        m_BattleStrix.RpcToAll("RemoveHand", handNum, m_GameManager.isFirstAttacker);

        if (m_GameManager.LevelUpCheck())
        {
            return;
        }

        if (m_GameManager.myDeckList.Count == 0)
        {
            m_GameManager.Refresh();
            return;
        }
        m_GameManager.ExecuteActionList();
    }
}
