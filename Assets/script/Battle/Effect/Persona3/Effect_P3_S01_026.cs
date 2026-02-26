using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_026 : EffectAbstract
{
    public override void AutoExecute1()
    {
        //【自】 このカードがプレイされて舞台に置かれた時、あなたは自分のキャラを1枚選び、そのターン中、パワーを＋1000。
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, -1, 1, 1);
        return;
    }

    public override void CharacterSelectDialogExecute(List<bool> ButtonSelectedNumList)
    {
        int power = 1000;

        for (int i = 0; i < ButtonSelectedNumList.Count; i++)
        {
            if (!ButtonSelectedNumList[i])
            {
                continue;
            }

            // 自分のカードのパワーを操作する
            if (ButtonSelectedNumList[i])
            {
                m_MyMainCardsManager.AddPowerUpUntilTurnEnd(i, power);
            }
        }

        m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
        m_GameManager.Syncronize();

        m_GameManager.ExecuteActionList();
        m_DialogManager.CharacterSelectDialogClose();
    }
}
