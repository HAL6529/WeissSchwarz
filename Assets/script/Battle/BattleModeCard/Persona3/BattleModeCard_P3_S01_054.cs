using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_054 : BattleModeCard
{
    public BattleModeCard_P3_S01_054()
    {
        this.level = 1;
        this.cost = 0;
        this.soul = 1;
        this.color = EnumController.CardColor.RED;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() {  EnumController.Attribute.Sports };
        this.cardNo = EnumController.CardNo.P3_S01_054;
        this.name = "äùñÏ ÇﬂÇÆÇ›";
        this.power = 5500;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = null;
    }
}
