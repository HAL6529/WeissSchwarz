using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectBrainStormForDraw : MonoBehaviour
{
    [SerializeField] GameManager m_GameManager;
    [SerializeField] BattleStrix m_BattleStrix;

    public void BrainStormForDraw(int place)
    {
        m_GameManager.GraveYardList.Add(m_GameManager.myStockList[0]);
        m_GameManager.myStockList.RemoveAt(0);
        for (int i = 0; i < 4; i++)
        {

        }
        m_GameManager.UpdateMyGraveYardCards();
        m_BattleStrix.SendUpdateEnemyGraveYard(m_GameManager.GraveYardList, m_GameManager.isFirstAttacker);

        m_GameManager.UpdateMyStockCards();
        m_BattleStrix.SendUpdateEnemyStockCards(m_GameManager.myStockList, m_GameManager.isTurnPlayer);
        Debug.Log("W’†");
    }
}
