using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_029 : BattleModeCard
{
    public BattleModeCard_LB_W02_029()
    {
        this.level = 1;
        this.cost = 2;
        this.soul = 1;
        this.color = EnumController.CardColor.GREEN;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Animal };
        this.cardNo = EnumController.CardNo.LB_W02_029;
        this.name = "“マスコット”クド";
        this.power = 7500;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = null;
    }
}
