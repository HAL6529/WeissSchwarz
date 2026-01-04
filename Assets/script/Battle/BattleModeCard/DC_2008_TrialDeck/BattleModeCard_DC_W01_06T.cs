using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCard_DC_W01_06T : BattleModeCard
{
    public Sprite sprite;
    public int level = -1;
    public int cost = -1;
    public int soul = -1;
    public EnumController.CardColor color = EnumController.CardColor.GREEN;
    public EnumController.Trigger trigger = EnumController.Trigger.DOUBLE_SOUL;
    public EnumController.Type type = EnumController.Type.CLIMAX;
    public List<EnumController.Attribute> attribute = new List<EnumController.Attribute>();
    public EnumController.CardNo cardNo = EnumController.CardNo.DC_W01_06T;
    public string name = "åãç•éÆÇÃâÃïP";
    public int power = -1;
    public bool isCounter = false;
    public bool isGreatPerformance = false;
    public EffectAbstract m_EffectAbstract = null;
}
