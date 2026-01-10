using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_057 : BattleModeCard
{
    public BattleModeCard_P3_S01_057()
    {
        this.level = 0;
        this.cost = 0;
        this.soul = 1;
        this.color = EnumController.CardColor.RED;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Magic, EnumController.Attribute.Weapon };
        this.cardNo = EnumController.CardNo.P3_S01_057;
        this.name = "çrä_ ê^éüòY";
        this.power = 1500;
        this.isCounter = false;
        this.isGreatPerformance = false;
    }
}
