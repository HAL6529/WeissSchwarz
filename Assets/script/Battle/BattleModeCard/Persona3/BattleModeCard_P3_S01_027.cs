using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_027 : BattleModeCard
{
    public BattleModeCard_P3_S01_027()
    {
        this.level = 2;
        this.cost = 2;
        this.soul = 2;
        this.color = EnumController.CardColor.GREEN;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Mecha, EnumController.Attribute.God };
        this.cardNo = EnumController.CardNo.P3_S01_027;
        this.name = "アイギス＆パラディオン";
        this.power = 7500;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = null;
    }
}
