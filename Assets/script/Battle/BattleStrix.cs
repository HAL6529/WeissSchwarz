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
        if (m_StrixManager.isOwner)
        {
            return;
        }
        m_GameManager.isFirstAttacker = b;
        m_GameManager.isTurnPlayer = b;
    }

    public void SendSetGameStartBtn()
    {
        RpcToAll(nameof(SetGameStartBtn));
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

    public void SendGameStart()
    {
        RpcToAll(nameof(GameStart));
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

    public void SendMarigan()
    {
        RpcToAll(nameof(Marigan));
    }

    [StrixRpc]
    public void Marigan()
    {
        logText.text = "É}ÉäÉKÉì";
        // å„çUÇÃèÍçá
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

    public void SendStandPhase()
    {
        RpcToAll(nameof(ChangePhase), EnumController.Turn.Stand);
        RpcToAll(nameof(StandPhase));
    }

    [StrixRpc]
    public void StandPhase()
    {
        logText.text = "StandPhase";
        m_GameManager.StandPhaseStart();
    }

    public void SendDrawPhase()
    {
        RpcToAll(nameof(ChangePhase), EnumController.Turn.Draw);
        RpcToAll(nameof(DrawPhase));
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

    public void SendClockPhase()
    {
        RpcToAll(nameof(ChangePhase), EnumController.Turn.Clock);
        RpcToAll(nameof(ClockPhase));
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

    public void SendMainPhase()
    {
        RpcToAll(nameof(ChangePhase), EnumController.Turn.Main);
        RpcToAll(nameof(MainPhase));
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

    public void SendClimaxPhase(BattleModeCard m_BattleModeCard, bool isTurnPlayer)
    {
        BattleModeCardTemp temp = new BattleModeCardTemp(m_BattleModeCard);
        RpcToAll(nameof(ChangePhase), EnumController.Turn.Climax);
        RpcToAll(nameof(ClimaxPhase), temp, isTurnPlayer);
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

    public void SendAttackPhase()
    {
        RpcToAll(nameof(ChangePhase), EnumController.Turn.Attack);
        RpcToAll(nameof(AttackPhase));
    }

    [StrixRpc]
    public void AttackPhase()
    {
        logText.text = "AttackPhase";
    }

    public void SendEncorePhase()
    {
        RpcToAll(nameof(ChangePhase), EnumController.Turn.Encore);
        RpcToAll(nameof(EncorePhase));
    }

    [StrixRpc]
    public void EncorePhase()
    {
        logText.text = "EncorePhase";
        m_GameManager.EncoreStart();
    }

    public void SendDamage(int num, bool isTurnPlayer)
    {
        RpcToAll(nameof(Damage),num ,isTurnPlayer);
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

}
