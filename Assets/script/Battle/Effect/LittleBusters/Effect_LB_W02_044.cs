using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_LB_W02_044 : EffectAbstract
{
    public override void EventExecute1()
    {
        //【カウンター】 あなたは自分のキャラを2枚まで選び、そのターン中、パワーを＋1000。
        PayCost(1);
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, -1);
        return;
    }
}
