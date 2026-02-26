using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_001 : EffectAbstract
{
    public override void AutoExecute1()
    {
        //【自】 このカードがプレイされて舞台に置かれた時、あなたはレベル1以上の自分のキャラを1枚選び、そのターン中、ソウルを＋1。
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, -1, 1, 1);
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

            // 自分のカードのソウルを操作する
            m_MyMainCardsManager.AddSoulUpUntilTurnEnd(i, 1);
            m_GameManager.Syncronize();
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
