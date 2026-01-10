using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_097 : BattleModeCard
{
    public BattleModeCard_P3_S01_097()
    {
        this.level = 3;
        this.cost = 3;
        this.soul = -1;
        this.color = EnumController.CardColor.BLUE;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.EVENT;
        this.attribute = new List<EnumController.Attribute>();
        this.cardNo = EnumController.CardNo.P3_S01_097;
        this.name = "シャッフルタイム";
        this.power = -1;
        this.isCounter = false;
        this.isGreatPerformance = false;
    }
}
