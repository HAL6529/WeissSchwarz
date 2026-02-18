using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_069 : BattleModeCard
{
    public BattleModeCard_P3_S01_069()
    {
        this.level = 2;
        this.cost = 1;
        this.soul = -1;
        this.color = EnumController.CardColor.RED;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.EVENT;
        this.attribute = new List<EnumController.Attribute>();
        this.cardNo = EnumController.CardNo.P3_S01_069;
        this.name = "DEATH/éÄê_";
        this.power = -1;
        this.isCounter = false;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = new Effect_P3_S01_069();
    }
}
