using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_067 : BattleModeCard
{
    public BattleModeCard_P3_S01_067()
    {
        this.level = 2;
        this.cost = 1;
        this.soul = 1;
        this.color = EnumController.CardColor.RED;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Sports, EnumController.Attribute.God };
        this.cardNo = EnumController.CardNo.P3_S01_067;
        this.name = "明彦＆ポリデュークス";
        this.power = 2500;
        this.isCounter = true;
        this.isGreatPerformance = false;
    }
}
