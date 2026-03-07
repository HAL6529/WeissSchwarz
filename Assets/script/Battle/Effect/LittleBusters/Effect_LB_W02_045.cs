using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_LB_W02_045 : EffectAbstract
{
    public override void EventExecute1()
    {
        //あなたは自分のキャラを2枚まで選び、【スタンド】する。
        PayCost(1);
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, EnumController.CharacterSelectDialog.None, -1, -1, 2);
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

            // 自分のカードを【スタンド】する。
            if (ButtonSelectedNumList[i])
            {
                m_MyMainCardsManager.CallOnStand(i);
            }
        }

        CharacterSelectDialogExecuteAfter();
    }

    public override void CharacterSelectDialogExecuteAfter()
    {
        m_GameManager.myHandList.Remove(m_BattleModeCard);
        m_GameManager.GraveYardList.Add(m_BattleModeCard);

        m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
        m_GameManager.Syncronize();

        m_GameManager.ExecuteActionList();
        m_DialogManager.CharacterSelectDialogClose();
    }
}
