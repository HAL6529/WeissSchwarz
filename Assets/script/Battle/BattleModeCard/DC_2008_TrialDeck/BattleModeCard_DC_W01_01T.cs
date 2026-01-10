using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_DC_W01_01T : BattleModeCard
{
    public BattleModeCard_DC_W01_01T()
    {
        this.level = 0;
        this.cost = 0;
        this.soul = 1;
        this.color = EnumController.CardColor.GREEN;
        this.trigger = EnumController.Trigger.NONE;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Magic, EnumController.Attribute.ShrineMaiden};
        this.cardNo = EnumController.CardNo.DC_W01_01T;
        this.name = "ŒÓƒm‹{ ŠÂ";
        this.power = 2000;
        this.isCounter = false;
        this.isGreatPerformance = false;
    }
}
