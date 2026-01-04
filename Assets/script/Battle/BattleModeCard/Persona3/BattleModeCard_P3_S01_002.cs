using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_002 : BattleModeCard
{
    public Sprite sprite;
    public int level = 1;
    public int cost = 0;
    public int soul = 1;
    public EnumController.CardColor color = EnumController.CardColor.YELLOW;
    public EnumController.Trigger trigger = EnumController.Trigger.NONE;
    public EnumController.Type type = EnumController.Type.CHARACTER;
    public List<EnumController.Attribute> attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Magic, EnumController.Attribute.Weapon };
    public EnumController.CardNo cardNo = EnumController.CardNo.P3_S01_002;
    public string name = "主人公＆オルフェウス";
    public int power = 4000;
    public bool isCounter = false;
    public bool isGreatPerformance = false;
    public EffectAbstract m_EffectAbstract = new Effect_P3_S01_002();
}
