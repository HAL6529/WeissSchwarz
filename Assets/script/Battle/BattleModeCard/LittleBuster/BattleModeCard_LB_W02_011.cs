using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_011 : BattleModeCard
{
    public BattleModeCard_LB_W02_011()
    {
        this.level = 3;
        this.cost = 2;
        this.soul = 2;
        this.color = EnumController.CardColor.YELLOW;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Sweets, EnumController.Attribute.FairyTale };
        this.cardNo = EnumController.CardNo.LB_W02_011;
        this.name = "ÅgÇ®âŸéqçDÇ´Åhè¨ü{";
        this.power = 9000;
        this.isCounter = false;
        this.isGreatPerformance = true;
        this.m_EffectAbstract = null;
    }
}
