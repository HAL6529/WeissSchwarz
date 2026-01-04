using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_19T : BattleModeCard
{
    public Sprite sprite;
    public int level = 2;
    public int cost = 1;
    public int soul = 1;
    public EnumController.CardColor color = EnumController.CardColor.BLUE;
    public EnumController.Trigger trigger = EnumController.Trigger.SOUL;
    public EnumController.Type type = EnumController.Type.CHARACTER;
    public List<EnumController.Attribute> attribute = new List<EnumController.Attribute>() { EnumController.Attribute.StudentCouncil, EnumController.Attribute.God };
    public EnumController.CardNo cardNo = EnumController.CardNo.P3_S01_19T;
    public string name = "美鶴＆アルテミシア";
    public int power = 6000;
    public bool isCounter = false;
    public bool isGreatPerformance = false;
    public EffectAbstract m_EffectAbstract = null;
}
