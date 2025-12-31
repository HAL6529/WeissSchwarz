using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_DC_W01_05T : EffectAbstract
{
    public override void ActExecute1()
    {
        //【起】［(1)］ あなたは相手の前列のキャラを1枚選び、そのターン中、パワーを－1000。
        PayCost(1);
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
        return;
    }
}
