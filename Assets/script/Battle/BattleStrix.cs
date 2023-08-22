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

    List<BattleModeCard> tempList = new List<BattleModeCard>();

    // Start is called before the first frame update
    void Start()
    {
        ObjectFactory.Instance.Register(typeof(BattleModeCardTemp));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendSetIsFirstAttacker(bool b)
    {
        if (b)
        {
            RpcToAll(nameof(SetIsFirstAttacker), false);
            return;
        }
        RpcToAll(nameof(SetIsFirstAttacker), true);
    }

    [StrixRpc]
    public void SetIsFirstAttacker(bool b)
    {
        Debug.Log("SetIsFirstAttacker");
        if (m_StrixManager.isOwner)
        {
            return;
        }
        m_GameManager.isFirstAttacker = b;
        m_GameManager.isTurnPlayer = b;
        if (b)
        {
            logText.text = "先攻";
        }
        else
        {
            logText.text = "後攻";
        }
    }

    public void SendSetGameStartBtn()
    {
        RpcToAll(nameof(SetGameStartBtn));
    }

    [StrixRpc]
    public void SetGameStartBtn()
    {
        Debug.Log("SetGameStartBtn");
        if (m_StrixManager.isOwner)
        {
            return;
        }
        m_GameManager.SetGameStartBtn();
    }

    public void SendGameStart()
    {
        RpcToAll(nameof(GameStart));
    }

    [StrixRpc]
    public void GameStart()
    {
        Debug.Log("GameStart");
        m_GameManager.Shuffle();
        m_GameManager.FirstDraw();

        // 先攻の場合
        if (m_GameManager.isFirstAttacker)
        {
            m_GameManager.MariganStart();
        }
    }

    public void SendMarigan()
    {
        RpcToAll(nameof(Marigan));
    }

    [StrixRpc]
    public void Marigan()
    {
        Debug.Log("Marigan");
        logText.text = "マリガン";
        // 後攻の場合
        if (!m_GameManager.isFirstAttacker)
        {
            m_GameManager.MariganStart();
        }
    }

    public void SendUpdateEnemyGraveYard(List<BattleModeCard> list, bool isFirstAttacker)
    {
        logText.text = "UpdateEnemyGraveYard";

        List<BattleModeCardTemp> temp = new List<BattleModeCardTemp>();
        
        for (int i = 0; i < list.Count; i++)
        {
            temp.Add(new BattleModeCardTemp(list[i]));
        }
        RpcToAll(nameof(UpdateEnemyGraveYard), temp, isFirstAttacker);
    }

    [StrixRpc]
    public void UpdateEnemyGraveYard(List<BattleModeCardTemp> list, bool isFirstAttacker)
    {
        if (m_GameManager.isFirstAttacker != isFirstAttacker)
        {
            m_GameManager.UpdateEnemyGraveYardCards(list);
        }
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

    [StrixRpc]
    public void UpdateEnemyClock(List<BattleModeCardTemp> list, bool isTurnPlayer)
    {
        if (m_GameManager.isTurnPlayer != isTurnPlayer)
        {
            m_GameManager.UpdateEnemyClock(list);
        }
    }

    public void SendDrawPhase()
    {
        logText.text = "ドローフェイズ";
        RpcToAll(nameof(ChangePhase), EnumController.Turn.Draw);
        RpcToAll(nameof(DrawPhase));
    }

    [StrixRpc]
    public void DrawPhase()
    {
        if (m_GameManager.isTurnPlayer)
        {
            m_GameManager.DrawPhaseStart();
        }
    }

    public void SendClockPhase()
    {
        logText.text = "クロックフェイズ";
        RpcToAll(nameof(ChangePhase), EnumController.Turn.Clock);
        RpcToAll(nameof(ClockPhase));
    }

    [StrixRpc]
    public void ClockPhase()
    {
        if (m_GameManager.isTurnPlayer)
        {
            m_GameManager.ClockPhaseStart();
        }
    }

    public void SendMainPhase()
    {
        RpcToAll(nameof(ChangePhase), EnumController.Turn.Main);
        RpcToAll(nameof(MainPhase));
    }

    [StrixRpc]
    public void MainPhase()
    {
        if (m_GameManager.isTurnPlayer)
        {
            m_GameManager.MainStart();
        }
    }

    public void SendUpdateMainCards(List<BattleModeCard> list, bool isTurnPlayer)
    {
        List<BattleModeCardTemp> temp = new List<BattleModeCardTemp>();
        Debug.Log(list.Count);
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

    [StrixRpc]
    public void UpdateMainCards(List<BattleModeCardTemp> list, bool isTurnPlayer)
    {
        logText.text = "UpdateMainCards";
        if (m_GameManager.isTurnPlayer != isTurnPlayer)
        {
            m_GameManager.UpdateEnemyMainCards(list);
        }
    }

    [StrixRpc]
    public void ChangePhase(EnumController.Turn turn)
    {
        m_GameManager.ChangePhase(turn);
    }

}
