using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_08T : BattleModeCard
{
    public BattleModeCard_LB_W02_08T()
    {
        this.level = 1;
        this.cost = 0;
        this.soul = 1;
        this.color = EnumController.CardColor.GREEN;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Marble };
        this.cardNo = EnumController.CardNo.LB_W02_08T;
        this.name = "ÅgÉGÉvÉçÉìÅhótóØâ¿";
        this.power = 3500;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = null;
    }
}
