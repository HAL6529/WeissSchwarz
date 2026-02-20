using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_040 : BattleModeCard
{
    public BattleModeCard_LB_W02_040()
    {
        this.level = 1;
        this.cost = 1;
        this.soul = 1;
        this.color = EnumController.CardColor.GREEN;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Sports };
        this.cardNo = EnumController.CardNo.LB_W02_040;
        this.cardName = "Ågèóâ§îLÅhç≤ÅXî¸";
        this.power = 1500;
        this.isCounter = true;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = new Effect_LB_W02_040();
    }
}
