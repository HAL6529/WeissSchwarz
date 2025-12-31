using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_LB_W02_088 : EffectAbstract
{
    public override void ActExecute1()
    {
        //【起】［(2) このカードを【レスト】する］ あなたは自分の山札を見てカード名に「小毬」を含むキャラを1枚まで選んで相手に見せ、手札に加える。その山札をシャッフルする。
        PayCost(2);
        m_MyMainCardsManager.CallOnRest(IntParamater1);
        m_DialogManager.SearchDialog(EnumController.SearchDialogParamater.LB_W02_088);
        return;
    }
}
