using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_11T : BattleModeCard
{
    public BattleModeCard_P3_S01_11T()
    {
        this.level = 2;
        this.cost = 2;
        this.soul = 2;
        this.color = EnumController.CardColor.YELLOW;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Magic, EnumController.Attribute.God };
        this.cardNo = EnumController.CardNo.P3_S01_11T;
        this.cardName = "主人公＆タナトス";
        this.power = 8000;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.Explanation1 = stringValues.P3_S01_11T_Explanation1;
        this.Explanation2 = stringValues.P3_S01_11T_Explanation2;
        this.Explanation3 = "";
        this.Explanation4 = "";
        this.Explanation5 = "";
        this.m_EffectAbstract = new Effect_P3_S01_11T();
    }
}
