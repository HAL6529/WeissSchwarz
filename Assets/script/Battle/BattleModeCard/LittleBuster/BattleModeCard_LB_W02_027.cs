using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_027 : BattleModeCard
{
    public BattleModeCard_LB_W02_027()
    {
        this.level = 2;
        this.cost = 1;
        this.soul = 1;
        this.color = EnumController.CardColor.GREEN;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Animal };
        this.cardNo = EnumController.CardNo.LB_W02_027;
        this.cardName = "ÅgíÖÇÆÇÈÇ›ÅhÉNÉh";
        this.power = 7000;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.isHandEncore = true;
        this.isClockEncore = false;
        this.Explanation1 = stringValues.LB_W02_027_Explanation1;
        this.Explanation2 = stringValues.LB_W02_027_Explanation2;
        this.Explanation3 = "";
        this.Explanation4 = "";
        this.Explanation5 = "";
        this.m_EffectAbstract = null;
    }
}
