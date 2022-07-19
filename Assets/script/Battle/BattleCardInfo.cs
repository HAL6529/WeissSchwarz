using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EnumController;

public class BattleCardInfo : MonoBehaviour
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
    public string cardName;
    public int power;
    public EnumController.Zone zone;
    public bool isBack;
    public bool isCounter;
    public bool canAttack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public BattleCardInfo()
    {
        this.sprite = null;
        this.level = -1;
        this.cost = -1;
        this.color = EnumController.CardColor.VOID;
        this.trigger = EnumController.Trriger.VOID;
        this.type = EnumController.Type.VOID;
        this.attributeOne = EnumController.Attribute.VOID;
        this.attributeTwo = EnumController.Attribute.VOID;
        this.attributeThree = EnumController.Attribute.VOID;
        this.cardNo = EnumController.CardNo.VOID;
        this.cardName = "";
        this.power = 0;
        this.zone = EnumController.Zone.VOID;
        this.isBack = true;
        this.isCounter = false;
        this.canAttack = false;
    }

    public BattleCardInfo(Sprite sprite, int level, int cost, EnumController.CardColor color, EnumController.Trriger trigger, EnumController.Type type,
                            EnumController.Attribute attributeOne, EnumController.Attribute attributeTwo, EnumController.Attribute attributeThree,
                            EnumController.CardNo cardNo, string cardName, int power, EnumController.Zone zone, bool isCounter)
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
        this.cardName = cardName;
        this.power = power;
        this.zone = zone;
        this.isBack = true;
        this.isCounter = isCounter;
        this.canAttack = false;
    }
}
