using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpDialog : MonoBehaviour
{
    [SerializeField] List<LevelUpButtonUtil> buttons = new List<LevelUpButtonUtil>();
    [SerializeField] GameManager m_GameManager;
    [SerializeField] BattleStrix m_BattleStrix;

    public bool isClockAndTwoDrawProcess = false;

    public int num = -1;

    public void onOKButton()
    {
        if(num == -1)
        {
            return;
        }
        m_GameManager.LevelUp(num);
        m_BattleStrix.RpcToAll("UpdateIsLevelUpProcess", false);
        OffDialog();

        if (isClockAndTwoDrawProcess)
        {
            isClockAndTwoDrawProcess = false;
            m_GameManager.ClockAndTwoDraw2();
        }
    }

    public void SetBattleModeCard(List<BattleModeCard> myLevelList)
    {
        num = -1;
        this.gameObject.SetActive(true);
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
