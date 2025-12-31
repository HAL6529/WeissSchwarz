using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_DC_W01_13T : EffectAbstract
{
    public override void ActExecute1()
    {
        // 【起】［(2) このカードを【レスト】する］ あなたは自分の控え室のキャラを1枚選び、手札に戻す。
        PayCost(2);
        m_MyMainCardsManager.CallOnRest(IntParamater1);
        m_GameManager.Syncronize();
        m_DialogManager.SulvageDialog(m_BattleModeCard, m_GameManager.GraveYardList, EnumController.Type.CHARACTER, 0, 1);
        return;
    }
}
