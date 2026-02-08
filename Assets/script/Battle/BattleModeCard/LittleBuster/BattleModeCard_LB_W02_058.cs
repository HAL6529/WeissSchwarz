using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_058 : BattleModeCard
{
    public BattleModeCard_LB_W02_058()
    {
        this.level = 0;
        this.cost = 0;
        this.soul = 1;
        this.color = EnumController.CardColor.RED;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Chairperson };
        this.cardNo = EnumController.CardNo.LB_W02_058;
        this.name = "“ñ–Ø ‰À“Þ‘½";
        this.power = 500;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = null;
    }
}
