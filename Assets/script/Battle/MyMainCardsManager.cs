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

    public void CallWhenReverseEnemyCard(int num)
    {
        int Place = -1;
        switch (num)
        {
            case 0:
                Place = 2;
                break;
            case 1:
                Place = 1;
                break;
            case 2:
                Place = 0;
                break;
            default:
                break;
        }
        CardList[Place].WhenReverseEnemyCard();
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

    public void FieldPowerAndLevelAndAttributeAndSoulReset()
    {
        for (int i = 0; i < CardList.Count; i++)
        {
            CardList[i].LevelUpdate();
            CardList[i].PowerUpdate();
            CardList[i].SoulUpdate();
        }
    }

    public int GetNumFieldCardNo(List<EnumController.CardNo> list)
    {
        if(list.Count == 0)
        {
            return 0;
        }
        int num = 0;
        for(int i = 0; i < CardList.Count; i++)
        {
            for(int n = 0; n < list.Count; n++)
            {
                BattleModeCard temp = CardList[i].getBattleModeCard();
                if(temp == null)
                {
                    continue;
                }
                if (temp.cardNo == list[n])
                {
                    num++;
                }
            }
        }

        return num;
    }

    public int GetFieldPower(int place)
    {
        return CardList[place].GetFieldPower();
    }

    public List<int> GetFieldLevel()
    {
        List<int> list = new List<int>();
        for (int i = 0; i < CardList.Count; i++)
        {
            list.Add(CardList[i].GetFieldLevel());
        }
        return list;
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

    public List<int> GetFieldSoul()
    {
        List<int> list = new List<int>();
        for (int i = 0; i < CardList.Count; i++)
        {
            list.Add(CardList[i].GetFieldSoul());
        }
        return list;
    }

    public List<bool> GetIsGreatPerformance()
    {
        List<bool> list = new List<bool>();
        for (int i = 0; i < CardList.Count; i++)
        {
            list.Add(CardList[i].isGreatPerformance);
        }
        return list;
    }

    public bool GetIsGreatPerformance(int place)
    {
        return CardList[place].isGreatPerformance;
    }

    public int GetFieldSoul(int place)
    {
        return CardList[place].GetFieldSoul();
    }

    public void AddPowerUpUntilTurnEnd(int num, int power)
    {
        CardList[num].m_PowerUpUntilTurnEnd.AddUpPower(power);
    }

    public PowerInstance.PowerUpUntilTurnEnd GetPowerUpUntilTurnEnd(int place)
    {
        return CardList[place].m_PowerUpUntilTurnEnd;
    }

    public void SetPowerUpUntilTurnEnd(int place, PowerInstance.PowerUpUntilTurnEnd paramater)
    {
        CardList[place].m_PowerUpUntilTurnEnd = paramater;
    }

    public void ExecuteAttack2(int num, EnumController.Attack status)
    {
        CardList[num].Attack2(status);
    }

    public void ExecuteResetPowerUpUntilTurnEnd()
    {
        for (int i = 0; i < CardList.Count; i++)
        {
            CardList[i].ResetPowerUpUntilTurnEnd();
        }
    }
}
