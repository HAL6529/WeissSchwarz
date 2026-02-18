using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_DC_W01_04T : BattleModeCard
{
    public BattleModeCard_DC_W01_04T()
    {
        this.level = 0;
        this.cost = 0;
        this.soul = 1;
        this.color = EnumController.CardColor.GREEN;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>();
        this.cardNo = EnumController.CardNo.DC_W01_04T;
        this.name = "â‘çÁ à©";
        this.power = 2500;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = new Effect_DC_W01_04T();
    }
}
