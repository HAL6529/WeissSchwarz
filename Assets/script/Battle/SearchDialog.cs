using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �f�b�L����J�[�h����D�ɉ�����ꍇ�A�T������J�[�h����D�ɉ�����ꍇ�Ɏg�p
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
        for (int i = 0; i < buttons.Count; i++)
        {
            if (i > list.Count - 1)
            {
                buttons[i].SetBattleModeCard(null, false);
            }
            else
            {
                if(list[i].type == EnumController.Type.CHARACTER)
                {
                    buttons[i].SetBattleModeCard(list[i], true);
                }
                else
                {
                    buttons[i].SetBattleModeCard(list[i], false);
                }
            }
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
        switch (paramater)
        {
            case EnumController.SearchDialogParamater.Search:
                if(num < 0)
                {
                    return;
                }

                List<BattleModeCard> deckListTemp = m_GameManager.myDeckList;
                List<BattleModeCard> stockListTemp = m_GameManager.myStockList;
                List<BattleModeCard> graveyardTemp = m_GameManager.GraveYardList;
                List<BattleModeCard> handListTemp = m_GameManager.myHandList;
                List<BattleModeCard> searchListTemp = new List<BattleModeCard>();
                searchListTemp.Add(deckListTemp[num]);

                graveyardTemp.Add(stockListTemp[stockListTemp.Count - 1]);
                stockListTemp.RemoveAt(stockListTemp.Count - 1);
                handListTemp.Remove(card);
                graveyardTemp.Add(card);
                handListTemp.Add(deckListTemp[num]);
                deckListTemp.Remove(deckListTemp[num]);

                List<BattleModeCardTemp> m_deckListTemp = new List<BattleModeCardTemp>();
                List<BattleModeCardTemp> m_stockListTemp = new List<BattleModeCardTemp>();
                List<BattleModeCardTemp> m_graveyardTemp = new List<BattleModeCardTemp>();
                List<BattleModeCardTemp> m_handListTemp = new List<BattleModeCardTemp>();

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

                ExecuteActionTemp m_ExecuteActionTemp = new ExecuteActionTemp();
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
