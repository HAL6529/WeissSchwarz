using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_AT_WX02_A01 : BattleModeCard
{
    public BattleModeCard_AT_WX02_A01()
    {
        this.level = 0;
        this.cost = 0;
        this.soul = 1;
        this.color = EnumController.CardColor.YELLOW;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Ooo, EnumController.Attribute.Hero };
        this.cardNo = EnumController.CardNo.AT_WX02_A01;
        this.name = "Finn: Everything In!";
        this.power = 3000;
        this.isCounter = false;
        this.isGreatPerformance = false;
    }
}
