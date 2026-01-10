using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_076 : BattleModeCard
{
    public BattleModeCard_P3_S01_076()
    {
        this.level = 1;
        this.cost = 1;
        this.soul = 1;
        this.color = EnumController.CardColor.BLUE;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Swimsuit, EnumController.Attribute.StudentCouncil };
        this.cardNo = EnumController.CardNo.P3_S01_076;
        this.name = "êÖíÖÇÃî¸íﬂ";
        this.power = 1000;
        this.isCounter = false;
        this.isGreatPerformance = false;
    }
}
