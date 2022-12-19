using System;
using System.Collections.Generic;
using SoftGear.Strix.Unity.Runtime;
using SoftGear.Strix.Unity.Runtime.Event;
using SoftGear.Strix.Client.Core.Request;
using SoftGear.Strix.Client.Core.Model.Manager.Filter;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleStrix : StrixBehaviour
{
    [SerializeField] GameManager m_GameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendGameStart()
    {
        if (StrixNetwork.instance.masterSession.IsConnected)
        {
            Debug.Log("ゲームサーバーに接続されています。");
        }
        else
        {
            Debug.Log("ゲームサーバーに接続されていません。");
        }
        Debug.Log("SendGameStart");
        RpcToAll(nameof(GameStart));
    }

    [StrixRpc]
    private void SetFirstAttacker(bool isCreateMode, bool isOwnerFirstAttacker)
    {
        Debug.Log("SetFirstAttacker");
        /*if (StrixNetwork.instance.isRoomOwner)
        {
            m_GameManager.isFirstAttacker = isOwnerFirstAttacker;
        }
        else
        {
            m_GameManager.isFirstAttacker = !isOwnerFirstAttacker;
        }*/
    }

    [StrixRpc]
    public void GameStart()
    {
        Debug.Log("GameStart");
        m_GameManager.GameStart();
    }
}
