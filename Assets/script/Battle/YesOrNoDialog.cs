using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EnumController;

public class YesOrNoDialog : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] GameObject cardObject;
    [SerializeField] Image cardObjectImage;
    [SerializeField] BattleStrix m_BattleStrix;
    [SerializeField] GameManager m_GameManager;
    [SerializeField] MyHandCardsManager m_MyHandCardsManager;
    [SerializeField] MyMainCardsManager m_MyMainCardsManager;
    [SerializeField] DialogManager m_DialogManager;
    [SerializeField] EffectBondForHandToField m_EffectBondForHandToField;
    [SerializeField] EffectBrainStormForDraw m_EffectBrainStormForDraw;
    [SerializeField] EventAnimationManager m_EventAnimationManager;
    [SerializeField] BattleModeCard P3_S01_062;

    private BattleModeCard m_BattleModeCard = null;

    private EnumController.YesOrNoDialogParamater m_YesOrNoDialogParamater;

    private int ParamaterNum1 = -1;

    private int ParamaterNum2 = -1;

    private int ParamaterNum3 = -1;

    private EnumController.Attack attackStatus = EnumController.Attack.VOID;

    private StringValues stringValues = new StringValues();

    /// <summary>
    /// カードの効果を使用するためのコスト
    /// </summary>
    private int cost = 0;

    /// <summary>
    /// 絆効果で回収するカードの名前
    /// </summary>
    private string sulvageCardName = "";

    public YesOrNoDialog()
    {
        m_YesOrNoDialogParamater = EnumController.YesOrNoDialogParamater.VOID;
    }

    public void SetParamater(EnumController.YesOrNoDialogParamater paramater)
    {
        SetParamater(paramater, null, -1, -1, -1, EnumController.Attack.VOID);
    }

    public void SetParamater(EnumController.YesOrNoDialogParamater paramater, BattleModeCard card)
    {
        SetParamater(paramater, card, -1, -1, -1, EnumController.Attack.VOID);
    }

    public void SetParamater(EnumController.YesOrNoDialogParamater paramater, BattleModeCard card, int num)
    {
        SetParamater(paramater, card, num, -1, -1, EnumController.Attack.VOID);
    }

    public void SetParamater(EnumController.YesOrNoDialogParamater paramater, BattleModeCard card, int num, EnumController.Attack status)
    {
        SetParamater(paramater, card, num, -1, -1, status);
    }

    public void SetParamater(EnumController.YesOrNoDialogParamater paramater, BattleModeCard card, int num1, int num2)
    {
        SetParamater(paramater, card, num1, num2, -1, EnumController.Attack.VOID);
    }

    public void SetParamater(EnumController.YesOrNoDialogParamater paramater, BattleModeCard card, int num1, int num2, int num3)
    {
        SetParamater(paramater, card, num1, num2, num3, EnumController.Attack.VOID);
    }

    private void SetParamater(EnumController.YesOrNoDialogParamater paramater, BattleModeCard card, int num1, int num2, int num3, EnumController.Attack status)
    {
        ParamaterNum1 = num1;
        ParamaterNum2 = num2;
        ParamaterNum3 = num3;
        m_BattleModeCard = card;
        attackStatus = status;
        sulvageCardName = "";
        cost = 0;
        this.gameObject.SetActive(true);
        cardObject.SetActive(false);
        m_YesOrNoDialogParamater = paramater;
        SetText();
        WaitDialog();
    }

    private void SetText()
    {
        string str = "";
        switch (m_YesOrNoDialogParamater)
        {
            case EnumController.YesOrNoDialogParamater.CONFIRM_CARD_EFFECT:
                str = stringValues.YesOrNoDialog_CONFIRM_CARD_EFFECT(m_BattleModeCard.name);
                break;
            case EnumController.YesOrNoDialogParamater.CONFIRM_USE_COUNTER:
                str = stringValues.YesOrNoDialog_CONFIRM_USE_COUNTER;
                break;
            case EnumController.YesOrNoDialogParamater.CLIMAX_PHASE:
                str = stringValues.YesOrNoDialog_CLIMAX_PHASE;
                break;
            case EnumController.YesOrNoDialogParamater.CONFIRM_BOOK_TRIGGER_FRONT:
            case EnumController.YesOrNoDialogParamater.CONFIRM_BOOK_TRIGGER_SIDE:
            case EnumController.YesOrNoDialogParamater.CONFIRM_BOOK_TRIGGER_DIRECT:
                str = stringValues.YesOrNoDialog_CONFIRM_BOOK_TRIGGER;
                break;
            case EnumController.YesOrNoDialogParamater.CONFIRM_BOUNCE_TRIGGER_FRONT:
            case EnumController.YesOrNoDialogParamater.CONFIRM_BOUNCE_TRIGGER_SIDE:
            case EnumController.YesOrNoDialogParamater.CONFIRM_BOUNCE_TRIGGER_DIRECT:
                str = stringValues.YesOrNoDialog_CONFIRM_BOUNCE_TRIGGER;
                break;
            case EnumController.YesOrNoDialogParamater.CONFIRM_POOL_TRIGGER_FRONT:
            case EnumController.YesOrNoDialogParamater.CONFIRM_POOL_TRIGGER_SIDE:
            case EnumController.YesOrNoDialogParamater.CONFIRM_POOL_TRIGGER_DIRECT:
                str = stringValues.YesOrNoDialog_CONFIRM_POOL_TRIGGER;
                break;
            case EnumController.YesOrNoDialogParamater.CONFIRM_SEND_ENCORE_PHASE:
                str = stringValues.YesOrNoDialog_CONFIRM_SEND_ENCORE_PHASE;
                break;
            case EnumController.YesOrNoDialogParamater.CONFIRM_CONTROL_DECKTOP:
                str = stringValues.YesOrNoDialog_CONFIRM_CONTROL_DECKTOP;
                cardObject.SetActive(true);
                cardObjectImage.sprite = m_GameManager.myDeckList[0].sprite;
                break;
            case EnumController.YesOrNoDialogParamater.EVENT_CONFIRM:
                str = stringValues.YesOrNoDialog_EVENT_CONFIRM(m_BattleModeCard.name);
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_HAND_TO_FIELD:
                str = stringValues.YesOrNoDialog_COST_CONFIRM_HAND_TO_FIELD(m_BattleModeCard.cost);
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_BOND_FOR_HAND_TO_FIELD:
                switch (m_BattleModeCard.cardNo)
                {
                    case EnumController.CardNo.AT_WX02_A10:
                        sulvageCardName = stringValues.AT_WX02_A12_NAME;
                        cost = 1;
                        break;
                    case EnumController.CardNo.DC_W01_09T:
                        sulvageCardName = stringValues.DC_W01_10T_NAME;
                        cost = 1;
                        break;
                    case EnumController.CardNo.P3_S01_003:
                        sulvageCardName = stringValues.P3_S01_017_NAME;
                        cost = 1;
                        break;
                    case EnumController.CardNo.P3_S01_032:
                        sulvageCardName = stringValues.P3_S01_030_NAME;
                        cost = 1;
                        break;
                    case EnumController.CardNo.P3_S01_051:
                        sulvageCardName = stringValues.P3_S01_055_NAME;
                        cost = 1;
                        break;
                    case EnumController.CardNo.P3_S01_082:
                        sulvageCardName = stringValues.P3_S01_081_NAME;
                        cost = 1;
                        break;
                    default:
                        sulvageCardName = "";
                        cost = 0;
                        break;
                }
                str = stringValues.YesOrNoDialog_COST_CONFIRM_BOND_FOR_HAND_TO_FIELD(sulvageCardName, cost);
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_BRAIN_STORM_FOR_DRAW:
                str = stringValues.YesOrNoDialog_COST_CONFIRM_BRAIN_STORM_FOR_DRAW;
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_DC_W01_01T:
                str = stringValues.YesOrNoDialog_COST_CONFIRM_DC_W01_01T;
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_DC_W01_02T:
                str = stringValues.YesOrNoDialog_COST_CONFIRM_DC_W01_02T;
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_DC_W01_04T:
                str = stringValues.YesOrNoDialog_COST_CONFIRM_DC_W01_04T;
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_DC_W01_05T:
                str = stringValues.YesOrNoDialog_COST_CONFIRM_DC_W01_05T;
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_DC_W01_10T:
                str = stringValues.YesOrNoDialog_COST_CONFIRM_DC_W01_10T;
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_DC_W01_13T:
                str = stringValues.YesOrNoDialog_COST_CONFIRM_DC_W01_13T;
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_LB_W02_02T_1:
                str = stringValues.YesOrNoDialog_COST_CONFIRM_LB_W02_02T_1;
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_LB_W02_02T_2:
                str = stringValues.YesOrNoDialog_COST_CONFIRM_LB_W02_02T_2;
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_LB_W02_03T:
                str = stringValues.YesOrNoDialog_COST_CONFIRM_LB_W02_03T;
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_LB_W02_05T:
                str = stringValues.YesOrNoDialog_COST_CONFIRM_LB_W02_05T;
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_LB_W02_09T:
                str = stringValues.YesOrNoDialog_COST_CONFIRM_LB_W02_09T;
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_LB_W02_14T:
                str = stringValues.YesOrNoDialog_COST_CONFIRM_LB_W02_14T;
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_LB_W02_17T:
                str = stringValues.YesOrNoDialog_COST_CONFIRM_LB_W02_17T;
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_01T:
                str = stringValues.YesOrNoDialog_COST_CONFIRM_P3_S01_01T;
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_04T:
                str = stringValues.YesOrNoDialog_COST_CONFIRM_P3_S01_04T;
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_11T_1:
                str = stringValues.YesOrNoDialog_COST_CONFIRM_P3_S01_11T_1;
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_11T_2:
                str = stringValues.YesOrNoDialog_COST_CONFIRM_P3_S01_11T_2;
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_16T:
                str = stringValues.YesOrNoDialog_COST_CONFIRM_P3_S01_16T;
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_002:
                str = stringValues.YesOrNoDialog_COST_CONFIRM_P3_S01_02;
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_004:
                str = stringValues.YesOrNoDialog_COST_CONFIRM_P3_S01_04;
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_028:
                str = stringValues.YesOrNoDialog_COST_CONFIRM_P3_S01_28;
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_030:
                str = stringValues.YesOrNoDialog_COST_CONFIRM_P3_S01_30;
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_034:
                str = stringValues.YesOrNoDialog_COST_CONFIRM_P3_S01_34;
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_051:
                str = stringValues.YesOrNoDialog_COST_CONFIRM_P3_S01_51;
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_052:
                str = stringValues.YesOrNoDialog_COST_CONFIRM_P3_S01_52;
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_055:
                str = stringValues.YesOrNoDialog_COST_CONFIRM_P3_S01_55;
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_056:
                str = stringValues.YesOrNoDialog_COST_CONFIRM_P3_S01_56;
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_062:
                str = stringValues.YesOrNoDialog_COST_CONFIRM_P3_S01_62;
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_077:
                str = stringValues.YesOrNoDialog_COST_CONFIRM_P3_S01_77;
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_080:
                str = stringValues.YesOrNoDialog_COST_CONFIRM_P3_S01_80;
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_081:
                str = stringValues.YesOrNoDialog_COST_CONFIRM_P3_S01_81;
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_091:
                str = stringValues.YesOrNoDialog_COST_CONFIRM_P3_S01_91;
                break;
            case EnumController.YesOrNoDialogParamater.VOID:
            default:
                str = "無効メッセージ";
                break;
        }
        text.text = str;
    }
    
    private void WaitDialog()
    {
        switch (m_YesOrNoDialogParamater)
        {
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_062:
            case EnumController.YesOrNoDialogParamater.CONFIRM_USE_COUNTER:
                m_BattleStrix.RpcToAll("NotEraseDialog", true, m_GameManager.isFirstAttacker);
                break;
            case EnumController.YesOrNoDialogParamater.CONFIRM_CARD_EFFECT:
                switch (m_BattleModeCard.cardNo)
                {
                    case EnumController.CardNo.DC_W01_07T:
                    case EnumController.CardNo.DC_W01_10T:
                    case EnumController.CardNo.DC_W01_16T:
                    case EnumController.CardNo.LB_W02_19T:
                    case EnumController.CardNo.P3_S01_040:
                    case EnumController.CardNo.P3_S01_052:
                    case EnumController.CardNo.P3_S01_057:
                    case EnumController.CardNo.P3_S01_058:
                    case EnumController.CardNo.P3_S01_060:
                    case EnumController.CardNo.P3_S01_061:
                    case EnumController.CardNo.P3_S01_076:
                    case EnumController.CardNo.P3_S01_088:
                        m_BattleStrix.RpcToAll("NotEraseDialog", true, m_GameManager.isFirstAttacker);
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
    }

    public void onYesClick()
    {
        switch (m_YesOrNoDialogParamater)
        {
            case EnumController.YesOrNoDialogParamater.CONFIRM_CARD_EFFECT:
                switch (m_BattleModeCard.cardNo)
                {
                    case EnumController.CardNo.AT_WX02_A03:
                        m_GameManager.Draw();
                        break;
                    case EnumController.CardNo.DC_W01_07T:
                    case EnumController.CardNo.DC_W01_10T:
                    case EnumController.CardNo.DC_W01_16T:
                    case EnumController.CardNo.LB_W02_19T:
                    case EnumController.CardNo.P3_S01_07T:
                    case EnumController.CardNo.P3_S01_020:
                    case EnumController.CardNo.P3_S01_040:
                    case EnumController.CardNo.P3_S01_052:
                    case EnumController.CardNo.P3_S01_058:
                    case EnumController.CardNo.P3_S01_060:
                    case EnumController.CardNo.P3_S01_061:
                    case EnumController.CardNo.P3_S01_076:
                    case EnumController.CardNo.P3_S01_088:
                    case EnumController.CardNo.P3_S01_095:
                        m_EventAnimationManager.AnimationStart(m_BattleModeCard, ParamaterNum1);
                        m_BattleStrix.EventAnimation(m_BattleModeCard, m_GameManager.isFirstAttacker);
                        break;
                    case EnumController.CardNo.P3_S01_057:
                    case EnumController.CardNo.P3_S01_080:
                        if (ParamaterNum2 == 1)
                        {
                            m_EventAnimationManager.AnimationStart(m_BattleModeCard, ParamaterNum1);
                            m_BattleStrix.EventAnimation(m_BattleModeCard, m_GameManager.isFirstAttacker);
                            break;
                        }
                        else
                        {
                            m_EventAnimationManager.AnimationStart_2(m_BattleModeCard, ParamaterNum1);
                            m_BattleStrix.EventAnimation(m_BattleModeCard, m_GameManager.isFirstAttacker);
                            break;
                        }
                        break;
                    default:
                        break;
                }
                break;
            case EnumController.YesOrNoDialogParamater.CONFIRM_USE_COUNTER:
                m_GameManager.m_HandCardUtilStatus = EnumController.HandCardUtilStatus.COUNTER_SELECT_MODE;
                m_MyHandCardsManager.canUseCounter();
                // ParamaterNum1:damage ParamaterNum2:place
                m_DialogManager.OKDialog(EnumController.OKDialogParamater.Counter_Confirm_Use_Card, ParamaterNum1, ParamaterNum2);
                break;
            case EnumController.YesOrNoDialogParamater.CONFIRM_BOOK_TRIGGER_FRONT:
            case EnumController.YesOrNoDialogParamater.CONFIRM_BOOK_TRIGGER_SIDE:
            case EnumController.YesOrNoDialogParamater.CONFIRM_BOOK_TRIGGER_DIRECT:
                m_GameManager.myStockList.Add(m_GameManager.myDeckList[0]);
                m_GameManager.myDeckList.RemoveAt(0);
                m_GameManager.Syncronize();

                if (m_GameManager.myDeckList.Count == 0)
                {
                    m_GameManager.Refresh();
                }
                m_GameManager.Syncronize();
                m_GameManager.Draw();

                switch (m_YesOrNoDialogParamater)
                {
                    case EnumController.YesOrNoDialogParamater.CONFIRM_BOOK_TRIGGER_DIRECT:
                        m_BattleStrix.RpcToAll("Damage", ParamaterNum1, m_GameManager.isFirstAttacker, EnumController.Damage.DIRECT_ATTACK, m_GameManager.SendShotList);
                        break;
                    case EnumController.YesOrNoDialogParamater.CONFIRM_BOOK_TRIGGER_SIDE:
                        m_BattleStrix.RpcToAll("Damage", ParamaterNum1, m_GameManager.isFirstAttacker, EnumController.Damage.SIDE_ATTACK, m_GameManager.SendShotList);
                        break;
                    case EnumController.YesOrNoDialogParamater.CONFIRM_BOOK_TRIGGER_FRONT:
                        // ("CallOKDialogForCounter",int damage, int place, m_GameManager.isFirstAttacker,List<EnumController.Shot> ReceiveShotList)
                        m_BattleStrix.RpcToAll("CallOKDialogForCounter", ParamaterNum1, ParamaterNum2, m_GameManager.isFirstAttacker, m_GameManager.SendShotList);
                        break;
                    default:
                        break;
                }
                break;
            case EnumController.YesOrNoDialogParamater.CONFIRM_BOUNCE_TRIGGER_FRONT:
            case EnumController.YesOrNoDialogParamater.CONFIRM_BOUNCE_TRIGGER_SIDE:
            case EnumController.YesOrNoDialogParamater.CONFIRM_BOUNCE_TRIGGER_DIRECT:
                m_GameManager.myStockList.Add(m_GameManager.myDeckList[0]);
                m_GameManager.myDeckList.RemoveAt(0);
                m_GameManager.Syncronize();

                if (m_GameManager.myDeckList.Count == 0)
                {
                    m_GameManager.Refresh();
                }
                m_GameManager.Syncronize();
                m_EventAnimationManager.AnimationStartForBounceTrigger(m_BattleModeCard, ParamaterNum1, ParamaterNum2, m_YesOrNoDialogParamater);
                m_BattleStrix.EventAnimation(m_BattleModeCard, m_GameManager.isFirstAttacker);
                break;
            case EnumController.YesOrNoDialogParamater.CONFIRM_POOL_TRIGGER_FRONT:
            case EnumController.YesOrNoDialogParamater.CONFIRM_POOL_TRIGGER_SIDE:
            case EnumController.YesOrNoDialogParamater.CONFIRM_POOL_TRIGGER_DIRECT:
                if (m_GameManager.myDeckList.Count <= 1)
                {
                    BattleModeCard temp = m_GameManager.myDeckList[0];
                    m_GameManager.myDeckList.RemoveAt(0);
                    m_GameManager.Refresh();
                    m_GameManager.myStockList.Add(m_GameManager.myDeckList[0]);
                    m_GameManager.myDeckList.RemoveAt(0);
                    m_GameManager.myStockList.Add(temp);
                }
                else
                {
                    m_GameManager.myStockList.Add(m_GameManager.myDeckList[1]);
                    m_GameManager.myDeckList.RemoveAt(1);
                    m_GameManager.myStockList.Add(m_GameManager.myDeckList[0]);
                    m_GameManager.myDeckList.RemoveAt(0);
                }
                m_GameManager.Syncronize();

                //m_GameManager.TriggerAfter();

                switch (m_YesOrNoDialogParamater)
                {
                    case EnumController.YesOrNoDialogParamater.CONFIRM_POOL_TRIGGER_DIRECT:
                        m_BattleStrix.RpcToAll("Damage", ParamaterNum1, m_GameManager.isFirstAttacker, EnumController.Damage.DIRECT_ATTACK, m_GameManager.SendShotList);
                        break;
                    case EnumController.YesOrNoDialogParamater.CONFIRM_POOL_TRIGGER_SIDE:
                        m_BattleStrix.RpcToAll("Damage", ParamaterNum1, m_GameManager.isFirstAttacker, EnumController.Damage.SIDE_ATTACK, m_GameManager.SendShotList);
                        break;
                    case EnumController.YesOrNoDialogParamater.CONFIRM_POOL_TRIGGER_FRONT:
                        // ("CallOKDialogForCounter",int damage, int place, m_GameManager.isFirstAttacker,List<EnumController.Shot> ReceiveShotList)
                        m_BattleStrix.RpcToAll("CallOKDialogForCounter", ParamaterNum1, ParamaterNum2, m_GameManager.isFirstAttacker, m_GameManager.SendShotList);
                        break;
                    default:
                        break;
                }
                break;
            case EnumController.YesOrNoDialogParamater.CONFIRM_SEND_ENCORE_PHASE:
                m_GameManager.SendEncorePhase();
                break;
            case EnumController.YesOrNoDialogParamater.CLIMAX_PHASE:
                m_GameManager.SendClimaxPhase(m_BattleModeCard);
                break;
            case EnumController.YesOrNoDialogParamater.EVENT_CONFIRM:
                m_EventAnimationManager.AnimationStart(m_BattleModeCard, -1, ParamaterNum1);
                m_BattleStrix.EventAnimation(m_BattleModeCard, m_GameManager.isFirstAttacker);
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_HAND_TO_FIELD:
                m_DialogManager.MainDialog(m_BattleModeCard, ParamaterNum1);
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_BOND_FOR_HAND_TO_FIELD:
                m_EventAnimationManager.AnimationStartForBond(m_BattleModeCard, sulvageCardName, cost);
                m_BattleStrix.EventAnimation(m_BattleModeCard, m_GameManager.isFirstAttacker);
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_BRAIN_STORM_FOR_DRAW:
                m_EffectBrainStormForDraw.BrainStormForDraw(ParamaterNum1);
                break;
            // 誘発効果を持つキャラクター(効果の解決後にアタック処理する)
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_DC_W01_02T:
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_LB_W02_03T:
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_11T_1:
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_004:
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_030:
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_055:
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_056:
                Action action = new Action(m_GameManager, EnumController.Action.ExecuteAttack2);
                action.SetParamaterMyMainCardsManager(m_MyMainCardsManager);
                action.SetParamaterAttackStatus(attackStatus);
                action.SetParamaterNum(ParamaterNum1);

                m_GameManager.ActionList.Add(action);

                m_EventAnimationManager.AnimationStart(m_BattleModeCard, ParamaterNum1);
                m_BattleStrix.EventAnimation(m_BattleModeCard, m_GameManager.isFirstAttacker);
                break;
            // 誘発効果を持つキャラクター(効果の解決後にアタック処理する)
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_DC_W01_10T:
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_01T:
                Action action2 = new Action(m_GameManager, EnumController.Action.ExecuteAttack2);
                action2.SetParamaterMyMainCardsManager(m_MyMainCardsManager);
                action2.SetParamaterAttackStatus(attackStatus);
                action2.SetParamaterNum(ParamaterNum1);

                m_GameManager.ActionList.Add(action2);

                m_EventAnimationManager.AnimationStart_2(m_BattleModeCard);
                m_BattleStrix.EventAnimation(m_BattleModeCard, m_GameManager.isFirstAttacker);
                break;
            // 起動効果を持つキャラクター
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_080:
                m_EventAnimationManager.AnimationStart_3(m_BattleModeCard, ParamaterNum1);
                m_BattleStrix.EventAnimation(m_BattleModeCard, m_GameManager.isFirstAttacker);
                break;
            // 起動効果を持つキャラクター
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_04T:
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_11T_2:
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_077:
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_081:
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_091:
                m_EventAnimationManager.AnimationStart_2(m_BattleModeCard, ParamaterNum1);
                m_BattleStrix.EventAnimation(m_BattleModeCard, m_GameManager.isFirstAttacker);
                break;
            // 起動効果を持つキャラクター
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_DC_W01_01T:
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_DC_W01_04T:
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_DC_W01_13T:
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_LB_W02_02T_2:
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_LB_W02_14T:
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_16T:
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_002:
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_028:
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_034:
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_051:
                m_EventAnimationManager.AnimationStart(m_BattleModeCard, ParamaterNum1);
                m_BattleStrix.EventAnimation(m_BattleModeCard, m_GameManager.isFirstAttacker);
                break;
            // 起動効果を持つキャラクター
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_DC_W01_05T:
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_LB_W02_05T:
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_LB_W02_09T:
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_LB_W02_17T:
                m_EventAnimationManager.AnimationStart(m_BattleModeCard);
                m_BattleStrix.EventAnimation(m_BattleModeCard, m_GameManager.isFirstAttacker);
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_LB_W02_02T_1:
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_052:
                m_EventAnimationManager.AnimationStart_2(m_BattleModeCard);
                m_BattleStrix.EventAnimation(m_BattleModeCard, m_GameManager.isFirstAttacker);
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_062:
                m_EventAnimationManager.AnimationStart(P3_S01_062, ParamaterNum1);
                m_BattleStrix.EventAnimation(P3_S01_062, m_GameManager.isFirstAttacker);
                break;
            case EnumController.YesOrNoDialogParamater.CONFIRM_CONTROL_DECKTOP:
                BattleModeCard tmp = m_GameManager.myDeckList[0];
                m_GameManager.myDeckList.RemoveAt(0);
                m_GameManager.myDeckList.Add(tmp);
                m_GameManager.Syncronize();
                m_GameManager.ExecuteActionList();
                break;
            case EnumController.YesOrNoDialogParamater.VOID:
            default:
                break;
        }
        m_MyHandCardsManager.CallNotShowPlayButton();
        this.gameObject.SetActive(false);

        switch (m_YesOrNoDialogParamater)
        {
            case EnumController.YesOrNoDialogParamater.CLIMAX_PHASE:
                return;
            case EnumController.YesOrNoDialogParamater.VOID:
                return;
            default:
                return;
        }
    }

    public void onNoClick()
    {
        m_MyHandCardsManager.CallNotShowPlayButton();
        this.gameObject.SetActive(false);
        switch (m_YesOrNoDialogParamater)
        {
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_062:
            case EnumController.YesOrNoDialogParamater.CONFIRM_CARD_EFFECT:
                m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
                m_GameManager.ExecuteActionList();
                break;
            case EnumController.YesOrNoDialogParamater.CONFIRM_CONTROL_DECKTOP:
                m_GameManager.ExecuteActionList();
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_DC_W01_02T:
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_DC_W01_10T:
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_LB_W02_03T:
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_01T:
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_11T_1:
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_004:
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_030:
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_055:
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_056:
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_081:
                Action action = new Action(m_GameManager, EnumController.Action.ExecuteAttack2);
                action.SetParamaterMyMainCardsManager(m_MyMainCardsManager);
                action.SetParamaterAttackStatus(attackStatus);
                action.SetParamaterNum(ParamaterNum1);

                m_GameManager.ActionList.Add(action);

                m_GameManager.ExecuteActionList();
                break;
            case EnumController.YesOrNoDialogParamater.CONFIRM_USE_COUNTER:
                // DamageForFrontAttack(int damage, int place, EnumController.Damage damageParamater, List<EnumController.Shot> ReceiveShotList)
                m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
                m_GameManager.DamageForFrontAttack(ParamaterNum1, ParamaterNum2, EnumController.Damage.FRONT_ATTACK, m_GameManager.SendShotList);
                break;
            case EnumController.YesOrNoDialogParamater.CONFIRM_BOOK_TRIGGER_FRONT:
            case EnumController.YesOrNoDialogParamater.CONFIRM_BOOK_TRIGGER_SIDE:
            case EnumController.YesOrNoDialogParamater.CONFIRM_BOOK_TRIGGER_DIRECT:
            case EnumController.YesOrNoDialogParamater.CONFIRM_BOUNCE_TRIGGER_FRONT:
            case EnumController.YesOrNoDialogParamater.CONFIRM_BOUNCE_TRIGGER_SIDE:
            case EnumController.YesOrNoDialogParamater.CONFIRM_BOUNCE_TRIGGER_DIRECT:
            case EnumController.YesOrNoDialogParamater.CONFIRM_POOL_TRIGGER_FRONT:
            case EnumController.YesOrNoDialogParamater.CONFIRM_POOL_TRIGGER_SIDE:
            case EnumController.YesOrNoDialogParamater.CONFIRM_POOL_TRIGGER_DIRECT:
                m_GameManager.Syncronize();
                m_GameManager.TriggerAfter();
                switch (m_YesOrNoDialogParamater)
                {
                    case EnumController.YesOrNoDialogParamater.CONFIRM_BOOK_TRIGGER_DIRECT:
                    case EnumController.YesOrNoDialogParamater.CONFIRM_BOUNCE_TRIGGER_DIRECT:
                    case EnumController.YesOrNoDialogParamater.CONFIRM_POOL_TRIGGER_DIRECT:
                        m_BattleStrix.RpcToAll("Damage", ParamaterNum1, m_GameManager.isFirstAttacker, EnumController.Damage.DIRECT_ATTACK, m_GameManager.SendShotList);
                        break;
                    case EnumController.YesOrNoDialogParamater.CONFIRM_BOOK_TRIGGER_SIDE:
                    case EnumController.YesOrNoDialogParamater.CONFIRM_BOUNCE_TRIGGER_SIDE:
                    case EnumController.YesOrNoDialogParamater.CONFIRM_POOL_TRIGGER_SIDE:
                        m_BattleStrix.RpcToAll("Damage", ParamaterNum1, m_GameManager.isFirstAttacker, EnumController.Damage.SIDE_ATTACK, m_GameManager.SendShotList);
                        break;
                    case EnumController.YesOrNoDialogParamater.CONFIRM_BOOK_TRIGGER_FRONT:
                    case EnumController.YesOrNoDialogParamater.CONFIRM_BOUNCE_TRIGGER_FRONT:
                    case EnumController.YesOrNoDialogParamater.CONFIRM_POOL_TRIGGER_FRONT:
                        // ("CallOKDialogForCounter",int damage, int place, m_GameManager.isFirstAttacker,List<EnumController.Shot> ReceiveShotList)
                        m_BattleStrix.RpcToAll("CallOKDialogForCounter", ParamaterNum1, ParamaterNum2, m_GameManager.isFirstAttacker, m_GameManager.SendShotList);
                        break;
                    default:
                        break;
                }
                break;
            case EnumController.YesOrNoDialogParamater.VOID:
                break;
            default: 
                break;
        }
    }

    public void OffDialog()
    {
        this.gameObject.SetActive(false);
    }
}
