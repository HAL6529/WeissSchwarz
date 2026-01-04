using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_LB_W02_018 : EffectAbstract
{
    public override void EventExecute1()
    {
        //※イベント
        //あなたはレベル0以下の相手の前列のキャラを1枚選び、手札に戻す。このカードをストック置場に置く。
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
        return;
    }
}
