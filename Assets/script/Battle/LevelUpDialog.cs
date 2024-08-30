using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpDialog : MonoBehaviour
{
    [SerializeField] List<LevelUpButtonUtil> buttons = new List<LevelUpButtonUtil>();
    [SerializeField] GameManager m_GameManager;
    [SerializeField] BattleStrix m_BattleStrix;

    private EnumController.LevelUpDialogParamater paramater;

    /// <summary>
    /// レベル置き場にカードのnum
    /// </summary>
    public int num = -1;

    /// <summary>
    /// フロントアタックされたときの場所パラメータ
    /// </summary>
    private int place = -1;

    public void onOKButton()
    {
        if(num == -1)
        {
            return;
        }
        m_GameManager.LevelUp(num);
        m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
        m_BattleStrix.RpcToAll("UpdateIsLevelUpProcess", false);
        OffDialog();
        m_GameManager.ExecuteActionList();
    }

    public void SetBattleModeCard(List<BattleModeCard> myLevelList)
    {
        this.paramater = EnumController.LevelUpDialogParamater.VOID;
        this.place = -1;
        num = -1;
        this.gameObject.SetActive(true);
        m_BattleStrix.RpcToAll("NotEraseDialog", true, m_GameManager.isFirstAttacker);
        for (int i = 0; i < buttons.Count; i++)
        {
            if(i > myLevelList.Count - 1)
            {
                buttons[i].SetBattleModeCard(null, false);
            }
            else
            {
                if(i < 7)
                {
                    buttons[i].SetBattleModeCard(myLevelList[i], true);
                }
                else
                {
                    buttons[i].SetBattleModeCard(myLevelList[i], false);
                }
            }
        }
    }

    /// <summary>
    /// フロントアタックされたとき用のSetBattleModeCard
    /// </summary>
    /// <param name="myLevelList"></param>
    /// <param name="paramater"></param>
    /// <param name="place"></param>
    public void SetBattleModeCard(List<BattleModeCard> myLevelList, EnumController.LevelUpDialogParamater paramater, int place)
    {
        this.paramater = paramater;
        this.place = place;
        num = -1;
        this.gameObject.SetActive(true);
        m_BattleStrix.RpcToAll("NotEraseDialog", true, m_GameManager.isFirstAttacker);
        for (int i = 0; i < buttons.Count; i++)
        {
            if (i > myLevelList.Count - 1)
            {
                buttons[i].SetBattleModeCard(null, false);
            }
            else
            {
                if (i < 7)
                {
                    buttons[i].SetBattleModeCard(myLevelList[i], true);
                }
                else
                {
                    buttons[i].SetBattleModeCard(myLevelList[i], false);
                }
            }
        }
    }

    public void CallOffSelected()
    {
        for(int i = 0; i < 7; i++)
        {
            buttons[i].OffSelected();
        }
    }

    public void OffDialog()
    {
        this.gameObject.SetActive(false);
    }
}
