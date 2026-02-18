using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_005 : BattleModeCard
{
    public BattleModeCard_LB_W02_005()
    {
        this.level = 1;
        this.cost = 0;
        this.soul = 1;
        this.color = EnumController.CardColor.YELLOW;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Sweets, EnumController.Attribute.FairyTale };
        this.cardNo = EnumController.CardNo.LB_W02_005;
        this.name = "ÅgÉiÅ[ÉXïûÅhè¨ü{";
        this.power = 3000;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = null;
    }
}
