using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_DC_W01_11T : BattleModeCard
{
    public BattleModeCard_DC_W01_11T()
    {
        this.level = 2;
        this.cost = 2;
        this.soul = 2;
        this.color = EnumController.CardColor.RED;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Magic, EnumController.Attribute.Banana };
        this.cardNo = EnumController.CardNo.DC_W01_11T;
        this.name = "î¸ètÅïâπñ≤";
        this.power = 9000;
        this.isCounter = false;
        this.isGreatPerformance = false;
    }
}
