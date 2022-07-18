using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<BattleCardInfo> handCards = new List<BattleCardInfo>();

    [SerializeField] List<HandCardUtil> handCardUtilList = new List<HandCardUtil>();
    Player myPlayer;

    // Start is called before the first frame update
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        // Photon Realtimeのサーバーへ接続（ロビーへ入室）
        PhotonNetwork.ConnectUsingSettings(null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ロビーへ入室完了
    void OnJoinedLobby()
    {
        // どこかのルームへ入室
        PhotonNetwork.JoinRandomRoom();
    }

    // ロビーへの入室が失敗
    void OnFailedToConnectToPhoton()
    {

    }

    // ルームへ入室失敗
    void OnPhotonRandomJoinFailed()
    {
        // 自分でルームを作成
        PhotonNetwork.CreateRoom(null);
    }

    // 無事にルームへ入室
    void OnJoinedRoom() {
        Debug.Log("ルームへ入室しました");
        GameObject tempPlayer = PhotonNetwork.Instantiate("Player", new Vector3(0, 0, 0), Quaternion.identity, 0);
        myPlayer = tempPlayer.GetComponent<Player>();
        updateHandList();
    }

    // PhotonRealTimeと接続が切れた場合
    void OnConnectionFail()
    {

    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            PhotonNetwork.Disconnect();
        }
        else
        {

        }
    }

    public void updateHandList()
    {
        int num = myPlayer.myHandList.Count;
        if (num < 11)
        {
            for (int i = 0; i < num; i++)
            {
                handCards[i] = myPlayer.myHandList[i];
            }           
        }

        for(int i = 0; i < handCardUtilList.Count; i++)
        {
            handCardUtilList[i].updateSprite();
        }
    }
}
