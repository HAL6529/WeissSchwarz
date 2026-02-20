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
    [SerializeField] Button OKButton;

    public bool isClockAndTwoDrawProcess = false;

    /// <summary>
    /// サーチorサルベージするカードの最低枚数
    /// </summary>
    public int SulvageMinNum = -1;

    /// <summary>
    /// サーチorサルベージするカードの最大枚数
    /// </summary>
    public int SulvageMaxNum = -1;

    /// <summary>
    /// イベントカードを使用する場合手札の何枚目を消費するか
    /// </summary>
    private int handNum = -1;

    private EnumController.SearchDialogParamater paramater = EnumController.SearchDialogParamater.VOID;

    private StringValues stringValues = new StringValues();

    private EnumController.ConfirmSearchOrSulvageCardDialog ConfirmSearchOrSulvageCardDialogParamater;

    private enum Mode
    {
        VOID,
        My_Clock_Sulvage,
        My_Deck_Search,
    }

    /// <summary>
    /// クロック回収かデッキサーチか
    /// </summary>
    private Mode m_Mode = Mode.VOID;

    private class SearchButtonUtilParamater
    {
        public BattleModeCard m_BattleModeCard;
        public bool isEnable = false;

        public SearchButtonUtilParamater(BattleModeCard m_BattleModeCard, bool isEnable)
        {
            this.m_BattleModeCard = m_BattleModeCard;
            this.isEnable = isEnable;
        }
    }

    private List<SearchButtonUtilParamater> SearchButtonUtilParamaterList = new List<SearchButtonUtilParamater>();

    public void SetBattleModeCard(EnumController.SearchDialogParamater paramater, int handNum)
    {
        this.handNum = handNum;
        SetBattleModeCard(paramater);
    }

    public void SetBattleModeCard(EnumController.SearchDialogParamater paramater)
    {
        this.paramater = paramater;
        this.gameObject.SetActive(true);
        OKButton.interactable = false;
        m_Mode = Mode.VOID;
        text.text = stringValues.SearchDialog_SearchMessage;
        m_GameManager.isSearchDialogProcess = true;
        switch (paramater)
        {
            case EnumController.SearchDialogParamater.AT_WX02_A07:
            case EnumController.SearchDialogParamater.P3_S01_077:
            case EnumController.SearchDialogParamater.LB_W02_001:
            case EnumController.SearchDialogParamater.LB_W02_034:
            case EnumController.SearchDialogParamater.LB_W02_088:
            case EnumController.SearchDialogParamater.LB_W02_093:
                m_Mode = Mode.My_Deck_Search;
                break;
            case EnumController.SearchDialogParamater.LB_W02_16T:
            case EnumController.SearchDialogParamater.P3_S01_081:
                m_Mode = Mode.My_Clock_Sulvage;
                break;
            default:
                break;
        }

        // サーチorサルベージするカードの枚数
        switch (paramater)
        {
            case EnumController.SearchDialogParamater.LB_W02_16T:
            case EnumController.SearchDialogParamater.P3_S01_081:
                SulvageMaxNum = 1;
                SulvageMinNum = 1;
                break;
            case EnumController.SearchDialogParamater.AT_WX02_A07:
            case EnumController.SearchDialogParamater.P3_S01_077:
            case EnumController.SearchDialogParamater.LB_W02_001:
            case EnumController.SearchDialogParamater.LB_W02_034:
            case EnumController.SearchDialogParamater.LB_W02_088:
            case EnumController.SearchDialogParamater.LB_W02_093:
                SulvageMaxNum = 1;
                SulvageMinNum = 0;
                break;
            default:
                SulvageMaxNum = -1;
                SulvageMinNum = -1;
                break;
        }

        SearchButtonUtilParamaterList = new List<SearchButtonUtilParamater>();
        int cnt = 0;
        switch (m_Mode)
        {
            case Mode.My_Clock_Sulvage:
                for(int i = 0; i < m_GameManager.myClockList.Count; i++)
                {
                    SearchButtonUtilParamaterList.Add(new SearchButtonUtilParamater(m_GameManager.myClockList[i], true));
                    cnt++;
                }
                break;
            case Mode.My_Deck_Search:
                for (int i = 0; i < m_GameManager.myDeckList.Count; i++)
                {
                    SearchButtonUtilParamaterList.Add(new SearchButtonUtilParamater(m_GameManager.myDeckList[i], true));
                    cnt++;
                }
                break;
            default : 
                break;
        }
        List<EnumController.Attribute> list = new List<EnumController.Attribute>();
        switch (paramater)
        {
            case EnumController.SearchDialogParamater.AT_WX02_A07:
                // Search your deck for up to 1 《Ooo》 character, reveal it to your opponent, put it into your hand, and shuffle your deck.
                list.Add(EnumController.Attribute.Ooo);
                for (int i = 0; i < SearchButtonUtilParamaterList.Count; i++)
                {
                    BattleModeCard temp = SearchButtonUtilParamaterList[i].m_BattleModeCard;
                    if (!HaveAttribute(temp, list) || temp.GetType() != EnumController.Type.CHARACTER)
                    {
                        SearchButtonUtilParamaterList[i].isEnable = false;
                        cnt--;
                    }
                }
                break;
            case EnumController.SearchDialogParamater.P3_S01_077:
                //【起】［(4)］ あなたは自分の山札を見てイベントを1枚まで選んで相手に見せ、手札に加える。その山札をシャッフルする。
                for (int i = 0; i < SearchButtonUtilParamaterList.Count; i++)
                {
                    BattleModeCard temp = SearchButtonUtilParamaterList[i].m_BattleModeCard;
                    if (temp.GetType() != EnumController.Type.EVENT)
                    {
                        SearchButtonUtilParamaterList[i].isEnable = false;
                        cnt--;
                    }
                }
                break;
            case EnumController.SearchDialogParamater.LB_W02_16T:
            case EnumController.SearchDialogParamater.P3_S01_081:
                //あなたは自分のクロックを1枚選び、手札に戻す。
                break;
            case EnumController.SearchDialogParamater.LB_W02_001:
                //【起】［(2) このカードを【レスト】する］ あなたは自分の山札を見て《スポーツ》のキャラを1枚まで選んで相手に見せ、手札に加える。その山札をシャッフルする。
                list.Add(EnumController.Attribute.Sports);
                for (int i = 0; i < SearchButtonUtilParamaterList.Count; i++)
                {
                    BattleModeCard temp = SearchButtonUtilParamaterList[i].m_BattleModeCard;
                    if (!HaveAttribute(temp, list) || temp.GetType() != EnumController.Type.CHARACTER)
                    {
                        SearchButtonUtilParamaterList[i].isEnable = false;
                        cnt--;
                    }
                }
                break;
            case EnumController.SearchDialogParamater.LB_W02_034:
                //【起】［(2) このカードを【レスト】する］ あなたは自分の山札を見てカード名に「葉留佳」を含むキャラを1枚まで選んで相手に見せ、手札に加える。その山札をシャッフルする。
                for (int i = 0; i < SearchButtonUtilParamaterList.Count; i++)
                {
                    BattleModeCard temp = SearchButtonUtilParamaterList[i].m_BattleModeCard;
                    if (!temp.GetName().Contains("葉留佳"))
                    {
                        SearchButtonUtilParamaterList[i].isEnable = false;
                        cnt--;
                    }
                }
                break;
            case EnumController.SearchDialogParamater.LB_W02_088:
                //【起】［(2) このカードを【レスト】する］ あなたは自分の山札を見てカード名に「小毬」を含むキャラを1枚まで選んで相手に見せ、手札に加える。その山札をシャッフルする。
                for (int i = 0; i < SearchButtonUtilParamaterList.Count; i++)
                {
                    BattleModeCard temp = SearchButtonUtilParamaterList[i].m_BattleModeCard;
                    if (!temp.GetName().Contains("小毬") )
                    {
                        SearchButtonUtilParamaterList[i].isEnable = false;
                        cnt--;
                    }
                }
                break;
            case EnumController.SearchDialogParamater.LB_W02_093:
                //あなたは自分の山札を見て《動物》のキャラを1枚まで選んで相手に見せ、手札に加える。その山札をシャッフルする。
                list.Add(EnumController.Attribute.Animal);
                for (int i = 0; i < SearchButtonUtilParamaterList.Count; i++)
                {
                    BattleModeCard temp = SearchButtonUtilParamaterList[i].m_BattleModeCard;
                    if (!HaveAttribute(temp, list) || temp.GetType() != EnumController.Type.CHARACTER)
                    {
                        SearchButtonUtilParamaterList[i].isEnable = false;
                        cnt--;
                    }
                }
                break;
            default:
                break;
        }

        if(cnt < SulvageMinNum)
        {
            m_GameManager.isSearchDialogProcess = false;
            this.gameObject.SetActive(false);
            m_GameManager.ExecuteActionList();
            return;
        }

        for(int i = 0; i < buttons.Count; i++)
        {
            buttons[i].OffSelected();
            if (i < SearchButtonUtilParamaterList.Count)
            {
                buttons[i].SetBattleModeCard(SearchButtonUtilParamaterList[i].m_BattleModeCard, SearchButtonUtilParamaterList[i].isEnable);
            }
            else
            {
                buttons[i].SetBattleModeCard(null, false);
            }
        }
    }

    /// <summary>
    /// BattleModeCardが特定の特徴を持っているか
    /// </summary>
    /// <param name="card"></param>
    /// <param name="attribute"></param>
    /// <returns></returns>
    private bool HaveAttribute(BattleModeCard card, List<EnumController.Attribute> attribute)
    {
        for(int i = 0; i < card.GetAttribute().Count; i++)
        {
            for(int n = 0; n < attribute.Count; n++)
            {
                if (card.GetAttribute(i) == attribute[n])
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void CallOffSelected()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].OffSelected();
        }
    }

    public void SwitchOKButton()
    {
        int cnt = 0;
        for (int i = 0; i < buttons.Count; i++)
        {
            if (buttons[i].isSelected)
            {
                cnt++;
            }
        }

        if(cnt <= SulvageMaxNum && cnt >= SulvageMinNum)
        {
            OKButton.interactable = true;
        }
        else
        {
            OKButton.interactable = false;
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

        deckListTemp = m_GameManager.myDeckList;
        memoryListTemp = m_GameManager.myMemoryList;
        stockListTemp = m_GameManager.myStockList;
        graveyardTemp = m_GameManager.GraveYardList;
        clockListTemp = m_GameManager.myClockList;
        handListTemp = m_GameManager.myHandList;

        BattleModeCard t;
        switch (paramater)
        {
            case EnumController.SearchDialogParamater.AT_WX02_A07:
            case EnumController.SearchDialogParamater.LB_W02_093:
                // イベントの場合は処理後に控室に送る
                t = handListTemp[handNum];
                handListTemp.RemoveAt(handNum);
                graveyardTemp.Add(t);
                break;
            case EnumController.SearchDialogParamater.LB_W02_16T:
                // あなたは自分のクロックを1枚選び、手札に戻す。このカードを思い出にする。
                t = handListTemp[handNum];
                handListTemp.RemoveAt(handNum);
                memoryListTemp.Add(t);
                break;
            case EnumController.SearchDialogParamater.P3_S01_077:
            case EnumController.SearchDialogParamater.P3_S01_081:
            case EnumController.SearchDialogParamater.LB_W02_001:
                break;
            default:
                break;
        }

        ConfirmSearchOrSulvageCardDialogParamater = EnumController.ConfirmSearchOrSulvageCardDialog.VOID;
        switch (m_Mode)
        {
            case Mode.My_Clock_Sulvage:
                ConfirmSearchOrSulvageCardDialogParamater = EnumController.ConfirmSearchOrSulvageCardDialog.CLOCK_SULVAGE;
                for (int i = 0; i < buttons.Count; i++)
                {
                    if (buttons[i].isSelected)
                    {
                        searchListTemp.Add(buttons[i].m_BattleModeCard);
                        handListTemp.Add(clockListTemp[i]);
                        clockListTemp.RemoveAt(i);
                    }
                }
                break;
            case Mode.My_Deck_Search:
                ConfirmSearchOrSulvageCardDialogParamater = EnumController.ConfirmSearchOrSulvageCardDialog.SEARCH;
                for (int i = 0; i < buttons.Count; i++)
                {
                    if (buttons[i].isSelected)
                    {
                        searchListTemp.Add(buttons[i].m_BattleModeCard);
                        handListTemp.Add(deckListTemp[i]);
                        deckListTemp.RemoveAt(i);
                    }
                }
                break;
            default:
                break;
        }

        for (int i = 0; i < deckListTemp.Count; i++)
        {
            m_deckListTemp.Add(new BattleModeCardTemp(deckListTemp[i]));
        }
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

        m_ExecuteActionTemp.deckList = m_deckListTemp;
        m_ExecuteActionTemp.memoryList = m_memoryListTemp;
        m_ExecuteActionTemp.stockList = m_stockListTemp;
        m_ExecuteActionTemp.graveyardList = m_graveyardTemp;
        m_ExecuteActionTemp.memoryList = m_memoryListTemp;
        m_ExecuteActionTemp.clockList = m_clockListTemp;
        m_ExecuteActionTemp.handList = m_handListTemp;
        m_ExecuteActionTemp.isFirstAttacker = m_GameManager.isFirstAttacker;

        m_BattleStrix.SendConfirmSearchOrSulvageCardDialog(searchListTemp, ConfirmSearchOrSulvageCardDialogParamater, m_ExecuteActionTemp, m_GameManager.isFirstAttacker);

        OffDialog();
    }

    public void OffDialog()
    {
        m_GameManager.isSearchDialogProcess = false;
        this.handNum = -1;
        this.gameObject.SetActive(false);
    }
}
