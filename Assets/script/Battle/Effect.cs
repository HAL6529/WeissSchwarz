using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    private GameManager m_GameManager = null;
    private BattleStrix m_BattleStrix = null;

    public Effect(GameManager m_GameManager, BattleStrix m_BattleStrix)
    {
        this.m_GameManager = m_GameManager;
        this.m_BattleStrix = m_BattleStrix;
    }

    public void BondForHandToFild(BattleModeCard card)
    {
        switch (card.cardNo)
        {
            case EnumController.CardNo.AT_WX02_A10:
                if (ConfirmStockForCost(1))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_BOND_FOR_HAND_TO_FIELD, card);
                }
                return;
            default:
                return;
        }
    }

    private bool ConfirmStockForCost(int num)
    {
        if(m_GameManager.myStockList.Count >= num)
        {
            return true;
        }
        return false;
    }

    public void CheckEffectForAct(BattleModeCard card, int num)
    {
        switch (card.cardNo)
        {
            //�h���[�W��
            case EnumController.CardNo.AT_WX02_A09:
                if (ConfirmStockForCost(1))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_BRAIN_STORM_FOR_DRAW, card, num);
                }
                return;
            default:
                return;
        }
    }

    /// <summary>
    /// �����̌��ʂ������Ă��邩���ׂ�
    /// </summary>
    /// <param name="card">BattleModeCard</param>
    /// <returns></returns>
    public PowerInstance.Assist CheckEffectForAssist(BattleModeCard card)
    {
        if(card == null)
        {
            return new PowerInstance.Assist(0);
        }
        switch (card.cardNo)
        {
            // 500����
            case EnumController.CardNo.AT_WX02_A11:
                return new PowerInstance.Assist(500);
            default:
                return new PowerInstance.Assist(0);
        }
    }

    /// <summary>
    /// �K�E���̌��ʂ������Ă��邩���ׂ�
    /// </summary>
    /// <param name="card"></param>
    /// <returns></returns>
    public PowerInstance.Gaul CheckEffectForGaul(BattleModeCard card)
    {
        if (card == null)
        {
            return new PowerInstance.Gaul();
        }
        List<EnumController.Attribute> AttributeList = new List<EnumController.Attribute>();

        switch (card.cardNo)
        {
            // �K�E�����ʂ������Ă���
            case EnumController.CardNo.AT_WX02_A12:
                AttributeList.Add(EnumController.Attribute.Ooo);
                return new PowerInstance.Gaul(500, AttributeList);
            default:
                return new PowerInstance.Gaul();
        }
    }

    public void WhenAttack(BattleModeCard card)
    {
        switch (card.cardNo)
        {
            case EnumController.CardNo.AT_WX02_A02:
                return;
            default:
                return;
        }
    }
}
