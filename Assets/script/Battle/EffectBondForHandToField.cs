using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectBondForHandToField : MonoBehaviour
{
    [SerializeField] GameManager m_GameManager;
    [SerializeField] BattleStrix m_BattleStrix;


    public void BondForCost(string sulvageCardName, int num)
    {
        for(int i = 0; i < num; i++)
        {
            m_GameManager.GraveYardList.Add(m_GameManager.myStockList[m_GameManager.myStockList.Count - 1]);
            m_GameManager.myStockList.RemoveAt(m_GameManager.myStockList.Count - 1);
        }
        m_GameManager.Syncronize();
        CheckExistSulvageCard(sulvageCardName);
    }

    private void CheckExistSulvageCard(string sulvageCardName)
    {
        for (int i = 0; i < m_GameManager.GraveYardList.Count; i++)
        {
            if (m_GameManager.GraveYardList[i].GetName().Equals(sulvageCardName))
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
