using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_06T : BattleModeCard
{
    public BattleModeCard_LB_W02_06T()
    {
        this.level = 0;
        this.cost = 0;
        this.soul = 1;
        this.color = EnumController.CardColor.GREEN;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>();
        this.cardNo = EnumController.CardNo.LB_W02_06T;
        this.name = "ÅgïÅí ÇÃè≠îNÅhóùé˜";
        this.power = 3000;
        this.isCounter = false;
        this.isGreatPerformance = false;
    }
}
