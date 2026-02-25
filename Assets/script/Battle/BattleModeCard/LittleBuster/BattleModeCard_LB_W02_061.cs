using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_061 : BattleModeCard
{
    public BattleModeCard_LB_W02_061()
    {
        this.level = 2;
        this.cost = 1;
        this.soul = 1;
        this.color = EnumController.CardColor.RED;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Marble, EnumController.Attribute.Chairperson };
        this.cardNo = EnumController.CardNo.LB_W02_061;
        this.cardName = "ótóØâ¿Åïâ¿ìﬁëΩ";
        this.power = 8500;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.isHandEncore = false;
        this.isClockEncore = false;
        this.Explanation1 = stringValues.LB_W02_061_Explanation1;
        this.Explanation2 = "";
        this.Explanation3 = "";
        this.Explanation4 = "";
        this.Explanation5 = "";
        this.m_EffectAbstract = null;
    }
}
