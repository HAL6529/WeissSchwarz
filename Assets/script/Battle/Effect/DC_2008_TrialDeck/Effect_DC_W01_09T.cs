using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_DC_W01_09T : EffectAbstract
{
    private string sulvageCardName = "ロボ美春";

    public override void KizunaExecute1()
    {
        // 【自】 絆／「ロボ美春」 ［(1)］ （このカードがプレイされて舞台に置かれた時、あなたはコストを払ってよい。そうしたら、あなたは自分の控え室の「ロボ美春」を1枚選び、手札に戻す）
        m_EffectBondForHandToField.BondForCost(sulvageCardName, 1);
        return;
    }
}
