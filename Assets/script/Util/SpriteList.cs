using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumController;

public class SpriteList : MonoBehaviour
{
    public List<Sprite> AdventureTimeSpriteList = new List<Sprite>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Sprite cardNoToSprite(EnumController.CardNo cardNo)
    {
        switch (cardNo)
        {
            case EnumController.CardNo.AT_WX02_A01:
                return AdventureTimeSpriteList[0];
            case EnumController.CardNo.AT_WX02_A02:
                return AdventureTimeSpriteList[1];
            case EnumController.CardNo.AT_WX02_A03:
                return AdventureTimeSpriteList[2];
            case EnumController.CardNo.AT_WX02_A04:
                return AdventureTimeSpriteList[3];
            case EnumController.CardNo.AT_WX02_A05:
                return AdventureTimeSpriteList[4];
            case EnumController.CardNo.AT_WX02_A06:
                return AdventureTimeSpriteList[5];
            case EnumController.CardNo.AT_WX02_A07:
                return AdventureTimeSpriteList[6];
            case EnumController.CardNo.AT_WX02_A08:
                return AdventureTimeSpriteList[7];
            case EnumController.CardNo.AT_WX02_A09:
                return AdventureTimeSpriteList[8];
            case EnumController.CardNo.AT_WX02_A10:
                return AdventureTimeSpriteList[9];
            case EnumController.CardNo.AT_WX02_A11:
                return AdventureTimeSpriteList[10];
            case EnumController.CardNo.AT_WX02_A12:
                return AdventureTimeSpriteList[11];
            case EnumController.CardNo.AT_WX02_A13:
                return AdventureTimeSpriteList[12];
            default:
                return null;
        }
    }
}
