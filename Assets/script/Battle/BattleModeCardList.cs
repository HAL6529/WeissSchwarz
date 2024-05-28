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
            case EnumController.CardNo.DC_W01_01T:
                return DC_2008TrialDeck[0];
            case EnumController.CardNo.DC_W01_02T:
                return DC_2008TrialDeck[1];
            case EnumController.CardNo.DC_W01_03T:
                return DC_2008TrialDeck[2];
            case EnumController.CardNo.DC_W01_04T:
                return DC_2008TrialDeck[3];
            case EnumController.CardNo.DC_W01_05T:
                return DC_2008TrialDeck[4];
            case EnumController.CardNo.DC_W01_06T:
                return DC_2008TrialDeck[5];
            case EnumController.CardNo.DC_W01_07T:
                return DC_2008TrialDeck[6];
            case EnumController.CardNo.DC_W01_08T:
                return DC_2008TrialDeck[7];
            case EnumController.CardNo.DC_W01_09T:
                return DC_2008TrialDeck[8];
            case EnumController.CardNo.DC_W01_10T:
                return DC_2008TrialDeck[9];
            case EnumController.CardNo.DC_W01_11T:
                return DC_2008TrialDeck[10];
            case EnumController.CardNo.DC_W01_12T:
                return DC_2008TrialDeck[11];
            case EnumController.CardNo.DC_W01_13T:
                return DC_2008TrialDeck[12];
            case EnumController.CardNo.DC_W01_14T:
                return DC_2008TrialDeck[13];
            case EnumController.CardNo.DC_W01_15T:
                return DC_2008TrialDeck[14];
            case EnumController.CardNo.DC_W01_16T:
                return DC_2008TrialDeck[15];
            case EnumController.CardNo.DC_W01_17T:
                return DC_2008TrialDeck[16];
            case EnumController.CardNo.DC_W01_18T:
                return DC_2008TrialDeck[17];
            case EnumController.CardNo.DC_W01_19T:
                return DC_2008TrialDeck[18];
            case EnumController.CardNo.DC_W01_20T:
                return DC_2008TrialDeck[19];
            case EnumController.CardNo.LB_W02_01T:
                return LittleBusters_2008TrialDeck[0];
            case EnumController.CardNo.LB_W02_02T:
                return LittleBusters_2008TrialDeck[1];
            case EnumController.CardNo.LB_W02_03T:
                return LittleBusters_2008TrialDeck[2];
            case EnumController.CardNo.LB_W02_04T:
                return LittleBusters_2008TrialDeck[3];
            case EnumController.CardNo.LB_W02_05T:
                return LittleBusters_2008TrialDeck[4];
            case EnumController.CardNo.LB_W02_06T:
                return LittleBusters_2008TrialDeck[5];
            case EnumController.CardNo.LB_W02_07T:
                return LittleBusters_2008TrialDeck[6];
            case EnumController.CardNo.LB_W02_08T:
                return LittleBusters_2008TrialDeck[7];
            case EnumController.CardNo.LB_W02_09T:
                return LittleBusters_2008TrialDeck[8];
            case EnumController.CardNo.LB_W02_10T:
                return LittleBusters_2008TrialDeck[9];
            case EnumController.CardNo.LB_W02_11T:
                return LittleBusters_2008TrialDeck[10];
            case EnumController.CardNo.LB_W02_12T:
                return LittleBusters_2008TrialDeck[11];
            case EnumController.CardNo.LB_W02_13T:
                return LittleBusters_2008TrialDeck[12];
            case EnumController.CardNo.LB_W02_14T:
                return LittleBusters_2008TrialDeck[13];
            case EnumController.CardNo.LB_W02_15T:
                return LittleBusters_2008TrialDeck[14];
            case EnumController.CardNo.LB_W02_16T:
                return LittleBusters_2008TrialDeck[15];
            case EnumController.CardNo.LB_W02_17T:
                return LittleBusters_2008TrialDeck[16];
            case EnumController.CardNo.LB_W02_18T:
                return LittleBusters_2008TrialDeck[17];
            case EnumController.CardNo.LB_W02_19T:
                return LittleBusters_2008TrialDeck[18];
            case EnumController.CardNo.LB_W02_20T:
                return LittleBusters_2008TrialDeck[19];
            default:
                return null;
        }
    }
}
