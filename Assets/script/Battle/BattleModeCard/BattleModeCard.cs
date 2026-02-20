using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EnumController;
using ExtendUtil;

public abstract class BattleModeCard : MonoBehaviour
{
    public Sprite sprite;
    protected int level;
    protected int cost;
    protected int soul;
    protected EnumController.CardColor color;
    protected EnumController.Trigger trigger;
    protected EnumController.Type type;
    protected List<EnumController.Attribute> attribute = new List<EnumController.Attribute>();
    protected EnumController.CardNo cardNo;
    protected string cardName;
    protected int power;
    protected bool isCounter;
    protected bool isGreatPerformance;
    public EffectAbstract m_EffectAbstract;

    public Sprite GetSprite() { return sprite; }

    public int GetLevel() { return level; }

    public int GetCost() { return cost; }

    public int GetSoul() { return soul; }

    public EnumController.CardColor GetCardColor() { return color; }

    public EnumController.Trigger GetTrigger() { return trigger; }

    public EnumController.Type GetType() { return type; }

    public List<EnumController.Attribute> GetAttribute() { return attribute; }

    public EnumController.Attribute GetAttribute(int num) 
    { 
        if(num > attribute.Count - 1)
        {
            return EnumController.Attribute.VOID;
        }

        return attribute[num]; 
    }

    public EnumController.CardNo GetCardNo() { return cardNo; }

    public string GetName() { return cardName; }

    public int GetPower() { return power; }

    public bool GetIsCounter() {  return isCounter; }

    public bool GetIsGreatPerformance() { return isGreatPerformance; }

    public EffectAbstract GetEffectAbstract() { return m_EffectAbstract; }

    public void SetPower(int power)
    {
        this.power = power;
    }

    public void SetSoul(int soul)
    {
        this.soul = soul;
    }

    public void SetLevel(int level)
    {
        this.level = level;
    }

    public void SetAttribute(List<EnumController.Attribute> attribute)
    {
        this.attribute = attribute;
    }
}
