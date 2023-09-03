using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpDialog : MonoBehaviour
{
    [SerializeField] List<LevelUpButtonUtil> buttons = new List<LevelUpButtonUtil>();

    public int num = -1;

    public void onOKButton()
    {

    }

    public void SetBattleModeCard(List<BattleModeCard> myLevelList)
    {
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

    public void OffDialog()
    {
        this.gameObject.SetActive(false);
    }
}
