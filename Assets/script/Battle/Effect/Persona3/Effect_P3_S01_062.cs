using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_062 : EffectAbstract
{
    public override void AutoExecute1()
    {
        // 【自】［(1)］ バトルしているこのカードが【リバース】した時、あなたはコストを払ってよい。そうしたら、このカードを手札に戻す。
        PayCost(1);
        m_MyMainCardsManager.CallPutHandFromField(GetIntParamater1());
        m_GameManager.ExecuteActionList();
        m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
        return;
    }
}
