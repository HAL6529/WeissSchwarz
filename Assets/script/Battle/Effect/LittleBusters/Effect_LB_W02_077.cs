using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_LB_W02_077 : EffectAbstract
{
    public override void AutoExecute1()
    {
        //【自】 このカードがアタックした時、クライマックス置場に「２つの長い影」があるなら、あなたは1枚引く。
        m_GameManager.Draw();
        m_GameManager.ExecuteActionList();
        return;
    }

    public override void ActExecute1()
    {
        //【起】［(3)］ あなたは自分のクロックを上から1枚選び、控え室に置く。
        PayCost(3);
        if (m_GameManager.myClockList.Count == 0)
        {
            return;
        }
        m_GameManager.GraveYardList.Add(m_GameManager.myClockList[m_GameManager.myClockList.Count - 1]);
        m_GameManager.myClockList.RemoveAt(m_GameManager.myClockList.Count - 1);
        m_GameManager.Syncronize();
        m_GameManager.ExecuteActionList();
        return;
    }
}
