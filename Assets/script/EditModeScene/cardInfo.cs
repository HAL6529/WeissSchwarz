using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EnumController;

public class cardInfo : MonoBehaviour
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
    public EnumController.Limit limit;

    public bool hasAccelerate;
    public bool hasBackUp;
    public bool hasBrainStorm;
    public bool hasBond;
    public bool hasChange;
    public bool hasClock;
    public bool hasEncore;
    public bool hasExperience;
    public bool hasGreatPerformance;
    public bool hasResonate;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
