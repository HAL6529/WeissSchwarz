using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_DC_W01_07T : BattleModeCard
{
    public BattleModeCard_DC_W01_07T()
    {
        this.level = 2;
        this.cost = 2;
        this.soul = 2;
        this.color = EnumController.CardColor.RED;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Glasses, EnumController.Attribute.Comics };
        this.cardNo = EnumController.CardNo.DC_W01_07T;
        this.cardName = "–Ÿ‰æ‰Æ‚Ì‚È‚È‚±";
        this.power = 7000;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.isHandEncore = false;
        this.isClockEncore = false;
        this.Explanation1 = stringValues.DC_W01_07T_Explanation1;
        this.Explanation2 = stringValues.DC_W01_07T_Explanation2;
        this.Explanation3 = "";
        this.Explanation4 = "";
        this.Explanation5 = "";
        this.m_EffectAbstract = new Effect_DC_W01_07T();
    }
}
