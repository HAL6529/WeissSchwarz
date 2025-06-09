using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandOverDialog : MonoBehaviour
{
    [SerializeField] MyHandCardsManager m_MyHandCardsManager;
    [SerializeField] GameObject button;
    [SerializeField] Text text;
    [SerializeField] GameManager m_GameManager;

    private StringValues stringValues = new StringValues();

    public List<BattleModeCard> HandOverList = new List<BattleModeCard>();
    public List<bool> HandOverBoolList = new List<bool>();

    public void SetParamater(EnumController.HandOverDialogParamater paramater)
    {
        switch (paramater)
        {
            case EnumController.HandOverDialogParamater.Active:
                Active();
                break;
            case EnumController.HandOverDialogParamater.Confirm:
                Confirm();
                break;
            default:
                break;
        }
    }

    public void Active()
    {
        text.text = stringValues.HandOverDialog;
        this.gameObject.SetActive(true);
        button.SetActive(false);
        HandOverList = m_GameManager.myHandList;
        HandOverBoolList = new List<bool>();
        for (int i = 0; i < m_GameManager.myHandList.Count; i++)
        {
            HandOverBoolList.Add(false);
        }
        Confirm();
    }

    public void Confirm()
    {
        if(HandOverBoolListTrueNum() == m_GameManager.myHandList.Count - m_GameManager.GetHAND_LIMIT_NUM())
        {
            button.SetActive(true);
            return;
        }
        button.SetActive(false);
    }

    public void OffDialog()
    {
        this.gameObject.SetActive(false);
    }

    public void onOKbutton()
    {
        this.gameObject.SetActive(false);
        button.SetActive(false);

        List<BattleModeCard> list = new List<BattleModeCard>();
        for (int i = 0; i < HandOverBoolList.Count; i++)
        {
            if (HandOverBoolList[i])
            {
                m_GameManager.GraveYardList.Add(m_GameManager.myHandList[i]);
            }
            else
            {
                list.Add(m_GameManager.myHandList[i]);
            }
        }
        m_GameManager.myHandList = list;
        HandOverList = new List<BattleModeCard>();
        HandOverBoolList = new List<bool>();
        m_GameManager.Syncronize();

        m_GameManager.m_HandCardUtilStatus = EnumController.HandCardUtilStatus.VOID;

        m_GameManager.ReceiveTurnChange2();
    }

    private int HandOverBoolListTrueNum()
    {
        int count = 0;
        for (int i = 0; i < HandOverBoolList.Count; i++)
        {
            if (HandOverBoolList[i])
            {
                count++;
            }
        }
        return count;
    }
}
