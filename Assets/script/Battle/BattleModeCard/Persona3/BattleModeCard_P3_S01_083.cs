using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_083 : BattleModeCard
{
    public BattleModeCard_P3_S01_083()
    {
        this.level = 0;
        this.cost = 0;
        this.soul = 1;
        this.color = EnumController.CardColor.BLUE;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Glasses, EnumController.Attribute.Gag };
        this.cardNo = EnumController.CardNo.P3_S01_083;
        this.name = "äÙåé èCéi";
        this.power = 1000;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = null;
    }
}
