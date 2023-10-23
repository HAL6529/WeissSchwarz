using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectBrainStormForDraw : MonoBehaviour
{
    [SerializeField] GameManager m_GameManager;
    [SerializeField] BattleStrix m_BattleStrix;

    public void BrainStormForDraw(int place)
    {
        m_GameManager.myStockList.RemoveAt(0);
        for (int i = 0; i < 4; i++)
        {
            
        }
        Debug.Log("W’†");
    }
}
