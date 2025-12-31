using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_16T : EffectAbstract
{
    public override void ActExecute1()
    {
        // 【起】［(2) このカードを【レスト】する］ あなたは1枚引く。
        PayCost(2);
        m_MyMainCardsManager.CallOnRest(IntParamater1);
        m_GameManager.Syncronize();
        m_GameManager.Draw();
        m_GameManager.ExecuteActionList();
        return;
    }

    public override void AutoExecute1()
    {
        // 【自】 他の《生徒会》のあなたのキャラがプレイされて舞台に置かれた時、あなたは自分の山札を上から1枚見て、山札の上か下に置く。
        m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.CONFIRM_CONTROL_DECKTOP, m_BattleModeCard);
        return;
    }
}
