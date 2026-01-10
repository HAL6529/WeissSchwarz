using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_022 : BattleModeCard
{
    public BattleModeCard_P3_S01_022()
    {
        this.level = 1;
        this.cost = 2;
        this.soul = -1;
        this.color = EnumController.CardColor.YELLOW;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.EVENT;
        this.attribute = new List<EnumController.Attribute>();
        this.cardNo = EnumController.CardNo.P3_S01_022;
        this.name = "ê^è™ì∞";
        this.power = -1;
        this.isCounter = true;
        this.isGreatPerformance = false;
    }
}
