using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_DC_W01_02T : BattleModeCard
{
    public Sprite sprite;
    public int level = 3;
    public int cost = 2;
    public int soul = 2;
    public EnumController.CardColor color = EnumController.CardColor.GREEN;
    public EnumController.Trigger trigger = EnumController.Trigger.SOUL;
    public EnumController.Type type = EnumController.Type.CHARACTER;
    public List<EnumController.Attribute> attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Magic, EnumController.Attribute.Music };
    public EnumController.CardNo cardNo = EnumController.CardNo.DC_W01_02T;
    public string name = "Ž„•ž‚Ì‚±‚Æ‚è";
    public int power = 9500;
    public bool isCounter = false;
    public bool isGreatPerformance = false;
    public EffectAbstract m_EffectAbstract = new Effect_DC_W01_02T();
}
