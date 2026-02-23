using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_040 : BattleModeCard
{
    public BattleModeCard_LB_W02_040()
    {
        this.level = 1;
        this.cost = 1;
        this.soul = 1;
        this.color = EnumController.CardColor.GREEN;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Sports };
        this.cardNo = EnumController.CardNo.LB_W02_040;
        this.cardName = "Ågèóâ§îLÅhç≤ÅXî¸";
        this.power = 1500;
        this.isCounter = true;
        this.isGreatPerformance = false;
        this.Explanation1 = stringValues.LB_W02_040_Explanation1;
        this.Explanation2 = stringValues.LB_W02_040_Explanation2;
        this.Explanation3 = "";
        this.Explanation4 = "";
        this.Explanation5 = "";
        this.m_EffectAbstract = new Effect_LB_W02_040();
    }
}
