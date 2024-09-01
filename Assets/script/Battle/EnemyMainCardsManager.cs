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

    public void SetFieldAttribute(List<EnumController.Attribute> list, int place)
    {
        CardList[place].AttributeList = list;
    }

    public void SetFieldLevel(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            CardList[i].SetFieldLevel(list[i]);
        }
    }

    public void SetFieldPower(List<int> list)
    {
        for(int i = 0; i < list.Count; i++)
        {
            CardList[i].SetFieldPower(list[i]);
        }
    }

    public void SetFieldSoul(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            CardList[i].SetFieldSoul(list[i]);
        }
    }

    public void SetIsGreatProcessList(List<bool> IsGreatProcessList)
    {
        for (int i = 0; i < IsGreatProcessList.Count; i++)
        {
            CardList[i].SetIsGreatProcess(IsGreatProcessList[i]);
        }
    }

    public int GetFieldLevel(int place)
    {
        return CardList[place].GetFieldLevel();
    }

    public int GetFieldPower(int place)
    {
        return CardList[place].GetFieldPower();
    }

    public bool GetIsGreatProcessList(int place)
    {
        return CardList[place].GetIsGreatPerformance();
    }

    public EnumController.State GetState(int place)
    {
        return CardList[place].GetState();
    }
}
