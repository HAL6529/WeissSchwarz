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

    /// <summary>
    /// ‰ž‰‡‚ÌŒvŽZ—p
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public int GetAssistPower(int num)
    {
        return CardList[num].m_Assist.getAssistPower();
    }

    /// <summary>
    /// ƒKƒEƒ‹Œø‰Ê‚ÌŒvŽZ—p
    /// </summary>
    /// <returns></returns>
    public int GetGaulPower(int num, List<EnumController.Attribute> attributeList)
    {
        if(attributeList == null)
        {
            return 0;
        }

        int count = 0;
        for (int i = 0; i < CardList.Count; i++)
        {
            if (CardList[i].HaveAttribute(attributeList))
            {
                count++;
            }
        }

        return CardList[num].m_Gaul.GetAssistPower(count);
    }

    public int GetLevelAssistPower(int num, int FieldLevel)
    {
        return CardList[num].m_LevelAssist.getAssistPower(FieldLevel);
    }

    public void setBattleModeCard(int num, BattleModeCard card, EnumController.State status)
    {
        CardList[num].setBattleModeCard(card, status);
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

    public void FieldPowerAndLevelAndAttributeReset()
    {
        for (int i = 0; i < CardList.Count; i++)
        {
            CardList[i].LevelUpdate();
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
