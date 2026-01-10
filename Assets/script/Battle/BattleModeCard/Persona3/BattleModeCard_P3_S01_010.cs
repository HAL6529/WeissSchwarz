using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_010 : BattleModeCard
{
    public BattleModeCard_P3_S01_010()
    {
        this.level = 1;
        this.cost = 1;
        this.soul = 1;
        this.color = EnumController.CardColor.YELLOW;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.TVMailOrder};
        this.cardNo = EnumController.CardNo.P3_S01_010;
        this.name = "‚½‚È‚©ŽÐ’·";
        this.power = 1500;
        this.isCounter = false;
        this.isGreatPerformance = false;
    }
}
