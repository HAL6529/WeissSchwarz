using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_DC_W01_12T : BattleModeCard
{
    public BattleModeCard_DC_W01_12T()
    {
        this.level = 2;
        this.cost = 2;
        this.soul = -1;
        this.color = EnumController.CardColor.RED;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.EVENT;
        this.attribute = new List<EnumController.Attribute>();
        this.cardNo = EnumController.CardNo.DC_W01_12T;
        this.name = "‚©‚¯‚ª‚¦‚Ì‚È‚¢’‡ŠÔ";
        this.power = -1;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = new Effect_DC_W01_12T();
    }
}
