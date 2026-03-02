using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_006 : EffectAbstract
{
    public override void ActExecute1()
    {
        //【起】［(6)］ あなたは他の自分と相手のキャラすべてを、手札に戻す。
        PayCost(6);

        for (int i = 0; i < m_GameManager.myFieldList.Count; i++)
        {
            if(i == GetIntParamater1())
            {
                continue;
            }

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

        m_GameManager.Syncronize();
        m_GameManager.ExecuteActionList();
        return;
    }
}
