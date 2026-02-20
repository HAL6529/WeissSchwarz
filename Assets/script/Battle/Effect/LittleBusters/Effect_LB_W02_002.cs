using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_LB_W02_002 : EffectAbstract
{
    private string sulvageCardName = "“リーダー”恭介";

    public override void KizunaExecute1()
    {
        // 【自】 絆／「“リーダー”恭介」 ［(1)］ （このカードがプレイされて舞台に置かれた時、あなたはコストを払ってよい。そうしたら、あなたは自分の控え室の「“リーダー”恭介」を1枚選び、手札に戻す）
        m_EffectBondForHandToField.BondForCost(sulvageCardName, 1);
        return;
    }

    public override void AutoExecute1()
    {
        //【自】［(1)］ このカードがアタックした時、クライマックス置場に「鈴と共にある日々」があるなら、あなたはコストを払ってよい。そうしたら、あなたは相手のキャラを１枚選び、手札に戻す。
        PayCost(1);
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
        return;
    }
}
