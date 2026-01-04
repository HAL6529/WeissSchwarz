using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_DC_W01_05T : BattleModeCard
{
    public Sprite sprite;
    public int level = 2;
    public int cost = 2;
    public int soul = 2;
    public EnumController.CardColor color = EnumController.CardColor.GREEN;
    public EnumController.Trigger trigger = EnumController.Trigger.SOUL;
    public EnumController.Type type = EnumController.Type.CHARACTER;
    public List<EnumController.Attribute> attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Music, EnumController.Attribute.Magic };
    public EnumController.CardNo cardNo = EnumController.CardNo.DC_W01_05T;
    public string name = "è¨óˆÅïÇ»Ç»Ç©";
    public int power = 8000;
    public bool isCounter = false;
    public bool isGreatPerformance = false;
    public EffectAbstract m_EffectAbstract = new Effect_DC_W01_05T();
}
