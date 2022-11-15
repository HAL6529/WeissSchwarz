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

    public bool isCreateMode = false;
    
    /// <summary>
    /// ルームに参加可能な最大人数
    /// </summary>
    public int capacity = 4;

    /// <summary>
    /// ルーム名
    /// </summary>
    public string roomName = "New Room";

    /// <summary>
    /// ルーム入室完了時イベント
    /// </summary>
    public UnityEvent onRoomEntered;

    /// <summary>
    /// ルーム入室失敗時イベント
    /// </summary>
    public UnityEvent onRoomEnterFailed;
    // Start is called before the first frame update
    void Start()
    {
        Connect();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Connect()
    {
        StrixNetwork.instance.applicationId = applicationId;
        StrixNetwork.instance.playerName = "";

        if (isCreateMode)
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
        }

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
        // m_RoomJoinArgs.port = port;
        // m_RoomJoinArgs.protocol = "TCP";
        // マスターサーバーに接続したら、そのサーバーでルームを検索できます
        /* StrixNetwork.instance.SearchJoinableRoom(
            condition: null,                                            // 全てのルームを検索します
            order: new Order("memberCount", OrderType.Ascending),       // 最もすいているルームが最初になるように並べます
            limit: 10,                                                                     // 結果を10件のみ取得します
            offset: 0,                                                                     // 結果を最初から取得します
            handler: searchResults => {
                Debug.Log("searchResult");
            },
            failureHandler: searchError => Debug.LogError("Search failed.Reason: " )
        );*/

        StrixNetwork.instance.JoinRoom(m_RoomJoinArgs, args => { Debug.Log("searchResult"); }, args => { Debug.Log("searchResult"); }, null);

        Debug.Log("成功");
    }

    private void CreateRoom()
    {
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

        StrixNetwork.instance.CreateRoom(roomProperties, memberProperties, args => {
            //onRoomEntered.Invoke();
        }, args => {
            //onRoomEnterFailed.Invoke();
        });
    }
}
