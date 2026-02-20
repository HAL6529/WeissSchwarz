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
    public EnumController.Trigger trigger;
    public EnumController.Type type;
    public List<EnumController.Attribute> attribute = new List<EnumController.Attribute>();
    public EnumController.CardNo cardNo;
    public string cardName;
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
            this.level = m_BattleModeCard.GetLevel();
            this.cost = m_BattleModeCard.GetCost();
            this.color = m_BattleModeCard.GetCardColor();
            this.trigger = m_BattleModeCard.GetTrigger();
            this.type = m_BattleModeCard.GetType();
            this.attribute = m_BattleModeCard.GetAttribute();
            this.cardNo = m_BattleModeCard.GetCardNo();
            this.cardName = m_BattleModeCard.GetName();
            this.soul = m_BattleModeCard.GetSoul();
            this.power = m_BattleModeCard.GetPower();
            this.isCounter = m_BattleModeCard.GetIsCounter();
            return;
        }
    }
}
