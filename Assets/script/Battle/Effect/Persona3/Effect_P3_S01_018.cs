using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_018 : EffectAbstract
{
    public override void EventExecute1()
    {
        //※イベント
        // あなたは相手のキャラを1枚選び、そのターン中、レベルを－1。
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1, 1, 1);
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

            // 相手のカードのレベルを操作する
            m_BattleStrix.RpcToAll("CallAddLevelUpUntilTurnEnd", m_GameManager.isTurnPlayer, i, -1);
        }

        m_GameManager.myHandList.Remove(m_BattleModeCard);
        m_GameManager.GraveYardList.Add(m_BattleModeCard);

        m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
        m_GameManager.Syncronize();

        m_GameManager.ExecuteActionList();
        m_DialogManager.CharacterSelectDialogClose();
    }
}
