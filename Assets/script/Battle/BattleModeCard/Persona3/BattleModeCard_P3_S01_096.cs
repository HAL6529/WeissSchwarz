using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_096 : BattleModeCard
{
    public BattleModeCard_P3_S01_096()
    {
        this.level = 1;
        this.cost = 0;
        this.soul = -1;
        this.color = EnumController.CardColor.BLUE;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.EVENT;
        this.attribute = new List<EnumController.Attribute>();
        this.cardNo = EnumController.CardNo.P3_S01_096;
        this.name = "青ひげファーマシー";
        this.power = -1;
        this.isCounter = true;
        this.isGreatPerformance = false;
    }
}
