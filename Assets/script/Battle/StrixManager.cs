using System;
using System.Linq;
using System.Collections.Generic;
using SoftGear.Strix.Unity.Runtime;
using SoftGear.Strix.Unity.Runtime.Event;
using SoftGear.Strix.Unity.Runtime.Session;
using SoftGear.Strix.Unity.Runtime.Error;
using SoftGear.Strix.Client.Core;
using SoftGear.Strix.Client.Core.Request;
using SoftGear.Strix.Client.Core.Auth.Message;
using SoftGear.Strix.Client.Core.Error;
using SoftGear.Strix.Client.Core.Model.Manager.Filter;
using SoftGear.Strix.Client.Core.Model.Manager.Filter.Builder;
using SoftGear.Strix.Client.Match.Room.Model;
using SoftGear.Strix.Client.Room;
using SoftGear.Strix.Client.Room.Error;
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
    StrixNetwork strixNetwork;

    [SerializeField] GameManager m_GameManager;
    [SerializeField] BattleStrix m_BattleStrix;
    [SerializeField] WinAndLose m_WinAndLose;

    /// <summary>
    /// 部屋を作っているか。作っていた場合true
    /// </summary>
    public bool isOwner;

    /// <summary>
    /// ルーム名
    /// </summary>
    public string roomName;

    /// <summary>
    /// パスワード
    /// </summary>
    public string passPhrase;

    public string Name;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public StrixManager()
    {
        isOwner = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        strixNetwork = StrixNetwork.instance;
        strixNetwork.roomSession.roomClient.RoomJoinNotified += RoomJoinNotified;
        roomName = RoomSelectClass.getRoomName();
        passPhrase = RoomSelectClass.getPassPhrase();
        Name = RoomSelectClass.getName();

        if (roomName == string.Empty || SaveData.cardInfoList.Count != 50)
        {
            SceneManager.LoadScene("RoomSelect");
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
                               limit: 2,
                               offset: 0,
                               handler: searchResults =>
                               {
                                   var foundRooms = searchResults.roomInfoCollection;
                                   if(foundRooms.Count == 0)
                                   {
                                       Debug.Log("Success");
                                       isOwner = true;
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
                                   // m_BattleStrix.RpcToAll("SetGameStartBtn");
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
        var errorCodeException = args.cause as ErrorCodeException;

        switch (errorCodeException.errorCode)
        {
            case SoftGear.Strix.Client.Room.Error.RoomErrorCode.RoomNotJoinable:
            case SoftGear.Strix.Client.Room.Error.RoomErrorCode.RoomFullOfMembers:
                SceneManager.LoadScene("RoomSelect");
                break;
            default:
                Debug.Log(args);
                break;
        }
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

    // 誰かが部屋に入ってきたときに呼び出される
    private void RoomJoinNotified(NotificationEventArgs<RoomJoinNotification<CustomizableMatchRoom>> notification)
    {
        m_GameManager.GameStart();
        strixNetwork.SetRoom(strixNetwork.selfRoomMember.GetRoomId(),
            new RoomProperties
            {
                name = roomName,
                password = passPhrase,
                capacity = 2,
                isJoinable = false,
            }
            , handler: __ =>{}
            , failureHandler: __ => {});
    }

    // オブジェクトが破棄された場合に呼び出される
    private void OnDestroy()
    {
        m_WinAndLose.Win();
    }
}
