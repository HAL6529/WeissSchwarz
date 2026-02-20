using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_015 : BattleModeCard
{
    public BattleModeCard_LB_W02_015()
    {
        this.level = 1;
        this.cost = 1;
        this.soul = 1;
        this.color = EnumController.CardColor.YELLOW;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Music, EnumController.Attribute.Animal };
        this.cardNo = EnumController.CardNo.LB_W02_015;
        this.cardName = "“深窓のクイーンオブハート”唯湖";
        this.power = 6000;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = null; 
    }
}
