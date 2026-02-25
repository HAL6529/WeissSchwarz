using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_090 : BattleModeCard
{
    public BattleModeCard_LB_W02_090()
    {
        this.level = 1;
        this.cost = 0;
        this.soul = 1;
        this.color = EnumController.CardColor.BLUE;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Animal};
        this.cardNo = EnumController.CardNo.LB_W02_090;
        this.cardName = "クド＆ストレルカ";
        this.power = 3500;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.isHandEncore = false;
        this.isClockEncore = false;
        this.Explanation1 = stringValues.LB_W02_090_Explanation1;
        this.Explanation2 = stringValues.LB_W02_090_Explanation2;
        this.Explanation3 = stringValues.LB_W02_090_Explanation3;
        this.Explanation4 = "";
        this.Explanation5 = "";
        this.m_EffectAbstract = null;
    }
}
