using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EffectAbstract : MonoBehaviour
{
    protected GameManager m_GameManager { get; set; }

    protected BattleStrix m_BattleStrix { get; set; }

    protected BattleModeCard m_BattleModeCard { get; set; }

    protected DialogManager m_DialogManager { get; set; }

    protected EnemyMainCardsManager m_EnemyMainCardsManager { get; set; }

    protected EventAnimationManager m_EventAnimationManager { get; set; }

    protected MainPowerUpDialog m_MainPowerUpDialog { get; set; }

    protected MyMainCardsManager m_MyMainCardsManager { get; set; }

    protected WinAndLose m_WinAndLose { get; set; }

    protected int ExecuteParamater { get; set; }

    protected int IntParamater1 { get; set; }

    protected int IntParamater2 { get; set; }

    protected int pumpPoint { get; set; }

    protected void ActExecute()
    {
        switch (ExecuteParamater)
        {
            case 1:
                EffectWhenAct(m_BattleModeCard);
                ActExecute1();
                break;
            case 2:
                EffectWhenAct(m_BattleModeCard);
                ActExecute2();
                break;
            case 3:
                EffectWhenAct(m_BattleModeCard);
                ActExecute3();
                break;
            default:
                break;
        }
    }

    protected void AutoExecute()
    {
        switch (ExecuteParamater)
        {
            case 1:
                AutoExecute1();
                break;
            case 2:
                AutoExecute2();
                break;
            case 3:
                AutoExecute3();
                break;
            default:
                break;
        }
    }

    protected void CounterExecute()
    {
        EffectWhenAct(m_BattleModeCard);
        EffectWhenCounter(m_BattleModeCard, IntParamater1);
        CounterExecute1();
    }

    protected void EventExecute()
    {
        EventExecute1();
    }

    public virtual void ActExecute1()
    {

    }

    public virtual void ActExecute2()
    {

    }

    public virtual void ActExecute3()
    {

    }

    public virtual void AutoExecute1()
    {

    }

    public virtual void AutoExecute2()
    {

    }

    public virtual void AutoExecute3()
    {

    }

    public virtual void CounterExecute1()
    {

    }

    public virtual void EventExecute1()
    {

    }

    protected void PayCost(int num)
    {
        for (int i = 0; i < num; i++)
        {
            m_GameManager.GraveYardList.Add(m_GameManager.myStockList[m_GameManager.myStockList.Count - 1]);
            m_GameManager.myStockList.RemoveAt(m_GameManager.myStockList.Count - 1);
        }
        m_GameManager.Syncronize();
    }

    /// <summary>
    /// あなたが【起】を使った時の効果のためのメソッド
    /// </summary>
    protected void EffectWhenAct(BattleModeCard card)
    {
        Action action = new Action(m_GameManager, EnumController.Action.EffectWhenAct);
        action.SetParamaterEventAnimationManager(m_EventAnimationManager);
        action.SetParamaterMyMainCardsManager(m_MyMainCardsManager);
        action.SetParamaterBattleStrix(m_BattleStrix);
        action.SetParamaterBattleModeCard(card);
        m_GameManager.ActionList.Add(action);
    }

    /// <summary>
    /// 【自】 あなたが『助太刀』を使った時の効果のためのメソッド
    /// </summary>
    /// <param name="card"></param>
    protected void EffectWhenCounter(BattleModeCard card, int IntParamater1)
    {
        Action action = new Action(m_GameManager, EnumController.Action.EffectWhenCounter);
        action.SetParamaterEventAnimationManager(m_EventAnimationManager);
        action.SetParamaterMyMainCardsManager(m_MyMainCardsManager);
        action.SetParamaterBattleStrix(m_BattleStrix);
        action.SetParamaterBattleModeCard(card);
        action.SetParamaterNum(IntParamater1);
        m_GameManager.ActionList.Add(action);
    }

}
