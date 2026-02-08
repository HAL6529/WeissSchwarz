using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_001 : BattleModeCard
{
    public BattleModeCard_LB_W02_001()
    {
        this.level = 0;
        this.cost = 0;
        this.soul = 1;
        this.color = EnumController.CardColor.YELLOW;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Sports };
        this.cardNo = EnumController.CardNo.LB_W02_001;
        this.name = "ç˘ê£êÏ ç≤ÅXî¸";
        this.power = 500;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = new Effect_LB_W02_001();
    }
}
