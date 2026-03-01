using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_DC_W01_05T : EffectAbstract
{
    public override void ActExecute1()
    {
        //【起】［(1)］ あなたは相手の前列のキャラを1枚選び、そのターン中、パワーを－1000。
        PayCost(1);
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, EnumController.CharacterSelectDialog.OnlyFrontLine, - 1, 1, 1);
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
        m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
        m_GameManager.Syncronize();

        m_GameManager.ExecuteActionList();
        m_DialogManager.CharacterSelectDialogClose();
    }
}
