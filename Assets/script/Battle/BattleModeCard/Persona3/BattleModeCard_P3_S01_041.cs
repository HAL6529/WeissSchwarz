using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_041 : BattleModeCard
{
    public BattleModeCard_P3_S01_041()
    {
        this.level = 1;
        this.cost = 1;
        this.soul = 1;
        this.color = EnumController.CardColor.GREEN;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Teacher, EnumController.Attribute.OnlineGame };
        this.cardNo = EnumController.CardNo.P3_S01_041;
        this.name = "íπäCêÊê∂";
        this.power = 4000;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = null;
    }
}
