using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_086 : BattleModeCard
{
    public BattleModeCard_P3_S01_086()
    {
        this.level = 2;
        this.cost = 2;
        this.soul = 1;
        this.color = EnumController.CardColor.BLUE;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Glasses };
        this.cardNo = EnumController.CardNo.P3_S01_086;
        this.name = "ê_ãΩ ó»";
        this.power = 9000;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = null;
    }
}