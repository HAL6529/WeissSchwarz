using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_LB_W02_02T : EffectAbstract
{
    public override void ActExecute1()
    {
        // 【起】［(1)］ このカードを思い出にする。
        PayCost(1);
        m_MyMainCardsManager.CallPutMemoryFromField(GetIntParamater1());
        m_GameManager.ExecuteActionList();
        return;
    }

    public override void ActExecute2()
    {
        // 【起】［(1)］ あなたは自分のキャラを1枚選び、そのターン中、パワーを＋1500。
        PayCost(1);
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, EnumController.CharacterSelectDialog.None, -1, 1, 1);
    }

    public override void CharacterSelectDialogExecute(List<bool> ButtonSelectedNumList)
    {
        int power = 1500;

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
