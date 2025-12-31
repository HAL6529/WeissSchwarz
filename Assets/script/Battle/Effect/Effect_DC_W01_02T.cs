using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_DC_W01_02T : EffectAbstract
{
    public override void AutoExecute1()
    {
        // 【自】 このカードがアタックした時、クライマックス置場に「結婚式の歌姫」があるなら、あなたは自分の山札を上から1枚選び、
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
        // 【自】 このカードがプレイされて舞台に置かれた時、あなたは相手の手札を見る。
        m_BattleStrix.RpcToAll("CallGetHandList", m_GameManager.isTurnPlayer);
        return;
    }
}
