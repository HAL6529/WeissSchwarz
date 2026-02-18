using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_LB_W02_054 : EffectAbstract
{
    public override void ActExecute1()
    {
        //【起】［(2) このカードを【レスト】する］ あなたは相手に1ダメージを与える。
        PayCost(2);
        m_MyMainCardsManager.CallOnRest(GetIntParamater1());
        m_GameManager.Syncronize();
        m_BattleStrix.RpcToAll("CallDamage", 1, GetIntParamater2(), m_GameManager.isFirstAttacker);
        return;
    }
}
