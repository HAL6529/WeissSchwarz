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

public class PlayerTest : MonoBehaviour
{
    public string playerName;

    private string enemyName;

    [SerializeField] private Text text;

    [SerializeField] private Text enemyText;

    [SerializeField] private InputField inputField;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateEnemyPlayerName(string enemy)
    {
        Debug.Log("OK");
        enemyName = enemy;
        enemyText.text = enemyName;
    }

    public void UpdateMyPlayerName()
    {
        text.text = playerName;
    }

    public void onClicked()
    {
        playerName = inputField.text;
        UpdateMyPlayerName();
    }
}
