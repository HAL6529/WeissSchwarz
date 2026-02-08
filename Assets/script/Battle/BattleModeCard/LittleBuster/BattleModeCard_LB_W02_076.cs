using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_076 : BattleModeCard
{
    public BattleModeCard_LB_W02_076()
    {
        this.level = 0;
        this.cost = 0;
        this.soul = 1;
        this.color = EnumController.CardColor.BLUE;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Sports, EnumController.Attribute.FairyTale };
        this.cardNo = EnumController.CardNo.LB_W02_076;
        this.name = "‘õ‚³‚ê‚é‚à‚Ì";
        this.power = 500;
        this.isCounter = true;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = new Effect_LB_W02_076();
    }
}
