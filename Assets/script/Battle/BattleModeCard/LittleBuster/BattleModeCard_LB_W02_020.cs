using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_020 : BattleModeCard
{
    public BattleModeCard_LB_W02_020()
    {
        this.level = 2;
        this.cost = 1;
        this.soul = -1;
        this.color = EnumController.CardColor.YELLOW;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.EVENT;
        this.attribute = new List<EnumController.Attribute>();
        this.cardNo = EnumController.CardNo.LB_W02_020;
        this.cardName = "Ç®îwíÜó¨ÇµÇ‹Ç∑ÇÊÅ[";
        this.power = -1;
        this.isCounter = true;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = null;
    }
}
