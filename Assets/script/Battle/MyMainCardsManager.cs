using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyMainCardsManager : MonoBehaviour
{
    private List<BattleModeCard> myFieldList = new List<BattleModeCard>();
    public List<BattleMyMainCardUtil> CardList = new List<BattleMyMainCardUtil>();

    public void CallStand()
    {
        for (int i = 0; i < CardList.Count; i++)
        {
            CardList[i].Stand();
        }
    }

    public void updateMyFieldCards(List<BattleModeCard> list)
    {
        myFieldList = list;
        for(int i = 0; i < CardList.Count; i++)
        {
            CardList[i].setBattleModeCard(myFieldList[i]);
        }       
    }

    public void CallNotShowMoveButton()
    {
        for (int i = 0; i < CardList.Count; i++)
        {
            CardList[i].GetComponent<BattleMyMainCardUtil>().NotShowMoveButton();
        }
    }

    public void CallNotShowDirectAttackButton()
    {
        for (int i = 0; i < CardList.Count; i++)
        {
            CardList[i].GetComponent<BattleMyMainCardUtil>().NotShowDirectAttackButton();
        }
    }

    public void CallNotShowFrontAndSideButton()
    {
        for (int i = 0; i < CardList.Count; i++)
        {
            CardList[i].GetComponent<BattleMyMainCardUtil>().NotShowFrontAndSideButton();
        }
    }
}
