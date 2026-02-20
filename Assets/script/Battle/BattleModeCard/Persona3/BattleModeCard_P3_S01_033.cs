using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_033 : BattleModeCard
{
    public BattleModeCard_P3_S01_033()
    {
        this.level = 1;
        this.cost = 1;
        this.soul = 1;
        this.color = EnumController.CardColor.GREEN;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Magic, EnumController.Attribute.God };
        this.cardNo = EnumController.CardNo.P3_S01_033;
        this.cardName = "ïóâ‘ÅïÉãÉLÉA";
        this.power = 2000;
        this.isCounter = true;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = new Effect_P3_S01_033();
    }
}
