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
        ObjectFactory.Instance.Register(typeof(BattleModeCard));
        ObjectFactory.Instance.Register(typeof(List<BattleModeCard>));
        ObjectFactory.Instance.Register(typeof(EnumController.CardColor));
        ObjectFactory.Instance.Register(typeof(EnumController.Trriger));
        ObjectFactory.Instance.Register(typeof(EnumController.Type));
        ObjectFactory.Instance.Register(typeof(EnumController.Attribute));
        ObjectFactory.Instance.Register(typeof(EnumController.CardNo));
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
        if (b)
        {
            logText.text = "êÊçU";
        }
        else
        {
            logText.text = "å„çU";
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
        Debug.Log("Marigan");
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
        Debug.Log("UpdateEnemyGraveYard");
        tempList = list;

        BattleModeCard b = list[0];
        RpcToAll(nameof(UpdateEnemyGraveYard), list, isFirstAttacker);
    }

    [StrixRpc]
    public void UpdateEnemyGraveYard(List<BattleModeCard> list,  bool isFirstAttacker)
    {
        // tempList = list;
        m_GameManager.UpdateEnemyGraveYardCards(tempList);

    }
}
