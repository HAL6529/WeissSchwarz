using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_LB_W02_001 : EffectAbstract
{
    public override void ActExecute1()
    {
        //【起】［(2) このカードを【レスト】する］ あなたは自分の山札を見て《スポーツ》のキャラを1枚まで選んで相手に見せ、手札に加える。その山札をシャッフルする。
        PayCost(2);
        m_MyMainCardsManager.CallOnRest(GetIntParamater1());
        m_DialogManager.SearchDialog(EnumController.SearchDialogParamater.LB_W02_001, GetIntParamater2());
        return;
    }
}
