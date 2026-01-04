using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_LB_W02_007 : EffectAbstract
{
    public override void ActExecute1()
    {
        //【起】［(2)］ あなたはレベル0以下の相手のキャラを1枚選び、手札に戻す。
        PayCost(2);
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
        return;
    }
}
