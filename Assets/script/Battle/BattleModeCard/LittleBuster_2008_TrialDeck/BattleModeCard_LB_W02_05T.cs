using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_05T : BattleModeCard
{
    public BattleModeCard_LB_W02_05T()
    {
        this.level = 0;
        this.cost = 0;
        this.soul = 1;
        this.color = EnumController.CardColor.GREEN;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Animal };
        this.cardNo = EnumController.CardNo.LB_W02_05T;
        this.name = "能美 クドリャフカ";
        this.power = 500;
        this.isCounter = false;
        this.isGreatPerformance = false;
    }

}
