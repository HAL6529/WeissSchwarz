using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_LB_W02_038 : EffectAbstract
{
    public override void ActExecute1()
    {
        //【起】［このカードを【レスト】する］ あなたは自分のキャラを1枚選び、ストック置場に置く
        m_MyMainCardsManager.CallOnRest(GetIntParamater1());
        m_GameManager.Syncronize();
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, EnumController.CharacterSelectDialog.None, -1, 1, 1);
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

            //自分のカードをストックに置く
            m_MyMainCardsManager.CallPutStockFromField(i);
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
