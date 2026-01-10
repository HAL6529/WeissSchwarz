using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_012 : BattleModeCard
{
    public BattleModeCard_P3_S01_012()
    {
        this.level = 0;
        this.cost = 0;
        this.soul = 1;
        this.color = EnumController.CardColor.YELLOW;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Animal, EnumController.Attribute.Weapon };
        this.cardNo = EnumController.CardNo.P3_S01_012;
        this.name = "ÉRÉçÉ}Éã";
        this.power = 2000;
        this.isCounter = false;
        this.isGreatPerformance = false;
    }
}
