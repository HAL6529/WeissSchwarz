using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_018 : EffectAbstract
{
    public override void EventExecute1()
    {
        //※イベント
        // あなたは相手のキャラを1枚選び、そのターン中、レベルを－1。
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
        return;
    }
}
