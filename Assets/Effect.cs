using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    private GameManager m_GameManager = null;
    private EffectBondForHandToField m_EffectBondForHandToField = null;

    public Effect(GameManager m_GameManager)
    {
        this.m_GameManager = m_GameManager;
        m_EffectBondForHandToField = new EffectBondForHandToField(m_GameManager);
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

    public void BondForHandToFild(BattleModeCard card)
    {
        switch (card.cardNo)
        {
            case EnumController.CardNo.AT_WX02_A10:
                if (ConfirmStockForCost(1))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_BOND_FOR_HAND_TO_FIELD, card);
                    Debug.Log("ãJ”\—Í");
                }
                return;
            default:
                Debug.Log("ãJ”\—Í‚ğ‚Á‚Ä‚¢‚È‚¢");
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
}
