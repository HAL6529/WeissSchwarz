using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_006 : BattleModeCard
{
    public Sprite sprite;
    public int level = 3;
    public int cost = 2;
    public int soul = 2;
    public EnumController.CardColor color = EnumController.CardColor.YELLOW;
    public EnumController.Trigger trigger = EnumController.Trigger.SOUL;
    public EnumController.Type type = EnumController.Type.CHARACTER;
    public List<EnumController.Attribute> attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Magic, EnumController.Attribute.God };
    public EnumController.CardNo cardNo = EnumController.CardNo.P3_S01_006;
    public string name = "主人公＆メサイア";
    public int power = 9000;
    public bool isCounter = false;
    public bool isGreatPerformance = true;
    public EffectAbstract m_EffectAbstract = null;
}
