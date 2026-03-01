using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_022 : EffectAbstract
{
    public override void EventExecute1()
    {
        //※イベント
        // 【カウンター】 あなたは自分のキャラを1枚選び、そのターン中、パワーを＋3000し、ソウルを＋1。
        PayCost(2);
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, EnumController.CharacterSelectDialog.None, -1, 1, 1);
        return;
    }

    public override void CharacterSelectDialogExecute(List<bool> ButtonSelectedNumList)
    {
        int power = 3000;

        for (int i = 0; i < ButtonSelectedNumList.Count; i++)
        {
            if (!ButtonSelectedNumList[i])
            {
                continue;
            }

            // 自分のカードのパワーとソウルを操作する
            m_MyMainCardsManager.AddSoulUpUntilTurnEnd(i, 1);
            m_MyMainCardsManager.AddPowerUpUntilTurnEnd(i, power);
            m_GameManager.Syncronize();
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
