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
}
