using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_072 : EffectAbstract
{
    public override void EventExecute1()
    {
        // ※イベント
        //あなたはレベル1以下の相手のキャラを1枚選び、山札の上に置く。
        PayCost(2);
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
        return;
    }
}
