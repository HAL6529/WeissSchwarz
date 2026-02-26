using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_047 : EffectAbstract
{
    public override void EventExecute1()
    {
        // ※イベント
        //あなたは自分の山札の上から1枚を、ストック置場に置く。あなたは自分のキャラを1枚選び、そのターン中、パワーを＋1500。
        m_GameManager.myStockList.Add(m_GameManager.myDeckList[0]);
        m_GameManager.myDeckList.RemoveAt(0);
        m_GameManager.Syncronize();
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, -1, 1, 1);
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
