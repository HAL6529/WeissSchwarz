using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EnumController;

public class YesOrNoDialog : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] BattleStrix m_BattleStrix;
    [SerializeField] GameManager m_GameManager;
    [SerializeField] MyHandCardsManager m_MyHandCardsManager;
    [SerializeField] MyMainCardsManager m_MyMainCardsManager;
    [SerializeField] DialogManager m_DialogManager;
    [SerializeField] EffectBondForHandToField m_EffectBondForHandToField;
    [SerializeField] EffectBrainStormForDraw m_EffectBrainStormForDraw;
    [SerializeField] EffectSendMemory m_EffectSendMemory;
    [SerializeField] EventAnimationManager m_EventAnimationManager;

    private BattleModeCard m_BattleModeCard = null;

    private EnumController.YesOrNoDialogParamater m_YesOrNoDialogParamater;

    private int ParamaterNum1 = -1;

    private int ParamaterNum2 = -1;

    private int ParamaterNum3 = -1;

    private bool isReceivedFromRPC = false;

    private StringValues stringValues = new StringValues();

    /// <summary>
    /// カードの効果を使用するためのコスト
    /// </summary>
    private int cost = 0;

    /// <summary>
    /// 絆効果で回収するカードのナンバー
    /// </summary>
    private EnumController.CardNo sulvageCardNo = EnumController.CardNo.VOID;

    public YesOrNoDialog()
    {
        m_YesOrNoDialogParamater = EnumController.YesOrNoDialogParamater.VOID;
    }

    public void SetParamater(EnumController.YesOrNoDialogParamater paramater)
    {
        ParamaterNum1 = -1;
        ParamaterNum2 = -1;
        ParamaterNum3 = -1;
        m_BattleModeCard = null;
        sulvageCardNo = EnumController.CardNo.VOID;
        cost = 0;
        this.gameObject.SetActive(true);
        m_YesOrNoDialogParamater = paramater;
        this.isReceivedFromRPC = false;
        SetText();
    }

    public void SetParamater(EnumController.YesOrNoDialogParamater paramater, BattleModeCard card)
    {
        ParamaterNum1 = -1;
        ParamaterNum2 = -1;
        ParamaterNum3 = -1;
        m_BattleModeCard = card;
        sulvageCardNo = EnumController.CardNo.VOID;
        cost = 0;
        this.gameObject.SetActive(true);
        m_YesOrNoDialogParamater = paramater;
        this.isReceivedFromRPC = false;
        SetText();
    }

    public void SetParamater(EnumController.YesOrNoDialogParamater paramater, BattleModeCard card, int num)
    {
        ParamaterNum1 = num;
        ParamaterNum2 = -1;
        ParamaterNum3 = -1;
        m_BattleModeCard = card;
        sulvageCardNo = EnumController.CardNo.VOID;
        cost = 0;
        this.gameObject.SetActive(true);
        m_YesOrNoDialogParamater = paramater;
        this.isReceivedFromRPC = false;
        SetText();
    }

    public void SetParamater(EnumController.YesOrNoDialogParamater paramater, BattleModeCard card, int num1, int num2)
    {
        ParamaterNum1 = num1;
        ParamaterNum2 = num2;
        ParamaterNum3 = -1;
        m_BattleModeCard = card;
        sulvageCardNo = EnumController.CardNo.VOID;
        cost = 0;
        this.gameObject.SetActive(true);
        m_YesOrNoDialogParamater = paramater;
        SetText();
    }

    public void SetParamater(EnumController.YesOrNoDialogParamater paramater, BattleModeCard card, int num1, int num2, int num3)
    {
        ParamaterNum1 = num1;
        ParamaterNum2 = num2;
        ParamaterNum3 = num3;
        m_BattleModeCard = card;
        sulvageCardNo = EnumController.CardNo.VOID;
        cost = 0;
        this.gameObject.SetActive(true);
        m_YesOrNoDialogParamater = paramater;
        SetText();
    }

    /// <summary>
    /// アンコールダイアログ用
    /// </summary>
    /// <param name="paramater"></param>
    /// <param name="m_BattleModeCard"></param>
    /// <param name="num"></param>
    /// <param name="isReceivedFromRPC"></param>
    public void SetParamater(EnumController.YesOrNoDialogParamater paramater, BattleModeCard card, int num, bool isReceivedFromRPC)
    {
        ParamaterNum1 = num;
        ParamaterNum2 = -1;
        m_BattleModeCard = card;
        sulvageCardNo = EnumController.CardNo.VOID;
        cost = 0;
        this.gameObject.SetActive(true);
        m_YesOrNoDialogParamater = paramater;
        this.isReceivedFromRPC = isReceivedFromRPC;
        SetText();
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
            case EnumController.YesOrNoDialogParamater.CONFIRM_POOL_TRIGGER_FRONT:
            case EnumController.YesOrNoDialogParamater.CONFIRM_POOL_TRIGGER_SIDE:
            case EnumController.YesOrNoDialogParamater.CONFIRM_POOL_TRIGGER_DIRECT:
                str = stringValues.YesOrNoDialog_CONFIRM_POOL_TRIGGER;
                break;
            case EnumController.YesOrNoDialogParamater.EVENT_CONFIRM:
                str = stringValues.YesOrNoDialog_EVENT_CONFIRM(m_BattleModeCard.name);
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_HAND_TO_FIELD:
                str = stringValues.YesOrNoDialog_COST_CONFIRM_HAND_TO_FIELD(m_BattleModeCard.cost);
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_BOND_FOR_HAND_TO_FIELD:
                string bondName = "";
                switch (m_BattleModeCard.cardNo)
                {
                    case EnumController.CardNo.AT_WX02_A10:
                        sulvageCardNo = EnumController.CardNo.AT_WX02_A12;
                        bondName = stringValues.AT_WX02_A12_NAME;
                        cost = 1;
                        break;
                    default:
                        bondName = "";
                        cost = 0;
                        break;
                }
                str = stringValues.YesOrNoDialog_COST_CONFIRM_BOND_FOR_HAND_TO_FIELD(bondName, cost);
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_BRAIN_STORM_FOR_DRAW:
                str = stringValues.YesOrNoDialog_COST_CONFIRM_BRAIN_STORM_FOR_DRAW;
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_DC_W01_01T:
                str = stringValues.YesOrNoDialog_COST_CONFIRM_DC_W01_01T;
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_DC_W01_04T:
                str = stringValues.YesOrNoDialog_COST_CONFIRM_DC_W01_04T;
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_LB_W02_05T:
                str = stringValues.YesOrNoDialog_COST_CONFIRM_LB_W02_05T;
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_SEND_MEMORY:
                str = stringValues.YesOrNoDialog_COST_CONFIRM_SEND_MEMORY;
                break;
            case EnumController.YesOrNoDialogParamater.VOID:
            default:
                str = "無効メッセージ";
                break;
        }
        text.text = str;
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
                        m_BattleStrix.RpcToAll("CallOKDialogForCounter", ParamaterNum1, ParamaterNum2, m_GameManager.isFirstAttacker, m_GameManager.SendShotList);
                        break;
                    default:
                        break;
                }
                break;
            case EnumController.YesOrNoDialogParamater.CLIMAX_PHASE:
                m_GameManager.SendClimaxPhase(m_BattleModeCard);
                break;
            case EnumController.YesOrNoDialogParamater.EVENT_CONFIRM:
                m_EventAnimationManager.AnimationStart(m_BattleModeCard);
                m_BattleStrix.EventAnimation(m_BattleModeCard, m_GameManager.isFirstAttacker);
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_HAND_TO_FIELD:
                m_DialogManager.MainDialog(m_BattleModeCard);
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_BOND_FOR_HAND_TO_FIELD:
                m_EffectBondForHandToField.BondForCost(sulvageCardNo, cost);
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_BRAIN_STORM_FOR_DRAW:
                m_EffectBrainStormForDraw.BrainStormForDraw(ParamaterNum1);
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_DC_W01_01T:
                m_EventAnimationManager.AnimationStart(m_BattleModeCard, ParamaterNum1);
                m_BattleStrix.EventAnimation(m_BattleModeCard, m_GameManager.isFirstAttacker);
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_DC_W01_04T:
                m_GameManager.GraveYardList.Add(m_GameManager.myStockList[m_GameManager.myStockList.Count - 1]);
                m_GameManager.myStockList.RemoveAt(m_GameManager.myStockList.Count - 1);
                m_MyMainCardsManager.AddPowerUpUntilTurnEnd(ParamaterNum1, 2000);
                m_GameManager.Syncronize();
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_LB_W02_05T:
                m_EventAnimationManager.AnimationStart(m_BattleModeCard);
                m_BattleStrix.EventAnimation(m_BattleModeCard, m_GameManager.isFirstAttacker);
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_SEND_MEMORY:
                m_EffectSendMemory.SendFieldToMemory(ParamaterNum1);
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
            case EnumController.YesOrNoDialogParamater.CONFIRM_USE_COUNTER:
                m_GameManager.DamageForFrontAttack(ParamaterNum1, ParamaterNum2);
                break;
            case EnumController.YesOrNoDialogParamater.CONFIRM_POOL_TRIGGER_FRONT:
            case EnumController.YesOrNoDialogParamater.CONFIRM_POOL_TRIGGER_SIDE:
            case EnumController.YesOrNoDialogParamater.CONFIRM_POOL_TRIGGER_DIRECT:
                m_GameManager.Syncronize();
                m_GameManager.TriggerAfter();
                switch (m_YesOrNoDialogParamater)
                {
                    case EnumController.YesOrNoDialogParamater.CONFIRM_POOL_TRIGGER_DIRECT:
                        m_BattleStrix.RpcToAll("Damage", ParamaterNum1, m_GameManager.isFirstAttacker, EnumController.Damage.DIRECT_ATTACK, m_GameManager.SendShotList);
                        break;
                    case EnumController.YesOrNoDialogParamater.CONFIRM_POOL_TRIGGER_SIDE:
                        m_BattleStrix.RpcToAll("Damage", ParamaterNum1, m_GameManager.isFirstAttacker, EnumController.Damage.SIDE_ATTACK, m_GameManager.SendShotList);
                        break;
                    case EnumController.YesOrNoDialogParamater.CONFIRM_POOL_TRIGGER_FRONT:
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
