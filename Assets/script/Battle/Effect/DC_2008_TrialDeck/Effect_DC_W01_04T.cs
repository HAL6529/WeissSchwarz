using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_DC_W01_04T : EffectAbstract
{
    public override void ActExecute1()
    {
        //【起】［(1)］ そのターン中、このカードのパワーを＋2000。
        PayCost(1);
        m_MyMainCardsManager.AddPowerUpUntilTurnEnd(IntParamater1, 2000);
        m_GameManager.Syncronize();
        m_GameManager.ExecuteActionList();
        return;
    }
}
