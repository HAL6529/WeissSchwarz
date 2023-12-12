using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumController;

namespace CardNoToCardInfo
{
    public class CardNoToExplanation
    {
        private StringValues stringValues = new StringValues();

        public string Explanation(EnumController.CardNo cardNo)
        {
            switch (cardNo)
            {
                case EnumController.CardNo.AT_WX02_A01:
                    return stringValues.AT_WX02_A01_Explanation;
                case EnumController.CardNo.AT_WX02_A02:
                    return stringValues.AT_WX02_A02_Explanation;
                case EnumController.CardNo.AT_WX02_A03:
                    return stringValues.AT_WX02_A03_Explanation;
                case EnumController.CardNo.AT_WX02_A04:
                    return stringValues.AT_WX02_A04_Explanation;
                case EnumController.CardNo.AT_WX02_A05:
                    return stringValues.AT_WX02_A05_Explanation;
                case EnumController.CardNo.AT_WX02_A06:
                    return stringValues.AT_WX02_A06_Explanation;
                case EnumController.CardNo.AT_WX02_A07:
                    return stringValues.AT_WX02_A07_Explanation;
                case EnumController.CardNo.AT_WX02_A08:
                    return stringValues.AT_WX02_A08_Explanation;
                case EnumController.CardNo.AT_WX02_A09:
                    return stringValues.AT_WX02_A09_Explanation;
                case EnumController.CardNo.AT_WX02_A10:
                    return stringValues.AT_WX02_A10_Explanation;
                case EnumController.CardNo.AT_WX02_A11:
                    return stringValues.AT_WX02_A11_Explanation;
                case EnumController.CardNo.AT_WX02_A12:
                    return stringValues.AT_WX02_A12_Explanation; ;
                case EnumController.CardNo.AT_WX02_A13:
                    return stringValues.AT_WX02_A13_Explanation;
                default:
                    return "";
            }
        }
    }
}
