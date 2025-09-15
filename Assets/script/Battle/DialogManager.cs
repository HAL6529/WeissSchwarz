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
    [SerializeField] ConfirmEnemyHandDialog m_ConfirmEnemyHandDialog;
    [SerializeField] BattleModeCardList m_BattleModeCardList;
    [SerializeField] GameManager m_GameManager;
    [SerializeField] GraveYardDetail m_GraveYardDetail;
    [SerializeField] GraveyardSelectDialog m_GraveyardSelectDialog;
    [SerializeField] MainPowerUpDialog m_MainPowerUpDialog;
    [SerializeField] SelectActionDialog m_SelectActionDialog;
    [SerializeField] SelectActEffectDialog m_SelectActEffectDialog;
    [SerializeField] SulvageDialog m_SulvageDialog;
    [SerializeField] WaitDialog m_WaitDialog;

    public void CloseWaitDialog()
    {
        m_WaitDialog.onClose();
    }

    public void GraveyardSelectDialog(BattleModeCard m_BattleModeCard)
    {
        m_GraveyardSelectDialog.SetParamater(m_BattleModeCard);
    }

    public void GraveyardSelectDialog(BattleModeCard m_BattleModeCard, int place)
    {
        m_GraveyardSelectDialog.SetParamater(m_BattleModeCard, place);
    }

    public void SulvageDialog(int handNum, BattleModeCard card, List<BattleModeCard> list, EnumController.Type type, int minSulvageCard, int maxSulvageCard)
    {
        m_SulvageDialog.SetBattleModeCard(handNum, card, list, type, minSulvageCard, maxSulvageCard);
    }

    public void SulvageDialog(BattleModeCard card, List<BattleModeCard> list, EnumController.Type type, int minSulvageCard, int maxSulvageCard)
    {
        m_SulvageDialog.SetBattleModeCard(card, list, type, minSulvageCard, maxSulvageCard);
    }

    public void SelectActionDialog(List<Action> ActionList)
    {
        m_SelectActionDialog.SetDialog(ActionList);
    }

    public void SelectActEffectDialog(List<SelectActEffectDialogContent> m_SelectActEffectDialogContentList)
    {
        m_SelectActEffectDialog.SetContent(m_SelectActEffectDialogContentList);
    }

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

    public void YesOrNoDialog(EnumController.YesOrNoDialogParamater paramater, BattleModeCard m_BattleModeCard, int num, EnumController.Attack status)
    {
        m_YesOrNoDialog.SetParamater(paramater, m_BattleModeCard, num, status);
    }

    public void YesOrNoDialog(EnumController.YesOrNoDialogParamater paramater, BattleModeCard m_BattleModeCard, int ParamaterNum1, int ParamaterNum2)
    {
        m_YesOrNoDialog.SetParamater(paramater, m_BattleModeCard, ParamaterNum1, ParamaterNum2);
    }

    public void YesOrNoDialog(EnumController.YesOrNoDialogParamater paramater, BattleModeCard m_BattleModeCard, int ParamaterNum1, int ParamaterNum2, int ParamaterNum3)
    {
        m_YesOrNoDialog.SetParamater(paramater, m_BattleModeCard, ParamaterNum1, ParamaterNum2, ParamaterNum3);
    }

    public void OKDialog(EnumController.OKDialogParamater paramater)
    {
        m_OKDialog.SetParamater(paramater);
    }

    public void OKDialog_SwitchActiveOKButton()
    {
        m_OKDialog.SwitchActiveOKButton();
    }

    public void OKDialog(EnumController.OKDialogParamater paramater, BattleModeCard card, int ParamaterNum1)
    {
        m_OKDialog.SetParamater(paramater, card, ParamaterNum1);
    }

    public void OKDialog(EnumController.OKDialogParamater paramater, int ParamaterNum1, int ParamaterNum2)
    {
        m_OKDialog.SetParamater(paramater, ParamaterNum1, ParamaterNum2);
    }

    public void OKDialog(EnumController.OKDialogParamater paramater, int ParamaterNum1, int ParamaterNum2 ,int ParamaterNum3)
    {
        m_OKDialog.SetParamater(paramater, ParamaterNum1, ParamaterNum2, ParamaterNum3);
    }

    public void OKDialog_SetBattleModeCard(BattleModeCard card)
    {
        m_OKDialog.SetBattleModeCard(card);
    }

    public void OKDialog_SetParamaterNum3(int num)
    {
        m_OKDialog.SetParamaterNum3(num);
    }

    public void MoveDialog(int place,  BattleModeCard card)
    {
        m_MoveDialog.Open(place, card);
    }

    public void MainDialog(BattleModeCard card, int HandNum)
    {
        m_MainDialog.SetBattleMordCard(card, HandNum);
    }

    public void LevelUpDialog(List<BattleModeCard> myClockList)
    {
        m_LevelUpDialog.SetBattleModeCard(myClockList);
    }

    public void PhaseDialog()
    {
        if (m_GameManager.isLevelUpProcess || m_GameManager.isAttackProcess || m_GameManager.isEncoreDialogProcess || m_GameManager.isDamageAnimation)
        {
            return;
        }
        m_PhaseDialog.Open();
    }

    public void EncoreDialog(List<BattleModeCard> list)
    {
        m_EncoreDialog.SetBattleModeCard(list);
        return;
    }

    public void EncoreDialogForEndPhase(List<BattleModeCard> list)
    {
        m_EncoreDialog.SetBattleModeCardForEndPhase(list);
        return;
    }

    public void HandOverDialog(EnumController.HandOverDialogParamater paramater)
    {
        m_HandOverDialog.SetParamater(paramater);
    }

    public void SearchDialog(EnumController.SearchDialogParamater paramater, int handNum)
    {
        m_SearchDialog.SetBattleModeCard(paramater, handNum);
    }

    public void SearchDialog(EnumController.SearchDialogParamater paramater)
    {
        m_SearchDialog.SetBattleModeCard(paramater);
    }

    public void CharacterSelectDialog(BattleModeCard card, bool isMine, int place)
    {
        m_CharacterSelectDialog.Open(card, isMine, place);
    }

    public void CharacterSelectDialog(int damage, int place, EnumController.YesOrNoDialogParamater paramater)
    {
        m_CharacterSelectDialog.Open(damage, place, paramater);
    }

    public void ConfirmEncoreKindsDialog(BattleModeCard m_BattleModeCard, int paramaterNum1, bool canHandEncore, bool canTwoStcockEncore, bool canThreeStocEncore, bool canClockEncore)
    {
        m_ConfirmEncoreKindsDialog.Active(m_BattleModeCard, paramaterNum1, canHandEncore, canTwoStcockEncore, canThreeStocEncore, canClockEncore);
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

    public void ConfirmEnemyHandDialog(List<BattleModeCardTemp> list)
    {
        List<BattleModeCard> enemyHandList = new List<BattleModeCard>();
        for (int i = 0; i < list.Count; i++)
        {
            BattleModeCard b = m_BattleModeCardList.ConvertCardNoToBattleModeCard(list[i].cardNo);
            enemyHandList.Add(b);
        }
        m_ConfirmEnemyHandDialog.SetBattleModeCardList(enemyHandList);
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
        // m_NotEraseDialog.OffDialog();
        m_ConfirmSearchOrSulvageCardDialog.OffDialog();
        m_GraveYardDetail.onCloseButton();
        m_GraveyardSelectDialog.OffDialog();
        m_MainPowerUpDialog.OffDialog();
        m_SelectActionDialog.OffDialog();
        m_SelectActEffectDialog.OffDialog();
        m_SulvageDialog.onCloseButton();
        m_WaitDialog.onClose();
        m_ConfirmEnemyHandDialog.OffDialog();
    }

    public void CloseAllDialog2()
    {
        // m_YesOrNoDialog.OffDialog();
        // m_OKDialog.OffDialog();
        m_MainDialog.OffMainDialog();
        m_MoveDialog.OffMainDialog();
        // m_LevelUpDialog.OffDialog();
        m_PhaseDialog.OffDialog();
        // m_EncoreDialog.OffDialog();
        // m_HandOverDialog.OffDialog();
        // m_SearchDialog.OffDialog();
        // m_CharacterSelectDialog.OffDialog();
        // m_ConfirmEncoreKindsDialog.OffDialog();
        // m_NotEraseDialog.OffDialog();
        // m_ConfirmSearchOrSulvageCardDialog.OffDialog();
        // m_GraveYardDetail.onCloseButton();
        // m_GraveyardSelectDialog.OffDialog();
        // m_MainPowerUpDialog.OffDialog();
        // m_SelectActionDialog.OffDialog();
        // m_SelectActEffectDialog.OffDialog();
        // m_SulvageDialog.onCloseButton();
        // m_WaitDialog.onClose();
        // m_ConfirmEnemyHandDialog.OffDialog();
    }
}
