using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_018 : BattleModeCard
{
    public BattleModeCard_P3_S01_018()
    {
        this.level = 1;
        this.cost = 0;
        this.soul = -1;
        this.color = EnumController.CardColor.YELLOW;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.EVENT;
        this.attribute = new List<EnumController.Attribute>();
        this.cardNo = EnumController.CardNo.P3_S01_018;
        this.cardName = "É^ÉãÉ^ÉçÉX";
        this.power = -1;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.isHandEncore = false;
        this.isClockEncore = false;
        this.Explanation1 = stringValues.P3_S01_018_Explanation1;
        this.Explanation2 = "";
        this.Explanation3 = "";
        this.Explanation4 = "";
        this.Explanation5 = "";
        this.m_EffectAbstract = new Effect_P3_S01_018();
    }
}
