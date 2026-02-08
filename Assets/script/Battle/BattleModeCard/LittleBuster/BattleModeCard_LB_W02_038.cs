using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_038 : BattleModeCard
{
    public BattleModeCard_LB_W02_038()
    {
        this.level = 0;
        this.cost = 1;
        this.soul = 1;
        this.color = EnumController.CardColor.GREEN;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Animal, EnumController.Attribute.Chairperson };
        this.cardNo = EnumController.CardNo.LB_W02_038;
        this.name = "ÉNÉhÅïâ¿ìﬁëΩ";
        this.power = 1500;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = new Effect_LB_W02_038();
    }
}
