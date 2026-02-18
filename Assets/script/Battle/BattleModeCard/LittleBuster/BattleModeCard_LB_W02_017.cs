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
        this.name = "Ågê_Ç»ÇÈÉmÅ[ÉRÉìÅhóÈ";
        this.power = 2000;
        this.isCounter = true;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = null;
    }
}
