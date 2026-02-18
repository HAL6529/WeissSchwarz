using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_071 : EffectAbstract
{
    public override void EventExecute1()
    {
        // ※イベント
        // あなたは相手に1ダメージを与える。
        PayCost(1);
        m_BattleStrix.RpcToAll("CallDamage", 1, GetIntParamater1(), m_GameManager.isFirstAttacker);
        return;
    }
}
