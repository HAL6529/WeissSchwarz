using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_071 : BattleModeCard
{
    public BattleModeCard_LB_W02_071()
    {
        this.level = 3;
        this.cost = 0;
        this.soul = -1;
        this.color = EnumController.CardColor.RED;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.EVENT;
        this.attribute = new List<EnumController.Attribute>();
        this.cardNo = EnumController.CardNo.LB_W02_071;
        this.cardName = "ƒNƒŠƒ€ƒ]ƒ“ƒŒƒbƒh‚Ì˜rÍ";
        this.power = -1;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = null;
    }
}
