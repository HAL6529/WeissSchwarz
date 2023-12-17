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
                m_GameManager.GraveYardList.Add(m_GameManager.myStockList[m_GameManager.myStockList.Count - 1]);
                m_GameManager.myStockList.RemoveAt(m_GameManager.myStockList.Count - 1);
                m_GameManager.myHandList.Remove(card);
                m_GameManager.GraveYardList.Add(card);
                m_GameManager.myHandList.Add(m_GameManager.myDeckList[num]);
                m_GameManager.myDeckList.Remove(m_GameManager.myDeckList[num]);
                m_GameManager.Syncronize();

                if (m_GameManager.myDeckList.Count == 0)
                {
                    m_GameManager.Refresh();
                }

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
