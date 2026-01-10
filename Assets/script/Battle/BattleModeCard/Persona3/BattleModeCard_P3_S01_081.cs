using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_081 : BattleModeCard
{
    public BattleModeCard_P3_S01_081()
    {
        this.level = 2;
        this.cost = 1;
        this.soul = 1;
        this.color = EnumController.CardColor.BLUE;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Magic, EnumController.Attribute.God };
        this.cardNo = EnumController.CardNo.P3_S01_081;
        this.name = "Ç‰Ç©ÇË&ÉCÉVÉX";
        this.power = 7000;
        this.isCounter = false;
        this.isGreatPerformance = false;
    }
}
