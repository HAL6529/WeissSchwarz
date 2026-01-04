using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_11T : BattleModeCard
{
    public Sprite sprite;
    public int level = 2;
    public int cost = 2;
    public int soul = 2;
    public EnumController.CardColor color = EnumController.CardColor.YELLOW;
    public EnumController.Trigger trigger = EnumController.Trigger.SOUL;
    public EnumController.Type type = EnumController.Type.CHARACTER;
    public List<EnumController.Attribute> attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Magic, EnumController.Attribute.God };
    public EnumController.CardNo cardNo = EnumController.CardNo.P3_S01_11T;
    public string name = "主人公＆タナトス";
    public int power = 8000;
    public bool isCounter = false;
    public bool isGreatPerformance = false;
    public EffectAbstract m_EffectAbstract = new Effect_P3_S01_11T();
}
