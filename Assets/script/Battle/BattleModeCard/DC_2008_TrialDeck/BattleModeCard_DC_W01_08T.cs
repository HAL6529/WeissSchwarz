using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_DC_W01_08T : BattleModeCard
{
    public BattleModeCard_DC_W01_08T()
    {
        this.level = 0;
        this.cost = 0;
        this.soul = 1;
        this.color = EnumController.CardColor.RED;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Glasses, EnumController.Attribute.Teacher };
        this.cardNo = EnumController.CardNo.DC_W01_08T;
        this.cardName = "ç éÏ Ç»Ç»Ç±";
        this.power = 500;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.isHandEncore = false;
        this.isClockEncore = false;
        this.Explanation1 = stringValues.DC_W01_08T_Explanation1;
        this.Explanation2 = "";
        this.Explanation3 = "";
        this.Explanation4 = "";
        this.Explanation5 = "";
        this.m_EffectAbstract = null;
    }
}
