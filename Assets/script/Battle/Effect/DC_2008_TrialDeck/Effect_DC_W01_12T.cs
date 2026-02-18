using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_DC_W01_12T : EffectAbstract
{
    public override void EventExecute1()
    {
        //※イベント
        // あなたは自分の控え室のキャラを2枚まで選び、手札に戻す。
        PayCost(2);
        m_DialogManager.SulvageDialog(GetIntParamater1(), m_BattleModeCard, m_GameManager.GraveYardList, EnumController.Type.CHARACTER, 0, 2);
        return;
    }
}
