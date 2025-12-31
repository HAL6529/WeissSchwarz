using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_069 : EffectAbstract
{
    public override void EventExecute1()
    {
        // ※イベント
        // あなたはレベル2以下の相手の前列のキャラを1枚選び、控え室に置く。
        PayCost(1);
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
        return;
    }
}
