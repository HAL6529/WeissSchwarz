using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_AT_WX02_A13 : BattleModeCard
{
    public BattleModeCard_AT_WX02_A13()
    {
        this.level = -1;
        this.cost = -1;
        this.soul = -1;
        this.color = EnumController.CardColor.RED;
        this.trigger = EnumController.Trigger.COMEBACK;
        this.type = EnumController.Type.CLIMAX;
        this.attribute = new List<EnumController.Attribute>();
        this.cardNo = EnumController.CardNo.AT_WX02_A13;
        this.name = "Adventure Time!";
        this.power = -1;
        this.isCounter = false;
        this.isGreatPerformance = false;
    }
}
