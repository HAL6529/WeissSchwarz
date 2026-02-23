using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_091 : BattleModeCard
{
    public BattleModeCard_P3_S01_091()
    {
        this.level = 1;
        this.cost = 1;
        this.soul = 1;
        this.color = EnumController.CardColor.BLUE;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Magic, EnumController.Attribute.Weapon };
        this.cardNo = EnumController.CardNo.P3_S01_091;
        this.cardName = "Šx‰H ‚ä‚©‚è";
        this.power = 1500;
        this.isCounter = true;
        this.isGreatPerformance = false;
        this.Explanation1 = stringValues.P3_S01_091_Explanation1;
        this.Explanation2 = stringValues.P3_S01_091_Explanation2;
        this.Explanation3 = "";
        this.Explanation4 = "";
        this.Explanation5 = "";
        this.m_EffectAbstract = new Effect_P3_S01_091();
    }
}
