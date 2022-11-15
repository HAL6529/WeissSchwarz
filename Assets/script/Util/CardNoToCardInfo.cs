using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumController;

namespace CardNoToCardInfo
{
    public class CardNoToCardInfo
    {
        public BattleModeCard cardNoToCardInfo(EnumController.CardNo cardNo, SpriteList sl)
        {
            Sprite sprite = sl.cardNoToSprite(cardNo);
            switch (cardNo)
            {
                // レベル,コスト,色,トリガー,種類,特徴1,特徴2,特徴3,カードナンバー,カードの名前,パワー,カウンターかどうか
                case EnumController.CardNo.AT_WX02_A01:
                    return new BattleModeCard(
                        sprite,
                        0,
                        0,
                        EnumController.CardColor.YELLOW,
                        EnumController.Trriger.NONE,
                        EnumController.Type.CHARACTER,
                        EnumController.Attribute.Ooo,
                        EnumController.Attribute.Hero,
                        EnumController.Attribute.NONE,
                        cardNo,
                        "Finn: Everything In!",
                        3000,
                        false);
                case EnumController.CardNo.AT_WX02_A02:
                    return new BattleModeCard(
                        sprite,
                        0,
                        0,
                        EnumController.CardColor.YELLOW,
                        EnumController.Trriger.NONE,
                        EnumController.Type.CHARACTER,
                        EnumController.Attribute.Ooo,
                        EnumController.Attribute.Hero,
                        EnumController.Attribute.NONE,
                        cardNo,
                        "Jake: Bacon Pancakes",
                        2000,
                        false);
                case EnumController.CardNo.AT_WX02_A03:
                    return new BattleModeCard(
                        sprite,
                        0,
                        0,
                        EnumController.CardColor.YELLOW,
                        EnumController.Trriger.NONE,
                        EnumController.Type.CHARACTER,
                        EnumController.Attribute.Ooo,
                        EnumController.Attribute.Hero,
                        EnumController.Attribute.NONE,
                        cardNo,
                        "Finn: Puncha Yo Buns!",
                        5000,
                        false);
                case EnumController.CardNo.AT_WX02_A04:
                    return new BattleModeCard(
                        sprite,
                        1,
                        0,
                        EnumController.CardColor.YELLOW,
                        EnumController.Trriger.NONE,
                        EnumController.Type.CHARACTER,
                        EnumController.Attribute.Ooo,
                        EnumController.Attribute.Hero,
                        EnumController.Attribute.NONE,
                        cardNo,
                        "Jake: Date at Sunset",
                        5000,
                        false);
                default:
                    return new BattleModeCard();
            }
        }
    }
}
