using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_03T : EffectAbstract
{
    public Effect_P3_S01_03T()
    {
        pumpPoint = 2000;
    }

    public override void CounterExecute1()
    {
        PayCost(1);
        m_MyMainCardsManager.AddPowerUpUntilTurnEnd(GetIntParamater1(), pumpPoint);
        m_GameManager.myHandList.RemoveAt(GetIntParamater2());
        m_GameManager.GraveYardList.Add(m_BattleModeCard);
        m_GameManager.Syncronize();
        m_GameManager.ExecuteActionList();
    }
}
