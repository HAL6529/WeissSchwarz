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
        // �}�X�^�[�T�[�o�[�ɐڑ�������A���̃T�[�o�[�Ń��[���������ł��܂�
        /* StrixNetwork.instance.SearchJoinableRoom(
            condition: null,                                            // �S�Ẵ��[�����������܂�
            order: new Order("memberCount", OrderType.Ascending),       // �ł������Ă��郋�[�����ŏ��ɂȂ�悤�ɕ��ׂ܂�
            limit: 10,                                                                     // ���ʂ�10���̂ݎ擾���܂�
            offset: 0,                                                                     // ���ʂ��ŏ�����擾���܂�
            handler: searchResults => {
                Debug.Log("searchResult");
            },
            failureHandler: searchError => Debug.LogError("Search failed.Reason: " )
        );*/

        StrixNetwork.instance.JoinRoom(m_RoomJoinArgs, args => { Debug.Log("searchResult"); }, args => { Debug.Log("searchResult"); }, null);

        Debug.Log("����");
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
