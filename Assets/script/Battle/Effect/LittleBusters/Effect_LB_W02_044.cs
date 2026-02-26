using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_LB_W02_044 : EffectAbstract
{
    public override void EventExecute1()
    {
        //【カウンター】 あなたは自分のキャラを2枚まで選び、そのターン中、パワーを＋1000。
        PayCost(1);
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, -1, -1, 2);
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

        m_GameManager.myHandList.Remove(m_BattleModeCard);
        m_GameManager.GraveYardList.Add(m_BattleModeCard);

        m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
        m_GameManager.Syncronize();

        m_GameManager.ExecuteActionList();
        m_DialogManager.CharacterSelectDialogClose();
    }
}
