using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_028 : EffectAbstract
{
    public override void ActExecute1()
    {
        // 【起】［(2)］ そのターン中、このカードのパワーを＋5000。
        PayCost(2);
        m_MyMainCardsManager.AddPowerUpUntilTurnEnd(IntParamater1, 5000);
        m_GameManager.Syncronize();
        m_GameManager.ExecuteActionList();
        return;
    }
}
