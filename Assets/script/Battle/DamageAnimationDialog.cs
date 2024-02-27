using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAnimationDialog : MonoBehaviour
{
    [SerializeField] List<DamageCardAnimation> DamageCardAnimationList = new List<DamageCardAnimation>();
    [SerializeField] GameManager m_GameManager;

    private EnumController.DamageAnimation m_DamageAnimation = EnumController.DamageAnimation.VOID;

    /// <summary>
    /// ダメージとして受けるカードリスト
    /// </summary>
    private List<BattleModeCard> tempList = new List<BattleModeCard>();

    public void SetBattleModeCard(List<BattleModeCard> list)
    {
        m_GameManager.isDamageAnimation = true;
        m_DamageAnimation = EnumController.DamageAnimation.VOID;
        tempList = list;
        if (list.Count == 0)
        {
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
        for (int i = 0;i < DamageCardAnimationList.Count; i++)
        {
            Debug.Log(i);
            if (i < list.Count - 1)
            {
                DamageCardAnimationList[i].AnimationStart(i, list[i], false);
            }
            else if(i == list.Count - 1)
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
                m_GameManager.Damage2ForCancel(tempList);
                break;
            case EnumController.DamageAnimation.DAMAGED:
                m_GameManager.Damage2ForDamaged(tempList);
                break;
            default:
                break;
        }
    }
}
