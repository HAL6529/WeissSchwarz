using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_047 : EffectAbstract
{
    public override void EventExecute1()
    {
        // ※イベント
        //あなたは自分の山札の上から1枚を、ストック置場に置く。あなたは自分のキャラを1枚選び、そのターン中、パワーを＋1500。
        m_GameManager.myStockList.Add(m_GameManager.myDeckList[0]);
        m_GameManager.myDeckList.RemoveAt(0);
        m_GameManager.Syncronize();
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, -1);
        return;
    }
}
