using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EnumController;
using ExtendUtil;

public class BattleModeCard : MonoBehaviour
{
    public Sprite sprite;
    public int level;
    public int cost;
    public int soul;
    public EnumController.CardColor color;
    public EnumController.Trigger trigger;
    public EnumController.Type type;
    public List<EnumController.Attribute> attribute = new List<EnumController.Attribute>();
    public EnumController.CardNo cardNo;
    public string name;
    public int power;
    public bool isCounter;
    public bool isGreatPerformance;
    public EffectAbstract m_EffectAbstract;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public BattleModeCard()
    {

    }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="cardNo">カードナンバー</param>
    public BattleModeCard(EnumController.CardNo cardNo)
    {
        this.cardNo = cardNo;
    }

    public BattleModeCard(Sprite sprite,
                   int level,
                   int cost,
                   EnumController.CardColor color,
                   EnumController.Trigger trigger,
                   EnumController.Type type,
                   List<EnumController.Attribute> attribute,
                   EnumController.CardNo cardNo,
                   string name,
                   int soul,
                   int power,
                   bool isCounter)
    {
        this.sprite = sprite;
        this.level = level;
        this.cost = cost;
        this.color = color;
        this.trigger = trigger;
        this.type = type;
        this.attribute = attribute;
        this.cardNo = cardNo;
        this.name = name;
        this.soul = soul;
        this.power = power;
        this.isCounter = isCounter;
    }
}
