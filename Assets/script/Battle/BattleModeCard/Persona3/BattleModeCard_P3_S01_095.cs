using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_095 : BattleModeCard
{
    public BattleModeCard_P3_S01_095()
    {
        this.level = 3;
        this.cost = 8;
        this.soul = -1;
        this.color = EnumController.CardColor.BLUE;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.EVENT;
        this.attribute = new List<EnumController.Attribute>();
        this.cardNo = EnumController.CardNo.P3_S01_095;
        this.name = "èàåY";
        this.power = -1;
        this.isCounter = false;
        this.isGreatPerformance = false;
    }
}
