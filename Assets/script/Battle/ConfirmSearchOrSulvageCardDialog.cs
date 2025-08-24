using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmSearchOrSulvageCardDialog : MonoBehaviour
{
    [SerializeField] List<ConfirmSearchOrSulvageCardDialogsBtnUtil> ConfirmSearchOrSulvageCardDialogsBtnUtilList = new List<ConfirmSearchOrSulvageCardDialogsBtnUtil>();
    [SerializeField] BattleStrix m_BattleStrix;
    [SerializeField] GameManager m_GameManager;
    [SerializeField] Text text;

    private StringValues stringValues = new StringValues();

    private ExecuteActionTemp m_ExecuteActionTemp = null;

    private EnumController.ConfirmSearchOrSulvageCardDialog paramater = EnumController.ConfirmSearchOrSulvageCardDialog.VOID;

    private List<BattleModeCard> sulvageList = new List<BattleModeCard>();

    /// <summary>
    /// サーチカードやサルベージカードの確認用
    /// </summary>
    /// <param name="list"></param>
    /// <param name="paramater"></param>
    public void SetBattleModeCard(List<BattleModeCard> list, EnumController.ConfirmSearchOrSulvageCardDialog paramater, ExecuteActionTemp m_ExecuteActionTemp)
    {
        if (list.Count > ConfirmSearchOrSulvageCardDialogsBtnUtilList.Count)
        {
            return;
        }
        this.m_ExecuteActionTemp = m_ExecuteActionTemp;
        this.paramater = paramater;
        sulvageList = list;
        switch (paramater)
        {
            case EnumController.ConfirmSearchOrSulvageCardDialog.SEARCH:
                text.text = stringValues.ConfirmSearchOrSulvageCardDialog_Search;
                break;
            case EnumController.ConfirmSearchOrSulvageCardDialog.SULVAGE:
                text.text = stringValues.ConfirmSearchOrSulvageCardDialog_Sulvage;
                break;
            case EnumController.ConfirmSearchOrSulvageCardDialog.COMEBACK:
                text.text = stringValues.ConfirmSearchOrSulvageCardDialog_Sulvage;
                break;
            case EnumController.ConfirmSearchOrSulvageCardDialog.CLOCK_SULVAGE:
                text.text = stringValues.ConfirmSearchOrSulvageCardDialog_Clock_Sulvage;
                break;
            case EnumController.ConfirmSearchOrSulvageCardDialog.P3_S01_057:
                text.text = stringValues.ConfirmSearchOrSulvageCardDialog_GraveyardToMemory;
                break;
            case EnumController.ConfirmSearchOrSulvageCardDialog.P3_S01_061:
                text.text = stringValues.ConfirmSearchOrSulvageCardDialog_GraveyardToDeckTop;
                break;
            case EnumController.ConfirmSearchOrSulvageCardDialog.P3_S01_080:
                break;
            case EnumController.ConfirmSearchOrSulvageCardDialog.DC_W01_12T:
                text.text = stringValues.ConfirmSearchOrSulvageCardDialog_Sulvage;
                break;
            default:
                text.text = "無効メッセージ";
                break;
        }

        if(list.Count == 0)
        {
            text.text = stringValues.ConfirmSearchOrSulvageCardDialog_Sulvage_NONE;
        }

        for(int i = 0; i < ConfirmSearchOrSulvageCardDialogsBtnUtilList.Count; i++)
        {
            if(i < list.Count)
            {
                ConfirmSearchOrSulvageCardDialogsBtnUtilList[i].SetBattleModeCard(list[i]);
            }
            else
            {
                ConfirmSearchOrSulvageCardDialogsBtnUtilList[i].SetBattleModeCard(null);
            }
        }
        this.gameObject.SetActive(true);
    }

    public void OffDialog()
    {
        this.gameObject.SetActive(false);
    }

    public void onOKButton()
    {
        this.gameObject.SetActive(false);
        m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
        switch (paramater)
        {
            case EnumController.ConfirmSearchOrSulvageCardDialog.P3_S01_057:
                P3_S01_057(m_ExecuteActionTemp);
                m_BattleStrix.RpcToAll("ExecuteActionList", m_GameManager.isTurnPlayer);
                return;
            case EnumController.ConfirmSearchOrSulvageCardDialog.P3_S01_061:
                P3_S01_061(m_ExecuteActionTemp);
                m_BattleStrix.RpcToAll("ExecuteActionList", m_GameManager.isTurnPlayer);
                return;
            case EnumController.ConfirmSearchOrSulvageCardDialog.CLOCK_SULVAGE:
            case EnumController.ConfirmSearchOrSulvageCardDialog.SEARCH:
                m_BattleStrix.RpcToAll("ExecuteAction_SearchAfterConfirmDialog", m_ExecuteActionTemp, m_GameManager.isFirstAttacker);
                return;
            case EnumController.ConfirmSearchOrSulvageCardDialog.SULVAGE:
                return;
            case EnumController.ConfirmSearchOrSulvageCardDialog.COMEBACK:
                m_BattleStrix.RpcToAll("ExecuteAction_ComeBackActionAfterConfirmDialog", m_ExecuteActionTemp, m_GameManager.isFirstAttacker);
                return;
            case EnumController.ConfirmSearchOrSulvageCardDialog.DC_W01_12T:
                m_BattleStrix.RpcToAll("ExecuteActionList", m_GameManager.isTurnPlayer);
                return;
            case EnumController.ConfirmSearchOrSulvageCardDialog.P3_S01_080:
                m_BattleStrix.RpcToAll("ExecuteAction_P3_S01_080", m_ExecuteActionTemp, m_GameManager.isFirstAttacker);
                return;
            default:
                return;
        }
    }

    private void P3_S01_057(ExecuteActionTemp executeActionTemp)
    {
        BattleModeCardList m_BattleModeCardList = m_GameManager.m_BattleModeCardList;
        List<BattleModeCard> stockList = new List<BattleModeCard>();
        List<BattleModeCard> graveyardList = new List<BattleModeCard>();
        List<BattleModeCard> handList = new List<BattleModeCard>();
        List<BattleModeCard> memoryList = new List<BattleModeCard>();
        List<BattleModeCard> clockList = new List<BattleModeCard>();

        for (int i = 0; i < m_ExecuteActionTemp.enemy_stockList.Count; i++)
        {
            BattleModeCard b = m_BattleModeCardList.ConvertCardNoToBattleModeCard(m_ExecuteActionTemp.enemy_stockList[i].cardNo);
            stockList.Add(b);
        }
        for (int i = 0; i < m_ExecuteActionTemp.enemy_graveyardList.Count; i++)
        {
            BattleModeCard b = m_BattleModeCardList.ConvertCardNoToBattleModeCard(m_ExecuteActionTemp.enemy_graveyardList[i].cardNo);
            graveyardList.Add(b);
        }
        for (int i = 0; i < m_ExecuteActionTemp.enemy_handList.Count; i++)
        {
            BattleModeCard b = m_BattleModeCardList.ConvertCardNoToBattleModeCard(m_ExecuteActionTemp.enemy_handList[i].cardNo);
            handList.Add(b);
        }
        for (int i = 0; i < m_ExecuteActionTemp.enemy_memoryList.Count; i++)
        {
            BattleModeCard b = m_BattleModeCardList.ConvertCardNoToBattleModeCard(m_ExecuteActionTemp.enemy_memoryList[i].cardNo);
            memoryList.Add(b);
        }
        for (int i = 0; i < m_ExecuteActionTemp.enemy_clockList.Count; i++)
        {
            BattleModeCard b = m_BattleModeCardList.ConvertCardNoToBattleModeCard(m_ExecuteActionTemp.enemy_clockList[i].cardNo);
            clockList.Add(b);
        }

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

    private void P3_S01_061(ExecuteActionTemp executeActionTemp)
    {
        BattleModeCardList m_BattleModeCardList = m_GameManager.m_BattleModeCardList;
        List<BattleModeCard> stockList = new List<BattleModeCard>();
        List<BattleModeCard> graveyardList = new List<BattleModeCard>();
        List<BattleModeCard> handList = new List<BattleModeCard>();
        List<BattleModeCard> memoryList = new List<BattleModeCard>();
        List<BattleModeCard> clockList = new List<BattleModeCard>();
        List<BattleModeCard> t = new List<BattleModeCard>();

        for (int i = 0; i < m_ExecuteActionTemp.enemy_stockList.Count; i++)
        {
            BattleModeCard b = m_BattleModeCardList.ConvertCardNoToBattleModeCard(m_ExecuteActionTemp.enemy_stockList[i].cardNo);
            stockList.Add(b);
        }
        for (int i = 0; i < m_ExecuteActionTemp.enemy_graveyardList.Count; i++)
        {
            BattleModeCard b = m_BattleModeCardList.ConvertCardNoToBattleModeCard(m_ExecuteActionTemp.enemy_graveyardList[i].cardNo);
            graveyardList.Add(b);
        }
        for (int i = 0; i < m_ExecuteActionTemp.enemy_handList.Count; i++)
        {
            BattleModeCard b = m_BattleModeCardList.ConvertCardNoToBattleModeCard(m_ExecuteActionTemp.enemy_handList[i].cardNo);
            handList.Add(b);
        }
        for (int i = 0; i < m_ExecuteActionTemp.enemy_memoryList.Count; i++)
        {
            BattleModeCard b = m_BattleModeCardList.ConvertCardNoToBattleModeCard(m_ExecuteActionTemp.enemy_memoryList[i].cardNo);
            memoryList.Add(b);
        }
        for (int i = 0; i < m_ExecuteActionTemp.enemy_clockList.Count; i++)
        {
            BattleModeCard b = m_BattleModeCardList.ConvertCardNoToBattleModeCard(m_ExecuteActionTemp.enemy_clockList[i].cardNo);
            clockList.Add(b);
        }

        m_GameManager.myStockList = stockList;
        m_GameManager.GraveYardList = graveyardList;
        m_GameManager.myHandList = handList;
        m_GameManager.myMemoryList = memoryList;
        m_GameManager.myClockList = clockList;

        for (int i = 0; i < sulvageList.Count; i++)
        {
            t.Add(sulvageList[i]);
        }

        for (int i = 0; i < m_GameManager.myDeckList.Count; i++)
        {
            t.Add(m_GameManager.myDeckList[i]);
        }

        m_GameManager.myDeckList = t;
        m_GameManager.Syncronize();

        if (m_GameManager.myDeckList.Count == 0)
        {
            m_GameManager.Refresh();
        }

        m_GameManager.Syncronize();
    }
}
