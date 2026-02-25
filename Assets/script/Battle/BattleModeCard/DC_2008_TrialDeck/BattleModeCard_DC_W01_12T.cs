using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_DC_W01_12T : BattleModeCard
{
    public BattleModeCard_DC_W01_12T()
    {
        this.level = 2;
        this.cost = 2;
        this.soul = -1;
        this.color = EnumController.CardColor.RED;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.EVENT;
        this.attribute = new List<EnumController.Attribute>();
        this.cardNo = EnumController.CardNo.DC_W01_12T;
        this.cardName = "‚©‚¯‚ª‚¦‚Ì‚È‚¢’‡ŠÔ";
        this.power = -1;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.isHandEncore = false;
        this.isClockEncore = false;
        this.Explanation1 = stringValues.DC_W01_12T_Explanation1;
        this.Explanation2 = "";
        this.Explanation3 = "";
        this.Explanation4 = "";
        this.Explanation5 = "";
        this.m_EffectAbstract = new Effect_DC_W01_12T();
    }
}
