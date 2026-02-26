using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_LB_W02_019 : EffectAbstract
{
    public override void EventExecute1()
    {
        //※イベント
        //あなたはレベル1以下の相手のキャラを1枚選び、ストック置場に置く。
        PayCost(1);
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

            //あなたはレベル1以下の相手のキャラを1枚選び、ストック置場に置く。
            m_BattleStrix.RpcToAll("ToStockFromField", i, m_GameManager.isTurnPlayer);
        }

        m_GameManager.myHandList.Remove(m_BattleModeCard);
        m_GameManager.GraveYardList.Add(m_BattleModeCard);

        m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
        m_GameManager.Syncronize();

        m_GameManager.ExecuteActionList();
        m_DialogManager.CharacterSelectDialogClose();
    }
}
