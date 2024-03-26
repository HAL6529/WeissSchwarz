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

    /// <summary>
    /// カムバックアイコンがトリガーしたとき用
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
        m_BattleStrix.RpcToAll("ExecuteAction_ComeBackActionAfterConfirmDialog", m_ExecuteActionTemp, m_GameManager.isFirstAttacker);
    }
}
