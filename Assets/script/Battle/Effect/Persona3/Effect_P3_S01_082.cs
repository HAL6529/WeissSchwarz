using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_082 : EffectAbstract
{
    private string sulvageCardName = "ゆかり＆イシス";

    public override void KizunaExecute1()
    {
        // 【自】 絆／「ゆかり＆イシス」 ［(1)］ （このカードがプレイされて舞台に置かれた時、あなたはコストを払ってよい。そうしたら、あなたは自分の控え室の「ゆかり＆イシス」を1枚選び、手札に戻す）
        m_EffectBondForHandToField.BondForCost(sulvageCardName, 1);
        return;
    }
}
