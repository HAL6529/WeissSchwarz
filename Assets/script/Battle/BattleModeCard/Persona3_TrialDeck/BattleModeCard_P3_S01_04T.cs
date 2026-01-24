using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_04T : BattleModeCard
{
    public BattleModeCard_P3_S01_04T()
    {
        this.level = 1;
        this.cost = 1;
        this.soul = 1;
        this.color = EnumController.CardColor.YELLOW;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.TVMailOrder };
        this.cardNo = EnumController.CardNo.P3_S01_04T;
        this.name = "‚½‚È‚©ŽÐ’·";
        this.power = 1500;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = new Effect_P3_S01_04T();
    }
}
