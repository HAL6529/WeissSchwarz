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
    public EnumController.Attribute attributeOne;
    public EnumController.Attribute attributeTwo;
    public EnumController.Attribute attributeThree;
    public EnumController.CardNo cardNo;
    public string name;
    public int power;
    public bool isCounter;
    public string explanation;

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
                   EnumController.Attribute attributeOne,
                   EnumController.Attribute attributeTwo,
                   EnumController.Attribute attributeThree,
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
        this.attributeOne = attributeOne;
        this.attributeTwo = attributeTwo;
        this.attributeThree = attributeThree;
        this.cardNo = cardNo;
        this.name = name;
        this.soul = soul;
        this.power = power;
        this.isCounter = isCounter;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
