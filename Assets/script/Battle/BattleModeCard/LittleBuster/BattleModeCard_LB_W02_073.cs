using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_073 : BattleModeCard
{
    public BattleModeCard_LB_W02_073()
    {
        this.level = -1;
        this.cost = -1;
        this.soul = -1;
        this.color = EnumController.CardColor.RED;
        this.trigger = EnumController.Trigger.DOUBLE_SOUL;
        this.type = EnumController.Type.CLIMAX;
        this.attribute = new List<EnumController.Attribute>();
        this.cardNo = EnumController.CardNo.LB_W02_073;
        this.name = "リトルバスターズ！";
        this.power = -1;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = null;
    }
}
