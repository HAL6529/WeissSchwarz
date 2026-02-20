using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_080 : BattleModeCard
{
    public BattleModeCard_P3_S01_080()
    {
        this.level = 2;
        this.cost = 1;
        this.soul = 1;
        this.color = EnumController.CardColor.BLUE;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.God, EnumController.Attribute.Devil };
        this.cardNo = EnumController.CardNo.P3_S01_080;
        this.cardName = "ÉCÉSÅ[Éã";
        this.power = 1500;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = new Effect_P3_S01_080();
    }
}
