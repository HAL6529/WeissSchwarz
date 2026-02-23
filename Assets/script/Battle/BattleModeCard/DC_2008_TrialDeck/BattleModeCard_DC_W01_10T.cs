using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_DC_W01_10T : BattleModeCard
{
    public BattleModeCard_DC_W01_10T()
    {
        this.level = 1;
        this.cost = 1;
        this.soul = 1;
        this.color = EnumController.CardColor.RED;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Mecha, EnumController.Attribute.Banana };
        this.cardNo = EnumController.CardNo.DC_W01_10T;
        this.cardName = "ÉçÉ{î¸èt";
        this.power = 4500;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.Explanation1 = stringValues.DC_W01_10T_Explanation1;
        this.Explanation2 = stringValues.DC_W01_10T_Explanation2;
        this.Explanation3 = "";
        this.Explanation4 = "";
        this.Explanation5 = "";
        this.m_EffectAbstract = new Effect_DC_W01_10T();
    }
}
