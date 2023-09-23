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

    public void YesOrNoDialog(EnumController.YesOrNoDialogParamater paramater)
    {
        m_YesOrNoDialog.SetParamater(paramater);
    }

    public void YesOrNoDialog(EnumController.YesOrNoDialogParamater paramater, BattleModeCard m_BattleModeCard)
    {
        m_YesOrNoDialog.SetParamater(paramater, m_BattleModeCard);
    }

    public void OKDialog(EnumController.OKDialogParamater paramater)
    {
        m_OKDialog.SetParamater(paramater);
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

    public void SetIsClockAndTwoDrawProcessOfLevelUpDialog()
    {
        m_LevelUpDialog.isClockAndTwoDrawProcess = true;
    }

    public void PhaseDialog()
    {
        m_PhaseDialog.Open();
    }

    public void EncoreDialog(List<BattleModeCard> list)
    {
        m_EncoreDialog.SetBattleModeCard(list);
        return;
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
    }
}
