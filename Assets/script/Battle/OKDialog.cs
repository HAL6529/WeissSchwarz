using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EnumController;

public class OKDialog : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] BattleStrix m_BattleStrix;
    [SerializeField] GameManager m_GameManager;
    [SerializeField] MyHandCardsManager m_MyHandCardsManager;
    [SerializeField] MyMainCardsManager m_MyMainCardsManager;

    private StringValues stringValues = new StringValues();
    private BattleModeCard m_BattleModeCard = null;

    private EnumController.OKDialogParamater m_DialogParamater;
    private int ParamaterNum1;
    private int ParamaterNum2;
    private int ParamaterNum3;

    public OKDialog()
    {
        m_DialogParamater = EnumController.OKDialogParamater.VOID;
    }

    public void SetBattleModeCard(BattleModeCard card)
    {
        m_BattleModeCard = card;
    }

    public void SetParamater(EnumController.OKDialogParamater paramater)
    {
        ParamaterNum1 = -1;
        ParamaterNum2 = -1;
        ParamaterNum3 = -1;
        m_BattleModeCard = null;
        this.gameObject.SetActive(true);
        m_DialogParamater = paramater;
        SetText();
    }

    public void SetParamater(EnumController.OKDialogParamater paramater, int num1, int num2)
    {
        ParamaterNum1 = num1;
        ParamaterNum2 = num2;
        ParamaterNum3 = -1;
        m_BattleModeCard = null;
        this.gameObject.SetActive(true);
        m_DialogParamater = paramater;
        SetText();
    }

    public void SetParamater(EnumController.OKDialogParamater paramater, int num1, int num2, int num3)
    {
        ParamaterNum1 = num1;
        ParamaterNum2 = num2;
        ParamaterNum3 = num3;
        m_BattleModeCard = null;
        this.gameObject.SetActive(true);
        m_DialogParamater = paramater;
        SetText();
    }

    private void SetText()
    {
        string str = "";
        switch (m_DialogParamater)
        {
            case EnumController.OKDialogParamater.Counter_Confirm_Use_Card:
                str = stringValues.OKDialog_Counter_Confirm_Use_Card;
                break;
            case EnumController.OKDialogParamater.Counter_Not_Exist:
                str = stringValues.OKDialog_Counter;
                break;
            case EnumController.OKDialogParamater.Marigan:
                str = stringValues.OKDialog_Marigan;
                break;
            case EnumController.OKDialogParamater.CLOCK:
                str = stringValues.OKDialog_Clock;
                break;
            default:
                str = "無効メッセージ";
                break;

        }
        text.text = str;
    }

    public void onClick()
    {
        switch (m_DialogParamater)
        {
            // ParamaterNum1: damage, ParamaterNum2: Place
            case EnumController.OKDialogParamater.Counter_Confirm_Use_Card:
                int place = 0;
                int pumpPoint = 0;
                m_GameManager.CounterSelectMode = false;
                if (m_BattleModeCard != null)
                {
                    switch (ParamaterNum2)
                    {
                        case 0:
                            place = 2;
                            break;
                        case 1:
                            place = 1;
                            break;
                        case 2:
                            place = 0;
                            break;
                        default : 
                            place = 0;
                            break;
                    }

                    switch (m_BattleModeCard.cardNo)
                    {
                        case EnumController.CardNo.AT_WX02_A05:
                            pumpPoint = 2500;
                            break;
                        default:
                            break;
                    }
                    m_MyMainCardsManager.AddPowerUpUntilTurnEnd(place, pumpPoint);
                    m_GameManager.myHandList.Remove(m_BattleModeCard);
                    m_GameManager.GraveYardList.Add(m_BattleModeCard);
                    m_GameManager.Syncronize();

                    m_MyHandCardsManager.ActiveAllMyHand();
                }
                DamageAndPowerCheck(ParamaterNum1, ParamaterNum2);
                break;
            // ParamaterNum1: damage, ParamaterNum2: Place
            case EnumController.OKDialogParamater.Counter_Not_Exist:
                m_MyHandCardsManager.ActiveAllMyHand();
                DamageAndPowerCheck(ParamaterNum1, ParamaterNum2);
                break;
            case EnumController.OKDialogParamater.Marigan:
                m_GameManager.MariganEnd();
                break;
            case EnumController.OKDialogParamater.CLOCK:
                m_GameManager.ClockAndTwoDraw(m_BattleModeCard);
                break;
            default:
                break;

        }
        this.gameObject.SetActive(false);
    }

    public void OffDialog()
    {
        this.gameObject.SetActive(false);
    }

    private void DamageAndPowerCheck(int param1, int param2)
    {
        m_GameManager.Damage(param1);
        int i = -1;
        switch (param2)
        {
            case 0:
                i = 2;
                break;
            case 1:
                i = 1;
                break;
            case 2:
                i = 0;
                break;
            default:
                i = 0;
                break;
        }
        m_GameManager.PowerCheck(i);
    }
}
