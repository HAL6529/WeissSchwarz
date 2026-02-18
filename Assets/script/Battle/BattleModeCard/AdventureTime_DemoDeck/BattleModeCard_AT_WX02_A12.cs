using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_AT_WX02_A12 : BattleModeCard
{
    public BattleModeCard_AT_WX02_A12()
    {
        this.level = 2;
        this.cost = 2;
        this.soul = 2;
        this.color = EnumController.CardColor.RED;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Ooo, EnumController.Attribute.Vampire };
        this.cardNo = EnumController.CardNo.AT_WX02_A12;
        this.name = "Marceline: Party Crasher";
        this.power = 8000;
        this.isCounter = false;
        this.isGreatPerformance = false;
    }
}
