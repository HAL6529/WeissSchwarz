using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_05T : BattleModeCard
{
    public BattleModeCard_P3_S01_05T()
    {
        this.level = 2;
        this.cost = 2;
        this.soul = 2;
        this.color = EnumController.CardColor.YELLOW;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>();
        this.cardNo = EnumController.CardNo.P3_S01_05T;
        this.name = "ê_ãΩ êT";
        this.power = 9000;
        this.isCounter = false;
        this.isGreatPerformance = false;
    }
}
