using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_LB_W02_062 : EffectAbstract
{
    public override void AutoExecute1()
    {
        //【自】 この能力は、1ターンにつき2回しか使えない。あなたが【起】を使った時、そのターン中、このカードのパワーを＋1500。
        int CheckActEffectCount = m_MyMainCardsManager.CheckActEffectCount(IntParamater1) + 1;
        m_MyMainCardsManager.SetActEffectCount(IntParamater1, CheckActEffectCount);

        m_MyMainCardsManager.AddPowerUpUntilTurnEnd(IntParamater1, 1500);
        m_GameManager.Syncronize();
        m_GameManager.ExecuteActionList();
        return;
    }
}
