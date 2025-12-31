using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_12T : EffectAbstract
{
    public override void EventExecute1()
    {
        //※イベント
        // 【カウンター】 あなたは自分のキャラを1枚選び、そのターン中、パワーを＋3000し、ソウルを＋1。
        PayCost(2);
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, -1);
        return;
    }
}
