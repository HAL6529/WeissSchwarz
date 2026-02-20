using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_055 : BattleModeCard
{
    public BattleModeCard_P3_S01_055()
    {
        this.level = 2;
        this.cost = 2;
        this.soul = 2;
        this.color = EnumController.CardColor.RED;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Weapon, EnumController.Attribute.God };
        this.cardNo = EnumController.CardNo.P3_S01_055;
        this.cardName = "順平＆トリスメギストス";
        this.power = 7500;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = new Effect_P3_S01_055();
    }
}
