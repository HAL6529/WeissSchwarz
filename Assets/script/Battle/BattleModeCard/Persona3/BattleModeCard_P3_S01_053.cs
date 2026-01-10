using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_053 : BattleModeCard
{
    public BattleModeCard_P3_S01_053()
    {
        this.level = 1;
        this.cost = 1;
        this.soul = 1;
        this.color = EnumController.CardColor.RED;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() {  EnumController.Attribute.Sports, EnumController.Attribute.God };
        this.cardNo = EnumController.CardNo.P3_S01_053;
        this.name = "真次郎＆カストール";
        this.power = 4000;
        this.isCounter = false;
        this.isGreatPerformance = false;
    }
}
