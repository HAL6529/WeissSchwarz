using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_060 : BattleModeCard
{
    public BattleModeCard_P3_S01_060()
    {
        this.level = 2;
        this.cost = 1;
        this.soul = 1;
        this.color = EnumController.CardColor.RED;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Weapon, EnumController.Attribute.God };
        this.cardNo = EnumController.CardNo.P3_S01_060;
        this.name = "ÉWÉìÅïÉÇÉçÉX";
        this.power = 500;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = new Effect_P3_S01_060();
    }
}
