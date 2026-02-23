using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_034 : BattleModeCard
{
    public BattleModeCard_LB_W02_034()
    {
        this.level = 1;
        this.cost = 1;
        this.soul = 1;
        this.color = EnumController.CardColor.GREEN;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Chairperson };
        this.cardNo = EnumController.CardNo.LB_W02_034;
        this.cardName = "ÅgïóãIÇÃî‘êlÅhâ¿ìﬁëΩ";
        this.power = 5000;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.Explanation1 = stringValues.LB_W02_034_Explanation1;
        this.Explanation2 = stringValues.LB_W02_034_Explanation2;
        this.Explanation3 = "";
        this.Explanation4 = "";
        this.Explanation5 = "";
        this.m_EffectAbstract = new Effect_LB_W02_034();
    }
}
