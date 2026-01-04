using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_LB_W02_09T : EffectAbstract
{
    public override void ActExecute1()
    {
        //【起】［(1)］ あなたは相手のキャラを1枚選び、そのターン中、パワーを－500。
        PayCost(1);
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
        return;
    }
}
