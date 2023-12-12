using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumController;

namespace ExtendUtil
{
    public class ExtendUtil
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
                default:
                    break;
            }
            return "";
        }

        public string CardNoConvertToString(EnumController.CardNo cardNo)
        {
            switch (cardNo)
            {
                case EnumController.CardNo.AT_WX02_A01:
                    return stringValues.AT_WX02_A01_CardNo;
                case EnumController.CardNo.AT_WX02_A02:
                    return stringValues.AT_WX02_A02_CardNo;
                case EnumController.CardNo.AT_WX02_A03:
                    return stringValues.AT_WX02_A03_CardNo;
                case EnumController.CardNo.AT_WX02_A04:
                    return stringValues.AT_WX02_A04_CardNo;
                default:
                    break;
            }
            return "";
        }

        public string AttributeConvertToString(EnumController.Attribute attribute)
        {
            switch (attribute)
            {
                case EnumController.Attribute.Ooo:
                    return "Ooo";
                case EnumController.Attribute.Hero:
                    return "Hero";
                case EnumController.Attribute.NONE:
                    return null;
                default:
                    break;
            }
            return null;
        }
    }
}

