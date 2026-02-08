using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_034 : BattleModeCard
{
    public BattleModeCard_LB_W02_034()
    {
        this.level = 1;
        this.cost = 1;
        this.soul = 1;
        this.color = EnumController.CardColor.GREEN;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Chairperson };
        this.cardNo = EnumController.CardNo.LB_W02_034;
        this.name = "ÅgïóãIÇÃî‘êlÅhâ¿ìﬁëΩ";
        this.power = 5000;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = new Effect_LB_W02_034();
    }
}
