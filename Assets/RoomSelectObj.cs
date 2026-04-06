using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomSelectObj : MonoBehaviour
{
    public Text RoomNameText;
    public Text RoomCommentText;
    public RoomSelectClass_InputPasswordDialog m_RoomSelectClass_InputPasswordDialog;
    public GameObject Menu;

    public void Set(string str_RoomNameText, string str_RoomCommentText)
    {
        RoomNameText.text = str_RoomNameText;
        RoomCommentText.text = str_RoomCommentText;
        if(str_RoomNameText == "")
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }

    public void onEnter()
    {
        m_RoomSelectClass_InputPasswordDialog.onOpen(RoomNameText.text);
        Menu.SetActive(false);
    }
}
