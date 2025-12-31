using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_DC_W01_18T : EffectAbstract
{
    public override void EventExecute1()
    {
        //※イベント
        // あなたはレベル1以下の相手のキャラを1枚選び、控え室に置く。
        PayCost(1);
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
    }
}
