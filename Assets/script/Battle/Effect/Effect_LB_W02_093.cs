using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_LB_W02_093 : EffectAbstract
{
    public override void EventExecute1()
    {
        //※イベント
        //あなたは自分の山札を見て《動物》のキャラを1枚まで選んで相手に見せ、手札に加える。その山札をシャッフルする。
        PayCost(1);
        m_DialogManager.SearchDialog(EnumController.SearchDialogParamater.LB_W02_093, IntParamater1);
        return;
    }
}
