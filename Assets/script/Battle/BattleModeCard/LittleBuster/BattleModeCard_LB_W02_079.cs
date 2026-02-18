using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_079 : BattleModeCard
{
    public BattleModeCard_LB_W02_079()
    {
        this.level = 1;
        this.cost = 0;
        this.soul = 1;
        this.color = EnumController.CardColor.BLUE;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Sweets, EnumController.Attribute.Maid };
        this.cardNo = EnumController.CardNo.LB_W02_079;
        this.name = "ÅgÇŸÇÒÇÌÇ©Ç´Ç„Å[Ç∆Åhè¨ü{";
        this.power = 5500;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = null;
    }
}
