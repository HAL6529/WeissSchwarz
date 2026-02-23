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
        this.Explanation1 = stringValues.LB_W02_081_Explanation1;
        this.Explanation2 = stringValues.LB_W02_081_Explanation2;
        this.Explanation3 = "";
        this.Explanation4 = "";
        this.Explanation5 = "";
        this.m_EffectAbstract = null;
    }
}
