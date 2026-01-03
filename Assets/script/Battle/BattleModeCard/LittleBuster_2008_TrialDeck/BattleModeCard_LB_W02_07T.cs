using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_07T : BattleModeCard
{
    public Sprite sprite;
    public int level = 1;
    public int cost = 1;
    public int soul = 1;
    public EnumController.CardColor color = EnumController.CardColor.GREEN;
    public EnumController.Trigger trigger = EnumController.Trigger.NONE;
    public EnumController.Type type = EnumController.Type.CHARACTER;
    public List<EnumController.Attribute> attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Sports };
    public EnumController.CardNo cardNo = EnumController.CardNo.LB_W02_07T;
    public string name = "Ågèóâ§îLÅhç≤ÅXî¸";
    public int power = 1500;
    public bool isCounter = true;
    public bool isGreatPerformance = false;
    public EffectAbstract m_EffectAbstract = new Effect_LB_W02_07T();
}
