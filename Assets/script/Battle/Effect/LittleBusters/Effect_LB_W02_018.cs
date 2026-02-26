using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_LB_W02_018 : EffectAbstract
{
    public override void EventExecute1()
    {
        //※イベント
        //あなたはレベル0以下の相手の前列のキャラを1枚選び、手札に戻す。このカードをストック置場に置く。
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

            // 相手のカードをバウンスする
            m_BattleStrix.RpcToAll("ToHandFromField", i, m_GameManager.isTurnPlayer);
        }

        //このカードをストック置場に置く。
        m_GameManager.myHandList.Remove(m_BattleModeCard);
        m_GameManager.myStockList.Add(m_BattleModeCard);

        m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
        m_GameManager.Syncronize();

        m_GameManager.ExecuteActionList();
        m_DialogManager.CharacterSelectDialogClose();
    }
}
