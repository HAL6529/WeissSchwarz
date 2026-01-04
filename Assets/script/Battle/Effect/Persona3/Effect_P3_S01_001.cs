using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_001 : EffectAbstract
{
    public override void AutoExecute1()
    {
        //【自】 このカードがプレイされて舞台に置かれた時、あなたはレベル1以上の自分のキャラを1枚選び、そのターン中、ソウルを＋1。
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, -1);
        return;
    }
}
