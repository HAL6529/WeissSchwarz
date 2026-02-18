using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_LB_W02_094 : EffectAbstract
{
    public override void EventExecute1()
    {
        //※イベント
        // あなたは自分のクロックを1枚選び、手札に戻す。このカードを思い出にする。
        PayCost(3);
        if (m_GameManager.myClockList.Count == 0)
        {
            m_GameManager.myMemoryList.Add(m_BattleModeCard);
            m_GameManager.myHandList.Remove(m_BattleModeCard);
            m_GameManager.Syncronize();
            m_GameManager.ExecuteActionList();
            return;
        }
        m_DialogManager.SearchDialog(EnumController.SearchDialogParamater.LB_W02_16T, GetIntParamater1());
        return;
    }
}
