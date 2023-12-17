using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectBrainStormForDraw : MonoBehaviour
{
    [SerializeField] GameManager m_GameManager;
    [SerializeField] BattleStrix m_BattleStrix;
    [SerializeField] MyMainCardsManager m_MyMainCardsManager;

    public void BrainStormForDraw(int place)
    {
        m_GameManager.GraveYardList.Add(m_GameManager.myStockList[m_GameManager.myStockList.Count - 1]);
        m_GameManager.myStockList.RemoveAt(m_GameManager.myStockList.Count - 1);

        m_MyMainCardsManager.CallOnRest(place);
        m_BattleStrix.RpcToAll("CallEnemyRest", place, m_GameManager.isTurnPlayer);

        List<BattleModeCard> temp = new List<BattleModeCard>();
        int count = 0;

        for (int i = 0; i < 4; i++)
        {
            if (m_GameManager.myDeckList[0].type == EnumController.Type.CLIMAX)
            {
                count++;
            }
            temp.Add(m_GameManager.myDeckList[0]);
            m_GameManager.myDeckList.RemoveAt(0);

            if (m_GameManager.myDeckList.Count == 0)
            {
                m_GameManager.Refresh();
            }

            m_GameManager.Syncronize();
        }

        for(int i = 0; i < temp.Count; i++)
        {
            m_GameManager.GraveYardList.Add(temp[i]);
        }

        for (int i = 0; i < count; i++)
        {
            m_GameManager.Draw();
        }

        m_GameManager.Syncronize();
    }
}
