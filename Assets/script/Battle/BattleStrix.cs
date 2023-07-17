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

    public bool CoinToss()
    {
        if (Random.Range(0, 1) == 0)
        {
            return true;
        }
        return false;               
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
    public void GameStart()
    {
        Debug.Log("GameStart");
        m_GameManager.GameStart();
    }
}
