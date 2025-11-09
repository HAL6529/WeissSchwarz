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
    [SerializeField] ShuffleDeckAnimationController m_ShuffleDeckAnimationController;
    [SerializeField] StrixManager m_StrixManager;
    [SerializeField] MyMainCardsManager m_MyMainCardsManager;
    [SerializeField] EnemyMainCardsManager m_EnemyMainCardsManager;
    [SerializeField] EnemyStockCardsManager m_EnemyStockCardsManager;
    [SerializeField] TriggerCardAnimationForEnemy m_TriggerCardAnimationForEnemy;
    [SerializeField] DialogManager m_DialogManager;
    [SerializeField] WinAndLose m_WinAndLose;
    [SerializeField] DamageAnimationDialog m_DamageAnimationDialog;
    [SerializeField] EventAnimationManager m_EventAnimationManager;
    [SerializeField] SEmanager m_SEmanager;

    List<BattleModeCard> tempList = new List<BattleModeCard>();

    // Start is called before the first frame update
    void Start()
    {
        ObjectFactory.Instance.Register(typeof(BattleModeCardTemp));
        ObjectFactory.Instance.Register(typeof(ExecuteActionTemp));
    }

    public void CallPlayEnemyTriggerAnimation(BattleModeCard card, bool isTurnPlayer)
    {
        BattleModeCardTemp temp = new BattleModeCardTemp(card);
        RpcToAll(nameof(PlayEnemyTriggerAnimation), temp, isTurnPlayer);
    }


    public void EventAnimation(BattleModeCard card, bool isFirstAttacker)
    {
        BattleModeCardTemp temp = new BattleModeCardTemp(card);
        RpcToAll(nameof(EventAnimationStart), temp, isFirstAttacker);
    }

    public void SendConfirmSearchOrSulvageCardDialog(List<BattleModeCard> list, EnumController.ConfirmSearchOrSulvageCardDialog paramater, ExecuteActionTemp m_ExecuteActionTemp, bool isFirstAttacker)
    {
        List<BattleModeCardTemp> temp = new List<BattleModeCardTemp>();

        for (int i = 0; i < list.Count; i++)
        {
            temp.Add(new (list[i]));
        }

        RpcToAll(nameof(ConfirmSearchOrSulvageCardDialog), temp, paramater, m_ExecuteActionTemp, isFirstAttacker);
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

    public void SendUpdateEnemyClock(List<BattleModeCard> list, bool isFirstAttacker)
    {
        List<BattleModeCardTemp> temp = new List<BattleModeCardTemp>();

        for (int i = 0; i < list.Count; i++)
        {
            temp.Add(new BattleModeCardTemp(list[i]));
        }
        RpcToAll(nameof(UpdateEnemyClock), temp, isFirstAttacker);
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

    public void SendUpdateEnemyStockCards(List<BattleModeCard> list, bool isFirstAttacker)
    {
        List<BattleModeCardTemp> temp = new List<BattleModeCardTemp>();

        for (int i = 0; i < list.Count; i++)
        {
            temp.Add(new BattleModeCardTemp(list[i]));
        }
        RpcToAll(nameof(UpdateEnemyStockCards), temp, isFirstAttacker);
    }

    public void SendUpdateMainCards(List<BattleModeCard> list, List<int> FieldLevelList, List<int> FieldPowerList, List<int> FieldSoulList, List<bool> IsGreatProcessList, bool isFirstAttacker)
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
        RpcToAll(nameof(UpdateMainCards), temp, FieldLevelList, FieldPowerList, FieldSoulList, IsGreatProcessList, isFirstAttacker);
    }

    public void SendUpdateMainCardsAttribute(List<List<EnumController.Attribute>> list, bool isFirstAttacker)
    {
        for(int i = 0; i < list.Count; i++)
        {
            RpcToAll(nameof(UpdateMainCardsAttribute), list[i], i, isFirstAttacker);
        }

    }

    public void SendUpdateEnemyMemoryCards(List<BattleModeCard> list, bool isFirstAttacker)
    {
        List<BattleModeCardTemp> temp = new List<BattleModeCardTemp>();

        for (int i = 0; i < list.Count; i++)
        {
            temp.Add(new BattleModeCardTemp(list[i]));
        }
        RpcToAll(nameof(UpdateEnemyMemoryCards), temp, isFirstAttacker);
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

    private void SendCallGetHandList_2()
    {
        List<BattleModeCardTemp> temp = new List<BattleModeCardTemp>();
        for (int i = 0; i < m_GameManager.myHandList.Count; i++)
        {
            if (m_GameManager.myHandList[i] != null)
            {
                temp.Add(new BattleModeCardTemp(m_GameManager.myHandList[i]));
            }
            else
            {
                temp.Add(null);
            }
        }

        RpcToAll(nameof(CallGetHandList_2), temp, m_GameManager.isTurnPlayer);
    }

    [StrixRpc]
    public void CallGetHandList(bool isTurnPlayer)
    {
        if (m_GameManager.isTurnPlayer != isTurnPlayer)
        {
            SendCallGetHandList_2();
        }
    }

    [StrixRpc]
    public void CallGetHandList_2(List<BattleModeCardTemp> list, bool isTurnPlayer)
    {
        if (m_GameManager.isTurnPlayer != isTurnPlayer)
        {
            m_DialogManager.ConfirmEnemyHandDialog(list);
        }
    }

    [StrixRpc]
    public void AttackPhase()
    {
        logText.text = "AttackPhase";
    }

    [StrixRpc]
    public void CallAddLevelUpUntilTurnEnd(bool isTurnPlayer, int place, int level)
    {
        if (m_GameManager.isTurnPlayer != isTurnPlayer)
        {
            m_MyMainCardsManager.AddLevelUpUntilTurnEnd(place, level);
            m_GameManager.Syncronize();
        }
    }

    [StrixRpc]
    public void CallAddPowerUpUntilTurnEnd(bool isTurnPlayer, int place, int power)
    {
        if (m_GameManager.isTurnPlayer != isTurnPlayer)
        {
            m_MyMainCardsManager.AddPowerUpUntilTurnEnd(place, power);
            m_GameManager.Syncronize();
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
    public void CallEnemyStand(int num, bool isTurnPlayer)
    {
        if (m_GameManager.isTurnPlayer != isTurnPlayer)
        {
            m_EnemyMainCardsManager.CallStand(num);
        }
    }

    [StrixRpc]
    public void CallExecuteActionList(bool isTurnPlayer)
    {
        if (m_GameManager.isTurnPlayer != isTurnPlayer)
        {
            m_GameManager.ExecuteActionList();
        }
    }

    [StrixRpc]
    public void CallExecuteSyncronize(bool isTurnPlayer)
    {
        if (m_GameManager.isTurnPlayer != isTurnPlayer)
        {
            m_GameManager.Syncronize();
        }
    }

    [StrixRpc]
    public void CallMyRest(int num, bool isTurnPlayer)
    {
        if (m_GameManager.isTurnPlayer != isTurnPlayer)
        {
            m_MyMainCardsManager.CallOnRest(num);
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

    [StrixRpc]
    public void CallOKDialogForCounter(int ParamaterNum1, int ParamaterNum2, bool isFirstAttacker, List<EnumController.Shot> SendShotList)
    {
        if (m_GameManager.isFirstAttacker != isFirstAttacker)
        {
            m_GameManager.CounterCheck(ParamaterNum1, ParamaterNum2, SendShotList);
        }
    }

    [StrixRpc]
    public void MyPowerIsBiggerThanEnemyPower(int num, EnumController.PowerCheck paramater, bool isTurnPlayer)
    {
        if (m_GameManager.isTurnPlayer != isTurnPlayer)
        {
            m_MyMainCardsManager.CallOnReverse(num);
            RpcToAll(nameof(CallPowerCheck2), paramater, m_GameManager.isTurnPlayer);
        }
    }

    [StrixRpc]
    public void MyPowerEqualEnemyPower(int place1, int place2, int place3, int level, EnumController.PowerCheck paramater, bool isTurnPlayer)
    {
        if (m_GameManager.isTurnPlayer != isTurnPlayer)
        {
            m_MyMainCardsManager.CallOnReverse(place3);
            m_EnemyMainCardsManager.CallReverse(place1);
            m_MyMainCardsManager.CallWhenReverseEnemyCard(place3, place1, level);
            RpcToAll(nameof(CallPowerCheck2), paramater, m_GameManager.isTurnPlayer);
        }
    }

    [StrixRpc]
    public void EnemyPowerIsBiggerThanMyPower(int place1, int place2, int place3, int level, EnumController.PowerCheck paramater, bool isTurnPlayer)
    {
        if (m_GameManager.isTurnPlayer != isTurnPlayer)
        {
            m_EnemyMainCardsManager.CallReverse(place1);
            m_MyMainCardsManager.CallWhenReverseEnemyCard(place3, place1, level);
            RpcToAll(nameof(CallPowerCheck2), paramater, m_GameManager.isTurnPlayer);
        }
    }

    [StrixRpc]
    public void CallPowerCheck2(EnumController.PowerCheck paramater, bool isTurnPlayer)
    {
        if (m_GameManager.isTurnPlayer != isTurnPlayer)
        {
            m_GameManager.PowerCheck2(paramater);
        }
    }
    
    [StrixRpc]
    public void ChangePhase(EnumController.Turn turn)
    {
        m_GameManager.ChangePhase(turn);
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

    [StrixRpc]
    public void ClockPhase()
    {
        logText.text = "ClockPhase";
        if (m_GameManager.isTurnPlayer)
        {
            m_GameManager.ClockPhaseStart();
        }
    }

    /// <summary>
    /// WaitDialogを閉じる
    /// </summary>
    [StrixRpc]
    public void CloseWaitDialog()
    {
        m_DialogManager.CloseWaitDialog();
    }

    [StrixRpc]
    public void CallDamage(int damage, int handNum, bool isFirstAttacker)
    {
        if (m_GameManager.isFirstAttacker != isFirstAttacker)
        {
            m_GameManager.Damage(damage, handNum);
        }
    }

    [StrixRpc]
    public void Damage(int num, bool isFirstAttacker, EnumController.Damage damage, List<EnumController.Shot> SendShotList)
    {
        if (m_GameManager.isFirstAttacker != isFirstAttacker)
        {
            m_GameManager.DamageForFrontAttack(num, -1, damage, SendShotList);
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
    public void EncoreDialog(bool isFirstAttacker)
    {
        if (m_GameManager.isFirstAttacker != isFirstAttacker)
        {
            m_GameManager.SendEncoreDialogFromRPC();
        }
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
    private void EventAnimationStart(BattleModeCardTemp temp, bool isFirstAttacker)
    {
        if (m_GameManager.isFirstAttacker != isFirstAttacker)
        {
            m_EventAnimationManager.AnimationStartForRPC(temp);
        }
    }

    /// <summary>
    /// 【起】［(2) このカードを【レスト】する］ あなたはクライマックス以外の自分の控え室のカードを1枚選び、そのカードとこのカードを山札に戻す。その山札をシャッフルする。あなたは1枚引く。
    /// </summary>
    [StrixRpc]
    public void ExecuteAction_P3_S01_080(ExecuteActionTemp m_ExecuteActionTemp, bool isFirstAttacker)
    {
        if (m_GameManager.isFirstAttacker != isFirstAttacker)
        {
            m_GameManager.m_ExecuteAction = new ExecuteAction(m_ExecuteActionTemp);
            m_GameManager.m_ExecuteAction.m_BattleStrix = m_GameManager.m_BattleStrix;
            m_GameManager.m_ExecuteAction.m_GameManager = m_GameManager;
            m_GameManager.m_ExecuteAction.m_BattleModeCardList = m_GameManager.m_BattleModeCardList;

            m_GameManager.m_ExecuteAction.ExecuteAction_SearchAfterConfirmDialog_P3_S01_080();
        }
    }

    /// <summary>
    /// カムバックアイコンが捲れた後確認ダイアログでOKボタンが押された後の処理
    /// </summary>
    [StrixRpc]
    public void ExecuteAction_ComeBackActionAfterConfirmDialog(ExecuteActionTemp m_ExecuteActionTemp, bool isFirstAttacker)
    {
        if (m_GameManager.isFirstAttacker != isFirstAttacker)
        {
            m_GameManager.m_ExecuteAction = new ExecuteAction(m_ExecuteActionTemp);
            m_GameManager.m_ExecuteAction.m_BattleStrix = m_GameManager.m_BattleStrix;
            m_GameManager.m_ExecuteAction.m_GameManager = m_GameManager;
            m_GameManager.m_ExecuteAction.m_BattleModeCardList = m_GameManager.m_BattleModeCardList;

            m_GameManager.m_ExecuteAction.ComeBackActionAfterConfirmDialog();
        }
    }

    /// <summary>
    /// サーチ後確認ダイアログでOKボタンが押された後の処理
    /// </summary>
    [StrixRpc]
    public void ExecuteAction_SearchAfterConfirmDialog(ExecuteActionTemp m_ExecuteActionTemp, bool isFirstAttacker)
    {
        if (m_GameManager.isFirstAttacker != isFirstAttacker)
        {
            m_GameManager.m_ExecuteAction = new ExecuteAction(m_ExecuteActionTemp);
            m_GameManager.m_ExecuteAction.m_BattleStrix = m_GameManager.m_BattleStrix;
            m_GameManager.m_ExecuteAction.m_GameManager = m_GameManager;
            m_GameManager.m_ExecuteAction.m_BattleModeCardList = m_GameManager.m_BattleModeCardList;

            m_GameManager.m_ExecuteAction.ExecuteAction_SearchAfterConfirmDialog();
        }
    }

    /// <summary>
    /// かけ仲でカードを回収する場合
    /// </summary>
    [StrixRpc]
    public void ExecuteAction_SearchAfterConfirmDialog_DC_W01_12T(ExecuteActionTemp m_ExecuteActionTemp, bool isFirstAttacker)
    {
        if (m_GameManager.isFirstAttacker != isFirstAttacker)
        {
            m_GameManager.m_ExecuteAction = new ExecuteAction(m_ExecuteActionTemp);
            m_GameManager.m_ExecuteAction.m_BattleStrix = m_GameManager.m_BattleStrix;
            m_GameManager.m_ExecuteAction.m_GameManager = m_GameManager;
            m_GameManager.m_ExecuteAction.m_BattleModeCardList = m_GameManager.m_BattleModeCardList;

            m_GameManager.m_ExecuteAction.ExecuteAction_SearchAfterConfirmDialog_DC_W01_12T();
        }
    }

    [StrixRpc]
    public void ExecuteActionList(bool isTurnPlayer)
    {
        Debug.Log("ExecuteActionList");
        if (m_GameManager.isTurnPlayer != isTurnPlayer)
        {
            m_GameManager.ExecuteActionList();
        }
    }

    [StrixRpc]
    public void ExecuteActionListForLast(bool isTurnPlayer)
    {
        Debug.Log("ExecuteActionList");
        m_GameManager.executeActionList = true;
        if (m_GameManager.isTurnPlayer != isTurnPlayer)
        {
            m_GameManager.ExecuteActionList();
        }
    }

    [StrixRpc]
    public void ChanggeExecuteActionList(bool paramater)
    {
        m_GameManager.executeActionList = paramater;
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
            return;
        }

        m_DialogManager.NotEraseDialog_Open();
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
    public void MariganStart()
    {
        // 後攻の場合
        if (!m_GameManager.isFirstAttacker)
        {
            m_GameManager.MariganStart();
        }
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
    public void PlayEnemyTriggerAnimation(BattleModeCardTemp card, bool isTurnPlayer)
    {
        if (m_GameManager.isTurnPlayer != isTurnPlayer)
        {
            m_TriggerCardAnimationForEnemy.Play(card);
        }
    }

    [StrixRpc]
    public void RemoveHand(int handNum, bool isFirstAttacker)
    {
        if (m_GameManager.isFirstAttacker != isFirstAttacker)
        {
            if(handNum < 0)
            {
                return;
            }
            BattleModeCard card = m_GameManager.myHandList[handNum];
            m_GameManager.myHandList.RemoveAt(handNum);
            m_GameManager.GraveYardList.Add(card);
            m_GameManager.Syncronize();
        }
    }

    [StrixRpc]
    public void SEManager_AttackSE_Play()
    {
        m_SEmanager.AttackSE_Play();
    }

    [StrixRpc]
    public void SEManager_DrawSE_Play()
    {
        m_SEmanager.DrawSE_Play();
    }

    [StrixRpc]
    public void SEManager_EffectSE_Play()
    {
        m_SEmanager.EffectSE_Play();
    }

    [StrixRpc]
    public void SEManager_LevelUpSE_Play()
    {
        m_SEmanager.LevelUpSE_Play();
    }

    [StrixRpc]
    public void SEManager_PlaySE_Play()
    {
        m_SEmanager.PlaySE_Play();
    }

    [StrixRpc]
    public void SendBattleDeckCardUtilAnimationStart(bool isFirstAttacker)
    {
        if (m_GameManager.isFirstAttacker == isFirstAttacker)
        {
            return;
        }
        m_ShuffleDeckAnimationController.AnimationStart();
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

    [StrixRpc]
    public void SendReceiveTurnChange(bool isFirstAttacker)
    {
        if (m_GameManager.isFirstAttacker == isFirstAttacker)
        {
            return;
        }
        m_GameManager.ReceiveTurnChange();
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
    public void Shot(int damage, List<EnumController.Shot> ShotList, bool isFirstAttacker)
    {
        if (m_GameManager.isFirstAttacker != isFirstAttacker)
        {
            m_GameManager.Shot(damage, ShotList);
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

    /// <summary>
    /// フィールドの特定の場所のキャラをデッキトップに送る
    /// </summary>
    /// <param name="place"></param>
    /// <param name="isTurnPlayer"></param>
    [StrixRpc]
    public void ToDeckTopFromField(int place, bool isTurnPlayer)
    {
        if (m_GameManager.isTurnPlayer != isTurnPlayer)
        {
            m_GameManager.ToDeckTopFromField(place);
        }
    }

    /// <summary>
    /// フィールドの特定の場所のキャラを控室に送る
    /// </summary>
    /// <param name="place"></param>
    /// <param name="isTurnPlayer"></param>
    [StrixRpc]
    public void ToGraveYardFromField(int place, bool isTurnPlayer)
    {
        if (m_GameManager.isTurnPlayer != isTurnPlayer)
        {
            m_GameManager.ToGraveYardFromField(place);
        }
    }

    /// <summary>
    /// フィールドの特定の場所のキャラを手札に戻す
    /// </summary>
    /// <param name="place"></param>
    /// <param name="isTurnPlayer"></param>
    [StrixRpc]
    public void ToHandFromField(int place, bool isTurnPlayer)
    {
        if (m_GameManager.isTurnPlayer != isTurnPlayer)
        {
            m_GameManager.ToHandFromField(place);
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
    public void UpdateEnemyGraveYard(List<BattleModeCardTemp> list, bool isFirstAttacker)
    {
        if (m_GameManager.isFirstAttacker != isFirstAttacker)
        {
            m_GameManager.UpdateEnemyGraveYardCards(list);
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
    public void UpdateEnemyStockCards(List<BattleModeCardTemp> list, bool isFirstAttacker)
    {
        if (m_GameManager.isFirstAttacker != isFirstAttacker)
        {
            m_GameManager.UpdateEnemyStockCards(list);
        }
    }

    [StrixRpc]
    public void UpdateMainCards(List<BattleModeCardTemp> list, List<int> FieldLevelList, List<int> FieldPowerList, List<int> FieldSoulList, List<bool> IsGreatProcessList, bool isFirstAttacker)
    {
        if (m_GameManager.isFirstAttacker != isFirstAttacker)
        {
            m_GameManager.UpdateEnemyMainCards(list, FieldLevelList, FieldPowerList, FieldSoulList, IsGreatProcessList);
        }
    }

    [StrixRpc]
    public void UpdateMainCardsState(List<EnumController.State> list, bool isFirstAttacker)
    {
        if (m_GameManager.isFirstAttacker != isFirstAttacker)
        {
            m_GameManager.UpdateEnemyMainCardsState(list);
        }
    }

    [StrixRpc]
    public void UpdateMainCardsAttribute(List<EnumController.Attribute> list, int place, bool isFirstAttacker)
    {
        if (m_GameManager.isFirstAttacker != isFirstAttacker)
        {
            m_GameManager.UpdateEnemyMainCardsAttribute(list, place);
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
    public void UpdateClimaxCard(BattleModeCardTemp myClimax, BattleModeCardTemp enemyClimax, bool isFirstAttacker)
    {
        if (m_GameManager.isFirstAttacker != isFirstAttacker)
        {
            m_GameManager.UpdateClimaxCard(myClimax, enemyClimax);
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
    public void UpdateEnemyMemoryCards(List<BattleModeCardTemp> list , bool isFirstAttacker)
    {
        if (m_GameManager.isFirstAttacker != isFirstAttacker)
        {
            m_GameManager.UpdateEnemyMemoryCards(list);
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
}
