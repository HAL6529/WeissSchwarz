using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_051 : EffectAbstract
{
    private string sulvageCardName = "順平＆トリスメギストス";

    public override void ActExecute1()
    {
        //【起】［(1)］ あなたは自分のカード名に「順平」を含むキャラを１枚選び、そのターン中、パワーを＋1000。
        PayCost(1);
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, EnumController.CharacterSelectDialog.ContainJunpei, - 1, 1, 1);
        return;
    }

    public override void KizunaExecute1()
    {
        // 【自】 絆／「順平＆トリスメギストス」 ［(1)］ （このカードがプレイされて舞台に置かれた時、あなたはコストを払ってよい。そうしたら、あなたは自分の控え室の「順平＆トリスメギストス」を1枚選び、手札に戻す）
        m_EffectBondForHandToField.BondForCost(sulvageCardName, 1);
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
