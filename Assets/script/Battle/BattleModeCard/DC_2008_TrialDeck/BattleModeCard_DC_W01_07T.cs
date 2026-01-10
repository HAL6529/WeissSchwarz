using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_DC_W01_07T : BattleModeCard
{
    public BattleModeCard_DC_W01_07T()
    {
        this.level = 2;
        this.cost = 2;
        this.soul = 2;
        this.color = EnumController.CardColor.RED;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Glasses, EnumController.Attribute.Comics };
        this.cardNo = EnumController.CardNo.DC_W01_07T;
        this.name = "–Ÿ‰æ‰Æ‚Ì‚È‚È‚±";
        this.power = 7000;
        this.isCounter = false;
        this.isGreatPerformance = false;
    }
}
