using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_016 : BattleModeCard
{
    public BattleModeCard_LB_W02_016()
    {
        this.level = 2;
        this.cost = 2;
        this.soul = 2;
        this.color = EnumController.CardColor.YELLOW;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Animal };
        this.cardNo = EnumController.CardNo.LB_W02_016;
        this.cardName = "Ågã±âÓÅïóÈ";
        this.power = 8000;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = null; 
    }
}
