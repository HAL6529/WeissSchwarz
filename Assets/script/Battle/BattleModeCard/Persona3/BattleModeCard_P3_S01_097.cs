using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_097 : BattleModeCard
{
    public BattleModeCard_P3_S01_097()
    {
        this.level = 3;
        this.cost = 3;
        this.soul = -1;
        this.color = EnumController.CardColor.BLUE;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.EVENT;
        this.attribute = new List<EnumController.Attribute>();
        this.cardNo = EnumController.CardNo.P3_S01_097;
        this.cardName = "シャッフルタイム";
        this.power = -1;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.isHandEncore = false;
        this.isClockEncore = false;
        this.Explanation1 = stringValues.P3_S01_097_Explanation1;
        this.Explanation2 = "";
        this.Explanation3 = "";
        this.Explanation4 = "";
        this.Explanation5 = "";
        this.m_EffectAbstract = null;
    }
}
