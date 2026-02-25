using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_14T : BattleModeCard
{
    public BattleModeCard_P3_S01_14T()
    {
        this.level = -1;
        this.cost = -1;
        this.soul = -1;
        this.color = EnumController.CardColor.YELLOW;
        this.trigger = EnumController.Trigger.DOUBLE_SOUL;
        this.type = EnumController.Type.CLIMAX;
        this.attribute = new List<EnumController.Attribute>();
        this.cardNo = EnumController.CardNo.P3_S01_14T;
        this.cardName = "ç≈å„ÇÃëIë";
        this.power = -1;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.isHandEncore = false;
        this.isClockEncore = false;
        this.Explanation1 = stringValues.P3_S01_14T_Explanation1;
        this.Explanation2 = "";
        this.Explanation3 = "";
        this.Explanation4 = "";
        this.Explanation5 = "";
        this.m_EffectAbstract = null;
    }
}
