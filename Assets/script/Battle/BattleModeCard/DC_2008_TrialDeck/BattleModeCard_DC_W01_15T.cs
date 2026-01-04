using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_DC_W01_15T : BattleModeCard
{
    public Sprite sprite;
    public int level = 1;
    public int cost = 1;
    public int soul = 1;
    public EnumController.CardColor color = EnumController.CardColor.RED;
    public EnumController.Trigger trigger = EnumController.Trigger.SOUL;
    public EnumController.Type type = EnumController.Type.CHARACTER;
    public List<EnumController.Attribute> attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Magic};
    public EnumController.CardNo cardNo = EnumController.CardNo.DC_W01_15T;
    public string name = "‘Ì‘€’…‚Ì—R–²";
    public int power = 6000;
    public bool isCounter = false;
    public bool isGreatPerformance = false;
    public EffectAbstract m_EffectAbstract = null;
}
