using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using SoftGear.Strix.Unity.Runtime;
using SoftGear.Strix.Unity.Runtime.Event;
using SoftGear.Strix.Client.Core.Request;
using SoftGear.Strix.Client.Core.Model.Manager.Filter;
using SoftGear.Strix.Net.Serialization;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using EnumController;

public class BattleStrix : StrixBehaviour
{
    [SerializeField] Text logText;
    [SerializeField] GameManager m_GameManager;
    [SerializeField] StrixManager m_StrixManager;
    [SerializeField] MyMainCardsManager m_MyMainCardsManager;
    [SerializeField] EnemyMainCardsManager m_EnemyMainCardsManager;
    [SerializeField] EnemyStockCardsManager m_EnemyStockCardsManager;
    [SerializeField] TriggerCardAnimationForEnemy m_TriggerCardAnimationForEnemy;
    [SerializeField] DialogManager m_DialogManager;
    [SerializeField] WinAndLose m_WinAndLose;
    [SerializeField] DamageAnimationDialog m_DamageAnimationDialog;

    List<BattleModeCard> tempList = new List<BattleModeCard>();

    // Start is called before the first frame update
    void Start()
    {
        ObjectFactory.Instance.Register(typeof(BattleModeCardTemp));
        ObjectFactory.Instance.Register(typeof(ExecuteActionTemp));
    }

    public void SendConfirmSearchOrSulvageCardDialog(List<BattleModeCard> list, EnumController.ConfirmSearchOrSulvageCardDialog paramater, ExecuteActionTemp m_ExecuteActionTemp, bool isFirstAttacker)
    {
        List<BattleModeCardTemp> temp = new List<BattleModeCardTemp>();

        for (int i = 0; i < list.Count; i++)
        {
            temp.Add(new BattleModeCardTemp(list[i]));
        }

        RpcToAll(nameof(ConfirmSearchOrSulvageCardDialog), temp, paramater, m_ExecuteActionTemp, isFirstAttacker);
    }

    public void SendUpdateEnemyGraveYard(List<BattleModeCard> list, bool isFirstAttacker)
    {
        List<BattleModeCardTemp> temp = new List<BattleModeCardTemp>();

        for (int i = 0; i < list.Count; i++)
        {
            temp.Add(new BattleModeCardTemp(list[i]));
        }
        RpcToAll(nameof(UpdateEnemyGraveYard), temp, isFirstAttacker);
    }

    public void SendUpdateEnemyStockCards(List<BattleModeCard> list, bool isFirstAttacker)
    {
        List<BattleModeCardTemp> temp = new List<BattleModeCardTemp>();

        for (int i = 0; i < list.Count; i++)
        {
            temp.Add(new BattleModeCardTemp(list[i]));
        }
        RpcToAll(nameof(UpdateEnemyStockCards), temp, isFirstAttacker);
    }

    public void SendUpdateEnemyClock(List<BattleModeCard> list, bool isFirstAttacker)
    {
        List<BattleModeCardTemp> temp = new List<BattleModeCardTemp>();

        for (int i = 0; i < list.Count; i++)
        {
            temp.Add(new BattleModeCardTemp(list[i]));
        }
        RpcToAll(nameof(UpdateEnemyClock), temp, isFirstAttacker);
    }

    public void SendUpdateMainCards(List<BattleModeCard> list, List<int> FieldPowerList ,bool isFirstAttacker)
    {
        List<BattleModeCardTemp> temp = new List<BattleModeCardTemp>();
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] != null)
            {
                temp.Add(new BattleModeCardTemp(list[i]));
            }
            else
            {
                temp.Add(null);
            }
        }
        RpcToAll(nameof(UpdateMainCards), temp, FieldPowerList, isFirstAttacker);
    }

    public void SendUpdateEnemyHandCards(List<BattleModeCard> list, bool isFirstAttacker)
    {
        List<BattleModeCardTemp> temp = new List<BattleModeCardTemp>();
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] != null)
            {
                temp.Add(new BattleModeCardTemp(list[i]));
            }
            else
            {
                temp.Add(null);
            }
        }
        RpcToAll(nameof(UpdateEnemyHandCards), temp, isFirstAttacker);
    }

    public void SendUpdateLevelCards(List<BattleModeCard> list, bool isFirstAttacker)
    {
        List<BattleModeCardTemp> temp = new List<BattleModeCardTemp>();
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] != null)
            {
                temp.Add(new BattleModeCardTemp(list[i]));
            }
            else
            {
                temp.Add(null);
            }
        }
        RpcToAll(nameof(UpdateEnemyLevelCards), temp, isFirstAttacker);
    }

    public void SendDamageAnimationDialog_SetBattleModeCardForTurnPlayer(List<BattleModeCard> list, bool isFirstAttacker)
    {
        List<BattleModeCardTemp> temp = new List<BattleModeCardTemp>();
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] != null)
            {
                temp.Add(new BattleModeCardTemp(list[i]));
            }
            else
            {
                temp.Add(null);
            }
        }
        RpcToAll(nameof(DamageAnimationDialog_SetBattleModeCardForTurnPlayer), temp, isFirstAttacker);
    }

    [StrixRpc]
    public void CallOKDialogForCounter(int ParamaterNum1, int ParamaterNum2, bool isFirstAttacker)
    {
        Debug.Log("CallOKDialogForCounter");
        if (m_GameManager.isFirstAttacker != isFirstAttacker)
        {
            m_GameManager.CounterCheck(ParamaterNum1, ParamaterNum2);
        }
    }


    [StrixRpc]
    public void SetIsFirstAttacker(bool b)
    {
        if (m_StrixManager.isOwner)
        {
            return;
        }
        m_GameManager.isFirstAttacker = b;
        m_GameManager.isTurnPlayer = b;
    }

    [StrixRpc]
    public void SetGameStartBtn()
    {
        if (m_StrixManager.isOwner)
        {
            return;
        }
        m_GameManager.SetGameStartBtn();
    }

    [StrixRpc]
    public void GameStart()
    {
        m_GameManager.Shuffle();
        m_GameManager.FirstDraw();

        // 先攻の場合
        if (m_GameManager.isFirstAttacker)
        {
            m_GameManager.MariganStart();
        }
    }

    [StrixRpc]
    public void MariganStart()
    {
        // 後攻の場合
        if (!m_GameManager.isFirstAttacker)
        {
            m_GameManager.MariganStart();
        }
    }

    [StrixRpc]
    public void SyncFieldPower(List<int> list, bool isTurnPlayer)
    {
        if (m_GameManager.isTurnPlayer != isTurnPlayer)
        {
            m_EnemyMainCardsManager.SetFieldPower(list);
        }
    }

    [StrixRpc]
    public void UpdateEnemyHandCards(List<BattleModeCardTemp> list, bool isFirstAttacker)
    {
        if (m_GameManager.isFirstAttacker != isFirstAttacker)
        {
            m_GameManager.UpdateEnemyHandCards(list);
        }
    }

    [StrixRpc]
    public void UpdateMainCards(List<BattleModeCardTemp> list, List<int> FieldPowerList, bool isFirstAttacker)
    {
        if (m_GameManager.isFirstAttacker != isFirstAttacker)
        {
            m_GameManager.UpdateEnemyMainCards(list, FieldPowerList);
        }
    }

    [StrixRpc]
    public void UpdateEnemyGraveYard(List<BattleModeCardTemp> list, bool isFirstAttacker)
    {
        if (m_GameManager.isFirstAttacker != isFirstAttacker)
        {
            m_GameManager.UpdateEnemyGraveYardCards(list);
        }
    }

    [StrixRpc]
    public void UpdateEnemyStockCards(List<BattleModeCardTemp> list, bool isFirstAttacker)
    {
        if (m_GameManager.isFirstAttacker != isFirstAttacker)
        {
            m_GameManager.UpdateEnemyStockCards(list);
        }
    }

    [StrixRpc]
    public void UpdateEnemyClock(List<BattleModeCardTemp> list, bool isFirstAttacker)
    {
        if (m_GameManager.isFirstAttacker != isFirstAttacker)
        {
            m_GameManager.UpdateEnemyClock(list);
        }
    }

    [StrixRpc]
    public void UpdateEnemyLevelCards(List<BattleModeCardTemp> list, bool isFirstAttacker)
    {
        if (m_GameManager.isFirstAttacker != isFirstAttacker)
        {
            m_GameManager.UpdateEnemyLevelCards(list);
        }
    }

    [StrixRpc]
    public void UpdateEnemyDeckCount(int num, bool isFirstAttacker)
    {
        if (m_GameManager.isFirstAttacker != isFirstAttacker)
        {
            m_GameManager.UpdateEnemyDeckCount(num);
        }
    }

    [StrixRpc]
    public void UpdateIsLevelUpProcess(bool b)
    {
        m_GameManager.isLevelUpProcess = b;
    }

    [StrixRpc]
    public void DrawPhase()
    {
        logText.text = "DrawPhase";
        if (m_GameManager.isTurnPlayer)
        {
            m_GameManager.DrawPhaseStart();
        }
    }

    [StrixRpc]
    public void ClockPhase()
    {
        logText.text = "ClockPhase";
        if (m_GameManager.isTurnPlayer)
        {
            m_GameManager.ClockPhaseStart();
        }
    }

    [StrixRpc]
    public void MainPhase()
    {
        logText.text = "MainPhase";
        if (m_GameManager.isTurnPlayer)
        {
            m_GameManager.MainStart();
        }
    }

    [StrixRpc]
    public void AttackPhase()
    {
        logText.text = "AttackPhase";
    }

    [StrixRpc]
    public void EncorePhase()
    {
        logText.text = "EncorePhase";
        if (m_GameManager.isTurnPlayer)
        {
            m_GameManager.EncoreStart();
        }
    }

    [StrixRpc]
    public void UpdateClimaxCard(BattleModeCardTemp myClimax, BattleModeCardTemp enemyClimax, bool isFirstAttacker)
    {
        if (m_GameManager.isFirstAttacker != isFirstAttacker)
        {
            m_GameManager.UpdateClimaxCard(myClimax, enemyClimax);
        }
    }

    [StrixRpc]
    public void CallEnemyStand(int num, bool isTurnPlayer)
    {
        if (m_GameManager.isTurnPlayer != isTurnPlayer)
        {
            m_EnemyMainCardsManager.CallStand(num);
        }
    }

    [StrixRpc]
    public void updateEnemyStockCards(int num, bool isTurnPlayer)
    {
        if (m_GameManager.isTurnPlayer != isTurnPlayer)
        {
            m_EnemyMainCardsManager.CallRest(num);
        }
    }

    [StrixRpc]
    public void CallEnemyRest(int num, bool isTurnPlayer)
    {
        if (m_GameManager.isTurnPlayer != isTurnPlayer)
        {
            m_EnemyMainCardsManager.CallRest(num);
        }
    }

    [StrixRpc]
    public void CallMyReverse(int num, bool isTurnPlayer)
    {
        if (m_GameManager.isTurnPlayer != isTurnPlayer)
        {
            m_MyMainCardsManager.CallOnReverse(num);
        }
    }

    /// <summary>
    /// 相手をリバースしたとき呼び出される
    /// </summary>
    /// <param name="num"></param>
    /// <param name="isTurnPlayer"></param>
    [StrixRpc]
    public void CallEnemyReverse(int num, bool isTurnPlayer)
    {
        if (m_GameManager.isTurnPlayer != isTurnPlayer)
        {
            m_EnemyMainCardsManager.CallReverse(num);
            Debug.Log("aaaa");
            m_MyMainCardsManager.CallWhenReverseEnemyCard(num);
        }
    }

    [StrixRpc]
    public void Damage(int num, bool isFirstAttacker, EnumController.Damage damage)
    {
        logText.text = "Damage:" + Convert.ToString(num);
        if (m_GameManager.isFirstAttacker != isFirstAttacker)
        {
            m_GameManager.Damage(num, damage);
        }
    }

    [StrixRpc]
    public void ChangePhase(EnumController.Turn turn)
    {
        m_GameManager.ChangePhase(turn);
    }

    [StrixRpc]
    public void EncoreDialog(bool isFirstAttacker)
    {
        if (m_GameManager.isFirstAttacker != isFirstAttacker)
        {
            m_GameManager.SendEncoreDialogFromRPC();
        }
    }

    [StrixRpc]
    public void SendReceiveTurnChange(bool isFirstAttacker)
    {
        if (m_GameManager.isFirstAttacker == isFirstAttacker)
        {
            return;
        }
        m_GameManager.ReceiveTurnChange();
    }

    [StrixRpc]
    public void SendReceiveReadyOK(bool isFirstAttacker)
    {
        if (m_GameManager.isFirstAttacker == isFirstAttacker)
        {
            return;
        }
        m_GameManager.ReceiveReadyOK();
    }

    public void CallPlayEnemyTriggerAnimation(BattleModeCard card, bool isTurnPlayer)
    {
        BattleModeCardTemp temp = new BattleModeCardTemp(card);
        RpcToAll(nameof(PlayEnemyTriggerAnimation), temp, isTurnPlayer);
    }

    [StrixRpc]
    public void PlayEnemyTriggerAnimation(BattleModeCardTemp card, bool isTurnPlayer)
    {
        if (m_GameManager.isTurnPlayer != isTurnPlayer)
        {
            m_TriggerCardAnimationForEnemy.Play(card);
        }
    }

    /// <summary>
    /// アタック中フラグ更新
    /// </summary>
    /// <param name="isAttackProcess"></param>
    [StrixRpc]
    public void SetIsAttackProcess(bool isAttackProcess)
    {
        m_GameManager.isAttackProcess = isAttackProcess;
    }

    [StrixRpc]
    public void NotEraseDialog(bool isOpen, bool isFirstAttacker)
    {
        if (m_GameManager.isFirstAttacker != isFirstAttacker)
        {
            if (isOpen)
            {
                m_DialogManager.NotEraseDialog_Open();
            }
            else
            {
                m_DialogManager.NotEraseDialog_Close();
            }
        }
    }

    [StrixRpc]
    public void WinAndLose_Win(bool isFirstAttacker)
    {
        if (m_GameManager.isFirstAttacker != isFirstAttacker)
        {
            m_WinAndLose.Win();
        }
    }

    /// <summary>
    /// サーチや回収を行った際に出力されるダイアログ
    /// </summary>
    /// <param name="list"></param>
    /// <param name="paramater"></param>
    /// <param name="isFirstAttacker"></param>
    [StrixRpc]
    public void ConfirmSearchOrSulvageCardDialog(List<BattleModeCardTemp> list, EnumController.ConfirmSearchOrSulvageCardDialog paramater, ExecuteActionTemp m_ExecuteActionTemp, bool isFirstAttacker)
    {
        if (m_GameManager.isFirstAttacker != isFirstAttacker)
        {
            m_DialogManager.ConfirmSearchOrSulvageCardDialog(list, paramater, m_ExecuteActionTemp);
        }
        else
        {
            m_DialogManager.NotEraseDialog_Open();
        }
    }

    /// <summary>
    /// カムバックアイコンが捲れた後確認ダイアログでOKボタンが押された後の処理
    /// </summary>
    [StrixRpc]
    public void ExecuteAction_ComeBackActionAfterConfirmDialog(ExecuteActionTemp m_ExecuteActionTemp, bool isFirstAttacker)
    {
        Debug.Log("ExecuteAction_ComeBackActionAfterConfirmDialog");
        if(m_GameManager.isFirstAttacker != isFirstAttacker)
        {
            m_GameManager.m_ExecuteAction = new ExecuteAction(m_ExecuteActionTemp);
            m_GameManager.m_ExecuteAction.m_BattleStrix = m_GameManager.m_BattleStrix;
            m_GameManager.m_ExecuteAction.m_GameManager = m_GameManager;
            m_GameManager.m_ExecuteAction.m_BattleModeCardList = m_GameManager.m_BattleModeCardList;

            m_GameManager.m_ExecuteAction.ComeBackActionAfterConfirmDialog();
        }
    }

    /// <summary>
    /// ダメージを受けた時のアニメーションをターンプレイヤーにも流すためのメソッド
    /// </summary>
    /// <param name="list"></param>
    /// <param name="isFirstAttacker"></param>
    [StrixRpc]
    public void DamageAnimationDialog_SetBattleModeCardForTurnPlayer(List<BattleModeCardTemp> list, bool isFirstAttacker)
    {
        if (m_GameManager.isFirstAttacker != isFirstAttacker)
        {
            // ダメージアニメーションの再生
            m_DamageAnimationDialog.SetBattleModeCardForTurnPlayer(list);
        }
    }
}
