using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_LB_W02_014 : EffectAbstract
{
    public override void AutoExecute1()
    {
        //【自】 相手がレベルアップした時、あなたは自分の山札の上から1枚を、ストック置場に置く。
        m_GameManager.myStockList.Add(m_GameManager.myDeckList[0]);
        m_GameManager.myDeckList.RemoveAt(0);
        m_GameManager.Syncronize();
        if (m_GameManager.myDeckList.Count == 0)
        {
            m_GameManager.Refresh();
        }
        else
        {
            m_GameManager.ExecuteActionList();
            return;
        }
        return;
    }

    public override void ActExecute1()
    {
        //【起】［(3)］ あなたは自分のキャラすべてに、そのターン中、ソウルを＋1。
        PayCost(3);

        for(int i = 0; i < m_GameManager.myFieldList.Count; i++)
        {
            if (m_GameManager.myFieldList[i] == null)
            {
                continue;
            }
            m_MyMainCardsManager.AddSoulUpUntilTurnEnd(i, 1);
        }
        m_GameManager.Syncronize();
        m_GameManager.ExecuteActionList();
        return;
    }
}
