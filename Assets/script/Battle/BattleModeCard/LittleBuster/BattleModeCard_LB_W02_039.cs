using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_039 : BattleModeCard
{
    public BattleModeCard_LB_W02_039()
    {
        this.level = 0;
        this.cost = 0;
        this.soul = 1;
        this.color = EnumController.CardColor.GREEN;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>();
        this.cardNo = EnumController.CardNo.LB_W02_039;
        this.cardName = "ÅgïÅí ÇÃè≠îNÅhóùé˜";
        this.power = 3000;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.isHandEncore = false;
        this.isClockEncore = false;
        this.Explanation1 = stringValues.LB_W02_039_Explanation1;
        this.Explanation2 = "";
        this.Explanation3 = "";
        this.Explanation4 = "";
        this.Explanation5 = "";
        this.m_EffectAbstract = null;
    }
}
