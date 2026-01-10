using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_089 : BattleModeCard
{
    public BattleModeCard_P3_S01_089()
    {
        this.level = 0;
        this.cost = 0;
        this.soul = 1;
        this.color = EnumController.CardColor.BLUE;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.StudentCouncil };
        this.cardNo = EnumController.CardNo.P3_S01_089;
        this.name = "è¨ìcãÀ èGóò";
        this.power = 3000;
        this.isCounter = false;
        this.isGreatPerformance = false;
    }
}
