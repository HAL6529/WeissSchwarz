using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_061 : BattleModeCard
{
    public BattleModeCard_P3_S01_061()
    {
        this.level = 3;
        this.cost = 2;
        this.soul = 2;
        this.color = EnumController.CardColor.RED;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Magic, EnumController.Attribute.God };
        this.cardNo = EnumController.CardNo.P3_S01_061;
        this.cardName = "タカヤ＆ヒュプノス";
        this.power = 8000;
        this.isCounter = false;
        this.isGreatPerformance = true;
        this.Explanation1 = stringValues.P3_S01_061_Explanation1;
        this.Explanation2 = stringValues.P3_S01_061_Explanation2;
        this.Explanation3 = stringValues.P3_S01_061_Explanation3;
        this.Explanation4 = "";
        this.Explanation5 = "";
        this.m_EffectAbstract = new Effect_P3_S01_061();
    }
}
