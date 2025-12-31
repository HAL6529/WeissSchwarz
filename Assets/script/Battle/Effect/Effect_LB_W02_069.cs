using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_LB_W02_069 : EffectAbstract
{
    public override void EventExecute1()
    {
        //※イベント
        //あなたは相手の前列のキャラを1枚選び、控え室に置く。
        PayCost(2);
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
        return;
    }
}
