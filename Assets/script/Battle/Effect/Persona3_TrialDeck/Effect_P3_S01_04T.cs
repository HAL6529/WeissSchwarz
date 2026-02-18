using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_04T : EffectAbstract
{
    public override void AutoExecute1()
    {
        // 【自】 このカードがプレイされて舞台に置かれた時、あなたは自分のキャラを1枚選び、
        // そのターン中、パワーを＋2000し、ソウルを＋1。
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, -1);
        return;
    }

    public override void ActExecute1()
    {
        // 【起】［(2) このカードを【レスト】する］ あなたはこのカードを手札に戻す。
        PayCost(2);
        m_MyMainCardsManager.CallOnRest(GetIntParamater1());
        m_GameManager.ToHandFromField(GetIntParamater1());
        m_GameManager.ExecuteActionList();
    }
}
