using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectBondForHandToField : MonoBehaviour
{
    [SerializeField] GameManager m_GameManager;
    [SerializeField] BattleStrix m_BattleStrix;


    public void BondForCost(EnumController.CardNo sulvageCardNo, int num)
    {
        for(int i = 0; i < num; i++)
        {
            m_GameManager.GraveYardList.Add(m_GameManager.myStockList[0]);
            m_GameManager.myStockList.RemoveAt(0);
        }
        m_GameManager.Syncronize();
        CheckExistSulvageCard(sulvageCardNo);
    }

    private void CheckExistSulvageCard(EnumController.CardNo sulvageCardNo)
    {
        for (int i = 0; i < m_GameManager.GraveYardList.Count; i++)
        {
            if(m_GameManager.GraveYardList[i].cardNo == sulvageCardNo)
            {
                BattleModeCard card = m_GameManager.GraveYardList[i];
                m_GameManager.GraveYardList.RemoveAt(i);
                m_GameManager.myHandList.Add(card);

                m_GameManager.Syncronize();
                return;
            }
        }
        return;
    }
}
