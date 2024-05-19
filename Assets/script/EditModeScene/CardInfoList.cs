using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInfoList : MonoBehaviour
{
    [SerializeField] List<cardInfo> cardInfo_list = new List<cardInfo>();

    public cardInfo Convert(string cardNo)
    {
        switch (cardNo)
        {
            case "AT_WX02_A01":
                return cardInfo_list[0];
            case "AT_WX02_A02":
                return cardInfo_list[1];
            case "AT_WX02_A03":
                return cardInfo_list[2];
            case "AT_WX02_A04":
                return cardInfo_list[3];
            case "AT_WX02_A05":
                return cardInfo_list[4];
            case "AT_WX02_A06":
                return cardInfo_list[5];
            case "AT_WX02_A07":
                return cardInfo_list[6];
            case "AT_WX02_A08":
                return cardInfo_list[7];
            case "AT_WX02_A09":
                return cardInfo_list[8];
            case "AT_WX02_A10":
                return cardInfo_list[9];
            case "AT_WX02_A11":
                return cardInfo_list[10];
            case "AT_WX02_A12":
                return cardInfo_list[11];
            case "AT_WX02_A13":
                return cardInfo_list[12];
            default:
                return null;
        }
    }
}
