using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_LB_W02_003 : EffectAbstract
{
    public override void AutoExecute1()
    {
        //【自】 この能力は、1ターンにつき2回しか使えない。あなたが【起】を使った時、あなたは自分のキャラを1枚選び、そのターン中、パワーを＋500。
        int CheckActEffectCount = m_MyMainCardsManager.CheckActEffectCount(GetIntParamater1()) + 1;
        m_MyMainCardsManager.SetActEffectCount(GetIntParamater1(), CheckActEffectCount);

        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, -1, 1, 1);
        return;
    }

    public override void CharacterSelectDialogExecute(List<bool> ButtonSelectedNumList)
    {
        int power = 500;

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
