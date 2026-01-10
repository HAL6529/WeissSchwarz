using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_DC_W01_19T : BattleModeCard
{
    public BattleModeCard_DC_W01_19T()
    {
        this.level = -1;
        this.cost = -1;
        this.soul = -1;
        this.color = EnumController.CardColor.RED;
        this.trigger = EnumController.Trigger.COMEBACK;
        this.type = EnumController.Type.CLIMAX;
        this.attribute = new List<EnumController.Attribute>();
        this.cardNo = EnumController.CardNo.DC_W01_19T;
        this.name = "Ç»Ç»Ç±Ç∆ÉÑÉM";
        this.power = -1;
        this.isCounter = false;
        this.isGreatPerformance = false;
    }
}
