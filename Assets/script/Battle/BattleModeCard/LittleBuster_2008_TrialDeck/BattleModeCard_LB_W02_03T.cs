using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_03T : BattleModeCard
{
    public BattleModeCard_LB_W02_03T()
    {
        this.level = 3;
        this.cost = 2;
        this.soul = 2;
        this.color = EnumController.CardColor.GREEN;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Animal };
        this.cardNo = EnumController.CardNo.LB_W02_03T;
        this.cardName = "ÅgÉ|ÉjÅ[ÉKÅ[ÉãÅhóÈ";
        this.power = 8500;
        this.isCounter = false;
        this.isGreatPerformance = true;
        this.m_EffectAbstract = new Effect_LB_W02_03T();
    }
}
