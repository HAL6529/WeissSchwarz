using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraveYardDetail : MonoBehaviour
{
    [SerializeField] List<GraveYardDetailButtonUtil> BtnList = new List<GraveYardDetailButtonUtil>();
    [SerializeField] List<BattleGraveYardUtil> BattleGraveYardUtilList = new List<BattleGraveYardUtil>();
    [SerializeField] GameObject GraveyardDetailObject;

    public void onCloseButton()
    {
        GraveyardDetailObject.SetActive(false);
    }

    public void UpdateList(List<BattleModeCard> list)
    {
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

    public void OffShowGraveYardButton()
    {
        for (int i = 0; i < BattleGraveYardUtilList.Count; i++)
        {
            BattleGraveYardUtilList[i].OffBtn();
        }
    }
}
