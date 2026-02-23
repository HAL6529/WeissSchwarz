using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_036 : BattleModeCard
{
    public BattleModeCard_P3_S01_036()
    {
        this.level = 3;
        this.cost = 2;
        this.soul = 2;
        this.color = EnumController.CardColor.GREEN;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Mecha, EnumController.Attribute.God };
        this.cardNo = EnumController.CardNo.P3_S01_036;
        this.cardName = "アイギス＆アテナ";
        this.power = 9500;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.Explanation1 = stringValues.P3_S01_036_Explanation1;
        this.Explanation2 = stringValues.P3_S01_036_Explanation2;
        this.Explanation3 = stringValues.P3_S01_036_Explanation3;
        this.Explanation4 = "";
        this.Explanation5 = "";
        this.m_EffectAbstract = null;
    }
}
