using System.Collections;
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

public class RoomSelectClass_Menu : MonoBehaviour
{
    public string host = "ec593633b2ecaca37e597b51.game.strixcloud.net";
    public int port = 9122;
    public string applicationId = "de65fc24-a8f1-49e8-becf-732e0420ac94";
    private string pass;
    StrixNetwork strixNetwork;

    [SerializeField] RoomSelectAlertAnimation m_RoomSelectAlertAnimation;
    [SerializeField] AudioSource m_AudioSource;
    [SerializeField] AudioClip BtnSE;

    public List<RoomSelectObj> RoomSelectObjList = new List<RoomSelectObj>();

    public void onSearch()
    {
        m_AudioSource.PlayOneShot(BtnSE);
        IConditionBuilder builder = ConditionBuilder.Builder().Field("key1").EqualTo(RoomSelectClass.Version); 
        strixNetwork = StrixNetwork.instance;
        strixNetwork.applicationId = applicationId;
        strixNetwork.ConnectMasterServer(host, port,
            connectEventHandler: _ => {
                strixNetwork.SearchRoom(
                               condition: builder.Build(),
                               order: new Order("memberCount", OrderType.Ascending),
                               limit: RoomSelectObjList.Count,
                               offset: 0,
                               handler: searchResults =>
                               {
                                   var foundRooms = searchResults.roomInfoCollection;
                                   List<RoomInfo> RoomInfoList = new List<RoomInfo>();
                                   foreach (var roomInfo in foundRooms)
                                   {
                                       RoomInfoList.Add(roomInfo);
                                   }

                                   for(int i = 0; i < RoomSelectObjList.Count; i++)
                                   {
                                       if(i < RoomInfoList.Count && RoomInfoList[i].isJoinable)
                                       {
                                           RoomInfo roomInfo = RoomInfoList[i];
                                           RoomSelectObjList[i].Set(roomInfo.name, "");
                                       }
                                       else
                                       {
                                           RoomSelectObjList[i].Set("", "");
                                       }
                                   }
                                   if (RoomInfoList.Count == 0)
                                   {
                                       m_RoomSelectAlertAnimation.AnimationStart(true);
                                   }
                               }, failureHandler: searchError => { });
            }, OnConnectFailedCallback);
        StrixNetwork.instance.roomSession.Disconnect();
    }

    private void OnConnectFailedCallback(StrixNetworkConnectFailedEventArgs args)
    {

    }
}
