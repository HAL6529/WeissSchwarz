using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInfoList : MonoBehaviour
{
    [SerializeField] List<cardInfo> cardInfoList = new List<cardInfo>();

    public cardInfo GetCardInfo(EnumController.CardNo cardNo)
    {
        for(int i = 0; i < cardInfoList.Count; i++)
        {
            if(cardInfoList[i].cardNo == cardNo)
            {
                return cardInfoList[i];
            }
        }

        return new cardInfo();
    }
}
