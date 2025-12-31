using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_095 : EffectAbstract
{
    public override void EventExecute1()
    {
        // ※イベント
        // あなたは自分のクロックすべてを、手札に戻す。このカードを思い出にする。
        PayCost(8);
        for (int i = 0; i < m_GameManager.myClockList.Count; i++)
        {
            m_GameManager.myHandList.Add(m_GameManager.myClockList[i]);
        }
        m_GameManager.myClockList = new List<BattleModeCard>();
        m_GameManager.myHandList.RemoveAt(IntParamater1);
        m_GameManager.myMemoryList.Add(m_BattleModeCard);
        m_GameManager.Syncronize();
        m_GameManager.ExecuteActionList();
        return;
    }
}
