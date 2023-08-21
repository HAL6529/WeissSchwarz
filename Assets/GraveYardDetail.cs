using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraveYardDetail : MonoBehaviour
{
    [SerializeField] List<GraveYardDetailButtonUtil> BtnList = new List<GraveYardDetailButtonUtil>();

    public void onCloseButton()
    {
        this.gameObject.SetActive(false);
    }

    public void UpdateList(List<BattleModeCard> list)
    {
        this.gameObject.SetActive(true);
        for (int i = 0; i < BtnList.Count; i++)
        {
            if(i < list.Count)
            {
                BtnList[i].setBattleModeCard(list[i]);
            }
            else
            {
                BtnList[i].setBattleModeCard(null);
            }

        }
    }
}
