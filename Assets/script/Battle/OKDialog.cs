using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EnumController;

public class OKDialog : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] BattleStrix m_BattleStrix;
    [SerializeField] EventAnimationManager m_EventAnimationManager;
    [SerializeField] GameManager m_GameManager;
    [SerializeField] MyHandCardsManager m_MyHandCardsManager;
    [SerializeField] MyMainCardsManager m_MyMainCardsManager;
    [SerializeField] DialogManager m_DialogManager;
    [SerializeField] GameObject OKBtn;

    private StringValues stringValues = new StringValues();
    private BattleModeCard m_BattleModeCard = null;

    private EnumController.OKDialogParamater m_DialogParamater;
    private int ParamaterNum1;
    private int ParamaterNum2;
    private int ParamaterNum3;

    private EnumController.EncoreDialog EncorePhaseDialogParamater = EnumController.EncoreDialog.VOID;

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
        EncorePhaseDialogParamater = EnumController.EncoreDialog.VOID;
        m_BattleModeCard = null;
        this.gameObject.SetActive(true);
        m_DialogParamater = paramater;
        InactiveOKButton();
        SetText();
        m_BattleStrix.RpcToAll("NotEraseDialog", true, m_GameManager.isFirstAttacker);
    }

    public void SetParamater(EnumController.OKDialogParamater paramater, BattleModeCard card, int num1, EnumController.EncoreDialog p)
    {
        ParamaterNum1 = num1;
        ParamaterNum2 = -1;
        ParamaterNum3 = -1;
        EncorePhaseDialogParamater = p;
        m_BattleModeCard = card;
        this.gameObject.SetActive(true);
        m_DialogParamater = paramater;
        InactiveOKButton();
        SetText();
        m_BattleStrix.RpcToAll("NotEraseDialog", true, m_GameManager.isFirstAttacker);
    }

    public void SetParamater(EnumController.OKDialogParamater paramater, int num1, int num2)
    {
        ParamaterNum1 = num1;
        ParamaterNum2 = num2;
        ParamaterNum3 = -1;
        EncorePhaseDialogParamater = EnumController.EncoreDialog.VOID;
        m_BattleModeCard = null;
        this.gameObject.SetActive(true);
        m_DialogParamater = paramater;
        InactiveOKButton();
        SetText();
        m_BattleStrix.RpcToAll("NotEraseDialog", true, m_GameManager.isFirstAttacker);
    }

    public void SetParamater(EnumController.OKDialogParamater paramater, int num1, int num2, int num3)
    {
        ParamaterNum1 = num1;
        ParamaterNum2 = num2;
        ParamaterNum3 = num3;
        EncorePhaseDialogParamater = EnumController.EncoreDialog.VOID;
        m_BattleModeCard = null;
        this.gameObject.SetActive(true);
        m_DialogParamater = paramater;
        InactiveOKButton();
        SetText();
        m_BattleStrix.RpcToAll("NotEraseDialog", true, m_GameManager.isFirstAttacker);
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
            case EnumController.OKDialogParamater.HAND_ENCORE_SELECT_DISCARD_CONFIRM:
                str = stringValues.OKDialog_HAND_ENCORE_SELECT_DISCARD_CONFIRM;
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

    private void InactiveOKButton()
    {
        switch (m_DialogParamater)
        {
            case EnumController.OKDialogParamater.HAND_ENCORE_SELECT_DISCARD_CONFIRM:
                SwitchActiveOKButton();
                break;
            default:
                break;
        }
    }

    public void SwitchActiveOKButton()
    {
        Debug.Log("SwitchActiveOKButton");
        if (m_GameManager.DisCardForHandEncore == null)
        {
            OKBtn.gameObject.SetActive(false);
            return;
        }
        OKBtn.gameObject.SetActive(true);
    }

    public void onClick()
    {
        switch (m_DialogParamater)
        {
            // ParamaterNum1: damage, ParamaterNum2: Place
            case EnumController.OKDialogParamater.Counter_Confirm_Use_Card:
                int place = 0;
                int pumpPoint = 0;
                int cost = 0;
                m_GameManager.m_HandCardUtilStatus = EnumController.HandCardUtilStatus.VOID;
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
                            place = -1;
                            break;
                    }

                    // --ここから大活躍用--
                    if (m_MyMainCardsManager.GetIsGreatPerformance(1))
                    {
                        place = 1;
                    }
                    // --ここまで大活躍用--

                    switch (m_BattleModeCard.cardNo)
                    {
                        case EnumController.CardNo.LB_W02_07T:
                            pumpPoint = 2000;
                            cost = 1;
                            break;
                        case EnumController.CardNo.AT_WX02_A05:
                            pumpPoint = 2500;
                            cost = 1;
                            break;
                        case EnumController.CardNo.DC_W01_17T:
                            pumpPoint = 3000;
                            cost = 1;
                            break;
                        case EnumController.CardNo.LB_W02_04T:
                            /*for (int i = 0; i < 1; i++)
                            {
                                m_GameManager.GraveYardList.Add(m_GameManager.myStockList[m_GameManager.myStockList.Count - 1]);
                                m_GameManager.myStockList.RemoveAt(m_GameManager.myStockList.Count - 1);
                            }
                            m_GameManager.myHandList.Remove(m_BattleModeCard);
                            m_GameManager.Syncronize();*/
                            m_EventAnimationManager.AnimationStart(m_BattleModeCard, place);
                            m_BattleStrix.EventAnimation(m_BattleModeCard, m_GameManager.isFirstAttacker);

                            Action action = new Action(m_GameManager, EnumController.Action.DamageForFrontAttack);
                            action.SetParamaterMyMainCardsManager(m_MyMainCardsManager);
                            action.SetParamaterNum(ParamaterNum1);
                            action.SetParamaterNum2(ParamaterNum2);

                            m_GameManager.ActionList.Add(action);

                            m_GameManager.m_DialogManager.CharacterSelectDialog(m_BattleModeCard, m_GameManager.myFieldList, -1);

                            m_MyHandCardsManager.ActiveAllMyHand();
                            m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
                            this.gameObject.SetActive(false);
                            return;
                        default:
                            break;
                    }
                    for(int i = 0; i < cost; i++)
                    {
                        BattleModeCard t = m_GameManager.myStockList[m_GameManager.myStockList.Count - 1];
                        m_GameManager.GraveYardList.Add(t);
                        m_GameManager.myStockList.Remove(t);
                    }
                    m_MyMainCardsManager.AddPowerUpUntilTurnEnd(place, pumpPoint);
                    m_GameManager.myHandList.Remove(m_BattleModeCard);
                    m_GameManager.GraveYardList.Add(m_BattleModeCard);
                    m_GameManager.Syncronize();
                }
                m_MyHandCardsManager.ActiveAllMyHand();
                // --ここから大活躍用--
                if (m_MyMainCardsManager.GetIsGreatPerformance(1))
                {
                    m_GameManager.DamageForFrontAttack(ParamaterNum1, ParamaterNum2, EnumController.Damage.FRONT_ATTACK, m_GameManager.SendShotList);
                    break;
                }
                // --ここまで大活躍用--
                m_GameManager.DamageForFrontAttack(ParamaterNum1, ParamaterNum2, EnumController.Damage.FRONT_ATTACK, m_GameManager.SendShotList);
                break;
            // ParamaterNum1: damage, ParamaterNum2: Place
            case EnumController.OKDialogParamater.Counter_Not_Exist:
                m_MyHandCardsManager.ActiveAllMyHand();
                m_GameManager.DamageForFrontAttack(ParamaterNum1, ParamaterNum2, EnumController.Damage.FRONT_ATTACK, m_GameManager.SendShotList);
                break;
            case EnumController.OKDialogParamater.HAND_ENCORE_SELECT_DISCARD_CONFIRM:
                if (m_GameManager.DisCardForHandEncore != null)
                {
                    m_GameManager.myHandList.Remove(m_GameManager.DisCardForHandEncore);
                    m_GameManager.GraveYardList.Add(m_GameManager.DisCardForHandEncore);
                    m_GameManager.DisCardForHandEncore = null;

                    m_GameManager.GraveYardList.Remove(m_BattleModeCard);
                    m_GameManager.myFieldList[ParamaterNum1] = m_BattleModeCard;
                    m_MyMainCardsManager.CallOnStand(ParamaterNum1);
                    m_MyMainCardsManager.setBattleModeCard(ParamaterNum1, m_BattleModeCard, EnumController.State.REST);
                    m_GameManager.Syncronize();
                }
                m_MyHandCardsManager.ActiveAllMyHand();
                m_GameManager.m_HandCardUtilStatus = EnumController.HandCardUtilStatus.VOID;
                m_DialogManager.EncoreDialog(m_GameManager.myFieldList, EncorePhaseDialogParamater);
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
        m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
        this.gameObject.SetActive(false);
    }

    public void OffDialog()
    {
        this.gameObject.SetActive(false);
    }
}
