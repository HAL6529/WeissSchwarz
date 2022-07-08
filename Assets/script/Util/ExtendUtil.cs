using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumController;

namespace ExtendUtil
{
    public class ExtendUtil
    {
        public string Explanation(EnumController.CardNo cardNo)
        {
            switch (cardNo)
            {
                case EnumController.CardNo.AT_WX02_A01:
                    return "";
                case EnumController.CardNo.AT_WX02_A02:
                    return "ÅyAUTOÅz When this card attacks, choose 1 of your other characters, and that character gets +1500 power until end of turn.";
                case EnumController.CardNo.AT_WX02_A03:
                    return "ÅyAUTOÅz ÅyCXCOMBOÅz When this card's battle opponent becomes ÅyREVERSEÅz, if ÅuMemory of a MemoryÅv is in your climax area, you may draw 1 card.";
                case EnumController.CardNo.AT_WX02_A04:
                    return "ÅyAUTOÅz Encore [Put 1 character from your hand into your waiting room] (When this card is put into your waiting room from the stage, you may pay the cost. If you do, return this card to its previous stage position as ÅyRESTÅz)";
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
                    return "AT_WX02_A01";
                case EnumController.CardNo.AT_WX02_A02:
                    return "AT_WX02_A02";
                case EnumController.CardNo.AT_WX02_A03:
                    return "AT_WX02_A03";
                case EnumController.CardNo.AT_WX02_A04:
                    return "AT_WX02_A04";
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

