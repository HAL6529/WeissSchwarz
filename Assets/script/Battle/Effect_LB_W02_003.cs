using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_LB_W02_003 : EffectAbstract
{
    public override void AutoExecute1()
    {
        //【自】 この能力は、1ターンにつき2回しか使えない。あなたが【起】を使った時、あなたは自分のキャラを1枚選び、そのターン中、パワーを＋500。
        int CheckActEffectCount = m_MyMainCardsManager.CheckActEffectCount(IntParamater1) + 1;
        m_MyMainCardsManager.SetActEffectCount(IntParamater1, CheckActEffectCount);

        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, -1);
        return;
    }
}
