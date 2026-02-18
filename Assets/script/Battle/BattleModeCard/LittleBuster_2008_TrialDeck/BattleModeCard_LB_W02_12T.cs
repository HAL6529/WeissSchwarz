using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_12T : BattleModeCard
{
    public BattleModeCard_LB_W02_12T()
    {
        this.level = 1;
        this.cost = 1;
        this.soul = -1;
        this.color = EnumController.CardColor.BLUE;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.EVENT;
        this.attribute = new List<EnumController.Attribute>();
        this.cardNo = EnumController.CardNo.LB_W02_12T;
        this.name = "‚ ‚ß‚è‚©‚ñ‚È—V‚Ñ";
        this.power = -1;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = new Effect_LB_W02_12T();
    }
}
