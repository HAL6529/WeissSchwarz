using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_005 : BattleModeCard
{
    public BattleModeCard_P3_S01_005()
    {
        this.level = 2;
        this.cost = 1;
        this.soul = 1;
        this.color = EnumController.CardColor.YELLOW;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Magic, EnumController.Attribute.God };
        this.cardNo = EnumController.CardNo.P3_S01_005;
        this.cardName = "天田＆カーラ・ネミ";
        this.power = 7000;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.isHandEncore = false;
        this.isClockEncore = false;
        this.Explanation1 = stringValues.P3_S01_005_Explanation1;
        this.Explanation2 = stringValues.P3_S01_005_Explanation2;
        this.Explanation3 = "";
        this.Explanation4 = "";
        this.Explanation5 = "";
        this.m_EffectAbstract = new Effect_P3_S01_005();
    }
}
