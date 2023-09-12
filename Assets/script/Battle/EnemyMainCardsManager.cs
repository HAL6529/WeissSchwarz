using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMainCardsManager : MonoBehaviour
{
    private List<BattleModeCard> enemyFieldList = new List<BattleModeCard>();
    public List<BattleEnemyMainCardUtil> CardList = new List<BattleEnemyMainCardUtil>();

    public void updateEnemyFieldCards(List<BattleModeCard> list)
    {
        enemyFieldList = list;
        for (int i = 0; i < CardList.Count; i++)
        {
            CardList[i].setBattleModeCard(enemyFieldList[i]);
        }
    }

    public void CallRest(int num)
    {
        CardList[num].Rest();
    }

    public void CallStand(int num)
    {
        CardList[num].Stand();
    }

    public void CallReverse(int num)
    {
        CardList[num].Reverse();
    }
}
