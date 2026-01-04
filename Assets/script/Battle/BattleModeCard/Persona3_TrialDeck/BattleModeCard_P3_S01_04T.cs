using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_04T : BattleModeCard
{
    public Sprite sprite;
    public int level = 1;
    public int cost = 1;
    public int soul = 1;
    public EnumController.CardColor color = EnumController.CardColor.YELLOW;
    public EnumController.Trigger trigger = EnumController.Trigger.SOUL;
    public EnumController.Type type = EnumController.Type.CHARACTER;
    public List<EnumController.Attribute> attribute = new List<EnumController.Attribute>() { EnumController.Attribute.TVMailOrder };
    public EnumController.CardNo cardNo = EnumController.CardNo.P3_S01_04T;
    public string name = "‚½‚È‚©ŽÐ’·";
    public int power = 1500;
    public bool isCounter = false;
    public bool isGreatPerformance = false;
    public EffectAbstract m_EffectAbstract = new Effect_P3_S01_04T();
}
