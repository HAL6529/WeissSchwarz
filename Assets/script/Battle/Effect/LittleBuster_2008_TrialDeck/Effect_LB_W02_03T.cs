using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_LB_W02_03T : EffectAbstract
{
    public override void AutoExecute1()
    {
        // 【自】 このカードがアタックした時、クライマックス置場に「そよ風のハミング」があるなら、あなたは自分の山札を上から1枚選び、
        // ストック置場に置き、そのターン中、このカードのパワーを＋3000。
        m_GameManager.myStockList.Add(m_GameManager.myDeckList[0]);
        m_GameManager.myDeckList.RemoveAt(0);
        m_GameManager.Syncronize();
        m_MyMainCardsManager.AddPowerUpUntilTurnEnd(IntParamater1, 3000);
        if (m_GameManager.myDeckList.Count == 0)
        {
            m_GameManager.Refresh();
        }
        else
        {
            m_GameManager.ExecuteActionList();
            return;
        }
        return;
    }
}
