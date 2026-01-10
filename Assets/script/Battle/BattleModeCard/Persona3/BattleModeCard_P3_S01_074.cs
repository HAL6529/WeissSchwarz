using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_074 : BattleModeCard
{
    public BattleModeCard_P3_S01_074()
    {
        this.level = -1;
        this.cost = -1;
        this.soul = -1;
        this.color = EnumController.CardColor.RED;
        this.trigger = EnumController.Trigger.COMEBACK;
        this.type = EnumController.Type.CLIMAX;
        this.attribute = new List<EnumController.Attribute>();
        this.cardNo = EnumController.CardNo.P3_S01_074;
        this.name = "ニュクス・アバター";
        this.power = -1;
        this.isCounter = false;
        this.isGreatPerformance = false;
    }
}
