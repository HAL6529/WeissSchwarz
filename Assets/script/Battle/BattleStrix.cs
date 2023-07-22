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
    [SerializeField] Text logText;
    [SerializeField] GameManager m_GameManager;
    [SerializeField] StrixManager m_StrixManager;
    // Start is called before the first frame update
    void Start()
    {
        
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

    [StrixRpc]
    public void GameStart()
    {
        Debug.Log("GameStart");
        m_GameManager.GameStart();
    }
}
