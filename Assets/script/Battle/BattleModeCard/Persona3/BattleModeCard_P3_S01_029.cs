using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_029 : BattleModeCard
{
    public BattleModeCard_P3_S01_029()
    {
        this.level = 1;
        this.cost = 1;
        this.soul = 1;
        this.color = EnumController.CardColor.GREEN;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Mecha, EnumController.Attribute.Weapon };
        this.cardNo = EnumController.CardNo.P3_S01_029;
        this.name = "ÉAÉCÉMÉX";
        this.power = 3500;
        this.isCounter = false;
        this.isGreatPerformance = false;
    }
}
