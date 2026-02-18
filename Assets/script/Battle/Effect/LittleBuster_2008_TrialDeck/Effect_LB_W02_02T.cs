using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_LB_W02_02T : EffectAbstract
{
    public override void ActExecute1()
    {
        // 【起】［(1)］ このカードを思い出にする。
        PayCost(1);
        m_MyMainCardsManager.CallPutMemoryFromField(GetIntParamater1());
        m_GameManager.ExecuteActionList();
        return;
    }

    public override void ActExecute2()
    {
        // 【起】［(1)］ あなたは自分のキャラを1枚選び、そのターン中、パワーを＋1500。
        PayCost(1);
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, -1);
    }
}
