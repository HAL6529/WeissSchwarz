using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmEncoreKindsDialog : MonoBehaviour
{
    [SerializeField] DialogManager m_DialogManager;
    [SerializeField] GameManager m_GameManager;
    [SerializeField] MyMainCardsManager m_MyMainCardsManager;
    [SerializeField] MyHandCardsManager m_MyHandCardsManager;

    [SerializeField] Button HandEncoreBtn;
    [SerializeField] Button TwoStockEncoreBtn;
    [SerializeField] Button ThreeStockEncoreBtn;
    [SerializeField] Button ClockEncoreBtn;
    [SerializeField] Button NotEncoreBtn;

    private BattleModeCard m_BattleModeCard = null;

    private int ParamaterNum1 = -1;

    private bool isReceivedFromRPC = false;

    public void Active(BattleModeCard m_BattleModeCard, int paramaterNum1, bool isReceivedFromRPC, bool canHandEncore, bool canTwoStcockEncore, bool canThreeStocEncore, bool canClockEncore)
    {
        this.m_BattleModeCard = m_BattleModeCard;
        this.isReceivedFromRPC = isReceivedFromRPC;
        ParamaterNum1 = paramaterNum1;

        HandEncoreBtn.interactable = canHandEncore;
        TwoStockEncoreBtn.interactable = canTwoStcockEncore;
        ThreeStockEncoreBtn.interactable = canThreeStocEncore;
        ClockEncoreBtn.interactable = canClockEncore;

        this.gameObject.SetActive(true);

    }

    public void onHandEncoreBtn()
    {
        m_MyHandCardsManager.CallNotShowPlayButton();
        this.gameObject.SetActive(false);
        m_GameManager.m_HandCardUtilStatus = EnumController.HandCardUtilStatus.HAND_ENCORE;
        m_DialogManager.OKDialog(EnumController.OKDialogParamater.HAND_ENCORE_SELECT_DISCARD_CONFIRM, m_BattleModeCard, ParamaterNum1, isReceivedFromRPC);
    }

    public void onTwoStockEncoreBtn()
    {

    }

    public void onThreeStockEncoreBtn()
    {
        for (int i = 0; i < 3; i++)
        {
            m_GameManager.GraveYardList.Add(m_GameManager.myStockList[m_GameManager.myStockList.Count - 1]);
            m_GameManager.myStockList.RemoveAt(m_GameManager.myStockList.Count - 1);
        }
        m_GameManager.GraveYardList.Remove(m_BattleModeCard);
        m_GameManager.myFieldList[ParamaterNum1] = m_BattleModeCard;
        m_MyMainCardsManager.CallOnStand(ParamaterNum1);

        m_MyMainCardsManager.setBattleModeCard(ParamaterNum1, m_BattleModeCard, EnumController.State.REST);

        m_GameManager.Syncronize();

        Close();
    }

    public void onClockEncoreBtn()
    {

    }

    public void onNotEncoreBtn()
    {
        Close();
    }

    private void Close()
    {
        m_MyHandCardsManager.CallNotShowPlayButton();
        this.gameObject.SetActive(false);
        m_DialogManager.EncoreDialog(m_GameManager.myFieldList, isReceivedFromRPC);
    }

    public void OffDialog()
    {
        this.gameObject.SetActive(false);
    }
}
