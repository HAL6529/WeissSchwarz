using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_061 : BattleModeCard
{
    public BattleModeCard_LB_W02_061()
    {
        this.level = 2;
        this.cost = 1;
        this.soul = 1;
        this.color = EnumController.CardColor.RED;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Marble, EnumController.Attribute.Chairperson };
        this.cardNo = EnumController.CardNo.LB_W02_061;
        this.name = "ótóØâ¿Åïâ¿ìﬁëΩ";
        this.power = 8500;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = null;
    }
}
