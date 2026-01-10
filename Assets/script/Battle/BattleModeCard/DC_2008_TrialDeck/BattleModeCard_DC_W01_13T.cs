using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_DC_W01_13T : BattleModeCard
{
    public BattleModeCard_DC_W01_13T()
    {
        this.level = 0;
        this.cost = 0;
        this.soul = 1;
        this.color = EnumController.CardColor.RED;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Mecha, EnumController.Attribute.Banana };
        this.cardNo = EnumController.CardNo.DC_W01_13T;
        this.name = "HM-A06Œ^ ƒ~ƒiƒc";
        this.power = 1000;
        this.isCounter = false;
        this.isGreatPerformance = false;
    }
}
