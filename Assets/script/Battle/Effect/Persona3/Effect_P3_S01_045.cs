using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_045 : EffectAbstract
{
    public override void EventExecute1()
    {
        // ※イベント
        // あなたは相手の前列のキャラを2枚まで選び、そのターン中、パワーを－1000。
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1, -1, 2);
        return;
    }

    public override void CharacterSelectDialogExecute(List<bool> ButtonSelectedNumList)
    {
        int power = -1000;

        for (int i = 0; i < ButtonSelectedNumList.Count; i++)
        {
            if (!ButtonSelectedNumList[i])
            {
                continue;
            }

            // 相手のカードのパワーを操作する
            if (ButtonSelectedNumList[i])
            {
                m_BattleStrix.RpcToAll("CallAddPowerUpUntilTurnEnd", m_GameManager.isTurnPlayer, i, power);
            }
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
