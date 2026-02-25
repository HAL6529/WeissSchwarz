using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_DC_W01_02T : BattleModeCard
{
    public BattleModeCard_DC_W01_02T()
    {
        this.level = 3;
        this.cost = 2;
        this.soul = 2;
        this.color = EnumController.CardColor.GREEN;
        this.trigger = EnumController.Trigger.SOUL;
        this.type = EnumController.Type.CHARACTER;
        this.attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Magic, EnumController.Attribute.Music};
        this.cardNo = EnumController.CardNo.DC_W01_02T;
        this.cardName = "Ž„•ž‚Ì‚±‚Æ‚è";
        this.power = 9500;
        this.isCounter = false;
        this.isGreatPerformance = true;
        this.isHandEncore = false;
        this.isClockEncore = false;
        this.Explanation1 = stringValues.DC_W01_02T_Explanation1;
        this.Explanation2 = stringValues.DC_W01_02T_Explanation2;
        this.Explanation3 = stringValues.DC_W01_02T_Explanation3;
        this.Explanation4 = "";
        this.Explanation5 = "";
        this.m_EffectAbstract = new Effect_DC_W01_02T();
    }
}
