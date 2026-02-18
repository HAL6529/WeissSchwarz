using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_068 : EffectAbstract
{
    public override void EventExecute1()
    {
        // ※イベント
        // あなたは自分の控え室のキャラを1枚選び、手札に戻す。
        PayCost(1);
        m_DialogManager.SulvageDialog(GetIntParamater1(), m_BattleModeCard, m_GameManager.GraveYardList, EnumController.Type.CHARACTER, 1, 1);
        return;
    }
}
