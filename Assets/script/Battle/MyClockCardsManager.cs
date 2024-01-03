using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyClockCardsManager : MonoBehaviour
{
    public List<GameObject> CardList = new List<GameObject>();

    public void updateMyClockCards(List<BattleModeCard> list)
    {
        int num = list.Count;
        for(int i = 0; i < CardList.Count; i++)
        {
            if(i < num)
            {
                CardList[i].SetActive(true);
                CardList[i].GetComponent<BattleClockCardUtil>().setBattleModeCard(list[i]);
            }
            else
            {
                CardList[i].SetActive(false);
                //CardList[i].GetComponent<BattleClockCardUtil>().setBattleModeCard(null);
            }
        }
    }
}
