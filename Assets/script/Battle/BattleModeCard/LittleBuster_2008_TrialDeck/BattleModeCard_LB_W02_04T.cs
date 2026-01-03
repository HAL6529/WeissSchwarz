using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_04T : BattleModeCard
{
    public Sprite sprite;
    public int level = 1;
    public int cost = 1;
    public int soul = -1;
    public EnumController.CardColor color = EnumController.CardColor.GREEN;
    public EnumController.Trigger trigger = EnumController.Trigger.NONE;
    public EnumController.Type type = EnumController.Type.EVENT;
    public List<EnumController.Attribute> attribute = new List<EnumController.Attribute>();
    public EnumController.CardNo cardNo = EnumController.CardNo.LB_W02_04T;
    public string name = "‹Ù‹}Ž–‘Ô";
    public int power = -1;
    public bool isCounter = true;
    public bool isGreatPerformance = false;
    public EffectAbstract m_EffectAbstract = new Effect_LB_W02_04T();
}
