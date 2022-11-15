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
    public EnumController.CardColor color;
    public EnumController.Trriger trigger;
    public EnumController.Type type;
    public EnumController.Attribute attributeOne;
    public EnumController.Attribute attributeTwo;
    public EnumController.Attribute attributeThree;
    public EnumController.CardNo cardNo;
    public string name;
    public int power;
    bool isCounter;

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
        cardNo = cardNo;
    }

    public BattleModeCard(Sprite sprite,
                   int level,
                   int cost,
                   EnumController.CardColor color,
                   EnumController.Trriger trigger,
                   EnumController.Type type,
                   EnumController.Attribute attributeOne,
                   EnumController.Attribute attributeTwo,
                   EnumController.Attribute attributeThree,
                   EnumController.CardNo cardNo,
                   string name,
                   int power,
                   bool isCounter)
    {
        sprite = sprite;
        level = level;
        cost = cost;
        color = color;
        trigger = trigger;
        type = type;
        attributeOne = attributeOne;
        attributeTwo = attributeTwo;
        attributeThree = attributeThree;
        cardNo = cardNo;
        name = name;
        power = power;
        isCounter = isCounter;
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
