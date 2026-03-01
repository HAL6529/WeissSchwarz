using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_DC_W01_07T : EffectAbstract
{
    public override void AutoExecute1()
    {
        // 【自】 他のバトルしているあなたのキャラが【リバース】した時、あなたは自分のキャラを1枚選び、そのターン中、パワーを＋1000。
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, EnumController.CharacterSelectDialog.None, - 1, 0, 1);
        return;
    }

    public override void ActExecute1()
    {
        //【起】［(3)］ あなたは自分の控え室のキャラを1枚選び、手札に戻す。
        PayCost(3);
        m_DialogManager.SulvageDialog(m_BattleModeCard, m_GameManager.GraveYardList, EnumController.Type.CHARACTER, 1, 1);
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
