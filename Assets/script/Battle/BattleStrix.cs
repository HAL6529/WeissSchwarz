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

    List<BattleModeCard> tempList = new List<BattleModeCard>();

    // Start is called before the first frame update
    void Start()
    {
        ObjectFactory.Instance.Register(typeof(BattleModeCardTemp));
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

        // êÊçUÇÃèÍçá
        if (m_GameManager.isFirstAttacker)
        {
            m_GameManager.MariganStart();
        }
    }

    [StrixRpc]
    public void MariganStart()
    {
        // å„çUÇÃèÍçá
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
    /// ëäéËÇÉäÉoÅ[ÉXÇµÇΩÇ∆Ç´åƒÇ—èoÇ≥ÇÍÇÈ
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
    public void Damage(int num, bool isTurnPlayer)
    {
        logText.text = "Damage:" + Convert.ToString(num);
        if (m_GameManager.isTurnPlayer != isTurnPlayer)
        {
            m_GameManager.Damage(num);
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

    [StrixRpc]
    public void SetIsAttackProcess(bool isAttackProcess)
    {
        m_GameManager.isAttackProcess = isAttackProcess;
    }
}
