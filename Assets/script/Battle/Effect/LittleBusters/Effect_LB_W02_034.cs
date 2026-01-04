using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_LB_W02_034 : EffectAbstract
{
    public override void AutoExecute1()
    {
        //【自】 このカードがアタックした時、クライマックス置場に「優等生のフリをした偽善者」があるなら、そのターン中、このカードのパワーを＋3000。
        m_MyMainCardsManager.AddPowerUpUntilTurnEnd(IntParamater1, 3000);
        m_GameManager.Syncronize();
        m_GameManager.ExecuteActionList();
        return;
    }

    public override void ActExecute1()
    {
        //【起】［(2) このカードを【レスト】する］ あなたは自分の山札を見てカード名に「葉留佳」を含むキャラを1枚まで選んで相手に見せ、手札に加える。その山札をシャッフルする。
        PayCost(2);
        m_MyMainCardsManager.CallOnRest(IntParamater1);
        m_GameManager.Syncronize();
        m_DialogManager.SearchDialog(EnumController.SearchDialogParamater.LB_W02_034, IntParamater2);
        return;
    }
}
