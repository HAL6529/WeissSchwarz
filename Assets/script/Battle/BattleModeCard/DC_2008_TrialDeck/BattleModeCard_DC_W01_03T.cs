using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_DC_W01_03T : BattleModeCard
{
    public BattleModeCard_DC_W01_03T()
    {
        this.level = 1;
        this.cost = 0;
        this.soul = -1;
        this.color = EnumController.CardColor.GREEN;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.EVENT;
        this.attribute = new List<EnumController.Attribute>();
        this.cardNo = EnumController.CardNo.DC_W01_03T;
        this.name = "ミス風見学園コンテスト";
        this.power = -1;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = new Effect_DC_W01_03T();
    }
}
