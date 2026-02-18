using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_028 : BattleModeCard
{
    public BattleModeCard_P3_S01_028()
    {
        this.level = 0;
        this.cost = 0;
        this.soul = 1;
        this.color = EnumController.CardColor.GREEN;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Twins };
        this.cardNo = EnumController.CardNo.P3_S01_028;
        this.name = "ê_ãΩ ü´";
        this.power = 2500;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = new Effect_P3_S01_028();
    }
}
