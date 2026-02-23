using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_015 : BattleModeCard
{
    public BattleModeCard_P3_S01_015()
    {
        this.level = 1;
        this.cost = 0;
        this.soul = 1;
        this.color = EnumController.CardColor.YELLOW;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.SchoolBag };
        this.cardNo = EnumController.CardNo.P3_S01_015;
        this.cardName = "•‘Žq";
        this.power = 4000;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.Explanation1 = stringValues.P3_S01_015_Explanation1;
        this.Explanation2 = "";
        this.Explanation3 = "";
        this.Explanation4 = "";
        this.Explanation5 = "";
        this.m_EffectAbstract = null;
    }
}
