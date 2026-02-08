using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_048 : BattleModeCard
{
    public BattleModeCard_LB_W02_048()
    {
        this.level = -1;
        this.cost = -1;
        this.soul = -1;
        this.color = EnumController.CardColor.GREEN;
        this.trigger = EnumController.Trigger.DOUBLE_SOUL;
        this.type = EnumController.Type.CLIMAX;
        this.attribute = new List<EnumController.Attribute>();
        this.cardNo = EnumController.CardNo.LB_W02_048;
        this.name = "‚½‚Á‚½ˆê‚Â‚ÌŽæ‚è•¿";
        this.power = -1;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = null;
    }
}
