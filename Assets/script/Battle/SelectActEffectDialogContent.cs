using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectActEffectDialogContent : MonoBehaviour
{
    private GameManager m_GameManager;
    private BattleModeCard m_BattleModeCard;
    private int effectNum = -1;
    private int paramaterNum1 = -1;

    public SelectActEffectDialogContent(GameManager m_GameManager, BattleModeCard m_BattleModeCard, int effectNum)
    {
        this.m_GameManager = m_GameManager;
        this.m_BattleModeCard = m_BattleModeCard;
        this.effectNum = effectNum;
    }

    public void Execute()
    {
        if(m_BattleModeCard == null || effectNum == -1)
        {
            return;
        }

        if(effectNum == 0)
        {
            switch (m_BattleModeCard.cardNo)
            {
                // 【起】［(1)］ あなたは自分のキャラを1枚選び、そのターン中、パワーを＋1500。
                case EnumController.CardNo.LB_W02_02T:
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_LB_W02_02T_1, m_BattleModeCard);
                    break;
                default:
                    break;
            }
        }else if(effectNum == 1)
        {
            switch (m_BattleModeCard.cardNo)
            {
                // 【起】［(1)］ このカードを思い出にする。
                case EnumController.CardNo.LB_W02_02T:
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_LB_W02_02T_2, m_BattleModeCard, paramaterNum1);
                    break;
                default:
                    break;
            }
        }
    }

    public List<string> GetText()
    {
        // 25文字程度で改行すること
        List<string> list = new List<string>();
        string text1 = "";
        string text2 = "";
        string text3 = "";

        if (m_BattleModeCard == null || effectNum == -1)
        {
            return null;
        }

        if (effectNum == 0)
        {
            switch (m_BattleModeCard.cardNo)
            {
                // 【起】［(1)］ あなたは自分のキャラを1枚選び、そのターン中、パワーを＋1500。
                case EnumController.CardNo.LB_W02_02T:
                    text1 = "【起】［(1)］ あなたは自分のキャラを1枚選び、";
                    text2 = "そのターン中、パワーを＋1500。";
                    break;
                default:
                    break;
            }
        }
        else if (effectNum == 1)
        {
            switch (m_BattleModeCard.cardNo)
            {
                // 【起】［(1)］ このカードを思い出にする。
                case EnumController.CardNo.LB_W02_02T:
                    text1 = "【起】［(1)］ このカードを思い出にする。";
                    break;
                default:
                    break;
            }
        }

        list.Add(text1);
        list.Add(text2);
        list.Add(text3);
        return list;
    }

    public void SetParamaterNum1(int num)
    {
        paramaterNum1 = num;
    }
}
