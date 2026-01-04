using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_045 : EffectAbstract
{
    public override void EventExecute1()
    {
        // ※イベント
        // あなたは相手の前列のキャラを2枚まで選び、そのターン中、パワーを－1000。
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
        return;
    }
}
