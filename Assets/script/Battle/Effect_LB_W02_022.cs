using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_LB_W02_022 : EffectAbstract
{
    public override void EventExecute1()
    {
        //※イベント
        //あなたは自分のキャラを2枚まで選び、そのターン中、パワーを＋2000。
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, -1);
        return;
    }
}
