using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_LB_W02_043 : EffectAbstract
{
    public override void EventExecute1()
    {
        //※イベント
        //あなたは自分のキャラすべてに、そのターン中、パワーを＋1500。
        int power = 1500;

        for (int i = 0; i < m_GameManager.myFieldList.Count; i++)
        {
            if (m_GameManager.myFieldList[i] != null)
            {
                m_MyMainCardsManager.AddPowerUpUntilTurnEnd(i, power);
            }
        }
        m_GameManager.GraveYardList.Add(m_GameManager.myHandList[GetIntParamater1()]);
        m_GameManager.myHandList.RemoveAt(GetIntParamater1());
        m_GameManager.Syncronize();
        m_GameManager.ExecuteActionList();
        return;
    }
}
