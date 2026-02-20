using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_081 : BattleModeCard
{
    public BattleModeCard_LB_W02_081()
    {
        this.level = 1;
        this.cost = 1;
        this.soul = 1;
        this.color = EnumController.CardColor.BLUE;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Shadow };
        this.cardNo = EnumController.CardNo.LB_W02_081;
        this.cardName = "Ågè¨à´ñÇè≠èóÅhî¸íπ";
        this.power = 4500;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = null;
    }
}
