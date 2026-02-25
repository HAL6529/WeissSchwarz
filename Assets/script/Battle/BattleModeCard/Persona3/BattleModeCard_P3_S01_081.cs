using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_081 : BattleModeCard
{
    public BattleModeCard_P3_S01_081()
    {
        this.level = 2;
        this.cost = 1;
        this.soul = 1;
        this.color = EnumController.CardColor.BLUE;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Magic, EnumController.Attribute.God };
        this.cardNo = EnumController.CardNo.P3_S01_081;
        this.cardName = "Ç‰Ç©ÇË&ÉCÉVÉX";
        this.power = 7000;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.isHandEncore = false;
        this.isClockEncore = false;
        this.Explanation1 = stringValues.P3_S01_081_Explanation1;
        this.Explanation2 = stringValues.P3_S01_081_Explanation2;
        this.Explanation3 = "";
        this.Explanation4 = "";
        this.Explanation5 = "";
        this.m_EffectAbstract = new Effect_P3_S01_081();
    }
}
