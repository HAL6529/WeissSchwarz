using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_DC_W01_01T : EffectAbstract
{
    public override void ActExecute1()
    {
        // 【起】［このカードを【レスト】する］ あなたは自分のキャラを1枚選び、そのターン中、パワーを＋1000。
        m_MyMainCardsManager.CallOnRest(GetIntParamater1());
        m_GameManager.Syncronize();
        m_MainPowerUpDialog.SetBattleMordCard(m_BattleModeCard);
        return;
    }
}
