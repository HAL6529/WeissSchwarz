using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_AT_WX02_A08 : BattleModeCard
{
    public BattleModeCard_AT_WX02_A08()
    {
        this.level = -1;
        this.cost = -1;
        this.soul = -1;
        this.color = EnumController.CardColor.YELLOW;
        this.trigger = EnumController.Trigger.SHOT;
        this.type = EnumController.Type.CLIMAX;
        this.attribute = new List<EnumController.Attribute>();
        this.cardNo = EnumController.CardNo.AT_WX02_A08;
        this.cardName = "Memory of a Memory";
        this.power = -1;
        this.isCounter = false;
        this.isGreatPerformance = false;
    }
}
