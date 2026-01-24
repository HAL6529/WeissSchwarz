using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_087 : BattleModeCard
{
    public BattleModeCard_P3_S01_087()
    {
        this.level = 0;
        this.cost = 0;
        this.soul = 1;
        this.color = EnumController.CardColor.BLUE;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.StudentCouncil, EnumController.Attribute.Glasses };
        this.cardNo = EnumController.CardNo.P3_S01_087;
        this.name = "ïöå© êÁêq";
        this.power = 500;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = new Effect_P3_S01_087();
    }
}
