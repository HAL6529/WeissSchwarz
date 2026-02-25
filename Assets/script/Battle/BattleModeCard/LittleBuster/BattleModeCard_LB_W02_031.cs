using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_031 : BattleModeCard
{
    public BattleModeCard_LB_W02_031()
    {
        this.level = 2;
        this.cost = 2;
        this.soul = 2;
        this.color = EnumController.CardColor.GREEN;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Marble };
        this.cardNo = EnumController.CardNo.LB_W02_031;
        this.cardName = "ŽOŽ} —t—¯‰À";
        this.power = 8000;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.isHandEncore = false;
        this.isClockEncore = false;
        this.Explanation1 = stringValues.LB_W02_031_Explanation1;
        this.Explanation2 = stringValues.LB_W02_031_Explanation2;
        this.Explanation3 = "";
        this.Explanation4 = "";
        this.Explanation5 = "";
        this.m_EffectAbstract = new Effect_LB_W02_031();
    }
}
