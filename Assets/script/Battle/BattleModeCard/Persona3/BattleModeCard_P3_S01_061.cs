using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_061 : BattleModeCard
{
    public BattleModeCard_P3_S01_061()
    {
        this.level = 3;
        this.cost = 2;
        this.soul = 2;
        this.color = EnumController.CardColor.RED;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Magic, EnumController.Attribute.God };
        this.cardNo = EnumController.CardNo.P3_S01_061;
        this.name = "タカヤ＆ヒュプノス";
        this.power = 8000;
        this.isCounter = false;
        this.isGreatPerformance = true;
        this.m_EffectAbstract = new Effect_P3_S01_061();
    }
}
