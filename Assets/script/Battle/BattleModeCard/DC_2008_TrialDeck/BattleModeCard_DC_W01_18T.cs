using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_DC_W01_18T : BattleModeCard
{
    public Sprite sprite;
    public int level = 2;
    public int cost = 1;
    public int soul = -1;
    public EnumController.CardColor color = EnumController.CardColor.RED;
    public EnumController.Trigger trigger = EnumController.Trigger.NONE;
    public EnumController.Type type = EnumController.Type.EVENT;
    public List<EnumController.Attribute> attribute = new List<EnumController.Attribute>();
    public EnumController.CardNo cardNo = EnumController.CardNo.DC_W01_18T;
    public string name = "Ç»Ç»Ç±Ç∆ÉÑÉM";
    public int power = -1;
    public bool isCounter = false;
    public bool isGreatPerformance = false;
    public EffectAbstract m_EffectAbstract = new Effect_DC_W01_18T();
}
