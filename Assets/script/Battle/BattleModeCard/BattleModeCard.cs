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
    protected bool isHandEncore;
    protected bool isClockEncore;

    protected string Explanation1;
    protected string Explanation2;
    protected string Explanation3;
    protected string Explanation4;
    protected string Explanation5;

    public EffectAbstract m_EffectAbstract;

    public Sprite GetSprite() { return sprite; }

    public int GetLevel() { return level; }

    public int GetCost() { return cost; }

    public int GetSoul() { return soul; }

    public EnumController.CardColor GetCardColor() { return color; }

    public EnumController.Trigger GetTrigger() { return trigger; }

    public EnumController.Type GetType() { return type; }

    public List<EnumController.Attribute> GetAttribute() { return attribute; }

    protected StringValues stringValues = new StringValues();

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

    public bool GetIsHandEncore() { return isHandEncore; }

    public bool GetIsClockEncore() { return isClockEncore; }

    public string GetExplanation1()
    {
        return Explanation1;
    }

    public string GetExplanation2()
    {
        return Explanation2;
    }

    public string GetExplanation3()
    {
        return Explanation3;
    }

    public string GetExplanation4()
    {
        return Explanation4;
    }

    public string GetExplanation5()
    {
        return Explanation5;
    }

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
