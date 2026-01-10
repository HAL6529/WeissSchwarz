using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_19T : BattleModeCard
{
    public BattleModeCard_LB_W02_19T()
    {
        this.level = 2;
        this.cost = 1;
        this.soul = 1;
        this.color = EnumController.CardColor.BLUE;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.FairyTale, EnumController.Attribute.Sweets };
        this.cardNo = EnumController.CardNo.LB_W02_19T;
        this.name = "ÅgÇ®ÇﬂÇ©ÇµÅhè¨ü{";
        this.power = 8000;
        this.isCounter = false;
        this.isGreatPerformance = false;
    }
}
