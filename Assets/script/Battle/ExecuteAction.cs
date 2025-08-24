using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecuteAction
{
    public BattleStrix m_BattleStrix { get; set; }
    public ExecuteActionTemp m_ExecuteActionTemp { get; set; }
    public GameManager m_GameManager { get; set; }
    public BattleModeCardList m_BattleModeCardList { get; set; }

    public ExecuteAction()
    {
        m_BattleStrix = null; 
        m_ExecuteActionTemp = null;
        m_GameManager = null;
    }

    public ExecuteAction(ExecuteActionTemp m_ExecuteActionTemp)
    {
        m_BattleStrix = null;
        this.m_ExecuteActionTemp = m_ExecuteActionTemp;
        m_GameManager = null;
    }

    public void ComeBackActionAfterConfirmDialog()
    {
        if (m_GameManager == null || m_BattleModeCardList == null)
        {
            return;
        }

        List <BattleModeCard> graveyardList = new List<BattleModeCard>();
        List <BattleModeCard> handList = new List<BattleModeCard>();
        for (int i = 0; i < m_ExecuteActionTemp.graveyardList.Count; i++)
        {
            BattleModeCard b = m_BattleModeCardList.ConvertCardNoToBattleModeCard(m_ExecuteActionTemp.graveyardList[i].cardNo);
            graveyardList.Add(b);
        }
        for (int i = 0; i < m_ExecuteActionTemp.handList.Count; i++)
        {
            BattleModeCard b = m_BattleModeCardList.ConvertCardNoToBattleModeCard(m_ExecuteActionTemp.handList[i].cardNo);
            handList.Add(b);
        }

        m_GameManager.GraveYardList = graveyardList;
        m_GameManager.myHandList = handList;
        m_GameManager.Syncronize();


        if (m_ExecuteActionTemp.damageParamater == EnumController.Damage.FRONT_ATTACK)
        {
            m_GameManager.TriggerAfter();
            m_BattleStrix.RpcToAll("CallOKDialogForCounter", m_ExecuteActionTemp.intParamater, m_ExecuteActionTemp.intParamater2, m_ExecuteActionTemp.isFirstAttacker, m_ExecuteActionTemp.SendShotList);
            return;
        }
        m_GameManager.TriggerAfter();
        m_BattleStrix.RpcToAll("Damage", m_ExecuteActionTemp.intParamater, m_ExecuteActionTemp.isFirstAttacker, m_ExecuteActionTemp.damageParamater, m_ExecuteActionTemp.SendShotList);
    }

    public void ExecuteAction_SearchAfterConfirmDialog()
    {
        if (m_GameManager == null || m_BattleModeCardList == null)
        {
            return;
        }

        List<BattleModeCard> deckList = new List<BattleModeCard>();
        List<BattleModeCard> stockList = new List<BattleModeCard>();
        List<BattleModeCard> graveyardList = new List<BattleModeCard>();
        List<BattleModeCard> handList = new List<BattleModeCard>();
        List<BattleModeCard> memoryList = new List<BattleModeCard>();
        List<BattleModeCard> clockList = new List<BattleModeCard>();

        for (int i = 0; i < m_ExecuteActionTemp.deckList.Count; i++)
        {
            BattleModeCard b = m_BattleModeCardList.ConvertCardNoToBattleModeCard(m_ExecuteActionTemp.deckList[i].cardNo);
            deckList.Add(b);
        }
        for (int i = 0; i < m_ExecuteActionTemp.stockList.Count; i++)
        {
            BattleModeCard b = m_BattleModeCardList.ConvertCardNoToBattleModeCard(m_ExecuteActionTemp.stockList[i].cardNo);
            stockList.Add(b);
        }
        for (int i = 0; i < m_ExecuteActionTemp.graveyardList.Count; i++)
        {
            BattleModeCard b = m_BattleModeCardList.ConvertCardNoToBattleModeCard(m_ExecuteActionTemp.graveyardList[i].cardNo);
            graveyardList.Add(b);
        }
        for (int i = 0; i < m_ExecuteActionTemp.handList.Count; i++)
        {
            BattleModeCard b = m_BattleModeCardList.ConvertCardNoToBattleModeCard(m_ExecuteActionTemp.handList[i].cardNo);
            handList.Add(b);
        }
        for (int i = 0; i < m_ExecuteActionTemp.memoryList.Count; i++)
        {
            BattleModeCard b = m_BattleModeCardList.ConvertCardNoToBattleModeCard(m_ExecuteActionTemp.memoryList[i].cardNo);
            memoryList.Add(b);
        }
        for (int i = 0; i < m_ExecuteActionTemp.clockList.Count; i++)
        {
            BattleModeCard b = m_BattleModeCardList.ConvertCardNoToBattleModeCard(m_ExecuteActionTemp.clockList[i].cardNo);
            clockList.Add(b);
        }

        m_GameManager.myDeckList = deckList;
        m_GameManager.myStockList = stockList;
        m_GameManager.GraveYardList = graveyardList;
        m_GameManager.myHandList = handList;
        m_GameManager.myMemoryList = memoryList;
        m_GameManager.myClockList = clockList;

        m_GameManager.Syncronize();

        if (m_GameManager.myDeckList.Count == 0)
        {
            m_GameManager.Refresh();
        }

        m_GameManager.Syncronize();
    }

    public void ExecuteAction_SearchAfterConfirmDialog_DC_W01_12T()
    {
        if (m_GameManager == null || m_BattleModeCardList == null)
        {
            return;
        }

        List<BattleModeCard> graveyardList = new List<BattleModeCard>();
        List<BattleModeCard> handList = new List<BattleModeCard>();
        for (int i = 0; i < m_ExecuteActionTemp.graveyardList.Count; i++)
        {
            BattleModeCard b = m_BattleModeCardList.ConvertCardNoToBattleModeCard(m_ExecuteActionTemp.graveyardList[i].cardNo);
            graveyardList.Add(b);
        }
        for (int i = 0; i < m_ExecuteActionTemp.handList.Count; i++)
        {
            BattleModeCard b = m_BattleModeCardList.ConvertCardNoToBattleModeCard(m_ExecuteActionTemp.handList[i].cardNo);
            handList.Add(b);
        }

        m_GameManager.GraveYardList = graveyardList;
        m_GameManager.myHandList = handList;
        m_GameManager.Syncronize();
        m_GameManager.ExecuteActionList();
    }

    public void ExecuteAction_SearchAfterConfirmDialog_P3_S01_080()
    {
        if (m_GameManager == null || m_BattleModeCardList == null)
        {
            return;
        }

        List<BattleModeCard> deckList = new List<BattleModeCard>();
        List<BattleModeCard> stockList = new List<BattleModeCard>();
        List<BattleModeCard> graveyardList = new List<BattleModeCard>();
        List<BattleModeCard> handList = new List<BattleModeCard>();
        List<BattleModeCard> memoryList = new List<BattleModeCard>();
        List<BattleModeCard> clockList = new List<BattleModeCard>();
        List<BattleModeCard> myFieldList = new List<BattleModeCard>();
        if(m_ExecuteActionTemp == null)
        {
            Debug.Log("aa");
        }

        for (int i = 0; i < m_ExecuteActionTemp.myFieldListTemp.Count; i++)
        {
            if(m_ExecuteActionTemp.myFieldListTemp[i] == null)
            {
                continue;
            }
            BattleModeCard b = m_BattleModeCardList.ConvertCardNoToBattleModeCard(m_ExecuteActionTemp.myFieldListTemp[i].cardNo);
            myFieldList.Add(b);
        }
        for (int i = 0; i < m_ExecuteActionTemp.deckList.Count; i++)
        {
            BattleModeCard b = m_BattleModeCardList.ConvertCardNoToBattleModeCard(m_ExecuteActionTemp.deckList[i].cardNo);
            deckList.Add(b);
        }
        for (int i = 0; i < m_ExecuteActionTemp.stockList.Count; i++)
        {
            BattleModeCard b = m_BattleModeCardList.ConvertCardNoToBattleModeCard(m_ExecuteActionTemp.stockList[i].cardNo);
            stockList.Add(b);
        }
        for (int i = 0; i < m_ExecuteActionTemp.graveyardList.Count; i++)
        {
            BattleModeCard b = m_BattleModeCardList.ConvertCardNoToBattleModeCard(m_ExecuteActionTemp.graveyardList[i].cardNo);
            graveyardList.Add(b);
        }
        for (int i = 0; i < m_ExecuteActionTemp.handList.Count; i++)
        {
            BattleModeCard b = m_BattleModeCardList.ConvertCardNoToBattleModeCard(m_ExecuteActionTemp.handList[i].cardNo);
            handList.Add(b);
        }
        for (int i = 0; i < m_ExecuteActionTemp.memoryList.Count; i++)
        {
            BattleModeCard b = m_BattleModeCardList.ConvertCardNoToBattleModeCard(m_ExecuteActionTemp.memoryList[i].cardNo);
            memoryList.Add(b);
        }
        for (int i = 0; i < m_ExecuteActionTemp.clockList.Count; i++)
        {
            BattleModeCard b = m_BattleModeCardList.ConvertCardNoToBattleModeCard(m_ExecuteActionTemp.clockList[i].cardNo);
            clockList.Add(b);
        }

        m_GameManager.myFieldList = myFieldList;
        m_GameManager.myDeckList = deckList;
        m_GameManager.myStockList = stockList;
        m_GameManager.GraveYardList = graveyardList;
        m_GameManager.myHandList = handList;
        m_GameManager.myMemoryList = memoryList;
        m_GameManager.myClockList = clockList;

        m_GameManager.Syncronize();

        if (m_GameManager.myDeckList.Count == 0)
        {
            m_GameManager.Refresh();
        }
        m_GameManager.Shuffle();
        m_GameManager.Draw();

        m_GameManager.Syncronize();
        m_GameManager.ExecuteActionList();
    }
}
