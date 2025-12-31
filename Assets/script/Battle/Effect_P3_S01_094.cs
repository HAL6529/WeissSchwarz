using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_094 : EffectAbstract
{
    public override void EventExecute1()
    {
        // ※イベント
        //【カウンター】 あなたは相手のキャラを1枚選び、【レスト】する。
        PayCost(4);
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
        return;
    }
}
