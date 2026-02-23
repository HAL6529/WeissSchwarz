using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_057 : BattleModeCard
{
    public BattleModeCard_P3_S01_057()
    {
        this.level = 0;
        this.cost = 0;
        this.soul = 1;
        this.color = EnumController.CardColor.RED;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Magic, EnumController.Attribute.Weapon };
        this.cardNo = EnumController.CardNo.P3_S01_057;
        this.cardName = "çrä_ ê^éüòY";
        this.power = 1500;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.Explanation1 = stringValues.P3_S01_057_Explanation1;
        this.Explanation2 = stringValues.P3_S01_057_Explanation2;
        this.Explanation3 = "";
        this.Explanation4 = "";
        this.Explanation5 = "";
        this.m_EffectAbstract = new Effect_P3_S01_057();
    }
}
