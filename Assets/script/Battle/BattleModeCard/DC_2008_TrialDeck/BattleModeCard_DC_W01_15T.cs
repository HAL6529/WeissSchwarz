using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_DC_W01_15T : BattleModeCard
{
    public BattleModeCard_DC_W01_15T()
    {
        this.level = 1;
        this.cost = 1;
        this.soul = 1;
        this.color = EnumController.CardColor.RED;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Magic };
        this.cardNo = EnumController.CardNo.DC_W01_15T;
        this.name = "‘Ì‘€’…‚Ì—R–²";
        this.power = 6000;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = null;
    }

}
