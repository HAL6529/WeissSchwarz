using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    private EnumController.Action paramater = EnumController.Action.VOID;

    private BattleStrix m_BattleStrix;
    private BattleModeCard m_BattleModeCard;
    private DialogManager m_DialogManager;
    private GameManager m_GameManager;
    private MyMainCardsManager m_MyMainCardsManager;
    private EnumController.Attack m_AttackStatus = EnumController.Attack.VOID;
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
        for (int m = 0; m < m_GameManager.ActionList.Count; m++)
        {
            Debug.Log(m_GameManager.ActionList[m].GetParamater());
        }
        switch (paramater)
        {
            case EnumController.Action.ClockAndTwoDraw:
                m_GameManager.ClockAndTwoDraw2();
                break;
            case EnumController.Action.DamageForFrontAttack2ForCancel:
                if (paramaterNum > -1)
                {
                    m_GameManager.PowerCheck(paramaterNum);
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
                    Debug.Log("Level Up");
                    Action action = new Action(m_GameManager, EnumController.Action.PowerCheckForLevelUpDialog);
                    action.SetParamaterNum(paramaterNum);
                    m_GameManager.ActionList.Add(action);
                    return;
                }

                if (paramaterNum > -1)
                {
                    m_GameManager.PowerCheck(paramaterNum);
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
                    // RefreshŒã‚ÍAction‚Í•K—v‚È‚¢‚ÆŽv‚í‚ê‚é
                    return;
                }
                break;
            case EnumController.Action.EncoreCheck:
                m_DialogManager.EncoreDialog(m_GameManager.myFieldList, EnumController.EncoreDialog.EncoreCheck);
                return;
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
            case EnumController.Action.DC_W01_07T:
                m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.CONFIRM_CARD_EFFECT, m_BattleModeCard, paramaterNum);
                return;
            case EnumController.Action.DC_W01_16T:
                m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.CONFIRM_CARD_EFFECT, m_BattleModeCard, paramaterNum);
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

    public void SetParamaterMyMainCardsManager(MyMainCardsManager paramater)
    {
        m_MyMainCardsManager = paramater;
    }

    public void SetParamaterWinAndLose(WinAndLose paramater)
    {
        m_WinAndLose = paramater;
    }
}
