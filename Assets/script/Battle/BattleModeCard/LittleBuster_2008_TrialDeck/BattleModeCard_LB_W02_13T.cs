using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_LB_W02_13T : BattleModeCard
{
    public Sprite sprite;
    public int level = 0;
    public int cost = 0;
    public int soul = 1;
    public EnumController.CardColor color = EnumController.CardColor.BLUE;
    public EnumController.Trigger trigger = EnumController.Trigger.NONE;
    public EnumController.Type type = EnumController.Type.CHARACTER;
    public List<EnumController.Attribute> attribute = new List<EnumController.Attribute>() { EnumController.Attribute.Book, EnumController.Attribute.Parasol };
    public EnumController.CardNo cardNo = EnumController.CardNo.LB_W02_13T;
    public string name = "“ミステリックブルー”美魚";
    public int power = 2000;
    public bool isCounter = false;
    public bool isGreatPerformance = false;
    public EffectAbstract m_EffectAbstract = null;
}
