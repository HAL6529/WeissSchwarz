using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_088 : EffectAbstract
{
    public override void AutoExecute1()
    {
        //【自】［(2)］ このカードがプレイされて舞台に置かれた時、あなたはコストを払ってよい。そうしたら、あなたは自分のクロックを上から1枚選び、控え室に置く。
        PayCost(2);
        int cnt = m_GameManager.myClockList.Count;
        if (cnt == 0)
        {
            return;
        }
        m_GameManager.GraveYardList.Add(m_GameManager.myClockList[cnt - 1]);
        m_GameManager.myClockList.RemoveAt(cnt - 1);
        m_GameManager.Syncronize();
        m_GameManager.ExecuteActionList();
        m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
        return;
    }
}
