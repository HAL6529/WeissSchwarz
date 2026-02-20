using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_066 : BattleModeCard
{
    public BattleModeCard_LB_W02_066()
    {
        this.level = 2;
        this.cost = 1;
        this.soul = 1;
        this.color = EnumController.CardColor.RED;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Music, EnumController.Attribute.Marble};
        this.cardNo = EnumController.CardNo.LB_W02_066;
        this.cardName = "Ågãÿì˜îné≠Åhê^êl";
        this.power = 1500;
        this.isCounter = true;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = null;
    }
}
