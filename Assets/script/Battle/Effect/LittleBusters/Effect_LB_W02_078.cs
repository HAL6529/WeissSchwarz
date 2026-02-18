using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_LB_W02_078 : EffectAbstract
{
    public override void AutoExecute1()
    {
        //【自】 あなたが『助太刀』を使った時、あなたはバトルしている自分のキャラを1枚選び、そのターン中、パワーを＋500。
        m_MyMainCardsManager.AddPowerUpUntilTurnEnd(GetIntParamater1(), 500);
        m_GameManager.Syncronize();
        m_GameManager.ExecuteActionList();
        return;
    }
}
