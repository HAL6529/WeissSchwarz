using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_LB_W02_004 : EffectAbstract
{
    public override void AutoExecute1()
    {
        //【自】［(1)］ このカードがアタックした時、クライマックス置場に「リーダーの帰還」があるなら、あなたはコストを払ってよい。そうしたら、あなたは相手のキャラを１枚選び、手札に戻す。
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
