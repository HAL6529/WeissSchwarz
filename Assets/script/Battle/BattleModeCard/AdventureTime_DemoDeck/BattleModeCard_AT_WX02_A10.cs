using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_AT_WX02_A10 : BattleModeCard
{
    public BattleModeCard_AT_WX02_A10()
    {
        this.level = 0;
        this.cost = 0;
        this.soul = 1;
        this.color = EnumController.CardColor.RED;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Ooo, EnumController.Attribute.Royalty };
        this.cardNo = EnumController.CardNo.AT_WX02_A10;
        this.cardName = "Princess Bubblegum: Tea Ceremony Adept";
        this.power = 1000;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = new Effect_AT_WX02_A10();
    }
}
