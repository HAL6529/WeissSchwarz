using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_055 : BattleModeCard
{
    public BattleModeCard_LB_W02_055()
    {
        this.level = 1;
        this.cost = 0;
        this.soul = 1;
        this.color = EnumController.CardColor.RED;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Sports };
        this.cardNo = EnumController.CardNo.LB_W02_055;
        this.cardName = "íºé} óùé˜";
        this.power = 4500;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.isHandEncore = true;
        this.isClockEncore = false;
        this.Explanation1 = stringValues.LB_W02_055_Explanation1;
        this.Explanation2 = stringValues.LB_W02_055_Explanation2;
        this.Explanation3 = "";
        this.Explanation4 = "";
        this.Explanation5 = "";
        this.m_EffectAbstract = new Effect_LB_W02_055();
    }
}
