using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumController;

public class BattleModeCardTemp
{
    public int level;
    public int cost;
    public int soul;
    public EnumController.CardColor color;
    public EnumController.Trriger trigger;
    public EnumController.Type type;
    public EnumController.Attribute attributeOne;
    public EnumController.Attribute attributeTwo;
    public EnumController.Attribute attributeThree;
    public EnumController.CardNo cardNo;
    public string name;
    public int power;
    public bool isCounter;
    public string explanation;

    public BattleModeCardTemp()
    {

    }

    public BattleModeCardTemp(BattleModeCard m_BattleModeCard)
    {
        if(m_BattleModeCard != null)
        {
            this.level = m_BattleModeCard.level;
            this.cost = m_BattleModeCard.cost;
            this.color = m_BattleModeCard.color;
            this.trigger = m_BattleModeCard.trigger;
            this.type = m_BattleModeCard.type;
            this.attributeOne = m_BattleModeCard.attributeOne;
            this.attributeTwo = m_BattleModeCard.attributeTwo;
            this.attributeThree = m_BattleModeCard.attributeThree;
            this.cardNo = m_BattleModeCard.cardNo;
            this.name = m_BattleModeCard.name;
            this.soul = m_BattleModeCard.soul;
            this.power = m_BattleModeCard.power;
            this.isCounter = m_BattleModeCard.isCounter;
            return;
        }
    }
}
