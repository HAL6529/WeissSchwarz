using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeCardList : MonoBehaviour
{
    public List<BattleModeCard> AdventureTimeList = new List<BattleModeCard>();
    public List<BattleModeCard> DC_2008TrialDeck = new List<BattleModeCard>();
    public List<BattleModeCard> LittleBusters_2008TrialDeck = new List<BattleModeCard>();

    public BattleModeCard ConvertCardNoToBattleModeCard(EnumController.CardNo num)
    {
        switch (num)
        {
            case EnumController.CardNo.AT_WX02_A01:
                return AdventureTimeList[0];
            case EnumController.CardNo.AT_WX02_A02:
                return AdventureTimeList[1];
            case EnumController.CardNo.AT_WX02_A03:
                return AdventureTimeList[2];
            case EnumController.CardNo.AT_WX02_A04:
                return AdventureTimeList[3];
            case EnumController.CardNo.AT_WX02_A05:
                return AdventureTimeList[4];
            case EnumController.CardNo.AT_WX02_A06:
                return AdventureTimeList[5];
            case EnumController.CardNo.AT_WX02_A07:
                return AdventureTimeList[6];
            case EnumController.CardNo.AT_WX02_A08:
                return AdventureTimeList[7];
            case EnumController.CardNo.AT_WX02_A09:
                return AdventureTimeList[8];
            case EnumController.CardNo.AT_WX02_A10:
                return AdventureTimeList[9];
            case EnumController.CardNo.AT_WX02_A11:
                return AdventureTimeList[10];
            case EnumController.CardNo.AT_WX02_A12:
                return AdventureTimeList[11];
            case EnumController.CardNo.AT_WX02_A13:
                return AdventureTimeList[12];
            default:
                return null;
        }
    }
}
