using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_051 : EffectAbstract
{
    public override void ActExecute1()
    {
        //【起】［(1)］ あなたは自分のカード名に「順平」を含むキャラを１枚選び、そのターン中、パワーを＋1000。
        PayCost(1);
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, -1);
        return;
    }
}
