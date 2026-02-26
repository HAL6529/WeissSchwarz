using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_094 : EffectAbstract
{
    public override void EventExecute1()
    {
        // ※イベント
        //【カウンター】 あなたは相手のキャラを1枚選び、【レスト】する。
        PayCost(4);
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

            //相手のカードをレストする
            m_BattleStrix.RpcToAll("CallMyRest", i, m_GameManager.isTurnPlayer);
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
