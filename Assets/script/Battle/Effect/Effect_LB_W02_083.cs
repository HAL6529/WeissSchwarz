using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_LB_W02_083 : EffectAbstract
{
    public override void ActExecute1()
    {
        // 【起】［(2) このカードを【レスト】する］ あなたは自分のクロックを上から1枚選び、控え室に置く。
        PayCost(2);
        m_MyMainCardsManager.CallOnRest(IntParamater1);
        m_GameManager.Syncronize();

        if (m_GameManager.myClockList.Count == 0)
        {
            m_GameManager.ExecuteActionList();
            return;
        }
        m_GameManager.GraveYardList.Add(m_GameManager.myClockList[m_GameManager.myClockList.Count - 1]);
        m_GameManager.myClockList.RemoveAt(m_GameManager.myClockList.Count - 1);
        m_GameManager.Syncronize();
        m_GameManager.ExecuteActionList();
    }

    public override void AutoExecute1()
    {
        // 【自】 あなたがレベルアップした時、あなたは自分の山札を上から1枚選び、ストック置場に置く。
        m_GameManager.myStockList.Add(m_GameManager.myDeckList[0]);
        m_GameManager.myDeckList.RemoveAt(0);
        m_GameManager.Syncronize();
        if (m_GameManager.myDeckList.Count == 0)
        {
            m_GameManager.Refresh();
        }
        else
        {
            m_GameManager.ExecuteActionList();
            return;
        }
        return;
    }
}
