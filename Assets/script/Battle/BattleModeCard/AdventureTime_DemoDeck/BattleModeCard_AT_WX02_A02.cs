using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_AT_WX02_A02 : BattleModeCard
{
    public BattleModeCard_AT_WX02_A02()
    {
        this.level = 0;
        this.cost = 0;
        this.soul = 1;
        this.color = EnumController.CardColor.YELLOW;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Ooo, EnumController.Attribute.Hero };
        this.cardNo = EnumController.CardNo.AT_WX02_A02;
        this.cardName = "Jake: Bacon Pancakes";
        this.power = 2000;
        this.isCounter = false;
        this.isHandEncore = false;
        this.isClockEncore = false;
        this.Explanation1 = stringValues.AT_WX02_A02_Explanation1;
        this.Explanation2 = "";
        this.Explanation3 = "";
        this.Explanation4 = "";
        this.Explanation5 = "";
        this.isGreatPerformance = false;
        this.m_EffectAbstract = new Effect_AT_WX02_A02();
    }
}
