using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_LB_W02_057 : EffectAbstract
{
    public override void AutoExecute1()
    {
        //【自】 このカードが【リバース】した時、このカードとバトルしているキャラのレベルが0以下なら、あなたはそのキャラを【リバース】してよい。
        m_EnemyMainCardsManager.CallReverse(GetIntParamater1());
        m_BattleStrix.RpcToAll("CallMyReverse", GetIntParamater1(), m_GameManager.isTurnPlayer);
        m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
        m_GameManager.ExecuteActionList();
        return;
    }
}
