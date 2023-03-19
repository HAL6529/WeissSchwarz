using System;
using System.Collections.Generic;
using SoftGear.Strix.Client.Core.Auth.Message;
using SoftGear.Strix.Client.Core.Error;
using SoftGear.Strix.Unity.Runtime;
using SoftGear.Strix.Net.Logging;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using SoftGear.Strix.Unity.Runtime.Event;

public class PlayerManager : StrixBehaviour
{
    [SerializeField] private PlayerTest m_PlayerTest;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [StrixRpc]
    public void CallUpdateEnemyName()
    {
        m_PlayerTest.UpdateEnemyPlayerName(m_PlayerTest.name);
    }
}
