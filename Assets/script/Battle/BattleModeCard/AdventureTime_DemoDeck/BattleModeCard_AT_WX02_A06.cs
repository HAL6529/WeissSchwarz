using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_AT_WX02_A06 : BattleModeCard
{
    public BattleModeCard_AT_WX02_A06()
    {
        this.level = 2;
        this.cost = 1;
        this.soul = 1;
        this.color = EnumController.CardColor.YELLOW;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Ooo, EnumController.Attribute.Hero };
        this.cardNo = EnumController.CardNo.AT_WX02_A06;
        this.name = "Finn & Jake: Rainy Day Daydream";
        this.power = 5500;
        this.isCounter = false;
        this.isGreatPerformance = false;
    }
}
