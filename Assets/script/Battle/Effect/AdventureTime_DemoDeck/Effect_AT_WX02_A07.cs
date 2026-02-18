using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_AT_WX02_A07 : EffectAbstract
{
    public override void EventExecute1()
    {
        //※イベント
        // Search your deck for up to 1 《Ooo》 character, reveal it to your opponent, put it into your hand, and shuffle your deck.
        PayCost(1);
        m_DialogManager.SearchDialog(EnumController.SearchDialogParamater.AT_WX02_A07, GetIntParamater1());
        return;
    }
}
