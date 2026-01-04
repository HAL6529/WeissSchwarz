using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_LB_W02_17T : EffectAbstract
{
    public override void ActExecute1()
    {
        //【起】［(1)］ あなたは《動物》の自分のキャラを1枚選び、そのターン中、パワーを＋500。
        PayCost(1);
        m_MainPowerUpDialog.SetBattleMordCard(m_BattleModeCard);
        m_GameManager.ExecuteActionList();
        return;
    }
}
