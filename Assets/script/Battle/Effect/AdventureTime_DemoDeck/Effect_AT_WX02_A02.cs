using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_AT_WX02_A02 : EffectAbstract
{
    public override void AutoExecute1()
    {
        //【AUTO】 When this card attacks, choose 1 of your other characters, and that character gets +1500 power until end of turn.
        m_GameManager.m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, GetIntParamater1(), 1, 1);
        return;
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
            m_MyMainCardsManager.AddPowerUpUntilTurnEnd(i, power);
        }

        m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
        m_GameManager.Syncronize();

        m_GameManager.ExecuteActionList();
        m_DialogManager.CharacterSelectDialogClose();
    }
}
