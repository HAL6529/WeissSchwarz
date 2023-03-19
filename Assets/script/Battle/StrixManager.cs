using System;
using System.Linq;
using System.Collections.Generic;
using SoftGear.Strix.Unity.Runtime;
using SoftGear.Strix.Unity.Runtime.Event;
using SoftGear.Strix.Client.Core.Request;
using SoftGear.Strix.Client.Core.Model.Manager.Filter;
using SoftGear.Strix.Client.Core.Model.Manager.Filter.Builder;
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

    public bool isCreateMode = true;

    [SerializeField] GameManager m_GameManager;

    /// <summary>
    /// ルームに参加可能な最大人数
    /// </summary>
    public int capacity = 4;

    /// <summary>
    /// ルーム名
    /// </summary>
    public string roomName = "New Room";

    public string passPhrase = "";

    // Start is called before the first frame update
    void Start()
    {
        var strixNetwork = StrixNetwork.instance;
        roomName = RoomSelectClass.getRoomName();
        passPhrase = RoomSelectClass.getPassPhrase();
        Debug.Log(roomName);
        Debug.Log(passPhrase);

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
                                       strixNetwork.CreateRoom(
                                           new RoomProperties
                                           {
                                               name = roomName,
                                               password = "aaa",
                                               capacity = 4,
                                               key1 = 4.0,
                                           },
                                           new RoomMemberProperties
                                           {
                                               name = "Braille"
                                           },
                                           handler: __ =>
                                           {
                                               Debug.Log("RoomCreated");
                                           },
                                           failureHandler: createRoomError => Debug.LogError("Could not create room.Reason: " + createRoomError.cause)
                                       );
                                       return;
                                   }
                                   var roomInfo = foundRooms.First();

                                   Debug.Log(roomInfo.roomId);
                                   strixNetwork.JoinRoom(
                                        host: roomInfo.host,
                                        port: roomInfo.port,
                                        protocol: roomInfo.protocol,
                                        roomId: roomInfo.roomId,
                                        playerName: "My Player Name",
                                        handler: __ => Debug.Log("Room joined."),
                                        failureHandler: joinError => Debug.LogError("Join failed.Reason: " + joinError.cause)
                                   );
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

    public void SetTrueCreateMode()
    {
        isCreateMode = true;
    }

    public void SetFalseCreateMode()
    {
        isCreateMode = false;
    }
}
