using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_AT_WX02_A09 : BattleModeCard
{
    public BattleModeCard_AT_WX02_A09()
    {
        this.level = 0;
        this.cost = 0;
        this.soul = 1;
        this.color = EnumController.CardColor.RED;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Ooo, EnumController.Attribute.Royalty };
        this.cardNo = EnumController.CardNo.AT_WX02_A09;
        this.name = "Lumpy Space Princess: Unimpressed";
        this.power = 2000;
        this.isCounter = false;
        this.isGreatPerformance = false;
    }
}
