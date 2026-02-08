using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_097 : BattleModeCard
{
    public BattleModeCard_LB_W02_097()
    {
        this.level = 1;
        this.cost = 2;
        this.soul = -1;
        this.color = EnumController.CardColor.BLUE;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.EVENT;
        this.attribute = new List<EnumController.Attribute>();
        this.cardNo = EnumController.CardNo.LB_W02_097;
        this.name = "óFèÓÇÃèÿ";
        this.power = -1;
        this.isCounter = true;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = null;
    }
}
