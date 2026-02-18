using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_093 : EffectAbstract
{
    public override void EventExecute1()
    {
        // ※イベント
        // あなたは1枚引く。
        m_GameManager.Draw();
        m_GameManager.myHandList.RemoveAt(GetIntParamater1());
        m_GameManager.GraveYardList.Add(m_BattleModeCard);
        m_GameManager.Syncronize();
        m_GameManager.ExecuteActionList();
        return;
    }
}
