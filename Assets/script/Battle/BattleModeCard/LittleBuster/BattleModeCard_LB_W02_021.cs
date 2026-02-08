using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_021 : BattleModeCard
{
    public BattleModeCard_LB_W02_021()
    {
        this.level = 0;
        this.cost = 1;
        this.soul = -1;
        this.color = EnumController.CardColor.YELLOW;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.EVENT;
        this.attribute = new List<EnumController.Attribute>();
        this.cardNo = EnumController.CardNo.LB_W02_021;
        this.name = "コールドゲームだ";
        this.power = -1;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = null;
    }
}
