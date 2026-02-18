using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_DC_W01_09T : BattleModeCard
{
    public BattleModeCard_DC_W01_09T()
    {
        this.level = 0;
        this.cost = 0;
        this.soul = 1;
        this.color = EnumController.CardColor.RED;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Teacher, EnumController.Attribute.Glasses };
        this.cardNo = EnumController.CardNo.DC_W01_09T;
        this.name = "”’‰Í —ï";
        this.power = 500;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = null;
    }
}
