using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_035 : BattleModeCard
{
    public BattleModeCard_LB_W02_035()
    {
        this.level = 2;
        this.cost = 2;
        this.soul = 2;
        this.color = EnumController.CardColor.GREEN;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Muscle, EnumController.Attribute.Sports };
        this.cardNo = EnumController.CardNo.LB_W02_035;
        this.cardName = "ê^êlÅïå™å·";
        this.power = 9000;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.isHandEncore = false;
        this.isClockEncore = false;
        this.Explanation1 = stringValues.LB_W02_035_Explanation1;
        this.Explanation2 = "";
        this.Explanation3 = "";
        this.Explanation4 = "";
        this.Explanation5 = "";
        this.m_EffectAbstract = null;
    }
}
