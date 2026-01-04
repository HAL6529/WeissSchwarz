using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_DC_W01_11T : BattleModeCard
{
    public Sprite sprite;
    public int level = 2;
    public int cost = 2;
    public int soul = 2;
    public EnumController.CardColor color = EnumController.CardColor.RED;
    public EnumController.Trigger trigger = EnumController.Trigger.SOUL;
    public EnumController.Type type = EnumController.Type.CHARACTER;
    public List<EnumController.Attribute> attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Magic, EnumController.Attribute.Banana };
    public EnumController.CardNo cardNo = EnumController.CardNo.DC_W01_11T;
    public string name = "î¸ètÅïâπñ≤";
    public int power = 9000;
    public bool isCounter = false;
    public bool isGreatPerformance = false;
    public EffectAbstract m_EffectAbstract = null;
}
