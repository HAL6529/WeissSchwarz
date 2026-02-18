using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_DC_W01_07T : EffectAbstract
{
    public override void AutoExecute1()
    {
        // 【自】 他のバトルしているあなたのキャラが【リバース】した時、あなたは自分のキャラを1枚選び、そのターン中、パワーを＋1000。
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, -1);
        return;
    }

    public override void ActExecute1()
    {
        //【起】［(3)］ あなたは自分の控え室のキャラを1枚選び、手札に戻す。
        PayCost(3);
        m_DialogManager.SulvageDialog(m_BattleModeCard, m_GameManager.GraveYardList, EnumController.Type.CHARACTER, 1, 1);
        return;
    }
}
