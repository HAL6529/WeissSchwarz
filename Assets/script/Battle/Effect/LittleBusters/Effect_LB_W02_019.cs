using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_LB_W02_019 : EffectAbstract
{
    public override void EventExecute1()
    {
        //※イベント
        //あなたはレベル1以下の相手のキャラを1枚選び、ストック置場に置く。
        PayCost(1);
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
        return;
    }
}
