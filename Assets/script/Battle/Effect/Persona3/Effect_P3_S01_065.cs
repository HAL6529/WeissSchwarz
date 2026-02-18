using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_065 : EffectAbstract
{
    public override void AutoExecute1()
    {
        //【自】 このカードがプレイされて舞台に置かれた時、あなたはすべてのプレイヤーに、1ダメージを与える。
        m_GameManager.Damage_EachPlayer(1);
        return;
    }

    public override void AutoExecute2()
    {
        //【自】［(1)］ このカードが舞台から控え室に置かれた時、あなたはコストを払ってよい。そうしたら、あなたは自分の控え室の「順平＆トリスメギストス」を1枚選び、手札に戻す。
        PayCost(1);
        m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
        for (int i = 0; i < m_GameManager.GraveYardList.Count; i++)
        {
            if (m_GameManager.GraveYardList[i].name == "順平＆トリスメギストス")
            {
                m_GameManager.myHandList.Add(m_GameManager.GraveYardList[i]);
                m_GameManager.GraveYardList.RemoveAt(i);
                m_GameManager.Syncronize();
                m_GameManager.ExecuteActionList();
                return;
            }
        }
        m_GameManager.ExecuteActionList();
        return;
    }
}
