using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_05T : BattleModeCard
{
    public BattleModeCard_LB_W02_05T()
    {
        this.level = 0;
        this.cost = 0;
        this.soul = 1;
        this.color = EnumController.CardColor.GREEN;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Animal };
        this.cardNo = EnumController.CardNo.LB_W02_05T;
        this.cardName = "能美 クドリャフカ";
        this.power = 500;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.Explanation1 = stringValues.LB_W02_05T_Explanation1;
        this.Explanation2 = stringValues.LB_W02_05T_Explanation2;
        this.Explanation3 = "";
        this.Explanation4 = "";
        this.Explanation5 = "";
        this.m_EffectAbstract = new Effect_LB_W02_05T();
    }

}
