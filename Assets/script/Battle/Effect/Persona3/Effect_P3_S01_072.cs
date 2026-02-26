using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_072 : EffectAbstract
{
    public override void EventExecute1()
    {
        // ※イベント
        //あなたはレベル1以下の相手のキャラを1枚選び、山札の上に置く。
        PayCost(2);
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

            // 相手のカードを山札の上に置く
            m_BattleStrix.RpcToAll("ToDeckTopFromField", i, m_GameManager.isTurnPlayer);
        }

        m_GameManager.myHandList.Remove(m_BattleModeCard);
        m_GameManager.GraveYardList.Add(m_BattleModeCard);

        m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
        m_GameManager.Syncronize();

        m_GameManager.ExecuteActionList();
        m_DialogManager.CharacterSelectDialogClose();
    }
}
