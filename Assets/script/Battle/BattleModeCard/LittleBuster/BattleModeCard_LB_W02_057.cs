using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_057 : BattleModeCard
{
    public BattleModeCard_LB_W02_057()
    {
        this.level = 0;
        this.cost = 0;
        this.soul = 1;
        this.color = EnumController.CardColor.RED;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Book, EnumController.Attribute.Parasol };
        this.cardNo = EnumController.CardNo.LB_W02_057;
        this.cardName = "Ågê‘Ç∏Ç´ÇÒÅhî¸ãõ";
        this.power = 1500;
        this.isCounter = false;
        this.isGreatPerformance = true;
        this.m_EffectAbstract = new Effect_LB_W02_057();
    }
}
