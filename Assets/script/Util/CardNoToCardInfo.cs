using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumController;

namespace CardNoToCardInfo
{
    public class CardNoToCardInfo
    {
        public BattleCardInfo cardNoToCardInfo(EnumController.CardNo cardNo, SpriteList sl)
        {
            Sprite sprite = sl.cardNoToSprite(cardNo);
            switch (cardNo)
            {
                // ���x��,�R�X�g,�F,�g���K�[,���,����1,����2,����3,�J�[�h�i���o�[,�J�[�h�̖��O,�]�[��,�J�E���^�[���ǂ���
                case EnumController.CardNo.AT_WX02_A01:
                    return new BattleCardInfo(sprite, 0, 0, EnumController. CardColor.YELLOW, EnumController.Trriger.NONE, EnumController.Type.CHARACTER,
                                                EnumController.Attribute.Ooo, EnumController.Attribute.Hero, EnumController.Attribute.NONE,
                                                cardNo, "Finn: Everything In!", 3000, EnumController.Zone.DECK, false);
                case EnumController.CardNo.AT_WX02_A02:
                    return new BattleCardInfo(sprite, 0, 0, EnumController.CardColor.YELLOW, EnumController.Trriger.NONE, EnumController.Type.CHARACTER,
                                                EnumController.Attribute.Ooo, EnumController.Attribute.Hero, EnumController.Attribute.NONE,
                                                cardNo, "Jake: Bacon Pancakes", 2000, EnumController.Zone.DECK, false);
                case EnumController.CardNo.AT_WX02_A03:
                    return new BattleCardInfo(sprite, 1, 0, EnumController.CardColor.YELLOW, EnumController.Trriger.NONE, EnumController.Type.CHARACTER,
                                                EnumController.Attribute.Ooo, EnumController.Attribute.Hero, EnumController.Attribute.NONE,
                                                cardNo, "Finn: Puncha Yo Buns!", 5000, EnumController.Zone.DECK, false);
                case EnumController.CardNo.AT_WX02_A04:
                    return new BattleCardInfo(sprite, 1, 0, EnumController.CardColor.YELLOW, EnumController.Trriger.NONE, EnumController.Type.CHARACTER,
                                                EnumController.Attribute.Ooo, EnumController.Attribute.Hero, EnumController.Attribute.NONE,
                                                cardNo, "Jake: Date at Sunset", 5000, EnumController.Zone.DECK, false);
                default:
                    return new BattleCardInfo();
            }
        }
    }
}
