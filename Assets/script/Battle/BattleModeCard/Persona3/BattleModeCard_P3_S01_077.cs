using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_077 : BattleModeCard
{
    public BattleModeCard_P3_S01_077()
    {
        this.level = 3;
        this.cost = 2;
        this.soul = 2;
        this.color = EnumController.CardColor.BLUE;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Magic, EnumController.Attribute.God };
        this.cardNo = EnumController.CardNo.P3_S01_077;
        this.cardName = "エリザベス";
        this.power = 9000;
        this.isCounter = false;
        this.isGreatPerformance = true;
        this.Explanation1 = stringValues.P3_S01_077_Explanation1;
        this.Explanation2 = stringValues.P3_S01_077_Explanation2;
        this.Explanation3 = stringValues.P3_S01_077_Explanation3;
        this.Explanation4 = "";
        this.Explanation5 = "";
        this.m_EffectAbstract = new Effect_P3_S01_077();
    }
}
