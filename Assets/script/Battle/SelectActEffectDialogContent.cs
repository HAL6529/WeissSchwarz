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
                // �y�N�z�m(1)�n ���Ȃ��͎����̃L������1���I�сA���̃^�[�����A�p���[���{1500�B
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
                // �y�N�z�m(1)�n ���̃J�[�h���v���o�ɂ���B
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
        // 25�������x�ŉ��s���邱��
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
                // �y�N�z�m(1)�n ���Ȃ��͎����̃L������1���I�сA���̃^�[�����A�p���[���{1500�B
                case EnumController.CardNo.LB_W02_02T:
                    text1 = "�y�N�z�m(1)�n ���Ȃ��͎����̃L������1���I�сA";
                    text2 = "���̃^�[�����A�p���[���{1500�B";
                    break;
                default:
                    break;
            }
        }
        else if (effectNum == 1)
        {
            switch (m_BattleModeCard.cardNo)
            {
                // �y�N�z�m(1)�n ���̃J�[�h���v���o�ɂ���B
                case EnumController.CardNo.LB_W02_02T:
                    text1 = "�y�N�z�m(1)�n ���̃J�[�h���v���o�ɂ���B";
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
