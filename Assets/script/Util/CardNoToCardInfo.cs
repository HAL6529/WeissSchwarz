using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumController;

namespace CardNoToCardInfo
{
    public class CardNoToExplanation
    {
        public string Explanation(EnumController.CardNo cardNo)
        {
            switch (cardNo)
            {
                case EnumController.CardNo.AT_WX02_A01:
                    return "";
                case EnumController.CardNo.AT_WX02_A02:
                    return "Bacon pancakes, makin' bacon pancakes,Take some bacon and I'll put it in a pancake, Bacon pancakes, that's what it's gonna make, Bacon pancaaake!";
                case EnumController.CardNo.AT_WX02_A03:
                    return "ÅyAUTOÅz ÅyCXCOMBOÅz When this card's battle opponent becomes ÅyREVERSEÅz, if [Memory of a Memory] is in your climax area, you may draw 1 card.";
                case EnumController.CardNo.AT_WX02_A04:
                    return "ÅyAUTOÅz Encore [Put 1 character from your hand into your waiting room] (When this card is put into your waiting room from the stage, you may pay the cost. If you do, return this card to its previous stage position as ÅyRESTÅz)";
                case EnumController.CardNo.AT_WX02_A05:
                    return "ÅyACTÅz ÅyCOUNTERÅz Backup 2500, Level 1 [(1) Put this card from your hand into your waiting room] (Choose 1 of your characters that is being frontal attacked, and that character gets +2500 power until end of turn)";
                case EnumController.CardNo.AT_WX02_A06:
                    return "ÅyCONTÅz Assist All of your characters in front of this card get +X power. X is equal to that character's level Å~500.";
                case EnumController.CardNo.AT_WX02_A07:
                    return "Search your deck for up to 1 ÅsOooÅt character, reveal it to your opponent, put it into your hand, and shuffle your deck.";
                case EnumController.CardNo.AT_WX02_A08:
                    return "ÅyCONTÅz All of your characters get +1000 power and +1 soul. During this turn, when the next damage dealt by the attacking character that triggered this card is canceled, deal 1 damage to your opponent)";
                case EnumController.CardNo.AT_WX02_A09:
                    return "ÅyACTÅz Brainstorm [(1) ÅyRESTÅz this card] Flip over 4 cards from the top of your deck, and put them into your waiting room. For each climax revealed among those cards, draw up to 1 card.";
                case EnumController.CardNo.AT_WX02_A10:
                    return "ÅyAUTOÅz Bond/[Marceline: Party Crasher] [(1)] (When this card is played and placed on stage, you may pay the cost. If you do, choose 1 [Marceline: Party Crasher] in your waiting room, and return it to your hand)";
                case EnumController.CardNo.AT_WX02_A11:
                    return "ÅyCONTÅz Assist All of your characters in front of this card get +500 power.";
                case EnumController.CardNo.AT_WX02_A12:
                    return "ÅyCONTÅz This card gets +500 power for each of your other ÅsOooÅt characters.";
                case EnumController.CardNo.AT_WX02_A13:
                    return "ÅyCONTÅz All of your characters get +1000 power and +1 soul. When this card triggers, you may choose 1 character in your waiting room, and return it to your hand)";
                default:
                    return "";
            }
        }
    }
}
