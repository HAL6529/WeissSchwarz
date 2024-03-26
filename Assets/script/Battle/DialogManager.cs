using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [SerializeField] MainDialog m_MainDialog;
    [SerializeField] MoveDialog m_MoveDialog;
    [SerializeField] OKDialog m_OKDialog;
    [SerializeField] YesOrNoDialog m_YesOrNoDialog;
    [SerializeField] LevelUpDialog m_LevelUpDialog;
    [SerializeField] PhaseDialog m_PhaseDialog;
    [SerializeField] EncoreDialog m_EncoreDialog;
    [SerializeField] HandOverDialog m_HandOverDialog;
    [SerializeField] SearchDialog m_SearchDialog;
    [SerializeField] CharacterSelectDialog m_CharacterSelectDialog;
    [SerializeField] NotEraseDialog m_NotEraseDialog;
    [SerializeField] ConfirmEncoreKindsDialog m_ConfirmEncoreKindsDialog;
    [SerializeField] ConfirmSearchOrSulvageCardDialog m_ConfirmSearchOrSulvageCardDialog;
    [SerializeField] BattleModeCardList m_BattleModeCardList;
    [SerializeField] GameManager m_GameManager;

    public void YesOrNoDialog(EnumController.YesOrNoDialogParamater paramater)
    {
        m_YesOrNoDialog.SetParamater(paramater);
    }

    public void YesOrNoDialog(EnumController.YesOrNoDialogParamater paramater, BattleModeCard m_BattleModeCard)
    {
        m_YesOrNoDialog.SetParamater(paramater, m_BattleModeCard);
    }

    public void YesOrNoDialog(EnumController.YesOrNoDialogParamater paramater, BattleModeCard m_BattleModeCard, int num)
    {
        m_YesOrNoDialog.SetParamater(paramater, m_BattleModeCard, num);
    }

    public void YesOrNoDialog(EnumController.YesOrNoDialogParamater paramater, BattleModeCard m_BattleModeCard, int ParamaterNum1, int ParamaterNum2)
    {
        m_YesOrNoDialog.SetParamater(paramater, m_BattleModeCard, ParamaterNum1, ParamaterNum2);
    }

    public void YesOrNoDialog(EnumController.YesOrNoDialogParamater paramater, BattleModeCard m_BattleModeCard, int ParamaterNum1, int ParamaterNum2, int ParamaterNum3)
    {
        m_YesOrNoDialog.SetParamater(paramater, m_BattleModeCard, ParamaterNum1, ParamaterNum2, ParamaterNum3);
    }

    /// <summary>
    /// アンコールダイアログ用
    /// </summary>
    /// <param name="paramater"></param>
    /// <param name="m_BattleModeCard"></param>
    /// <param name="num"></param>
    /// <param name="isReceivedFromRPC"></param>
    public void YesOrNoDialog(EnumController.YesOrNoDialogParamater paramater, BattleModeCard m_BattleModeCard, int num, bool isReceivedFromRPC)
    {
        m_YesOrNoDialog.SetParamater(paramater, m_BattleModeCard, num, isReceivedFromRPC);
    }

    public void OKDialog(EnumController.OKDialogParamater paramater)
    {
        m_OKDialog.SetParamater(paramater);
    }

    public void OKDialog_SwitchActiveOKButton()
    {
        m_OKDialog.SwitchActiveOKButton();
    }

    public void OKDialog(EnumController.OKDialogParamater paramater, BattleModeCard card, int ParamaterNum1, bool isReceivedFromRPC)
    {
        m_OKDialog.SetParamater(paramater, card, ParamaterNum1, isReceivedFromRPC);
    }

    public void OKDialog(EnumController.OKDialogParamater paramater, int ParamaterNum1, int ParamaterNum2)
    {
        m_OKDialog.SetParamater(paramater, ParamaterNum1, ParamaterNum2);
    }

    public void OKDialog(EnumController.OKDialogParamater paramater, int ParamaterNum1, int ParamaterNum2 ,int ParamaterNum3)
    {
        m_OKDialog.SetParamater(paramater, ParamaterNum1, ParamaterNum2, ParamaterNum3);
    }

    public void OKDialog(BattleModeCard card)
    {
        m_OKDialog.SetBattleModeCard(card);
    }

    public void MoveDialog(int place,  BattleModeCard card)
    {
        m_MoveDialog.Open(place, card);
    }

    public void MainDialog(BattleModeCard card)
    {
        m_MainDialog.SetBattleMordCard(card);
    }

    public void LevelUpDialog(List<BattleModeCard> myClockList)
    {
        m_LevelUpDialog.SetBattleModeCard(myClockList);
    }

    public void LevelUpDialog(List<BattleModeCard> myClockList, EnumController.LevelUpDialogParamater paramater, int place)
    {
        m_LevelUpDialog.SetBattleModeCard(myClockList, paramater, place);
    }

    public void SetIsClockAndTwoDrawProcessOfLevelUpDialog()
    {
        m_LevelUpDialog.isClockAndTwoDrawProcess = true;
    }

    public void PhaseDialog()
    {
        if (m_GameManager.isLevelUpProcess || m_GameManager.isAttackProcess)
        {
            return;
        }
        m_PhaseDialog.Open();
    }

    public void EncoreDialog(List<BattleModeCard> list, bool isReceivedFromRPC)
    {
        m_EncoreDialog.SetBattleModeCard(list, isReceivedFromRPC);
        return;
    }

    public void HandOverDialog(EnumController.HandOverDialogParamater paramater)
    {
        m_HandOverDialog.SetParamater(paramater);
    }

    public void SearchDialog(List<BattleModeCard> list, EnumController.SearchDialogParamater paramater, BattleModeCard card)
    {
        m_SearchDialog.SetBattleModeCard(list, paramater, card);
    }

    public void CharacterSelectDialog(List<BattleModeCard> list, int place, EnumController.Attack status)
    {
        m_CharacterSelectDialog.Open(list, place, status);
    }

    public void ConfirmEncoreKindsDialog(BattleModeCard m_BattleModeCard, int paramaterNum1, bool isReceivedFromRPC, bool canHandEncore, bool canTwoStcockEncore, bool canThreeStocEncore, bool canClockEncore)
    {
        m_ConfirmEncoreKindsDialog.Active(m_BattleModeCard, paramaterNum1, isReceivedFromRPC, canHandEncore, canTwoStcockEncore, canThreeStocEncore, canClockEncore);
    }

    public void NotEraseDialog_Open()
    {
        m_NotEraseDialog.Open();
    }

    public void NotEraseDialog_Close()
    {
        m_NotEraseDialog.OffDialog();
    }

    /// <summary>
    /// サーチや回収を行った際に出力されるダイアログ
    /// BattleStrixから呼ばれるだけ
    /// </summary>
    /// <param name="list"></param>
    /// <param name="paramater"></param>
    public void ConfirmSearchOrSulvageCardDialog(List<BattleModeCardTemp> list, EnumController.ConfirmSearchOrSulvageCardDialog paramater, ExecuteActionTemp m_ExecuteActionTemp)
    {
        List<BattleModeCard> tempList = new List<BattleModeCard>();
        for (int i = 0; i < list.Count; i++)
        {
            BattleModeCard b = m_BattleModeCardList.ConvertCardNoToBattleModeCard(list[i].cardNo);
            tempList.Add(b);
        }
        m_ConfirmSearchOrSulvageCardDialog.SetBattleModeCard(tempList, paramater, m_ExecuteActionTemp);
    }

    public void CloseAllDialog()
    {
        m_YesOrNoDialog.OffDialog();
        m_OKDialog.OffDialog();
        m_MainDialog.OffMainDialog();
        m_MoveDialog.OffMainDialog();
        m_LevelUpDialog.OffDialog();
        m_PhaseDialog.OffDialog();
        m_EncoreDialog.OffDialog();
        m_HandOverDialog.OffDialog();
        m_SearchDialog.OffDialog();
        m_CharacterSelectDialog.OffDialog();
        m_ConfirmEncoreKindsDialog.OffDialog();
        m_NotEraseDialog.OffDialog();
        m_ConfirmSearchOrSulvageCardDialog.OffDialog();
    }
}
