using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_068 : BattleModeCard
{
    public BattleModeCard_LB_W02_068()
    {
        this.level = 2;
        this.cost = 0;
        this.soul = -1;
        this.color = EnumController.CardColor.RED;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.EVENT;
        this.attribute = new List<EnumController.Attribute>();
        this.cardNo = EnumController.CardNo.LB_W02_068;
        this.cardName = "ãæÇÊÅAãæ";
        this.power = -1;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.isHandEncore = false;
        this.isClockEncore = false;
        this.Explanation1 = stringValues.LB_W02_068_Explanation1;
        this.Explanation2 = "";
        this.Explanation3 = "";
        this.Explanation4 = "";
        this.Explanation5 = "";
        this.m_EffectAbstract = null;
    }
}
