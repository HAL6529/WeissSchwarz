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
        this.cardName = "‘õ‚³‚ê‚é‚à‚Ì";
        this.power = 500;
        this.isCounter = true;
        this.isGreatPerformance = false;
        this.isHandEncore = false;
        this.isClockEncore = false;
        this.Explanation1 = stringValues.LB_W02_076_Explanation1;
        this.Explanation2 = stringValues.LB_W02_076_Explanation2;
        this.Explanation3 = "";
        this.Explanation4 = "";
        this.Explanation5 = "";
        this.m_EffectAbstract = new Effect_LB_W02_076();
    }
}
