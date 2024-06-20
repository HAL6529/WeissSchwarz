using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSendMemory : MonoBehaviour
{
    [SerializeField] GameManager m_GameManager;
    [SerializeField] BattleStrix m_BattleStrix;
    [SerializeField] MyMainCardsManager m_MyMainCardsManager;

    public void SendFieldToMemory(int place)
    {
        m_GameManager.GraveYardList.Add(m_GameManager.myStockList[m_GameManager.myStockList.Count - 1]);
        m_GameManager.myStockList.RemoveAt(m_GameManager.myStockList.Count - 1);
        m_GameManager.myMemoryList.Add(m_GameManager.myFieldList[place]);
        m_GameManager.myFieldList[place] = null;
        m_MyMainCardsManager.setBattleModeCard(place, null, EnumController.State.STAND);
        m_GameManager.Syncronize();
    }
}
