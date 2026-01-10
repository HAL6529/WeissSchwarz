using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_20T : BattleModeCard
{
    public BattleModeCard_P3_S01_20T()
    {
        this.level = -1;
        this.cost = -1;
        this.soul = -1;
        this.color = EnumController.CardColor.BLUE;
        this.trigger = EnumController.Trigger.DOUBLE_SOUL;
        this.type = EnumController.Type.CLIMAX;
        this.attribute = new List<EnumController.Attribute>();
        this.cardNo = EnumController.CardNo.P3_S01_20T;
        this.name = "êæÇ¢çáÇ¡ÇΩñÒë©";
        this.power = -1;
        this.isCounter = false;
        this.isGreatPerformance = false;
    }
}
