using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_031 : BattleModeCard
{
    public BattleModeCard_P3_S01_031()
    {
        this.level = 2;
        this.cost = 2;
        this.soul = 2;
        this.color = EnumController.CardColor.GREEN;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Mecha, EnumController.Attribute.God };
        this.cardNo = EnumController.CardNo.P3_S01_031;
        this.name = "メティス＆プシュケイ";
        this.power = 8000;
        this.isCounter = false;
        this.isGreatPerformance = false;
    }
}
