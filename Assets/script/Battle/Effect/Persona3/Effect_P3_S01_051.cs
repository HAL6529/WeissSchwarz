using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_051 : EffectAbstract
{
    private string sulvageCardName = "順平＆トリスメギストス";

    public override void ActExecute1()
    {
        //【起】［(1)］ あなたは自分のカード名に「順平」を含むキャラを１枚選び、そのターン中、パワーを＋1000。
        PayCost(1);
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, -1);
        return;
    }

    public override void KizunaExecute1()
    {
        // 【自】 絆／「順平＆トリスメギストス」 ［(1)］ （このカードがプレイされて舞台に置かれた時、あなたはコストを払ってよい。そうしたら、あなたは自分の控え室の「順平＆トリスメギストス」を1枚選び、手札に戻す）
        m_EffectBondForHandToField.BondForCost(sulvageCardName, 1);
        return;
    }
}
