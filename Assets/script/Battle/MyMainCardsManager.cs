using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyMainCardsManager : MonoBehaviour
{
    private List<BattleModeCard> myFieldList = new List<BattleModeCard>();
    public List<BattleMyMainCardUtil> CardList = new List<BattleMyMainCardUtil>();
    [SerializeField] BattleStrix m_BattleStrix;
    [SerializeField] GameManager m_GameManager;

    public void CallStand()
    {
        for (int i = 0; i < CardList.Count; i++)
        {
            CardList[i].Stand();
        }
    }

    public void CallOnStand(int num)
    {
        CardList[num].Stand();
    }

    public void CallOnReverse(int num)
    {
        CardList[num].onReverse();
    }

    public void CallOnRest(int num)
    {
        CardList[num].onRest();
    }

    public int GetAssistPower(int num)
    {
        return CardList[num].m_Assist.getAssistPower();
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

    public EnumController.State GetState(int num)
    {
        return CardList[num].GetState();
    }

    public void FieldPowerReset()
    {
        for (int i = 0; i < CardList.Count; i++)
        {
            CardList[i].PowerUpdate();
        }
    }

    public List<int> GetFieldPower()
    {
        List<int> list = new List<int>();
        for (int i = 0; i < CardList.Count; i++)
        {
            list.Add(CardList[i].GetFieldPower());
        }
        return list;
    }

    public int GetFieldPower(int place)
    {
        return CardList[place].GetFieldPower();
    }
}
