using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_017 : BattleModeCard
{
    public BattleModeCard_LB_W02_017()
    {
        this.level = 2;
        this.cost = 1;
        this.soul = 1;
        this.color = EnumController.CardColor.YELLOW;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Animal, EnumController.Attribute.Sports };
        this.cardNo = EnumController.CardNo.LB_W02_017;
        this.cardName = "Ågê_Ç»ÇÈÉmÅ[ÉRÉìÅhóÈ";
        this.power = 2000;
        this.isCounter = true;
        this.isGreatPerformance = false;
        this.Explanation1 = stringValues.LB_W02_017_Explanation1;
        this.Explanation2 = stringValues.LB_W02_017_Explanation2;
        this.Explanation3 = "";
        this.Explanation4 = "";
        this.Explanation5 = "";
        this.m_EffectAbstract = null;
    }
}
