using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_084 : BattleModeCard
{
    public BattleModeCard_P3_S01_084()
    {
        this.level = 0;
        this.cost = 0;
        this.soul = 1;
        this.color = EnumController.CardColor.BLUE;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Magic, EnumController.Attribute.StudentCouncil };
        this.cardNo = EnumController.CardNo.P3_S01_084;
        this.cardName = "ãÀè î¸íﬂ";
        this.power = 500;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.isHandEncore = true;
        this.isClockEncore = false;
        this.Explanation1 = stringValues.P3_S01_084_Explanation1;
        this.Explanation2 = stringValues.P3_S01_084_Explanation2;
        this.Explanation3 = "";
        this.Explanation4 = "";
        this.Explanation5 = "";
        this.m_EffectAbstract = null;
    }
}
