using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_058 : BattleModeCard
{
    public BattleModeCard_P3_S01_058()
    {
        this.level = 1;
        this.cost = 0;
        this.soul = 1;
        this.color = EnumController.CardColor.RED;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Alcohol, EnumController.Attribute.Zen };
        this.cardNo = EnumController.CardNo.P3_S01_058;
        this.cardName = "–³’B";
        this.power = 3500;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = new Effect_P3_S01_058();
    }
}
