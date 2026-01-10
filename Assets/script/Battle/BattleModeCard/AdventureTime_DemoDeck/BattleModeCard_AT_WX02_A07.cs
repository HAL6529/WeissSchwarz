using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_AT_WX02_A07 : BattleModeCard
{
    public BattleModeCard_AT_WX02_A07()
    {
        this.level = 1;
        this.cost = 1;
        this.soul = -1;
        this.color = EnumController.CardColor.YELLOW;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.EVENT;
        this.attribute = new List<EnumController.Attribute>();
        this.cardNo = EnumController.CardNo.AT_WX02_A07;
        this.name = "Quest Received!";
        this.power = -1;
        this.isCounter = false;
        this.isGreatPerformance = false;
    }
}
