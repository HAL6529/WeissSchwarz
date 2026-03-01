using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_LB_W02_013 : EffectAbstract
{
    public override void AutoExecute1()
    {
        //【自】 このカードがプレイされて舞台に置かれた時、あなたは【スタンド】している自分のキャラを1枚選び、【レスト】する。
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, EnumController.CharacterSelectDialog.OnlyStand, - 1, 1, 1);
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

            //自分のカードをレストする
            m_MyMainCardsManager.CallOnRest(i);
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
