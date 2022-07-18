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
        // Photon Realtime�̃T�[�o�[�֐ڑ��i���r�[�֓����j
        PhotonNetwork.ConnectUsingSettings(null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ���r�[�֓�������
    void OnJoinedLobby()
    {
        // �ǂ����̃��[���֓���
        PhotonNetwork.JoinRandomRoom();
    }

    // ���r�[�ւ̓��������s
    void OnFailedToConnectToPhoton()
    {

    }

    // ���[���֓������s
    void OnPhotonRandomJoinFailed()
    {
        // �����Ń��[�����쐬
        PhotonNetwork.CreateRoom(null);
    }

    // �����Ƀ��[���֓���
    void OnJoinedRoom() {
        Debug.Log("���[���֓������܂���");
        GameObject tempPlayer = PhotonNetwork.Instantiate("Player", new Vector3(0, 0, 0), Quaternion.identity, 0);
        myPlayer = tempPlayer.GetComponent<Player>();
        updateHandList();
    }

    // PhotonRealTime�Ɛڑ����؂ꂽ�ꍇ
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
