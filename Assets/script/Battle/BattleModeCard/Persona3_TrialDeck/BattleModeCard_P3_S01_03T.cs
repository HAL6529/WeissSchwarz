using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_03T : BattleModeCard
{
    public Sprite sprite;
    public int level = 1;
    public int cost = 1;
    public int soul = 1;
    public EnumController.CardColor color = EnumController.CardColor.YELLOW;
    public EnumController.Trigger trigger = EnumController.Trigger.SOUL;
    public EnumController.Type type = EnumController.Type.CHARACTER;
    public List<EnumController.Attribute> attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Animal, EnumController.Attribute.Weapon };
    public EnumController.CardNo cardNo = EnumController.CardNo.P3_S01_03T;
    public string name = "—F‹ß Œ’“ñ";
    public int power = 2000;
    public bool isCounter = true;
    public bool isGreatPerformance = false;
    public EffectAbstract m_EffectAbstract = null;
}
