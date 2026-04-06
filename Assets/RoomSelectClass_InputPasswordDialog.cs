using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomSelectClass_InputPasswordDialog : MonoBehaviour
{
    public RoomSelectClass m_RoomSelectClass;

    private string roomName;

    [SerializeField] Text t_PassPhrase;

    public void onOpen(string m_roomName)
    {
        roomName = m_roomName;
        this.gameObject.SetActive(true);
    }

    public void onClose()
    {
        this.gameObject.SetActive(false);
    }

    public void Enter()
    {
        m_RoomSelectClass.onInputPasswordDialogEnter(roomName, t_PassPhrase.text);
    }
}
