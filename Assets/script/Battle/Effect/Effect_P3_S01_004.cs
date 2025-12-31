using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_004 : EffectAbstract
{
    public override void AutoExecute1()
    {
        //【自】 このカードがアタックした時、クライマックス置場に「露天風呂」があるなら、あなたは相手のキャラを1枚選び、手札に戻してよい。
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
        return;
    }
}
