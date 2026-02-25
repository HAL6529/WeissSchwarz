using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_04T : BattleModeCard
{
    public BattleModeCard_LB_W02_04T()
    {
        this.level = 1;
        this.cost = 1;
        this.soul = -1;
        this.color = EnumController.CardColor.GREEN;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.EVENT;
        this.attribute = new List<EnumController.Attribute>();
        this.cardNo = EnumController.CardNo.LB_W02_04T;
        this.cardName = "‹Ù‹}Ž–‘Ô";
        this.power = -1;
        this.isCounter = true;
        this.isGreatPerformance = false;
        this.isHandEncore = false;
        this.isClockEncore = false;
        this.Explanation1 = stringValues.LB_W02_04T_Explanation1;
        this.Explanation2 = "";
        this.Explanation3 = "";
        this.Explanation4 = "";
        this.Explanation5 = "";
        this.m_EffectAbstract = new Effect_LB_W02_04T();
    }
}
