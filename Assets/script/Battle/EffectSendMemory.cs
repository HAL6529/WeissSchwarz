using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSendMemory : MonoBehaviour
{
    [SerializeField] GameManager m_GameManager;
    [SerializeField] BattleStrix m_BattleStrix;

    public void SendMemory(int place)
    {
        m_GameManager.myMemoryList.Add(m_GameManager.myFieldList[place]);
        m_GameManager.myFieldList[place] = null;
    }
}
