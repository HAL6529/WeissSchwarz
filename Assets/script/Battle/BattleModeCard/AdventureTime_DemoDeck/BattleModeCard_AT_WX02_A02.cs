using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_AT_WX02_A02 : BattleModeCard
{
    public Sprite sprite;
    public int level = 0;
    public int cost = 0;
    public int soul = 1;
    public EnumController.CardColor color = EnumController.CardColor.YELLOW;
    public EnumController.Trigger trigger = EnumController.Trigger.NONE;
    public EnumController.Type type = EnumController.Type.CHARACTER;
    public List<EnumController.Attribute> attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Ooo, EnumController.Attribute.Hero };
    public EnumController.CardNo cardNo = EnumController.CardNo.AT_WX02_A02;
    public string name = "Jake: Bacon Pancakes";
    public int power = 2000;
    public bool isCounter = false;
    public bool isGreatPerformance = false;
    public EffectAbstract m_EffectAbstract = null;
}
