using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_065 : BattleModeCard
{
    public BattleModeCard_LB_W02_065()
    {
        this.level = 1;
        this.cost = 1;
        this.soul = 1;
        this.color = EnumController.CardColor.RED;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Muscle };
        this.cardNo = EnumController.CardNo.LB_W02_065;
        this.name = "Ågãÿì˜îné≠Åhê^êl";
        this.power = 7000;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = null;
    }
}
