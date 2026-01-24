using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_034 : BattleModeCard
{
    public BattleModeCard_P3_S01_034()
    {
        this.level = 1;
        this.cost = 1;
        this.soul = 1;
        this.color = EnumController.CardColor.GREEN;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Mecha, EnumController.Attribute.Weapon };
        this.cardNo = EnumController.CardNo.P3_S01_034;
        this.name = "ÉÅÉeÉBÉX";
        this.power = 4500;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = new Effect_P3_S01_034();
    }
}
