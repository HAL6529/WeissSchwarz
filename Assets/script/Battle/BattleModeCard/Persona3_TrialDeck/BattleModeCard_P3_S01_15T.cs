using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_15T : BattleModeCard
{
    public BattleModeCard_P3_S01_15T()
    {
        this.level = 1;
        this.cost = 1;
        this.soul = 1;
        this.color = EnumController.CardColor.BLUE;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.StudentCouncil, EnumController.Attribute.God };
        this.cardNo = EnumController.CardNo.P3_S01_15T;
        this.cardName = "美鶴＆ペンテシレア";
        this.power = 5000;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.isHandEncore = true;
        this.isClockEncore = false;
        this.Explanation1 = stringValues.P3_S01_15T_Explanation1;
        this.Explanation2 = stringValues.P3_S01_15T_Explanation2;
        this.Explanation3 = "";
        this.Explanation4 = "";
        this.Explanation5 = "";
        this.m_EffectAbstract = null;
    }
}
