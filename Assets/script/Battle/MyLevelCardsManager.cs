using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyLevelCardsManager : MonoBehaviour
{
    public List<LevelCardUtil> CardList = new List<LevelCardUtil>();

    public void updateMyLevelCards(List<BattleModeCard> list)
    {
        for(int i = 0; i < CardList.Count; i++)
        {
            if(i < list.Count)
            {
                CardList[i].SetBattleModeCard(list[i]);
            }
            else
            {
                CardList[i].SetBattleModeCard(null);
            }
        }
    }
}
