using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    private GameManager m_GameManager = null;
    private BattleStrix m_BattleStrix = null;
    private MyMainCardsManager m_MyMainCardsManager;
    private EnemyMainCardsManager m_EnemyMainCardsManager;

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
                if (ConfirmStockForCost(1))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_BOND_FOR_HAND_TO_FIELD, card);
                }
                return;
            default:
                return;
        }
    }

    /// <summary>
    /// 相手のカードをリバースしたときに発動する効果
    /// </summary>
    /// <param name="reversedCardPlace">リバースしたキャラの場所(リバースしたキャラのコントローラー視点)</param>
    public void WhenReverseEnemyCardEffect(BattleModeCard card, int reversedCardPlace)
    {
        switch (card.cardNo)
        {
            case EnumController.CardNo.AT_WX02_A03:
                if (ConfirmClimaxCombo(EnumController.CardNo.AT_WX02_A08))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.CONFIRM_CARD_EFFECT, card);
                }
                return;
            case EnumController.CardNo.DC_W01_10T:
                m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.CONFIRM_CARD_EFFECT, card, reversedCardPlace);
                return;
            default:
                return;
        }
    }

    /// <summary>
    /// 自分がリバースしたときに発動する効果
    /// </summary>
    public void WhenReverseMyCardEffect(BattleModeCard card, int place)
    {
        this.m_MyMainCardsManager = m_GameManager.GetMyMainCardsManager();
        this.m_EnemyMainCardsManager = m_GameManager.GetEnemyMainCardsManager();
        Debug.Log(place);
        switch (card.cardNo)
        {
            case EnumController.CardNo.DC_W01_16T:
                int enemyPlace = -1;
                switch (place)
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
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.CONFIRM_CARD_EFFECT, card, place);
                }
                return;
            default:
                return;
        }
    }

    /// <summary>
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
                if (ConfirmStockForCost(1))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_SEND_MEMORY, card, num);
                }
                return;
            // 【起】［(1)］ 他のあなたのキャラすべてに、そのターン中、《動物》を与える。
            case EnumController.CardNo.LB_W02_05T:
                if (ConfirmStockForCost(1))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_LB_W02_05T, card, num);
                }
                return;
            //【起】［(1)］ あなたは《動物》の自分のキャラを1枚選び、そのターン中、パワーを＋500。
            case EnumController.CardNo.LB_W02_17T:
                if (ConfirmStockForCost(1))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_LB_W02_17T, card, num);
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
                return new PowerInstance.Assist(500);
            default:
                return new PowerInstance.Assist(0);
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
        switch (card.cardNo)
        {
            case EnumController.CardNo.AT_WX02_A02:
                m_GameManager.m_DialogManager.CharacterSelectDialog(m_GameManager.myFieldList, place, status);
                return true;
            /*case EnumController.CardNo.DC_W01_10T:
                if (ConfirmStockForCost(1))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_DC_W01_10T, card, num);
                    return true;
                }
                return false;*/
            case EnumController.CardNo.LB_W02_03T:
                /*if (m_GameManager.MyClimaxCard.cardNo == EnumController.CardNo.LB_W02_10T)
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_LB_W02_03T, card, place);
                    return true;
                }*/
                return false;
            default:
                return false;
        }
    }
}
