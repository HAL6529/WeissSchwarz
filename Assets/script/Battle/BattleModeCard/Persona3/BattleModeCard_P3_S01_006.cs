using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_006 : BattleModeCard
{
    public BattleModeCard_P3_S01_006()
    {
        this.level = 3;
        this.cost = 2;
        this.soul = 2;
        this.color = EnumController.CardColor.YELLOW;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Magic, EnumController.Attribute.God };
        this.cardNo = EnumController.CardNo.P3_S01_006;
        this.cardName = "主人公＆メサイア";
        this.power = 9000;
        this.isCounter = false;
        this.isGreatPerformance = true;
        this.m_EffectAbstract = null;
    }
}
