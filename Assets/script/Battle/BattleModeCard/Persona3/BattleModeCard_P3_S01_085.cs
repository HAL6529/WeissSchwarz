using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_085 : BattleModeCard
{
    public BattleModeCard_P3_S01_085()
    {
        this.level = 1;
        this.cost = 0;
        this.soul = 1;
        this.color = EnumController.CardColor.BLUE;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Magic, EnumController.Attribute.God };
        this.cardNo = EnumController.CardNo.P3_S01_085;
        this.name = "Ç‰Ç©ÇËÅïÉCÉI";
        this.power = 1500;
        this.isCounter = false;
        this.isGreatPerformance = false;
    }
}
