using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_DC_W01_02T : BattleModeCard
{
    public BattleModeCard_DC_W01_02T()
    {
        this.level = 3;
        this.cost = 2;
        this.soul = 2;
        this.color = EnumController.CardColor.GREEN;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Magic, EnumController.Attribute.Music};
        this.cardNo = EnumController.CardNo.DC_W01_02T;
        this.cardName = "Ž„•ž‚Ì‚±‚Æ‚è";
        this.power = 9500;
        this.isCounter = false;
        this.isGreatPerformance = true;
        this.m_EffectAbstract = new Effect_DC_W01_02T();
    }
}
