using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_AT_WX02_A05 : BattleModeCard
{
    public Sprite sprite;
    public int level = 1;
    public int cost = 1;
    public int soul = 1;
    public EnumController.CardColor color = EnumController.CardColor.YELLOW;
    public EnumController.Trigger trigger = EnumController.Trigger.NONE;
    public EnumController.Type type = EnumController.Type.CHARACTER;
    public List<EnumController.Attribute> attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Ooo };
    public EnumController.CardNo cardNo = EnumController.CardNo.AT_WX02_A05;
    public string name = "BMO: Conversation Parade";
    public int power = 1000;
    public bool isCounter = true;
    public bool isGreatPerformance = false;
    public EffectAbstract m_EffectAbstract = null;
}
