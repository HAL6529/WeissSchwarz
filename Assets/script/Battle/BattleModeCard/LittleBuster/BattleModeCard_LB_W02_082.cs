using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_082 : BattleModeCard
{
    public BattleModeCard_LB_W02_082()
    {
        this.level = 0;
        this.cost = 0;
        this.soul = 1;
        this.color = EnumController.CardColor.BLUE;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Book, EnumController.Attribute.Parasol };
        this.cardNo = EnumController.CardNo.LB_W02_082;
        this.cardName = "“ミステリックブルー”美魚";
        this.power = 2000;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = null;
    }
}
