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
                    return stringValues.AT_WX02_A12_Explanation;
                case EnumController.CardNo.AT_WX02_A13:
                    return stringValues.AT_WX02_A13_Explanation;
                case EnumController.CardNo.DC_W01_01T:
                    return stringValues.DC_W01_01T_Explanation;
                case EnumController.CardNo.DC_W01_02T:
                    return stringValues.DC_W01_02T_Explanation;
                case EnumController.CardNo.DC_W01_03T:
                    return stringValues.DC_W01_03T_Explanation;
                case EnumController.CardNo.DC_W01_04T:
                    return stringValues.DC_W01_04T_Explanation;
                case EnumController.CardNo.DC_W01_05T:
                    return stringValues.DC_W01_05T_Explanation;
                case EnumController.CardNo.DC_W01_06T:
                    return stringValues.DC_W01_06T_Explanation;
                case EnumController.CardNo.DC_W01_07T:
                    return stringValues.DC_W01_07T_Explanation;
                case EnumController.CardNo.DC_W01_08T:
                    return stringValues.DC_W01_08T_Explanation;
                case EnumController.CardNo.DC_W01_09T:
                    return stringValues.DC_W01_09T_Explanation;
                case EnumController.CardNo.DC_W01_10T:
                    return stringValues.DC_W01_10T_Explanation;
                case EnumController.CardNo.DC_W01_11T:
                    return stringValues.DC_W01_11T_Explanation;
                case EnumController.CardNo.DC_W01_12T:
                    return stringValues.DC_W01_12T_Explanation;
                case EnumController.CardNo.DC_W01_13T:
                    return stringValues.DC_W01_13T_Explanation;
                case EnumController.CardNo.DC_W01_14T:
                    return stringValues.DC_W01_14T_Explanation;
                case EnumController.CardNo.DC_W01_15T:
                    return stringValues.DC_W01_15T_Explanation;
                case EnumController.CardNo.DC_W01_16T:
                    return stringValues.DC_W01_16T_Explanation;
                case EnumController.CardNo.DC_W01_17T:
                    return stringValues.DC_W01_17T_Explanation;
                case EnumController.CardNo.DC_W01_18T:
                    return stringValues.DC_W01_18T_Explanation;
                case EnumController.CardNo.DC_W01_19T:
                    return stringValues.DC_W01_19T_Explanation;
                case EnumController.CardNo.DC_W01_20T:
                    return stringValues.DC_W01_20T_Explanation;
                case EnumController.CardNo.LB_W02_01T:
                    return stringValues.LB_W02_01T_Explanation;
                case EnumController.CardNo.LB_W02_02T:
                    return stringValues.LB_W02_02T_Explanation;
                case EnumController.CardNo.LB_W02_03T:
                    return stringValues.LB_W02_03T_Explanation;
                case EnumController.CardNo.LB_W02_04T:
                    return stringValues.LB_W02_04T_Explanation;
                case EnumController.CardNo.LB_W02_05T:
                    return stringValues.LB_W02_05T_Explanation;
                case EnumController.CardNo.LB_W02_06T:
                    return stringValues.LB_W02_06T_Explanation;
                case EnumController.CardNo.LB_W02_07T:
                    return stringValues.LB_W02_07T_Explanation;
                case EnumController.CardNo.LB_W02_08T:
                    return stringValues.LB_W02_08T_Explanation;
                case EnumController.CardNo.LB_W02_09T:
                    return stringValues.LB_W02_09T_Explanation;
                case EnumController.CardNo.LB_W02_10T:
                    return stringValues.LB_W02_10T_Explanation;
                case EnumController.CardNo.LB_W02_11T:
                    return stringValues.LB_W02_11T_Explanation;
                case EnumController.CardNo.LB_W02_12T:
                    return stringValues.LB_W02_12T_Explanation;
                case EnumController.CardNo.LB_W02_13T:
                    return stringValues.LB_W02_13T_Explanation;
                case EnumController.CardNo.LB_W02_14T:
                    return stringValues.LB_W02_14T_Explanation;
                case EnumController.CardNo.LB_W02_15T:
                    return stringValues.LB_W02_15T_Explanation;
                case EnumController.CardNo.LB_W02_16T:
                    return stringValues.LB_W02_16T_Explanation;
                case EnumController.CardNo.LB_W02_17T:
                    return stringValues.LB_W02_17T_Explanation;
                case EnumController.CardNo.LB_W02_18T:
                    return stringValues.LB_W02_18T_Explanation;
                case EnumController.CardNo.LB_W02_19T:
                    return stringValues.LB_W02_19T_Explanation;
                case EnumController.CardNo.LB_W02_20T:
                    return stringValues.LB_W02_20T_Explanation;
                default:
                    return "";
            }
        }
    }
}
