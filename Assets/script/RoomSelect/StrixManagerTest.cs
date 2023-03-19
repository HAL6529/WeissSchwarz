using System;
using System.Collections.Generic;
using SoftGear.Strix.Unity.Runtime;
using SoftGear.Strix.Unity.Runtime.Event;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StrixManagerTest : MonoBehaviour
{
    public string host = "127.0.0.1";
    public int port = 9122;
    public string applicationId = "00000000-0000-0000-0000-000000000000";

    /// <summary>
    /// ���[���ɎQ���\�ȍő�l��
    /// </summary>
    public int capacity = 4;

    /// <summary>
    /// ���[����
    /// </summary>
    public string roomName = "New Room";

    /// <summary>
    /// ���[�������������C�x���g
    /// </summary>
    public UnityEvent onRoomEntered;

    /// <summary>
    /// ���[���������s���C�x���g
    /// </summary>
    public UnityEvent onRoomEnterFailed;
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
        StrixNetwork.instance.ConnectMasterServer(host, port, OnConnectCallback, OnConnectFailedCallback);
    }

    private void OnConnectCallback(StrixNetworkConnectEventArgs args)
    {

    }

    private void OnConnectFailedCallback(StrixNetworkConnectFailedEventArgs args)
    {

    }

    public void onRandomJoinButton()
    {
       StrixNetwork.instance.JoinRandomRoom(
       StrixNetwork.instance.playerName,
       args => {
           RoomJoined();
       },
       args => {
           CreateRoom();
       });
    }

    private void RoomJoined()
    {

    }

    private void CreateRoom()
    {
        RoomProperties roomProperties = new RoomProperties
        {
            capacity = capacity,
            name = roomName
        };

        RoomMemberProperties memberProperties = new RoomMemberProperties
        {
            name = StrixNetwork.instance.playerName
        };


        StrixNetwork.instance.CreateRoom(roomProperties, memberProperties, args => {
            onRoomEntered.Invoke();
        }, args => {
            onRoomEnterFailed.Invoke();
        });
    }
}
