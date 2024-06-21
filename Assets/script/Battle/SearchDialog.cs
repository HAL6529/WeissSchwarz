using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// デッキからカードを手札に加える場合、控室からカードを手札に加える場合に使用
/// </summary>
public class SearchDialog : MonoBehaviour
{
    [SerializeField] List<SearchButtonUtil> buttons = new List<SearchButtonUtil>();
    [SerializeField] GameManager m_GameManager;
    [SerializeField] BattleStrix m_BattleStrix;
    [SerializeField] Text text;

    public bool isClockAndTwoDrawProcess = false;

    public int num = -1;

    private EnumController.SearchDialogParamater paramater = EnumController.SearchDialogParamater.VOID;
    private BattleModeCard card = null;

    private StringValues stringValues = new StringValues();

    public void SetBattleModeCard(List<BattleModeCard> list, EnumController.SearchDialogParamater paramater, BattleModeCard card)
    {
        num = -1;
        this.paramater = paramater;
        this.gameObject.SetActive(true);
        this.card = card;
        text.text = stringValues.SearchDialog_SearchMessage;
        switch (paramater)
        {
            case EnumController.SearchDialogParamater.ClockSulvage:
                for (int i = 0; i < buttons.Count; i++)
                {
                    if (i > list.Count - 1)
                    {
                        buttons[i].SetBattleModeCard(null, false);
                    }
                    else
                    {
                        buttons[i].SetBattleModeCard(list[i], true);
                    }
                }
                break;
            default:
                for (int i = 0; i < buttons.Count; i++)
                {
                    if (i > list.Count - 1)
                    {
                        buttons[i].SetBattleModeCard(null, false);
                    }
                    else
                    {
                        if (list[i].type == EnumController.Type.CHARACTER)
                        {
                            buttons[i].SetBattleModeCard(list[i], true);
                        }
                        else
                        {
                            buttons[i].SetBattleModeCard(list[i], false);
                        }
                    }
                }
                break;
        }
    }

    public void CallOffSelected()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].OffSelected();
        }
    }

    public void onOKbutton()
    {
        List<BattleModeCard> deckListTemp = new List<BattleModeCard>();
        List<BattleModeCard> memoryListTemp = new List<BattleModeCard>();
        List<BattleModeCard> stockListTemp = new List<BattleModeCard>();
        List<BattleModeCard> graveyardTemp = new List<BattleModeCard>();
        List<BattleModeCard> clockListTemp = new List<BattleModeCard>();
        List<BattleModeCard> handListTemp = new List<BattleModeCard>();
        List<BattleModeCard> searchListTemp = new List<BattleModeCard>();

        List<BattleModeCardTemp> m_deckListTemp = new List<BattleModeCardTemp>();
        List<BattleModeCardTemp> m_memoryListTemp = new List<BattleModeCardTemp>();
        List<BattleModeCardTemp> m_stockListTemp = new List<BattleModeCardTemp>();
        List<BattleModeCardTemp> m_graveyardTemp = new List<BattleModeCardTemp>();
        List<BattleModeCardTemp> m_clockListTemp = new List<BattleModeCardTemp>();
        List<BattleModeCardTemp> m_handListTemp = new List<BattleModeCardTemp>();

        ExecuteActionTemp m_ExecuteActionTemp = new ExecuteActionTemp();

        switch (paramater)
        {
            case EnumController.SearchDialogParamater.ClockSulvage:
                if (num < 0)
                {
                    return;
                }
                memoryListTemp = m_GameManager.myMemoryList;
                stockListTemp = m_GameManager.myStockList;
                graveyardTemp = m_GameManager.GraveYardList;
                clockListTemp = m_GameManager.myClockList;
                handListTemp = m_GameManager.myHandList;
                searchListTemp.Add(clockListTemp[num]);

                for(int i = 0; i < 3; i++)
                {
                    graveyardTemp.Add(stockListTemp[stockListTemp.Count - 1]);
                    stockListTemp.RemoveAt(stockListTemp.Count - 1);
                }
                handListTemp.Remove(card);
                memoryListTemp.Add(card);
                handListTemp.Add(clockListTemp[num]);
                clockListTemp.Remove(clockListTemp[num]);

                for (int i = 0; i < memoryListTemp.Count; i++)
                {
                    m_memoryListTemp.Add(new BattleModeCardTemp(memoryListTemp[i]));
                }
                for (int i = 0; i < stockListTemp.Count; i++)
                {
                    m_stockListTemp.Add(new BattleModeCardTemp(stockListTemp[i]));
                }
                for (int i = 0; i < graveyardTemp.Count; i++)
                {
                    m_graveyardTemp.Add(new BattleModeCardTemp(graveyardTemp[i]));
                }
                for (int i = 0; i < clockListTemp.Count; i++)
                {
                    m_clockListTemp.Add(new BattleModeCardTemp(clockListTemp[i]));
                }
                for (int i = 0; i < handListTemp.Count; i++)
                {
                    m_handListTemp.Add(new BattleModeCardTemp(handListTemp[i]));
                }

                m_ExecuteActionTemp.memoryList = m_memoryListTemp;
                m_ExecuteActionTemp.stockList = m_stockListTemp;
                m_ExecuteActionTemp.graveyardList = m_graveyardTemp;
                m_ExecuteActionTemp.memoryList = m_memoryListTemp;
                m_ExecuteActionTemp.clockList = m_clockListTemp;
                m_ExecuteActionTemp.handList = m_handListTemp;
                m_ExecuteActionTemp.isFirstAttacker = m_GameManager.isFirstAttacker;

                m_BattleStrix.SendConfirmSearchOrSulvageCardDialog(searchListTemp, EnumController.ConfirmSearchOrSulvageCardDialog.CLOCK_SULVAGE, m_ExecuteActionTemp, m_GameManager.isFirstAttacker);
                OffDialog();
                break;
            case EnumController.SearchDialogParamater.Search:
                if(num < 0)
                {
                    return;
                }

                deckListTemp = m_GameManager.myDeckList;
                stockListTemp = m_GameManager.myStockList;
                graveyardTemp = m_GameManager.GraveYardList;
                handListTemp = m_GameManager.myHandList;
                searchListTemp.Add(deckListTemp[num]);

                graveyardTemp.Add(stockListTemp[stockListTemp.Count - 1]);
                stockListTemp.RemoveAt(stockListTemp.Count - 1);
                handListTemp.Remove(card);
                graveyardTemp.Add(card);
                handListTemp.Add(deckListTemp[num]);
                deckListTemp.Remove(deckListTemp[num]);

                for (int i = 0; i < deckListTemp.Count; i++)
                {
                    m_deckListTemp.Add(new BattleModeCardTemp(deckListTemp[i]));
                }
                for (int i = 0; i < stockListTemp.Count; i++)
                {
                    m_stockListTemp.Add(new BattleModeCardTemp(stockListTemp[i]));
                }
                for (int i = 0; i < graveyardTemp.Count; i++)
                {
                    m_graveyardTemp.Add(new BattleModeCardTemp(graveyardTemp[i]));
                }
                for (int i = 0; i < handListTemp.Count; i++)
                {
                    m_handListTemp.Add(new BattleModeCardTemp(handListTemp[i]));
                }

                m_ExecuteActionTemp.deckList = m_deckListTemp;
                m_ExecuteActionTemp.stockList = m_stockListTemp;
                m_ExecuteActionTemp.graveyardList = m_graveyardTemp;
                m_ExecuteActionTemp.handList = m_handListTemp;
                m_ExecuteActionTemp.isFirstAttacker = m_GameManager.isFirstAttacker;

                m_BattleStrix.SendConfirmSearchOrSulvageCardDialog(searchListTemp, EnumController.ConfirmSearchOrSulvageCardDialog.SEARCH, m_ExecuteActionTemp, m_GameManager.isFirstAttacker);

                OffDialog(); 
                break;
            default:
                break;
        }
    }

    public void OffDialog()
    {
        this.gameObject.SetActive(false);
    }
}
