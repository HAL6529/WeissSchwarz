using System;
using System.Linq;
using System.Collections.Generic;
using SoftGear.Strix.Unity.Runtime;
using SoftGear.Strix.Unity.Runtime.Event;
using SoftGear.Strix.Unity.Runtime.Session;
using SoftGear.Strix.Client.Core;
using SoftGear.Strix.Client.Core.Request;
using SoftGear.Strix.Client.Core.Auth.Message;
using SoftGear.Strix.Client.Core.Error;
using SoftGear.Strix.Client.Core.Model.Manager.Filter;
using SoftGear.Strix.Client.Core.Model.Manager.Filter.Builder;
using SoftGear.Strix.Client.Match.Room.Model;
using SoftGear.Strix.Client.Room;
using SoftGear.Strix.Client.Room.Message;
using SoftGear.Strix.Net.Serialization;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StrixManager : MonoBehaviour
{
    public string host = "ec593633b2ecaca37e597b51.game.strixcloud.net";
    public int port = 9122;
    public string applicationId = "de65fc24-a8f1-49e8-becf-732e0420ac94";
    private string pass;

    [SerializeField] GameManager m_GameManager;
    [SerializeField] BattleStrix m_BattleStrix;
    [SerializeField] Text logText;

    /// <summary>
    /// ����������Ă��邩�B����Ă����ꍇtrue
    /// </summary>
    public bool isOwner;

    /// <summary>
    /// ���[����
    /// </summary>
    public string roomName;

    /// <summary>
    /// �p�X���[�h
    /// </summary>
    public string passPhrase;

    public string Name;

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    public StrixManager()
    {
        isOwner = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        var strixNetwork = StrixNetwork.instance;
        strixNetwork.roomSession.roomClient.RoomJoinNotified += RoomJoinNotified;
        roomName = RoomSelectClass.getRoomName();
        passPhrase = RoomSelectClass.getPassPhrase();
        Name = RoomSelectClass.getName();

        if (roomName == string.Empty)
        {
            return;
        }

        IConditionBuilder builder;
        builder = ConditionBuilder.Builder().Field("name").EqualTo(roomName);
        builder.And().Field("password").EqualTo(passPhrase);

        strixNetwork.applicationId = applicationId;
        strixNetwork.ConnectMasterServer(host, port,
            connectEventHandler: _ => {
                strixNetwork.SearchRoom(
                               condition: builder.Build(),
                               order: new Order("memberCount", OrderType.Ascending),
                               limit: 10,
                               offset: 0,
                               handler: searchResults =>
                               {
                                   var foundRooms = searchResults.roomInfoCollection;
                                   if(foundRooms.Count == 0)
                                   {
                                       Debug.Log("Success");
                                       isOwner = true;
                                       logText.text = "true";
                                       strixNetwork.CreateRoom(
                                           new RoomProperties
                                           {
                                               name = roomName,
                                               password = passPhrase,
                                               capacity = 2,
                                           },
                                           new RoomMemberProperties
                                           {
                                               name = Name
                                           },
                                           handler: __ =>
                                           {
                                               Debug.Log("RoomCreated");
                                           },
                                           failureHandler: createRoomError => Debug.LogError("Could not create room.Reason: " + createRoomError.cause)
                                       );
                                       return;
                                   }
                                   RoomInfo roomInfo = foundRooms.First();
                                   Debug.Log(roomInfo.host);
                                   RoomJoinArgs m_RoomJoinArgs = new RoomJoinArgs()
                                   {
                                       host = roomInfo.host,
                                       port = roomInfo.port,
                                       protocol = roomInfo.protocol,
                                       roomId = roomInfo.roomId,
                                       password = passPhrase,
                                       memberProperties = new RoomMemberProperties
                                       {
                                           name = Name
                                       }
                                   };
                                   strixNetwork.JoinRoom(
                                        m_RoomJoinArgs,
                                        OnRoomJoin, 
                                        OnRoomJoinFailed
                                   );
                                   m_BattleStrix.RpcToAll("SetGameStartBtn");
                               },
                               failureHandler: searchError => Debug.LogError("aa")
                               );
            }, OnConnectFailedCallback);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Connect()
    {

    }

    private void OnConnectCallback(StrixNetworkConnectEventArgs args)
    {

    }

    private void OnConnectFailedCallback(StrixNetworkConnectFailedEventArgs args)
    {

    }

    private void OnRoomJoin(RoomJoinEventArgs args)
    {
        Debug.Log("succcess");
    }

    private void OnRoomJoinFailed(FailureEventArgs args)
    {
        Debug.Log(args);
    }

    private void RoomJoined()
    {

    }

    private void JoinRoom()
    {

    }

    private void CreateRoom()
    {

    }

    // �N���������ɓ����Ă����Ƃ��ɌĂяo�����
    private void RoomJoinNotified(NotificationEventArgs<RoomJoinNotification<CustomizableMatchRoom>> notification)
    {
        logText.text = "�N���������Ă���";
    }

}
