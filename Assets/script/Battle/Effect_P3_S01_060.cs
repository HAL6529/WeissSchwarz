using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_060 : EffectAbstract
{
    public override void AutoExecute1()
    {
        //【自】［(1)］ このカードがプレイされて舞台に置かれた時、あなたはコストを払ってよい。そうしたら、あなたはレベル1以下の相手のキャラを1枚選び、控え室に置く。
        PayCost(1);
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
        return;
    }
}
