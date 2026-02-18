using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_AT_WX02_A05 : BattleModeCard
{
    public BattleModeCard_AT_WX02_A05()
    {
        this.level = 1;
        this.cost = 1;
        this.soul = 1;
        this.color = EnumController.CardColor.YELLOW;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Ooo };
        this.cardNo = EnumController.CardNo.AT_WX02_A05;
        this.name = "BMO: Conversation Parade";
        this.power = 1000;
        this.isCounter = true;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = new Effect_AT_WX02_A05();
    }
}
