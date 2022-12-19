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

public class StrixManager : MonoBehaviour
{
    public string host = "127.0.0.1";
    public int port = 9122;
    public string applicationId = "00000000-0000-0000-0000-000000000000";
    private string pass;

    public bool isCreateMode = true;

    private bool isOwnerFirstAttacker = false;
    [SerializeField] GameManager m_GameManager;

    /// <summary>
    /// ルームに参加可能な最大人数
    /// </summary>
    public int capacity = 4;

    /// <summary>
    /// ルーム名
    /// </summary>
    public string roomName = "New Room";

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Connect()
    {
        StrixNetwork.instance.applicationId = applicationId;
        StrixNetwork.instance.playerName = "";
        StrixNetwork.instance.ConnectMasterServer(host, port,
            connectEventHandler: _ => {
                CreateRoom();
                //this.gameObject.GetComponent<BattleStrix>().SendGameStart();
            }, OnConnectFailedCallback);
        /*if (isCreateMode)
        {
            StrixNetwork.instance.ConnectMasterServer(host, port,
                connectEventHandler: _ => {
                    CreateRoom();
                }, OnConnectFailedCallback);
        }
        else
        {
            StrixNetwork.instance.ConnectMasterServer(host, port,
                connectEventHandler: _ => {
                    JoinRoom();
                }, OnConnectFailedCallback);
        }*/
        Debug.Log("Connect");

    }

    private void OnConnectCallback(StrixNetworkConnectEventArgs args)
    {

    }

    private void OnConnectFailedCallback(StrixNetworkConnectFailedEventArgs args)
    {

    }

    private void RoomJoined()
    {

    }

    private void JoinRoom()
    {
        RoomJoinArgs m_RoomJoinArgs = new RoomJoinArgs();

        m_RoomJoinArgs.host = host;
        StrixNetwork.instance.JoinRoom(m_RoomJoinArgs, args => { Debug.Log("searchResult"); }, args => { Debug.Log("searchResult"); }, null);
        this.gameObject.GetComponent<BattleStrix>().SendGameStart();
        Debug.Log("成功");
    }

    private void CreateRoom()
    {
        CoinToss();
        RoomProperties roomProperties = new RoomProperties
        {
            capacity = 2,
            name = "New Room",
            password = pass,
        };

        RoomMemberProperties memberProperties = new RoomMemberProperties
        {
            name = StrixNetwork.instance.playerName
        };

        StrixNetwork.instance.CreateRoom(roomProperties, memberProperties, createResult => {
            //onRoomEntered.Invoke();
        }, args => {
            //onRoomEnterFailed.Invoke();
        });
    }

    private void CoinToss()
    {
        if (UnityEngine.Random.Range(0, 2) == 0)
        {
            isOwnerFirstAttacker = true;
        }
        else
        {
            isOwnerFirstAttacker = false;
        }
    }

    public void SetTrueCreateMode()
    {
        isCreateMode = true;
    }

    public void SetFalseCreateMode()
    {
        isCreateMode = false;
    }
}
