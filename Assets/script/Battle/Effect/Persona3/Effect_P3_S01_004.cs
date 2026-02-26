using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_004 : EffectAbstract
{
    public override void AutoExecute1()
    {
        //【自】 このカードがアタックした時、クライマックス置場に「露天風呂」があるなら、あなたは相手のキャラを1枚選び、手札に戻してよい。
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1, 0, 1);
        return;
    }

    public override void CharacterSelectDialogExecute(List<bool> ButtonSelectedNumList)
    {
        for (int i = 0; i < ButtonSelectedNumList.Count; i++)
        {
            if (!ButtonSelectedNumList[i])
            {
                continue;
            }

            // 相手のカードをバウンスする
            m_BattleStrix.RpcToAll("ToHandFromField", i, m_GameManager.isTurnPlayer);
        }

        CharacterSelectDialogExecuteAfter();
    }

    public override void CharacterSelectDialogExecuteAfter()
    {
        m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
        m_GameManager.Syncronize();

        m_GameManager.ExecuteActionList();
        m_DialogManager.CharacterSelectDialogClose();
    }
}
