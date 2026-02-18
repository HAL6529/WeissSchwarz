using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_020 : EffectAbstract
{
    public override void EventExecute1()
    {
        //※イベント
        // あなたは自分と相手のキャラすべてを、手札に戻す。
        PayCost(6);
        for (int i = 0; i < m_GameManager.myFieldList.Count; i++)
        {
            if (m_GameManager.myFieldList[i] != null)
            {
                m_MyMainCardsManager.CallPutHandFromField(i);
            }

        }

        for (int i = 0; i < m_GameManager.enemyFieldList.Count; i++)
        {
            if (m_GameManager.enemyFieldList[i] != null)
            {
                m_BattleStrix.RpcToAll("ToHandFromField", i, m_GameManager.isTurnPlayer);
            }

        }

        m_GameManager.myHandList.RemoveAt(GetIntParamater1());
        m_GameManager.GraveYardList.Add(m_BattleModeCard);
        m_GameManager.Syncronize();
        m_GameManager.ExecuteActionList();
        return;
    }
}
