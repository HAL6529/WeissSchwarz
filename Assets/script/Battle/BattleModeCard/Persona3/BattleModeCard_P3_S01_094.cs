using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_094 : BattleModeCard
{
    public BattleModeCard_P3_S01_094()
    {
        this.level = 2;
        this.cost = 4;
        this.soul = -1;
        this.color = EnumController.CardColor.BLUE;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.EVENT;
        this.attribute = new List<EnumController.Attribute>();
        this.cardNo = EnumController.CardNo.P3_S01_094;
        this.cardName = "ジャックブラザーズ";
        this.power = -1;
        this.isCounter = true;
        this.isGreatPerformance = false;
        this.m_EffectAbstract = new Effect_P3_S01_094();
    }
}
