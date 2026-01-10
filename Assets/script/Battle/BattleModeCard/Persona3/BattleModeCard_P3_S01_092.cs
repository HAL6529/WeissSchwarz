using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_092 : BattleModeCard
{
    public BattleModeCard_P3_S01_092()
    {
        this.level = 2;
        this.cost = 1;
        this.soul = 1;
        this.color = EnumController.CardColor.BLUE;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.StudentCouncil, EnumController.Attribute.God };
        this.cardNo = EnumController.CardNo.P3_S01_092;
        this.name = "美鶴＆アルテミシア";
        this.power = 6000;
        this.isCounter = false;
        this.isGreatPerformance = false;
    }
}
