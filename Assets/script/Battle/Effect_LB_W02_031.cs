using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_LB_W02_031 : EffectAbstract
{
    public override void AutoExecute1()
    {
        // 【自】 このカードがアタックした時、クライマックス置場に「たった一つの取り柄」があるなら、あなたは自分の山札を上から1枚選び、
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

    public override void AutoExecute2()
    {
        //【自】 このカードとバトルしているレベル2以上のキャラが【リバース】した時、あなたは自分の山札の上から1枚を、ストック置場に置いてよい。
        m_GameManager.myStockList.Add(m_GameManager.myDeckList[0]);
        m_GameManager.myDeckList.RemoveAt(0);
        m_GameManager.Syncronize();
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
