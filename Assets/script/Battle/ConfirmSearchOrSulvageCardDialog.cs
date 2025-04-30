using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmSearchOrSulvageCardDialog : MonoBehaviour
{
    [SerializeField] List<ConfirmSearchOrSulvageCardDialogsBtnUtil> ConfirmSearchOrSulvageCardDialogsBtnUtilList = new List<ConfirmSearchOrSulvageCardDialogsBtnUtil>();
    [SerializeField] BattleStrix m_BattleStrix;
    [SerializeField] GameManager m_GameManager;
    [SerializeField] Text text;

    private StringValues stringValues = new StringValues();

    private ExecuteActionTemp m_ExecuteActionTemp = null;

    private EnumController.ConfirmSearchOrSulvageCardDialog paramater = EnumController.ConfirmSearchOrSulvageCardDialog.VOID;

    /// <summary>
    /// サーチカードやサルベージカードの確認用
    /// </summary>
    /// <param name="list"></param>
    /// <param name="paramater"></param>
    public void SetBattleModeCard(List<BattleModeCard> list, EnumController.ConfirmSearchOrSulvageCardDialog paramater, ExecuteActionTemp m_ExecuteActionTemp)
    {
        if (list.Count > ConfirmSearchOrSulvageCardDialogsBtnUtilList.Count)
        {
            return;
        }
        this.m_ExecuteActionTemp = m_ExecuteActionTemp;
        this.paramater = paramater;
        switch (paramater)
        {
            case EnumController.ConfirmSearchOrSulvageCardDialog.SEARCH:
                text.text = stringValues.ConfirmSearchOrSulvageCardDialog_Search;
                break;
            case EnumController.ConfirmSearchOrSulvageCardDialog.SULVAGE:
                text.text = stringValues.ConfirmSearchOrSulvageCardDialog_Sulvage;
                break;
            case EnumController.ConfirmSearchOrSulvageCardDialog.COMEBACK:
                text.text = stringValues.ConfirmSearchOrSulvageCardDialog_Sulvage;
                break;
            case EnumController.ConfirmSearchOrSulvageCardDialog.CLOCK_SULVAGE:
                text.text = stringValues.ConfirmSearchOrSulvageCardDialog_Clock_Sulvage;
                break;
            case EnumController.ConfirmSearchOrSulvageCardDialog.DC_W01_12T:
                text.text = stringValues.ConfirmSearchOrSulvageCardDialog_Sulvage;
                break;
            default:
                text.text = "無効メッセージ";
                break;
        }

        for(int i = 0; i < ConfirmSearchOrSulvageCardDialogsBtnUtilList.Count; i++)
        {
            if(i < list.Count)
            {
                ConfirmSearchOrSulvageCardDialogsBtnUtilList[i].SetBattleModeCard(list[i]);
            }
            else
            {
                ConfirmSearchOrSulvageCardDialogsBtnUtilList[i].SetBattleModeCard(null);
            }
        }
        this.gameObject.SetActive(true);
    }

    public void OffDialog()
    {
        this.gameObject.SetActive(false);
    }

    public void onOKButton()
    {
        this.gameObject.SetActive(false);
        m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
        switch (paramater)
        {
            case EnumController.ConfirmSearchOrSulvageCardDialog.SEARCH:
                m_BattleStrix.RpcToAll("ExecuteAction_SearchAfterConfirmDialog", m_ExecuteActionTemp, m_GameManager.isFirstAttacker);
                return;
            case EnumController.ConfirmSearchOrSulvageCardDialog.SULVAGE:
                return;
            case EnumController.ConfirmSearchOrSulvageCardDialog.COMEBACK:
                m_BattleStrix.RpcToAll("ExecuteAction_ComeBackActionAfterConfirmDialog", m_ExecuteActionTemp, m_GameManager.isFirstAttacker);
                return;
            case EnumController.ConfirmSearchOrSulvageCardDialog.CLOCK_SULVAGE:
                m_BattleStrix.RpcToAll("ExecuteAction_SearchAfterConfirmDialog_ClockSulvage", m_ExecuteActionTemp, m_GameManager.isFirstAttacker);
                return;
            case EnumController.ConfirmSearchOrSulvageCardDialog.DC_W01_12T:
                m_BattleStrix.RpcToAll("ExecuteActionList", m_GameManager.isTurnPlayer);
                return;
            default:
                return;
        }
    }
}
