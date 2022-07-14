using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
        PhotonNetwork.Instantiate("Player", new Vector3(0, 0, 0), Quaternion.identity, 0);
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
}
