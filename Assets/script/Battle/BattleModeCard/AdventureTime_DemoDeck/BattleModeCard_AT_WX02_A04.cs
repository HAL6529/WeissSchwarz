using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_AT_WX02_A04 : BattleModeCard
{
    public BattleModeCard_AT_WX02_A04()
    {
        this.level = 1;
        this.cost = 0;
        this.soul = 1;
        this.color = EnumController.CardColor.YELLOW;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Ooo, EnumController.Attribute.Hero };
        this.cardNo = EnumController.CardNo.AT_WX02_A04;
        this.cardName = "Jake: Date at Sunset";
        this.power = 5000;
        this.isCounter = false;
        this.isHandEncore = true;
        this.isClockEncore = false;
        this.Explanation1 = stringValues.AT_WX02_A04_Explanation1;
        this.Explanation2 = "";
        this.Explanation3 = "";
        this.Explanation4 = "";
        this.Explanation5 = "";
        this.isGreatPerformance = false;
    }
}
