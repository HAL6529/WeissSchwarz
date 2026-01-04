using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_08T : BattleModeCard
{
    public Sprite sprite;
    public int level = 0;
    public int cost = 0;
    public int soul = 1;
    public EnumController.CardColor color = EnumController.CardColor.YELLOW;
    public EnumController.Trigger trigger = EnumController.Trigger.NONE;
    public EnumController.Type type = EnumController.Type.CHARACTER;
    public List<EnumController.Attribute> attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Animal, EnumController.Attribute.Fan };
    public EnumController.CardNo cardNo = EnumController.CardNo.P3_S01_08T;
    public string name = "ƒxƒx";
    public int power = 3000;
    public bool isCounter = false;
    public bool isGreatPerformance = false;
    public EffectAbstract m_EffectAbstract = null;
}
