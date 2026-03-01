using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_069 : EffectAbstract
{
    public override void EventExecute1()
    {
        // ※イベント
        // あなたはレベル2以下の相手の前列のキャラを1枚選び、控え室に置く。
        PayCost(1);
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, EnumController.CharacterSelectDialog.OnlyFrontLineAndUnderLv2, - 1, 1, 1);
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

            // 相手のカードを控室に送る
            m_BattleStrix.RpcToAll("ToGraveYardFromField", i, m_GameManager.isTurnPlayer);
        }

        CharacterSelectDialogExecuteAfter();
    }

    public override void CharacterSelectDialogExecuteAfter()
    {
        m_GameManager.myHandList.Remove(m_BattleModeCard);
        m_GameManager.GraveYardList.Add(m_BattleModeCard);

        m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
        m_GameManager.Syncronize();

        m_GameManager.ExecuteActionList();
        m_DialogManager.CharacterSelectDialogClose();
    }
}
