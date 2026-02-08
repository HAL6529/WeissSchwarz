using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_046 : BattleModeCard
{
    public BattleModeCard_LB_W02_046()
    {
        this.level = 1;
        this.cost = 0;
        this.soul = -1;
        this.color = EnumController.CardColor.GREEN;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.EVENT;
        this.attribute = new List<EnumController.Attribute>();
        this.cardNo = EnumController.CardNo.LB_W02_046;
        this.name = "‚Ô‚ç‚Á‚­‚Ù‚í‚¢‚Æ";
        this.power = -1;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = null;
    }
}
