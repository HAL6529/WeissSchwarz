using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_009 : BattleModeCard
{
    public BattleModeCard_P3_S01_009()
    {
        this.level = 1;
        this.cost = 1;
        this.soul = 1;
        this.color = EnumController.CardColor.YELLOW;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Animal, EnumController.Attribute.Weapon };
        this.cardNo = EnumController.CardNo.P3_S01_009;
        this.name = "コロマル＆ケルベロス";
        this.power = 2000;
        this.isCounter = true;
        this.isGreatPerformance = false;
    }
}
