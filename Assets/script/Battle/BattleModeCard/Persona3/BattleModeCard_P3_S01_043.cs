using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_043 : BattleModeCard
{
    public BattleModeCard_P3_S01_043()
    {
        this.level = 2;
        this.cost = 3;
        this.soul = -1;
        this.color = EnumController.CardColor.GREEN;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.EVENT;
        this.attribute = new List<EnumController.Attribute>();
        this.cardNo = EnumController.CardNo.P3_S01_043;
        this.cardName = "ëççUåÇÉ`ÉÉÉìÉXÅI";
        this.power = -1;
        this.isCounter = true;
        this.isGreatPerformance = false;
        this.Explanation1 = stringValues.P3_S01_043_Explanation1;
        this.Explanation2 = "";
        this.Explanation3 = "";
        this.Explanation4 = "";
        this.Explanation5 = "";
        this.m_EffectAbstract = new Effect_P3_S01_043();
    }
}
