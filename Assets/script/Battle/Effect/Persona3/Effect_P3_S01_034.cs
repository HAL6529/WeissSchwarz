using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_034 : EffectAbstract
{
    public override void ActExecute1()
    {
        // 【起】［(1)］ そのターン中、このカードのパワーを＋2000。
        PayCost(1);
        m_MyMainCardsManager.AddPowerUpUntilTurnEnd(GetIntParamater1(), 2000);
        m_GameManager.Syncronize();
        m_GameManager.ExecuteActionList();
        return;
    }
}
