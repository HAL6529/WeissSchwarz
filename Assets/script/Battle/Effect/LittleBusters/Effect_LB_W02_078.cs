using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_LB_W02_078 : EffectAbstract
{
    private string sulvageCardName = "宮沢 謙吾";

    public override void KizunaExecute1()
    {
        // 【自】 絆／「宮沢 謙吾」 ［(1)］ （このカードがプレイされて舞台に置かれた時、あなたはコストを払ってよい。そうしたら、あなたは自分の控え室の「宮沢 謙吾」を1枚選び、手札に戻す）
        m_EffectBondForHandToField.BondForCost(sulvageCardName, 1);
        return;
    }

    public override void AutoExecute1()
    {
        //【自】 あなたが『助太刀』を使った時、あなたはバトルしている自分のキャラを1枚選び、そのターン中、パワーを＋500。
        m_MyMainCardsManager.AddPowerUpUntilTurnEnd(GetIntParamater1(), 500);
        m_GameManager.Syncronize();
        m_GameManager.ExecuteActionList();
        return;
    }
}
