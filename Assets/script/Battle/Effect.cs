using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    private GameManager m_GameManager = null;
    private BattleStrix m_BattleStrix = null;
    private MyMainCardsManager m_MyMainCardsManager;
    private EnemyMainCardsManager m_EnemyMainCardsManager;
    public EventAnimationManager m_EventAnimationManager;

    public Effect(GameManager m_GameManager, BattleStrix m_BattleStrix)
    {
        this.m_GameManager = m_GameManager;
        this.m_BattleStrix = m_BattleStrix;
    }

    public void BondForHandToFild(BattleModeCard card)
    {
        switch (card.cardNo)
        {
            case EnumController.CardNo.AT_WX02_A10:
            case EnumController.CardNo.DC_W01_09T:
            case EnumController.CardNo.P3_S01_003:
            case EnumController.CardNo.P3_S01_032:
            case EnumController.CardNo.P3_S01_051:
            case EnumController.CardNo.P3_S01_082:
            case EnumController.CardNo.LB_W02_002:
                if (ConfirmStockForCost(1))
                {
                    Action action_Bond = new Action(m_GameManager, EnumController.Action.Bond);
                    action_Bond.SetParamaterBattleModeCard(card);
                    m_GameManager.ActionList.Add(action_Bond);
                    break;
                }
                return;
            default:
                return;
        }
    }

    /// <summary>
    /// 「【自】 あなたがレベルアップした時」の効果
    /// </summary>
    /// <param name="m_BattleModeCard"></param>
    public void WhenLevelUp(BattleModeCard m_BattleModeCard)
    {
        if (m_BattleModeCard == null)
        {
            return;
        }

        switch (m_BattleModeCard.cardNo)
        {
            case EnumController.CardNo.LB_W02_14T:
                Debug.Log(m_BattleModeCard.name);
                Action action_LB_W02_14T = new Action(m_GameManager, EnumController.Action.LB_W02_14T);
                action_LB_W02_14T.SetParamaterEventAnimationManager(m_EventAnimationManager);
                action_LB_W02_14T.SetParamaterBattleStrix(m_BattleStrix);
                action_LB_W02_14T.SetParamaterBattleModeCard(m_BattleModeCard);
                m_GameManager.ActionList.Add(action_LB_W02_14T);
                break;
            default:
                break;
        }
    }

    public void PutGraveYardFromField(BattleMyMainCardAvility m_BattleMyMainCardAvility)
    {
        if (m_BattleMyMainCardAvility.m_BattleModeCard == null)
        {
            return;
        }

        switch (m_BattleMyMainCardAvility.m_BattleModeCard.cardNo)
        {
            //【自】［(1)］ このカードが舞台から控え室に置かれた時、あなたはコストを払ってよい。そうしたら、あなたは自分の控え室の「順平＆トリスメギストス」を1枚選び、手札に戻す。
            case EnumController.CardNo.P3_S01_065:
                if (ConfirmStockForCost(1))
                {
                    Action action_P3_S01_065 = new Action(m_GameManager, EnumController.Action.P3_S01_065_2);
                    action_P3_S01_065.SetParamaterEventAnimationManager(m_EventAnimationManager);
                    action_P3_S01_065.SetParamaterBattleStrix(m_BattleStrix);
                    action_P3_S01_065.SetParamaterBattleModeCard(m_BattleMyMainCardAvility.m_BattleModeCard);
                    action_P3_S01_065.SetParamaterNum(m_BattleMyMainCardAvility.PlaceNum);
                    m_GameManager.ActionList.Add(action_P3_S01_065);
                }
                return;
            default:
                return;
        }
    }

    /// <summary>
    /// 「【自】 このカードがプレイされて舞台に置かれた時」の効果
    /// </summary>
    /// <param name="m_BattleModeCard"></param>
    /// <param name="place"></param>
    public void WhenPlaceCardEffect(BattleModeCard m_BattleModeCard, int place)
    {
        if (m_BattleModeCard == null)
        {
            return;
        }

        this.m_MyMainCardsManager = m_GameManager.GetMyMainCardsManager();
        switch (m_BattleModeCard.cardNo)
        {
            case EnumController.CardNo.DC_W01_02T:
                Action action_DC_W01_02T = new Action(m_GameManager, EnumController.Action.DC_W01_02T);
                action_DC_W01_02T.SetParamaterEventAnimationManager(m_EventAnimationManager);
                action_DC_W01_02T.SetParamaterBattleStrix(m_BattleStrix);
                action_DC_W01_02T.SetParamaterBattleModeCard(m_BattleModeCard);
                m_GameManager.ActionList.Add(action_DC_W01_02T);
                break;
            case EnumController.CardNo.P3_S01_01T:
            case EnumController.CardNo.P3_S01_005:
                // 【自】 このカードがプレイされて舞台に置かれた時、そのターン中、このカードのソウルを＋1。
                Action action_P3_S01_01T = new Action(m_GameManager, EnumController.Action.P3_S01_01T);
                action_P3_S01_01T.SetParamaterEventAnimationManager(m_EventAnimationManager);
                action_P3_S01_01T.SetParamaterBattleStrix(m_BattleStrix);
                action_P3_S01_01T.SetParamaterBattleModeCard(m_BattleModeCard);
                action_P3_S01_01T.SetParamaterMyMainCardsManager(m_MyMainCardsManager);
                action_P3_S01_01T.SetParamaterNum(place);
                m_GameManager.ActionList.Add(action_P3_S01_01T);
                return;
            case EnumController.CardNo.P3_S01_04T:
            case EnumController.CardNo.P3_S01_010:
                // 【自】 このカードがプレイされて舞台に置かれた時、あなたは自分のキャラを1枚選び、そのターン中、パワーを＋2000し、ソウルを＋1。
                Action action_P3_S01_04T = new Action(m_GameManager, EnumController.Action.P3_S01_04T);
                action_P3_S01_04T.SetParamaterEventAnimationManager(m_EventAnimationManager);
                action_P3_S01_04T.SetParamaterBattleStrix(m_BattleStrix);
                action_P3_S01_04T.SetParamaterBattleModeCard(m_BattleModeCard);
                action_P3_S01_04T.SetParamaterMyMainCardsManager(m_MyMainCardsManager);
                action_P3_S01_04T.SetParamaterNum(place);
                m_GameManager.ActionList.Add(action_P3_S01_04T);
                return;
            case EnumController.CardNo.P3_S01_07T:
            case EnumController.CardNo.P3_S01_012:
                // 【自】 このカードがプレイされて舞台に置かれた時、そのターン中、このカードのパワーを＋1500。
                Action action_P3_S01_07T = new Action(m_GameManager, EnumController.Action.P3_S01_07T);
                action_P3_S01_07T.SetParamaterEventAnimationManager(m_EventAnimationManager);
                action_P3_S01_07T.SetParamaterBattleStrix(m_BattleStrix);
                action_P3_S01_07T.SetParamaterBattleModeCard(m_BattleModeCard);
                action_P3_S01_07T.SetParamaterMyMainCardsManager(m_MyMainCardsManager);
                action_P3_S01_07T.SetParamaterNum(place);
                m_GameManager.ActionList.Add(action_P3_S01_07T);
                return;
            case EnumController.CardNo.P3_S01_001:
                // 【自】 このカードがプレイされて舞台に置かれた時、あなたはレベル1以上の自分のキャラを1枚選び、そのターン中、ソウルを＋1。
                Action action_P3_S01_001 = new Action(m_GameManager, EnumController.Action.P3_S01_001);
                action_P3_S01_001.SetParamaterEventAnimationManager(m_EventAnimationManager);
                action_P3_S01_001.SetParamaterBattleStrix(m_BattleStrix);
                action_P3_S01_001.SetParamaterBattleModeCard(m_BattleModeCard);
                action_P3_S01_001.SetParamaterMyMainCardsManager(m_MyMainCardsManager);
                action_P3_S01_001.SetParamaterNum(place);
                m_GameManager.ActionList.Add(action_P3_S01_001);
                return;
            case EnumController.CardNo.P3_S01_026:
                // 【自】 このカードがプレイされて舞台に置かれた時、あなたは自分のキャラを1枚選び、そのターン中、パワーを＋1000。
                Action action_P3_S01_026 = new Action(m_GameManager, EnumController.Action.P3_S01_026);
                action_P3_S01_026.SetParamaterEventAnimationManager(m_EventAnimationManager);
                action_P3_S01_026.SetParamaterBattleStrix(m_BattleStrix);
                action_P3_S01_026.SetParamaterBattleModeCard(m_BattleModeCard);
                action_P3_S01_026.SetParamaterMyMainCardsManager(m_MyMainCardsManager);
                action_P3_S01_026.SetParamaterNum(place);
                m_GameManager.ActionList.Add(action_P3_S01_026);
                return;
            case EnumController.CardNo.P3_S01_052:
                // 【自】［(1)］ このカードがプレイされて舞台に置かれた時、あなたはコストを払ってよい。そうしたら、あなたは自分の控え室の「辰巳東交番」を1枚選び、手札に戻す。
                if (ConfirmStockForCost(1))
                {
                    Action action_P3_S01_052 = new Action(m_GameManager, EnumController.Action.P3_S01_052);
                    action_P3_S01_052.SetParamaterEventAnimationManager(m_EventAnimationManager);
                    action_P3_S01_052.SetParamaterBattleStrix(m_BattleStrix);
                    action_P3_S01_052.SetParamaterBattleModeCard(m_BattleModeCard);
                    action_P3_S01_052.SetParamaterMyMainCardsManager(m_MyMainCardsManager);
                    action_P3_S01_052.SetParamaterNum(place);
                    m_GameManager.ActionList.Add(action_P3_S01_052);
                }
                return;
            case EnumController.CardNo.P3_S01_057:
                //【自】 このカードがプレイされて舞台に置かれた時、あなたは相手の控え室のイベントを1枚選び、思い出にしてよい。
                for(int i = 0; i < m_GameManager.enemyGraveYardList.Count; i++)
                {
                    if (m_GameManager.enemyGraveYardList[i].type == EnumController.Type.EVENT)
                    {
                        Action action_P3_S01_057_1 = new Action(m_GameManager, EnumController.Action.P3_S01_057_1);
                        action_P3_S01_057_1.SetParamaterEventAnimationManager(m_EventAnimationManager);
                        action_P3_S01_057_1.SetParamaterBattleStrix(m_BattleStrix);
                        action_P3_S01_057_1.SetParamaterBattleModeCard(m_BattleModeCard);
                        action_P3_S01_057_1.SetParamaterMyMainCardsManager(m_MyMainCardsManager);
                        action_P3_S01_057_1.SetParamaterNum(place);
                        m_GameManager.ActionList.Add(action_P3_S01_057_1);
                        return;
                    }
                }
                return;
            case EnumController.CardNo.P3_S01_060:
                // 【自】［(1)］ このカードがプレイされて舞台に置かれた時、あなたはコストを払ってよい。そうしたら、あなたはレベル1以下の相手のキャラを1枚選び、控え室に置く。
                if (ConfirmStockForCost(1))
                {
                    Action action_P3_S01_060 = new Action(m_GameManager, EnumController.Action.P3_S01_060);
                    action_P3_S01_060.SetParamaterEventAnimationManager(m_EventAnimationManager);
                    action_P3_S01_060.SetParamaterBattleStrix(m_BattleStrix);
                    action_P3_S01_060.SetParamaterBattleModeCard(m_BattleModeCard);
                    action_P3_S01_060.SetParamaterMyMainCardsManager(m_MyMainCardsManager);
                    action_P3_S01_060.SetParamaterNum(place);
                    m_GameManager.ActionList.Add(action_P3_S01_060);
                }
                return;
            case EnumController.CardNo.P3_S01_061:
                //【自】 このカードがプレイされて舞台に置かれた時、あなたは相手の控え室のカードを1枚選び、山札の上に置いてよい。
                if(m_GameManager.enemyGraveYardList.Count > 0)
                {
                    Action action_P3_S01_061 = new Action(m_GameManager, EnumController.Action.P3_S01_061);
                    action_P3_S01_061.SetParamaterEventAnimationManager(m_EventAnimationManager);
                    action_P3_S01_061.SetParamaterBattleStrix(m_BattleStrix);
                    action_P3_S01_061.SetParamaterBattleModeCard(m_BattleModeCard);
                    action_P3_S01_061.SetParamaterMyMainCardsManager(m_MyMainCardsManager);
                    action_P3_S01_061.SetParamaterNum(place);
                    m_GameManager.ActionList.Add(action_P3_S01_061);
                }
                return;
            case EnumController.CardNo.P3_S01_065:
                //【自】 このカードがプレイされて舞台に置かれた時、あなたはすべてのプレイヤーに、1ダメージを与える。
                Action action_P3_S01_065 = new Action(m_GameManager, EnumController.Action.P3_S01_065_1);
                action_P3_S01_065.SetParamaterEventAnimationManager(m_EventAnimationManager);
                action_P3_S01_065.SetParamaterBattleStrix(m_BattleStrix);
                action_P3_S01_065.SetParamaterBattleModeCard(m_BattleModeCard);
                action_P3_S01_065.SetParamaterMyMainCardsManager(m_MyMainCardsManager);
                action_P3_S01_065.SetParamaterNum(place);
                m_GameManager.ActionList.Add(action_P3_S01_065);
                return;
            case EnumController.CardNo.P3_S01_080:
                //【自】 このカードがプレイされて舞台に置かれた時、あなたは1枚引いてよい。
                Action action_P3_S01_080_1 = new Action(m_GameManager, EnumController.Action.P3_S01_080_1);
                action_P3_S01_080_1.SetParamaterEventAnimationManager(m_EventAnimationManager);
                action_P3_S01_080_1.SetParamaterBattleStrix(m_BattleStrix);
                action_P3_S01_080_1.SetParamaterBattleModeCard(m_BattleModeCard);
                action_P3_S01_080_1.SetParamaterMyMainCardsManager(m_MyMainCardsManager);
                action_P3_S01_080_1.SetParamaterNum(place);
                m_GameManager.ActionList.Add(action_P3_S01_080_1);
                // 【自】［(1)］ このカードがプレイされて舞台に置かれた時、あなたはコストを払ってよい。そうしたら、あなたは自分の控え室の「ベルベットルーム」を1枚選び、手札に戻す。
                if (ConfirmStockForCost(1))
                {
                    Action action_P3_S01_080_2 = new Action(m_GameManager, EnumController.Action.P3_S01_080_2);
                    action_P3_S01_080_2.SetParamaterEventAnimationManager(m_EventAnimationManager);
                    action_P3_S01_080_2.SetParamaterBattleStrix(m_BattleStrix);
                    action_P3_S01_080_2.SetParamaterBattleModeCard(m_BattleModeCard);
                    action_P3_S01_080_2.SetParamaterMyMainCardsManager(m_MyMainCardsManager);
                    action_P3_S01_080_2.SetParamaterNum(place);
                    m_GameManager.ActionList.Add(action_P3_S01_080_2);
                }
                return;
            case EnumController.CardNo.P3_S01_088:
                //【自】［(2)］ このカードがプレイされて舞台に置かれた時、あなたはコストを払ってよい。そうしたら、あなたは自分のクロックを上から1枚選び、控え室に置く。
                if (ConfirmStockForCost(2))
                {
                    Action action_P3_S01_088 = new Action(m_GameManager, EnumController.Action.P3_S01_088);
                    action_P3_S01_088.SetParamaterEventAnimationManager(m_EventAnimationManager);
                    action_P3_S01_088.SetParamaterBattleStrix(m_BattleStrix);
                    action_P3_S01_088.SetParamaterBattleModeCard(m_BattleModeCard);
                    action_P3_S01_088.SetParamaterMyMainCardsManager(m_MyMainCardsManager);
                    action_P3_S01_088.SetParamaterNum(place);
                    m_GameManager.ActionList.Add(action_P3_S01_088);
                }
                return;
            default:
                break;
        }
    }

    /// <summary>
    /// 相手のカードをリバースしたときに発動する効果
    /// </summary>
    /// <param name="reversedCardPlace">リバースしたキャラの場所(リバースしたキャラのコントローラー視点)</param>
    /// <param name="reversedCardLevel">リバースしたキャラのレベル</param>
    public void WhenReverseEnemyCardEffect(BattleModeCard card, int reversedCardPlace, int reversedCardLevel)
    {
        switch (card.cardNo)
        {
            case EnumController.CardNo.AT_WX02_A03:
                if (ConfirmClimaxCombo(EnumController.CardNo.AT_WX02_A08))
                {
                    Action action_AT_WX02_A08 = new Action(m_GameManager, EnumController.Action.AT_WX02_A08);
                    action_AT_WX02_A08.SetParamaterBattleModeCard(card);

                    m_GameManager.ActionList.Add(action_AT_WX02_A08);

                    //m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.CONFIRM_CARD_EFFECT, card);
                }
                return;
            case EnumController.CardNo.DC_W01_10T:
                Action action_DC_W01_10T = new Action(m_GameManager, EnumController.Action.DC_W01_10T);
                action_DC_W01_10T.SetParamaterBattleModeCard(card);
                action_DC_W01_10T.SetParamaterNum(reversedCardPlace);

                m_GameManager.ActionList.Add(action_DC_W01_10T);
                //m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.CONFIRM_CARD_EFFECT, card, reversedCardPlace);
                return;
            case EnumController.CardNo.LB_W02_19T:
                if(reversedCardLevel > 1)
                {
                    Action action_LB_W02_19T = new Action(m_GameManager, EnumController.Action.LB_W02_19T);
                    action_LB_W02_19T.SetParamaterBattleModeCard(card);
                    m_GameManager.ActionList.Add(action_LB_W02_19T);
                }
                return;
            default:
                return;
        }
    }

    /// <summary>
    /// 「【自】 このカードが【リバース】した時」に発動する効果
    /// </summary>
    public void WhenReverseMyCardEffect(BattleMyMainCardAvility m_BattleMyMainCardAvility)
    {
        if (m_BattleMyMainCardAvility.m_BattleModeCard == null)
        {
            return;
        }
        this.m_MyMainCardsManager = m_GameManager.GetMyMainCardsManager();
        this.m_EnemyMainCardsManager = m_GameManager.GetEnemyMainCardsManager();


        if (m_BattleMyMainCardAvility.Takaya)
        {
            Action action_P3_S01_062 = new Action(m_GameManager, EnumController.Action.P3_S01_062);
            action_P3_S01_062.SetParamaterEventAnimationManager(m_EventAnimationManager);
            action_P3_S01_062.SetParamaterBattleStrix(m_BattleStrix);
            action_P3_S01_062.SetParamaterBattleModeCard(m_BattleMyMainCardAvility.m_BattleModeCard);
            action_P3_S01_062.SetParamaterNum(m_BattleMyMainCardAvility.PlaceNum);
            m_GameManager.ActionList.Add(action_P3_S01_062);
        }
        int enemyPlace = -1;
        switch (m_BattleMyMainCardAvility.m_BattleModeCard.cardNo)
        {
            // 【自】 このカードが【リバース】した時、このカードとバトルしているキャラのレベルが1以下なら、あなたはそのキャラを【リバース】してよい。
            case EnumController.CardNo.DC_W01_16T:
            case EnumController.CardNo.P3_S01_058:
                switch (m_BattleMyMainCardAvility.PlaceNum)
                {
                    case 0:
                        enemyPlace = 2;
                        break;
                    case 1:
                        enemyPlace = 1;
                        break;
                    case 2:
                        enemyPlace = 0;
                        break;
                    default:
                        break;
                }
                if (m_EnemyMainCardsManager.GetFieldLevel(enemyPlace) <= 1 && m_EnemyMainCardsManager.GetState(enemyPlace) != EnumController.State.REVERSE)
                {
                    Action action = new Action(m_GameManager, EnumController.Action.DC_W01_16T);
                    action.SetParamaterBattleModeCard(m_BattleMyMainCardAvility.m_BattleModeCard);
                    action.SetParamaterNum(m_BattleMyMainCardAvility.PlaceNum);
                    m_GameManager.ActionList.Add(action);
                }
                return;
            //【自】 このカードが【リバース】した時、このカードとバトルしているキャラのレベルが0以下なら、あなたはそのキャラを【リバース】してよい。
            case EnumController.CardNo.P3_S01_057:
                switch (m_BattleMyMainCardAvility.PlaceNum)
                {
                    case 0:
                        enemyPlace = 2;
                        break;
                    case 1:
                        enemyPlace = 1;
                        break;
                    case 2:
                        enemyPlace = 0;
                        break;
                    default:
                        break;
                }
                if (m_EnemyMainCardsManager.GetFieldLevel(enemyPlace) <= 0 && m_EnemyMainCardsManager.GetState(enemyPlace) != EnumController.State.REVERSE)
                {
                    Action action = new Action(m_GameManager, EnumController.Action.P3_S01_057_2);
                    action.SetParamaterBattleModeCard(m_BattleMyMainCardAvility.m_BattleModeCard);
                    action.SetParamaterNum(m_BattleMyMainCardAvility.PlaceNum);
                    m_GameManager.ActionList.Add(action);
                }
                return;
            default:
                return;
        }
    }

    /// <summary>
    /// 「【自】 他のバトルしているあなたのキャラが【リバース】した時」に発動する効果
    /// <summary>
    public void EffectWhenMyOtherCardReversed(BattleMyMainCardAvility m_BattleMyMainCardAvility)
    {
        if(m_BattleMyMainCardAvility.m_BattleModeCard == null)
        {
            return;
        }

        switch (m_BattleMyMainCardAvility.m_BattleModeCard.cardNo)
        {
            //【自】 他のバトルしているあなたのキャラが【リバース】した時、そのターン中、このカードのパワーを＋2000。
            case EnumController.CardNo.P3_S01_055:
                Action action_P3_S01_055 = new Action(m_GameManager, EnumController.Action.P3_S01_055);
                action_P3_S01_055.SetParamaterEventAnimationManager(m_EventAnimationManager);
                action_P3_S01_055.SetParamaterBattleStrix(m_BattleStrix);
                action_P3_S01_055.SetParamaterBattleModeCard(m_BattleMyMainCardAvility.m_BattleModeCard);
                action_P3_S01_055.SetParamaterNum(m_BattleMyMainCardAvility.PlaceNum);
                m_GameManager.ActionList.Add(action_P3_S01_055);
                return;
            // 【自】 他のバトルしているあなたのキャラが【リバース】した時、あなたは自分のキャラを1枚選び、そのターン中、パワーを＋1000。
            case EnumController.CardNo.DC_W01_07T:
                Action action_DC_W01_07T = new Action(m_GameManager, EnumController.Action.DC_W01_07T);
                action_DC_W01_07T.SetParamaterBattleModeCard(m_BattleMyMainCardAvility.m_BattleModeCard);
                m_GameManager.ActionList.Add(action_DC_W01_07T);
                return;
            default:
                return;
        }
    }

    /// <summary>
    /// 「【自】 他のあなたのキャラがプレイされて舞台に置かれた時」に発動する効果
    /// </summary>
    /// <param name="effectCard">効果を発動するカード</param>
    /// <param name="placeNum">プレイされたカードの位置</param>
    /// <param name="effectCardPlaceNum">効果を発動するカードの位置</param>
    public void EffectWhenMyOtherCardPut(BattleModeCard effectCard, int placeNum, int effectCardPlaceNum)
    {
        if (effectCard == null)
        {
            return;
        }
        this.m_MyMainCardsManager = m_GameManager.GetMyMainCardsManager();
        switch (effectCard.cardNo)
        {
            case EnumController.CardNo.P3_S01_040:
                //【自】［このカードを【レスト】する］ 他の《スポーツ》のあなたのキャラがプレイされて舞台に置かれた時、あなたはコストを払ってよい。そうしたら、あなたは自分の山札の上から1枚を、ストック置場に置く。
                if (m_MyMainCardsManager.HaveAttribute(placeNum, EnumController.Attribute.Sports) && m_MyMainCardsManager.GetState(effectCardPlaceNum) == EnumController.State.STAND)
                {
                    Action action = new Action(m_GameManager, EnumController.Action.P3_S01_040);
                    action.SetParamaterEventAnimationManager(m_EventAnimationManager);
                    action.SetParamaterBattleStrix(m_BattleStrix);
                    action.SetParamaterBattleModeCard(effectCard);
                    action.SetParamaterNum(effectCardPlaceNum);
                    m_GameManager.ActionList.Add(action);
                    return;
                }
                return;
            case EnumController.CardNo.P3_S01_076:
                //【自】［(1) このカードを【レスト】する］ 他の《生徒会》のあなたのキャラがプレイされて舞台に置かれた時、あなたはコストを払ってよい。そうしたら、あなたは1枚引く。
                if (m_MyMainCardsManager.HaveAttribute(placeNum, EnumController.Attribute.StudentCouncil) && ConfirmStockForCost(1))
                {
                    Action action = new Action(m_GameManager, EnumController.Action.P3_S01_076);
                    action.SetParamaterEventAnimationManager(m_EventAnimationManager);
                    action.SetParamaterBattleStrix(m_BattleStrix);
                    action.SetParamaterBattleModeCard(effectCard);
                    action.SetParamaterNum(effectCardPlaceNum);
                    m_GameManager.ActionList.Add(action);
                    return;
                }
                return;
            case EnumController.CardNo.P3_S01_16T:
            case EnumController.CardNo.P3_S01_087:
                //【自】 他の《生徒会》のあなたのキャラがプレイされて舞台に置かれた時、あなたは自分の山札を上から1枚見て、山札の上か下に置く。
                if (m_MyMainCardsManager.HaveAttribute(placeNum, EnumController.Attribute.StudentCouncil))
                {
                    Action action = new Action(m_GameManager, EnumController.Action.P3_S01_16T);
                    action.SetParamaterEventAnimationManager(m_EventAnimationManager);
                    action.SetParamaterBattleStrix(m_BattleStrix);
                    action.SetParamaterBattleModeCard(effectCard);
                    m_GameManager.ActionList.Add(action);
                    return;
                }
                return;
            default:
                return;
        }
    }

    
    /// 効果を発動するために必要なストックを満たしているか
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    private bool ConfirmStockForCost(int num)
    {
        if(m_GameManager.myStockList.Count >= num)
        {
            return true;
        }
        return false;
    }

    private bool ConfirmClimaxCombo(EnumController.CardNo card)
    {
        if (m_GameManager.MyClimaxCard == null)
        {
            return false;
        }
        if (m_GameManager.MyClimaxCard.cardNo == card)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// 起動効果の分岐
    /// </summary>
    /// <param name="card"></param>
    /// <param name="num">メインのどの場所にいてるか</param>
    public void CheckEffectForAct(BattleModeCard card, int num)
    {
        switch (card.cardNo)
        {
            //ドロー集中
            case EnumController.CardNo.AT_WX02_A09:
                if (ConfirmStockForCost(1))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_BRAIN_STORM_FOR_DRAW, card, num);
                }
                return;
            case EnumController.CardNo.DC_W01_01T:
                if (ConfirmStockForCost(0))
                {
                    // 【起】［このカードを【レスト】する］ あなたは自分のキャラを1枚選び、そのターン中、パワーを＋1000。
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_DC_W01_01T, card, num);
                }
                return;
            // 【起】［(1)］ そのターン中、このカードのパワーを＋2000。
            case EnumController.CardNo.DC_W01_04T:
                if (ConfirmStockForCost(1))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_DC_W01_04T, card, num);
                }
                return;
            // 【起】［(1)］ あなたは相手の前列のキャラを1枚選び、そのターン中、パワーを－1000。
            case EnumController.CardNo.DC_W01_05T:
                if (ConfirmStockForCost(1))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_DC_W01_05T, card, num);
                }
                return;
            // 【起】［(2) このカードを【レスト】する］ あなたは自分の控え室のキャラを1枚選び、手札に戻す。
            case EnumController.CardNo.DC_W01_13T:
                if (ConfirmStockForCost(2))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_DC_W01_13T, card, num);
                }
                return;
            // 【起】［(1)］ あなたは自分のキャラを1枚選び、そのターン中、パワーを＋1500。
            // 【起】［(1)］ このカードを思い出にする。
            case EnumController.CardNo.LB_W02_02T:
                List<SelectActEffectDialogContent> LB_W02_02T_List = new List<SelectActEffectDialogContent>();
                if (ConfirmStockForCost(1))
                {
                    // effect1: 【起】［(1)］ あなたは自分のキャラを1枚選び、そのターン中、パワーを＋1500。
                    SelectActEffectDialogContent m_effect1 = new SelectActEffectDialogContent(m_GameManager, card, 0);
                    LB_W02_02T_List.Add(m_effect1);

                    // effect2:【起】［(1)］ このカードを思い出にする。
                    SelectActEffectDialogContent m_effect2 = new SelectActEffectDialogContent(m_GameManager, card, 1);
                    m_effect2.SetParamaterNum1(num);
                    LB_W02_02T_List.Add(m_effect2);

                    // m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_SEND_MEMORY, card, num);
                }

                if(LB_W02_02T_List.Count > 0)
                {
                    m_GameManager.m_DialogManager.SelectActEffectDialog(LB_W02_02T_List);
                }
                return;
            // 【起】［(1)］ 他のあなたのキャラすべてに、そのターン中、《動物》を与える。
            case EnumController.CardNo.LB_W02_05T:
                if (ConfirmStockForCost(1))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_LB_W02_05T, card, num);
                }
                return;
            // 【起】［(1)］ あなたは相手のキャラを1枚選び、そのターン中、パワーを－500。
            case EnumController.CardNo.LB_W02_09T:
                if (ConfirmStockForCost(1))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_LB_W02_09T, card, num);
                }
                return;
            case EnumController.CardNo.LB_W02_14T:
                // 【起】［(2) このカードを【レスト】する］ あなたは自分のクロックを上から1枚選び、控え室に置く。
                if (ConfirmStockForCost(2))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_LB_W02_14T, card, num);
                }
                return;
            //【起】［(1)］ あなたは《動物》の自分のキャラを1枚選び、そのターン中、パワーを＋500。
            case EnumController.CardNo.LB_W02_17T:
                if (ConfirmStockForCost(1))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_LB_W02_17T, card, num);
                }
                return;
            case EnumController.CardNo.P3_S01_002:
                // 【起】［(2) このカードを【レスト】する］ このカードを思い出にする。あなたは自分の手札の「主人公＆タナトス」を１枚選び、このカードがいた枠に置く。
                if (ConfirmStockForCost(2))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_002, card, num);
                }
                return;
            case EnumController.CardNo.P3_S01_04T:
            case EnumController.CardNo.P3_S01_010:
                // 【起】［(2) このカードを【レスト】する］ あなたはこのカードを手札に戻す。
                if (ConfirmStockForCost(2))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_04T, card, num);
                }
                return;
            case EnumController.CardNo.P3_S01_11T:
            case EnumController.CardNo.P3_S01_017:
                //【起】［(1)］ そのターン中、このカードのソウルを＋1。
                if (ConfirmStockForCost(1))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_11T_2, card, num);
                }
                return;
            case EnumController.CardNo.P3_S01_16T:
            case EnumController.CardNo.P3_S01_087:
                // 【起】［(2) このカードを【レスト】する］ あなたは1枚引く。
                if (ConfirmStockForCost(2))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_16T, card, num);
                }
                return;
            case EnumController.CardNo.P3_S01_028:
                // 【起】［(2)］ そのターン中、このカードのパワーを＋5000。
                if (ConfirmStockForCost(2))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_028, card, num);
                }
                return;
            case EnumController.CardNo.P3_S01_034:
                // 【起】［(1)］ そのターン中、このカードのパワーを＋2000。
                if (ConfirmStockForCost(1))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_034, card, num);
                }
                return;
            case EnumController.CardNo.P3_S01_051:
                //【起】［(1)］ あなたは自分のカード名に「順平」を含むキャラを１枚選び、そのターン中、パワーを＋1000。
                if (ConfirmStockForCost(1))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_051, card, num);
                }
                return;
            case EnumController.CardNo.P3_S01_052:
                // 【起】［(3)］ あなたはレベル1以下の相手の前列のキャラを1枚選び、控え室に置く。
                if (ConfirmStockForCost(3))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_052, card, num);
                }
                return;
            case EnumController.CardNo.P3_S01_077:
                // 【起】［(4)］ あなたは自分の山札を見てイベントを1枚まで選んで相手に見せ、手札に加える。その山札をシャッフルする。
                if (ConfirmStockForCost(4))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_077, card, num);
                }
                return;
            case EnumController.CardNo.P3_S01_080:
                //【起】［(2) このカードを【レスト】する］ あなたはクライマックス以外の自分の控え室のカードを1枚選び、そのカードとこのカードを山札に戻す。その山札をシャッフルする。あなたは1枚引く。
                if (ConfirmStockForCost(2))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_080, card, num);
                }
                return;
            case EnumController.CardNo.P3_S01_081:
                // 【起】［(4)］ あなたは自分のクロックを1枚選び、手札に戻す。
                if (ConfirmStockForCost(4))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_081, card, num);
                }
                return;
            case EnumController.CardNo.P3_S01_091:
                // 【起】［(2) このカードを【レスト】する］ あなたはこのカードを手札に戻す。
                if (ConfirmStockForCost(2))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_091, card, num);
                }
                return;
            case EnumController.CardNo.LB_W02_001:
                // 【起】［(2) このカードを【レスト】する］ あなたは自分の山札を見て《スポーツ》のキャラを1枚まで選んで相手に見せ、手札に加える。その山札をシャッフルする。
                if (ConfirmStockForCost(2))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_LB_W02_001, card, num);
                }
                return;
            default:
                return;
        }
    }

    /// <summary>
    /// 応援の効果を持っているか調べる
    /// </summary>
    /// <param name="card">BattleModeCard</param>
    /// <returns></returns>
    public PowerInstance.Assist CheckEffectForAssist(BattleModeCard card)
    {
        if(card == null)
        {
            return new PowerInstance.Assist(0);
        }
        switch (card.cardNo)
        {
            // 500応援
            case EnumController.CardNo.AT_WX02_A11:
            case EnumController.CardNo.LB_W02_05T:
            case EnumController.CardNo.LB_W02_17T:
            case EnumController.CardNo.P3_S01_02T:
            case EnumController.CardNo.P3_S01_007:
            case EnumController.CardNo.P3_S01_053:
            case EnumController.CardNo.P3_S01_063:
            case EnumController.CardNo.P3_S01_076:
            case EnumController.CardNo.P3_S01_083:
            case EnumController.CardNo.LB_W02_001:
                return new PowerInstance.Assist(500);
            default:
                return new PowerInstance.Assist(0);
        }
    }

    /// <summary>
    /// アンコール ［手札のキャラを1枚控え室に置く］を持つキャラへの応援の効果を持っているか調べる
    /// </summary>
    /// <param name="card">BattleModeCard</param>
    /// <returns></returns>
    public PowerInstance.AssistForHaveEncore CheckEffectForAssistForHaveEncore(BattleModeCard card)
    {
        if (card == null)
        {
            return new PowerInstance.AssistForHaveEncore(0);
        }
        switch (card.cardNo)
        {
            // 1000応援
            case EnumController.CardNo.P3_S01_041:
            case EnumController.CardNo.P3_S01_076:
                return new PowerInstance.AssistForHaveEncore(1000);
            default:
                return new PowerInstance.AssistForHaveEncore(0);
        }
    }

    /// <summary>
    /// 全体応援の効果を持っているか調べる
    /// </summary>
    /// <param name="card"></param>
    /// <returns></returns>
    public PowerInstance.AllAssist CheckEffectForAllAssist(BattleModeCard card)
    {
        List<EnumController.Attribute> AttributeList = new List<EnumController.Attribute>();
        if (card == null)
        {
            return new PowerInstance.AllAssist(0, AttributeList);
        }

        switch (card.cardNo)
        {
            case EnumController.CardNo.P3_S01_084:
                AttributeList.Add(EnumController.Attribute.StudentCouncil);
                return new PowerInstance.AllAssist(500, AttributeList);
            default:
                return new PowerInstance.AllAssist(0, AttributeList);
        }
    }

    /// <summary>
    /// ガウルの効果を持っているか調べる
    /// </summary>
    /// <param name="card"></param>
    /// <returns></returns>
    public PowerInstance.Gaul CheckEffectForGaul(BattleModeCard card)
    {
        if (card == null)
        {
            return new PowerInstance.Gaul();
        }
        List<EnumController.Attribute> AttributeList = new List<EnumController.Attribute>();

        switch (card.cardNo)
        {
            // ガウル効果を持っている
            case EnumController.CardNo.AT_WX02_A12:
                AttributeList.Add(EnumController.Attribute.Ooo);
                return new PowerInstance.Gaul(500, AttributeList);
            default:
                return new PowerInstance.Gaul();
        }
    }

    /// <summary>
    /// レベル応援の効果を持っているか調べる
    /// </summary>
    /// <param name="card">BattleModeCard</param>
    /// <returns></returns>
    public PowerInstance.LevelAssist CheckEffectForLevelAssist(BattleModeCard card)
    {
        if (card == null)
        {
            return new PowerInstance.LevelAssist(0);
        }
        switch (card.cardNo)
        {
            // レベル*500応援
            case EnumController.CardNo.AT_WX02_A06:
                return new PowerInstance.LevelAssist(500);
            default:
                return new PowerInstance.LevelAssist(0);
        }
    }

    /// <summary>
    /// アタックしたときの効果を持っているか調べる
    /// </summary>
    /// <param name="card"></param>
    public bool CheckWhenAttack(BattleModeCard card, int place, EnumController.Attack status)
    {
        this.m_MyMainCardsManager = m_GameManager.GetMyMainCardsManager();
        switch (card.cardNo)
        {
            case EnumController.CardNo.AT_WX02_A02:
                Action action = new Action(m_GameManager, EnumController.Action.ExecuteAttack2);
                action.SetParamaterMyMainCardsManager(m_MyMainCardsManager);
                action.SetParamaterAttackStatus(status);
                action.SetParamaterNum(place);

                m_GameManager.ActionList.Add(action);

                m_GameManager.m_DialogManager.CharacterSelectDialog(card, true, place);
                return true;
            case EnumController.CardNo.DC_W01_02T:
                // 【自】 このカードがアタックした時、クライマックス置場に「結婚式の歌姫」があるなら、あなたは自分の山札を上から1枚選び、ストック置場に置き、そのターン中、このカードのパワーを＋3000。
                if (m_GameManager.MyClimaxCard == null)
                {
                    return false;
                }

                if (m_GameManager.MyClimaxCard.name == "結婚式の歌姫")
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_DC_W01_02T, card, place, status);
                    return true;
                }
                return false;
            case EnumController.CardNo.DC_W01_10T:
                // 【自】［(1)］ このカードがアタックした時、クライマックス置場に「美春のオルゴール」があるなら、あなたはコストを払ってよい。そうしたら、あなたは自分の控え室のキャラを1枚選び、手札に戻す。
                if (m_GameManager.MyClimaxCard == null)
                {
                    return false;
                }

                if (m_GameManager.MyClimaxCard.name == "美春のオルゴール" && ConfirmStockForCost(1))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_DC_W01_10T, card, place, status);
                    return true;
                }
                return false;
            case EnumController.CardNo.LB_W02_03T:
                // 【自】 このカードがアタックした時、クライマックス置場に「そよ風のハミング」があるなら、あなたは自分の山札を上から1枚選び、ストック置場に置き、そのターン中、このカードのパワーを＋3000。
                if (m_GameManager.MyClimaxCard == null)
                {
                    return false;
                }

                if (m_GameManager.MyClimaxCard.name == "そよ風のハミング")
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_LB_W02_03T, card, place, status);
                    return true;
                }
                return false;
            case EnumController.CardNo.P3_S01_004:
                // 【自】 このカードがアタックした時、クライマックス置場に「露天風呂」があるなら、あなたは相手のキャラを1枚選び、手札に戻してよい。
                if (m_GameManager.MyClimaxCard == null)
                {
                    return false;
                }

                if (m_GameManager.MyClimaxCard.name == "露天風呂")
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_004, card, place, status);
                    return true;
                }
                return false;
            case EnumController.CardNo.P3_S01_01T:
            case EnumController.CardNo.P3_S01_005:
                // 【自】 このカードがアタックした時、クライマックス置場に「復讐の終わり」があるなら、あなたは相手のキャラを1枚選び、手札に戻してよい。
                if (m_GameManager.MyClimaxCard == null)
                {
                    return false;
                }

                if (m_GameManager.MyClimaxCard.name == "復讐の終わり")
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_01T, card, place, status);
                    return true;
                }
                return false;
            case EnumController.CardNo.P3_S01_11T:
            case EnumController.CardNo.P3_S01_017:
                if (m_GameManager.MyClimaxCard == null)
                {
                    return false;
                }

                if (m_GameManager.MyClimaxCard.name == "最後の選択")
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_11T_1, card, place, status);
                    return true;
                }
                return false;
            case EnumController.CardNo.P3_S01_030:
                // 【自】 このカードがアタックした時、クライマックス置場に「切れない絆」があるなら、あなたは自分の山札の上から1枚を、ストック置場に置き、そのターン中、このカードのパワーを＋3000。
                if (m_GameManager.MyClimaxCard == null)
                {
                    return false;
                }

                if (m_GameManager.MyClimaxCard.name == "切れない絆")
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_030, card, place, status);
                    return true;
                }
                return false;
            case EnumController.CardNo.P3_S01_055:
                //【自】 このカードがアタックした時、クライマックス置場に「ありがとう」があるなら、あなたは自分の控え室のキャラを1枚選び、手札に戻す。
                if (m_GameManager.MyClimaxCard == null)
                {
                    return false;
                }

                if (m_GameManager.MyClimaxCard.name == "ありがとう")
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_055, card, place, status);
                    return true;
                }
                return false;
            case EnumController.CardNo.P3_S01_056:
                // 【自】 このカードがアタックした時、クライマックス置場に「友への誓い」があるなら、あなたは自分の控え室のキャラを1枚選び、手札に戻す。
                if (m_GameManager.MyClimaxCard == null)
                {
                    return false;
                }

                if (m_GameManager.MyClimaxCard.name == "友への誓い")
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_056, card, place, status);
                    return true;
                }
                return false;
            case EnumController.CardNo.P3_S01_061:
                //【自】 このカードがアタックした時、クライマックス置場に「ニュクス・アバター」があるなら、あなたは自分の控え室のキャラを1枚選び、手札に戻す。
                if (m_GameManager.MyClimaxCard == null)
                {
                    return false;
                }

                if (m_GameManager.GraveYardList.Count > 0 && m_GameManager.MyClimaxCard.name == "ニュクス・アバター")
                {
                    Action action_P3_S01_061 = new Action(m_GameManager, EnumController.Action.ExecuteAttack2);
                    action_P3_S01_061.SetParamaterMyMainCardsManager(m_MyMainCardsManager);
                    action_P3_S01_061.SetParamaterAttackStatus(status);
                    action_P3_S01_061.SetParamaterNum(place);

                    m_GameManager.ActionList.Add(action_P3_S01_061);
                    m_EventAnimationManager.AnimationStart_2(card, place);
                    m_BattleStrix.EventAnimation(card, m_GameManager.isFirstAttacker);
                    return true;
                }
                return false;
            case EnumController.CardNo.P3_S01_077:
                //【自】 このカードがアタックした時、クライマックス置場に「最強なる者」があるなら、あなたは1枚引く。
                if (m_GameManager.MyClimaxCard == null)
                {
                    return false;
                }

                if (m_GameManager.MyClimaxCard.name == "最強なる者")
                {
                    Action action_P3_S01_077 = new Action(m_GameManager, EnumController.Action.ExecuteAttack2);
                    action_P3_S01_077.SetParamaterMyMainCardsManager(m_MyMainCardsManager);
                    action_P3_S01_077.SetParamaterAttackStatus(status);
                    action_P3_S01_077.SetParamaterNum(place);

                    m_GameManager.ActionList.Add(action_P3_S01_077);
                    m_EventAnimationManager.AnimationStart(card, place);
                    m_BattleStrix.EventAnimation(card, m_GameManager.isFirstAttacker);
                    return true;
                }
                return false;
            case EnumController.CardNo.P3_S01_081:
                //【自】 このカードがアタックした時、クライマックス置場に「父の遺志」があるなら、あなたは1枚引く。
                if (m_GameManager.MyClimaxCard == null)
                {
                    return false;
                }

                if (m_GameManager.MyClimaxCard.name == "父の遺志")
                {
                    Action action_P3_S01_081 = new Action(m_GameManager, EnumController.Action.ExecuteAttack2);
                    action_P3_S01_081.SetParamaterMyMainCardsManager(m_MyMainCardsManager);
                    action_P3_S01_081.SetParamaterAttackStatus(status);
                    action_P3_S01_081.SetParamaterNum(place);

                    m_GameManager.ActionList.Add(action_P3_S01_081);
                    m_EventAnimationManager.AnimationStart(card, place);
                    m_BattleStrix.EventAnimation(card, m_GameManager.isFirstAttacker);
                    return true;
                }
                return false;
            case EnumController.CardNo.LB_W02_002:
                //【自】［(1)］ このカードがアタックした時、クライマックス置場に「鈴と共にある日々」があるなら、あなたはコストを払ってよい。そうしたら、あなたは相手のキャラを１枚選び、手札に戻す。
                if (m_GameManager.MyClimaxCard == null)
                {
                    return false;
                }

                if (m_GameManager.MyClimaxCard.name == "鈴と共にある日々" && ConfirmStockForCost(1))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_LB_W02_002, card, place, status);
                    return true;
                }
                return false;
            case EnumController.CardNo.LB_W02_004:
                //【自】［(1)］ このカードがアタックした時、クライマックス置場に「リーダーの帰還」があるなら、あなたはコストを払ってよい。そうしたら、あなたは相手のキャラを１枚選び、手札に戻す。
                if (m_GameManager.MyClimaxCard == null)
                {
                    return false;
                }

                if (m_GameManager.MyClimaxCard.name == "リーダーの帰還" && ConfirmStockForCost(1))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_LB_W02_004, card, place, status);
                    return true;
                }
                return false;
            default:
                return false;
        }
    }
}
