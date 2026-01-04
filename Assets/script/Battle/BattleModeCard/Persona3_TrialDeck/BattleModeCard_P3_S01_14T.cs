using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_P3_S01_14T : BattleModeCard
{
    public Sprite sprite;
    public int level = -1;
    public int cost = -1;
    public int soul = -1;
    public EnumController.CardColor color = EnumController.CardColor.YELLOW;
    public EnumController.Trigger trigger = EnumController.Trigger.DOUBLE_SOUL;
    public EnumController.Type type = EnumController.Type.CLIMAX;
    public List<EnumController.Attribute> attribute = new List<EnumController.Attribute>();
    public EnumController.CardNo cardNo = EnumController.CardNo.P3_S01_14T;
    public string name = "ç≈å„ÇÃëIë";
    public int power = -1;
    public bool isCounter = false;
    public bool isGreatPerformance = false;
    public EffectAbstract m_EffectAbstract = null;
}
