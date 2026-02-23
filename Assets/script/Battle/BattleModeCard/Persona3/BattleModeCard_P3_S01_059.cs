using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_059 : BattleModeCard
{
    public BattleModeCard_P3_S01_059()
    {
        this.level = 1;
        this.cost = 1;
        this.soul = 1;
        this.color = EnumController.CardColor.RED;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Weapon, EnumController.Attribute.God };
        this.cardNo = EnumController.CardNo.P3_S01_059;
        this.cardName = "èáïΩÅïÉwÉãÉÅÉX";
        this.power = 5000;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.Explanation1 = stringValues.P3_S01_059_Explanation1;
        this.Explanation2 = stringValues.P3_S01_059_Explanation2;
        this.Explanation3 = "";
        this.Explanation4 = "";
        this.Explanation5 = "";
        this.m_EffectAbstract = null;
    }
}
