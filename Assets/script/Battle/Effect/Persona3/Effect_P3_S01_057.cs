using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_057 : EffectAbstract
{
    public override void AutoExecute1()
    {
        //【自】 このカードがプレイされて舞台に置かれた時、あなたは相手の控え室のイベントを1枚選び、思い出にしてよい。
        m_DialogManager.GraveyardSelectDialog(m_BattleModeCard);
        return;
    }

    public override void AutoExecute2()
    {
        //【自】 このカードが【リバース】した時、このカードとバトルしているキャラのレベルが0以下なら、あなたはそのキャラを【リバース】してよい。
        m_EnemyMainCardsManager.CallReverse(GetIntParamater1());
        m_BattleStrix.RpcToAll("CallMyReverse", GetIntParamater1(), m_GameManager.isTurnPlayer);
        m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
        m_GameManager.ExecuteActionList();
        return;
    }
}
