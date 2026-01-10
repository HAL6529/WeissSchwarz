using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_DC_W01_05T : BattleModeCard
{
    public BattleModeCard_DC_W01_05T()
    {
        this.level = 2;
        this.cost = 2;
        this.soul = 2;
        this.color = EnumController.CardColor.GREEN;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Music, EnumController.Attribute.Magic};
        this.cardNo = EnumController.CardNo.DC_W01_05T;
        this.name = "è¨óˆÅïÇ»Ç»Ç©";
        this.power = 8000;
        this.isCounter = false;
        this.isGreatPerformance = false;
    }
}
