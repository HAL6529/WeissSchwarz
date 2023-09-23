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

    public void SendUpdateEnemyStockCards(List<BattleModeCard> list, bool isTurnPlayer)
    {
        List<BattleModeCardTemp> temp = new List<BattleModeCardTemp>();

        for (int i = 0; i < list.Count; i++)
        {
            temp.Add(new BattleModeCardTemp(list[i]));
        }
        RpcToAll(nameof(UpdateEnemyStockCards), temp, isTurnPlayer);
    }

    public void SendUpdateEnemyClock(List<BattleModeCard> list, bool isTurnPlayer)
    {
        List<BattleModeCardTemp> temp = new List<BattleModeCardTemp>();

        for (int i = 0; i < list.Count; i++)
        {
            temp.Add(new BattleModeCardTemp(list[i]));
        }
        RpcToAll(nameof(UpdateEnemyClock), temp, isTurnPlayer);
    }

    public void SendUpdateMainCards(List<BattleModeCard> list, bool isTurnPlayer)
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
        RpcToAll(nameof(UpdateMainCards), temp, isTurnPlayer);
    }

    public void SendUpdateEnemyHandCards(List<BattleModeCard> list, bool isTurnPlayer)
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
        RpcToAll(nameof(UpdateEnemyHandCards), temp, isTurnPlayer);
    }

    public void SendUpdateLevelCards(List<BattleModeCard> list, bool isTurnPlayer)
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
        RpcToAll(nameof(UpdateEnemyLevelCards), temp, isTurnPlayer);
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

        // æU‚Ìê‡
        if (m_GameManager.isFirstAttacker)
        {
            m_GameManager.MariganStart();
        }
    }

    [StrixRpc]
    public void MariganStart()
    {
        logText.text = "ƒ}ƒŠƒKƒ“";
        // ŒãU‚Ìê‡
        if (!m_GameManager.isFirstAttacker)
        {
            m_GameManager.MariganStart();
        }
    }

    [StrixRpc]
    public void UpdateEnemyHandCards(List<BattleModeCardTemp> list, bool isTurnPlayer)
    {
        if (m_GameManager.isTurnPlayer != isTurnPlayer)
        {
            m_GameManager.UpdateEnemyHandCards(list);
        }
    }

    [StrixRpc]
    public void UpdateMainCards(List<BattleModeCardTemp> list, bool isTurnPlayer)
    {
        if (m_GameManager.isTurnPlayer != isTurnPlayer)
        {
            m_GameManager.UpdateEnemyMainCards(list);
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
    public void UpdateEnemyStockCards(List<BattleModeCardTemp> list, bool isTurnPlayer)
    {
        if (m_GameManager.isTurnPlayer != isTurnPlayer)
        {
            m_GameManager.UpdateEnemyStockCards(list);
        }
    }

    [StrixRpc]
    public void UpdateEnemyClock(List<BattleModeCardTemp> list, bool isTurnPlayer)
    {
        if (m_GameManager.isTurnPlayer != isTurnPlayer)
        {
            m_GameManager.UpdateEnemyClock(list);
        }
    }

    [StrixRpc]
    public void UpdateEnemyLevelCards(List<BattleModeCardTemp> list, bool isTurnPlayer)
    {
        if (m_GameManager.isTurnPlayer != isTurnPlayer)
        {
            m_GameManager.UpdateEnemyLevelCards(list);
        }
    }

    [StrixRpc]
    public void UpdateEnemyDeckCount(int num, bool isTurnPlayer)
    {
        if (m_GameManager.isTurnPlayer != isTurnPlayer)
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
    public void StandPhase()
    {
        logText.text = "StandPhase";
        m_GameManager.StandPhaseStart();
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
    public void ClimaxPhase(BattleModeCardTemp m_BattleModeCardTemp, bool isTurnPlayer)
    {
        logText.text = "ClimaxPhase";
        if (m_GameManager.isTurnPlayer != isTurnPlayer)
        {
            m_GameManager.ClimaxStart(m_BattleModeCardTemp);
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

    [StrixRpc]
    public void CallEnemyReverse(int num, bool isTurnPlayer)
    {
        if (m_GameManager.isTurnPlayer != isTurnPlayer)
        {
            m_EnemyMainCardsManager.CallReverse(num);
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
    public void TurnChange()
    {
        m_GameManager.turn++;
        m_GameManager.isTurnPlayer = !m_GameManager.isTurnPlayer;
        m_GameManager.phase = EnumController.Turn.Stand;
        m_GameManager.StandPhaseStart();
    }
}
