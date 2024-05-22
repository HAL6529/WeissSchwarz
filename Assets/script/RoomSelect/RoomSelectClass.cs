using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoomSelectClass : MonoBehaviour
{
    [SerializeField] GameObject CreateRoomMenu;

    [SerializeField] Text t_RoomName;

    [SerializeField] Text t_PassPhrase;

    [SerializeField] Text t_PlayerName;

    [SerializeField] InputField t_Name;

    [SerializeField] RoomSelectAlertAnimation m_RoomSelectAlertAnimation;

    public static string RoomName;

    public static string PassPhrase;

    public static string Name;

    RoomSelectClass()
    {
        RoomName = "";
        PassPhrase = "";
        Name = "";
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void onCreateDeckButton()
    {
        SceneManager.LoadScene("DeckEdit");
    }

    public void onCreateRoomMenuButton()
    {
        CreateRoomMenu.SetActive(true);
    }

    public void onCloseCreateRoomButton()
    {
        CreateRoomMenu.SetActive(false);
    }

    public void onCreateRoomButton()
    {
        string roomName = t_RoomName.text;
        string passPhrase = t_PassPhrase.text;
        bool result = false;
        bool roomNameResult = false;
        bool passPhraseResult = false;
        bool nameResult = false;
        bool deckCountResult = false;

        if (roomName == string.Empty)
        {
            result = true;
            roomNameResult = true;
        }

        if (passPhrase == string.Empty)
        {
            result = true;
            passPhraseResult = true;
        }

        if (Name == string.Empty)
        {
            result = true;
            nameResult = true;
        }

        if (SaveData.cardInfoList.Count != 50)
        {
            result = true;
            deckCountResult = true;
        }

        if (result)
        {
            m_RoomSelectAlertAnimation.AnimationStart(deckCountResult, roomNameResult, passPhraseResult, nameResult);
            return;
        }

        RoomName = roomName;
        PassPhrase = passPhrase;

        SceneManager.LoadScene("Battle");
    }

    public void onExitButton()
    {
        SceneManager.LoadScene("Menu");
    }

    public void onNameOKButton()
    {
        string name = t_Name.text;
        if (name == string.Empty)
        {
            return;
        }
        t_Name.text = "";
        t_PlayerName.text = name;
        Name = name;
    }


    public static string getRoomName()
    {
        return RoomName;
    }

    public static string getPassPhrase()
    {
        return PassPhrase;
    }

    public static string getName()
    {
        return Name;
    }
}
