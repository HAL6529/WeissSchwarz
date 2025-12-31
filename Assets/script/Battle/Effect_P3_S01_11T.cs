using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_11T : EffectAbstract
{
    public override void AutoExecute1()
    {
        //【自】 このカードがアタックした時、クライマックス置場に「最後の選択」があるなら、あなたは相手のキャラを1枚選び、手札に戻してよい。
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
        return;
    }

    public override void ActExecute1()
    {
        // 【起】［(1)］ そのターン中、このカードのソウルを＋1。
        PayCost(1);
        m_MyMainCardsManager.AddSoulUpUntilTurnEnd(IntParamater1, 1);
        m_GameManager.Syncronize();
        m_GameManager.ExecuteActionList();
        return;
    }
}
