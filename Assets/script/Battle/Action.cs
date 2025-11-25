using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    private EnumController.Action paramater = EnumController.Action.VOID;

    private BattleStrix m_BattleStrix;
    private BattleModeCard m_BattleModeCard;
    private List<BattleModeCard> m_BattleModeCardList = new List<BattleModeCard>();
    private DialogManager m_DialogManager;
    private GameManager m_GameManager;
    private MyMainCardsManager m_MyMainCardsManager;
    private EnumController.Attack m_AttackStatus = EnumController.Attack.VOID;
    private EventAnimationManager m_EventAnimationManager;
    private WinAndLose m_WinAndLose;

    private int paramaterNum = -1;
    private int paramaterNum2 = -1;

    public Action(GameManager m_GameManager, EnumController.Action paramater)
    {
        this.m_GameManager = m_GameManager;
        this.paramater = paramater;
    }

    public void Execute(int num)
    {
        m_GameManager.ActionList.RemoveAt(num);
        switch (paramater)
        {
            case EnumController.Action.Bond:
                m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_BOND_FOR_HAND_TO_FIELD, m_BattleModeCard);
                break;
            case EnumController.Action.ClockAndTwoDraw:
                m_GameManager.ClockAndTwoDraw2();
                break;
            case EnumController.Action.ClockAndTwoDraw2:
                m_GameManager.ClockAndTwoDraw3();
                break;
            case EnumController.Action.DamageForFrontAttack2ForCancel:
                if (paramaterNum > -1)
                {
                    m_GameManager.PowerCheck(paramaterNum, EnumController.PowerCheck.DamageForFrontAttack2ForCancel);
                    return;
                }

                if (m_GameManager.ReceiveShotList.Count > 0)
                {
                    m_GameManager.ReceiveShotList.RemoveAt(0);
                    m_BattleStrix.RpcToAll("Shot", 1, m_GameManager.ReceiveShotList, m_GameManager.isFirstAttacker);
                    return;
                }

                m_BattleStrix.RpcToAll("SetIsAttackProcess", false);
                break;
            case EnumController.Action.DamageForFrontAttack:
                m_GameManager.DamageForFrontAttack(paramaterNum, paramaterNum2, EnumController.Damage.FRONT_ATTACK, m_GameManager.SendShotList);
                break;
            case EnumController.Action.DamageForFrontAttack2ForDamaged:
                if (m_GameManager.LevelUpCheck())
                {
                    Action action = new Action(m_GameManager, EnumController.Action.PowerCheckForLevelUpDialog);
                    action.SetParamaterNum(paramaterNum);
                    m_GameManager.ActionList.Add(action);
                    return;
                }

                if (paramaterNum > -1)
                {
                    m_GameManager.PowerCheck(paramaterNum, EnumController.PowerCheck.DamageForFrontAttack2ForDamaged);
                    return;
                }

                m_BattleStrix.RpcToAll("SetIsAttackProcess", false);
                break;
            case EnumController.Action.DamageRefresh:
                m_GameManager.myClockList.Add(m_GameManager.myDeckList[0]);
                m_GameManager.myDeckList.RemoveAt(0);
                m_GameManager.Syncronize();

                if(m_GameManager.myDeckList.Count == 0)
                {
                    m_BattleStrix.RpcToAll("WinAndLose_Win", m_GameManager.isFirstAttacker);
                    m_WinAndLose.Lose();
                }

                if (m_GameManager.LevelUpCheck())
                {
                    // Refresh後はActionは必要ないと思われる
                    return;
                }
                break;
            // 「あなたが【起】を使った時、」の効果のチェック
            case EnumController.Action.EffectWhenAct:
                m_MyMainCardsManager.ConfirmEffectWhenAct();
                break;
            case EnumController.Action.EventAnimationManager:
                m_GameManager.GraveYardList.Add(m_BattleModeCard);
                m_GameManager.myHandList.Remove(m_BattleModeCard);
                m_GameManager.Syncronize();
                break;
            case EnumController.Action.ExecuteAttack2:
                m_MyMainCardsManager.ExecuteAttack2(paramaterNum, m_AttackStatus);
                break;
            case EnumController.Action.PowerCheckForLevelUpDialog:
                m_GameManager.PowerCheckForLevelUpDialog(paramaterNum);
                break;
            case EnumController.Action.SulvageDialog:
                for(int i = 0; i < m_BattleModeCardList.Count; i++)
                {
                    m_GameManager.GraveYardList.Remove(m_BattleModeCardList[i]);
                    m_GameManager.myHandList.Add(m_BattleModeCardList[i]);
                }

                if(paramaterNum > -1)
                {
                    m_GameManager.GraveYardList.Add(m_GameManager.myHandList[paramaterNum]);
                    m_GameManager.myHandList.RemoveAt(paramaterNum);
                }
                m_GameManager.Syncronize();
                break;
            case EnumController.Action.TurnChange:
                //ターンプレイヤーを先に解決し、非ターンプレイヤーの場合はターンチェンジする
                if (m_GameManager.isTurnPlayer)
                {
                    m_BattleStrix.RpcToAll("EncoreDialog", m_GameManager.isFirstAttacker);
                }
                else
                {
                    m_GameManager.TurnChange();
                }
                return;
            case EnumController.Action.AT_WX02_A08:
                m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.CONFIRM_CARD_EFFECT, m_BattleModeCard);
                return;
            case EnumController.Action.DC_W01_02T:
                m_EventAnimationManager.AnimationStart_2(m_BattleModeCard);
                m_BattleStrix.EventAnimation(m_BattleModeCard, m_GameManager.isFirstAttacker);
                return;
            case EnumController.Action.LB_W02_14T:
            case EnumController.Action.P3_S01_16T:
                m_EventAnimationManager.AnimationStart_2(m_BattleModeCard);
                m_BattleStrix.EventAnimation(m_BattleModeCard, m_GameManager.isFirstAttacker);
                return;
            case EnumController.Action.P3_S01_055:
                m_EventAnimationManager.AnimationStart_2(m_BattleModeCard, paramaterNum);
                m_BattleStrix.EventAnimation(m_BattleModeCard, m_GameManager.isFirstAttacker);
                return;
            case EnumController.Action.DC_W01_07T:
            case EnumController.Action.DC_W01_10T:
            case EnumController.Action.DC_W01_16T:
            case EnumController.Action.LB_W02_19T:
            case EnumController.Action.P3_S01_040:
            case EnumController.Action.P3_S01_052:
            case EnumController.Action.P3_S01_060:
            case EnumController.Action.P3_S01_061:
            case EnumController.Action.P3_S01_076:
            case EnumController.Action.P3_S01_088:
            case EnumController.Action.LB_W02_031:
                m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.CONFIRM_CARD_EFFECT, m_BattleModeCard, paramaterNum);
                return;
            case EnumController.Action.P3_S01_057_1:
            case EnumController.Action.P3_S01_080_1:
                m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.CONFIRM_CARD_EFFECT, m_BattleModeCard, paramaterNum, 1);
                return;
            case EnumController.Action.P3_S01_057_2:
            case EnumController.Action.P3_S01_080_2:
            case EnumController.Action.P3_S01_065_2:
                m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.CONFIRM_CARD_EFFECT, m_BattleModeCard, paramaterNum, 2);
                return;
            case EnumController.Action.P3_S01_01T:
            case EnumController.Action.P3_S01_04T:
            case EnumController.Action.P3_S01_07T:
            case EnumController.Action.P3_S01_001:
            case EnumController.Action.P3_S01_026:
            case EnumController.Action.P3_S01_065_1:
            case EnumController.Action.LB_W02_003:
            case EnumController.Action.LB_W02_062:
                m_EventAnimationManager.AnimationStart(m_BattleModeCard, paramaterNum);
                m_BattleStrix.EventAnimation(m_BattleModeCard, m_GameManager.isFirstAttacker);
                return;
            case EnumController.Action.P3_S01_062:
                m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_062, m_BattleModeCard, paramaterNum);
                return;
            case EnumController.Action.P3_S01_065_Damage:
                m_BattleStrix.RpcToAll("CallDamage", 1, -1, m_GameManager.isFirstAttacker);
                return;
            default:
                break;
        }
        m_GameManager.ExecuteActionList();
    }

    public EnumController.Action GetParamater()
    {
        return paramater;
    }

    public void SetParamaterBattleStrix(BattleStrix paramater)
    {
        m_BattleStrix = paramater;
    }

    public void SetParamaterBattleModeCard(BattleModeCard paramater)
    {
        m_BattleModeCard = paramater;
    }

    public void SetParamaterBattleModeCardList(List<BattleModeCard> paramater)
    {
        m_BattleModeCardList = paramater;
    }

    public void SetParamaterDialogManager(DialogManager paramater)
    {
        m_DialogManager = paramater;
    }

    public void SetParamaterNum(int num) 
    {
        paramaterNum = num;
    }

    public void SetParamaterNum2(int num)
    {
        paramaterNum2 = num;
    }

    public void SetParamaterAttackStatus(EnumController.Attack paramater)
    {
        m_AttackStatus = paramater;
    }

    public void SetParamaterEventAnimationManager(EventAnimationManager paramaterr)
    {
       m_EventAnimationManager = paramaterr;
    }

    public void SetParamaterMyMainCardsManager(MyMainCardsManager paramater)
    {
        m_MyMainCardsManager = paramater;
    }

    public void SetParamaterWinAndLose(WinAndLose paramater)
    {
        m_WinAndLose = paramater;
    }
}
