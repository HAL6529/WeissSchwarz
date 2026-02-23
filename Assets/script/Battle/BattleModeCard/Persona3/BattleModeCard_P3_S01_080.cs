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
        this.Explanation1 = stringValues.P3_S01_080_Explanation1;
        this.Explanation2 = stringValues.P3_S01_080_Explanation2;
        this.Explanation3 = stringValues.P3_S01_080_Explanation3;
        this.Explanation4 = "";
        this.Explanation5 = "";
        this.m_EffectAbstract = new Effect_P3_S01_080();
    }
}
