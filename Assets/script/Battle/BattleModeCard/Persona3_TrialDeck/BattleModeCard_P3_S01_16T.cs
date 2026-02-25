using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_16T : BattleModeCard
{
    public BattleModeCard_P3_S01_16T()
    {
        this.level = 0;
        this.cost = 0;
        this.soul = 1;
        this.color = EnumController.CardColor.BLUE;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.StudentCouncil, EnumController.Attribute.Glasses };
        this.cardNo = EnumController.CardNo.P3_S01_16T;
        this.cardName = "ïöå© êÁêq";
        this.power = 500;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.isHandEncore = false;
        this.isClockEncore = false;
        this.Explanation1 = stringValues.P3_S01_16T_Explanation1;
        this.Explanation2 = stringValues.P3_S01_16T_Explanation2;
        this.Explanation3 = "";
        this.Explanation4 = "";
        this.Explanation5 = "";
        this.m_EffectAbstract = new Effect_P3_S01_16T();
    }
}
