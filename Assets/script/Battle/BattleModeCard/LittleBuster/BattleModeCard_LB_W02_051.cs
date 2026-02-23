using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_051 : BattleModeCard
{
    public BattleModeCard_LB_W02_051()
    {
        this.level = 0;
        this.cost = 0;
        this.soul = 1;
        this.color = EnumController.CardColor.RED;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Music, EnumController.Attribute.Weapon };
        this.cardNo = EnumController.CardNo.LB_W02_051;
        this.cardName = "ÅgâÿóÌÇ»ÇÈåïêπÅhóBåŒ";
        this.power = 500;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.Explanation1 = stringValues.LB_W02_051_Explanation1;
        this.Explanation2 = stringValues.LB_W02_051_Explanation2;
        this.Explanation3 = "";
        this.Explanation4 = "";
        this.Explanation5 = "";
        this.m_EffectAbstract = null;
    }
}
