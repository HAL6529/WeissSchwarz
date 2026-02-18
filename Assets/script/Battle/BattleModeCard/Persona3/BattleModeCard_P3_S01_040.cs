using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_040 : BattleModeCard
{
    public BattleModeCard_P3_S01_040()
    {
        this.level = 1;
        this.cost = 1;
        this.soul = 1;
        this.color = EnumController.CardColor.GREEN;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Sports, EnumController.Attribute.Manager };
        this.cardNo = EnumController.CardNo.P3_S01_040;
        this.name = "êºòe åãéq";
        this.power = 2000;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = new Effect_P3_S01_040();
    }
}
