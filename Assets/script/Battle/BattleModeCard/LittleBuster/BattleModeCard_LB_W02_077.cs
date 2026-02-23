using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_077 : BattleModeCard
{
    public BattleModeCard_LB_W02_077()
    {
        this.level = 2;
        this.cost = 2;
        this.soul = 2;
        this.color = EnumController.CardColor.BLUE;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Book, EnumController.Attribute.Parasol };
        this.cardNo = EnumController.CardNo.LB_W02_077;
        this.cardName = "ÅgìVëRëfçﬁÅhî¸ãõ";
        this.power = 7500;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.Explanation1 = stringValues.LB_W02_077_Explanation1;
        this.Explanation2 = stringValues.LB_W02_077_Explanation2;
        this.Explanation3 = "";
        this.Explanation4 = "";
        this.Explanation5 = "";
        this.m_EffectAbstract = new Effect_LB_W02_077();
    }
}
