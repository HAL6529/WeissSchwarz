using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_003 : BattleModeCard
{
    public Sprite sprite;
    public int level = 0;
    public int cost = 0;
    public int soul = 1;
    public EnumController.CardColor color = EnumController.CardColor.YELLOW;
    public EnumController.Trigger trigger = EnumController.Trigger.NONE;
    public EnumController.Type type = EnumController.Type.CHARACTER;
    public List<EnumController.Attribute> attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Death };
    public EnumController.CardNo cardNo = EnumController.CardNo.P3_S01_003;
    public string name = "ÉtÉ@ÉãÉçÉX";
    public int power = 1000;
    public bool isCounter = false;
    public bool isGreatPerformance = false;
    public EffectAbstract m_EffectAbstract = null;
}
