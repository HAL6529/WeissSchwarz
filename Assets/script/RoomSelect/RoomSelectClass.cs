using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoomSelectClass : MonoBehaviour
{
    [SerializeField] GameObject CreateRoomMenu;

    [SerializeField] GameObject Menu;

    [SerializeField] Text t_RoomName;

    [SerializeField] Text t_PassPhrase;

    [SerializeField] Text t_PlayerName;

    [SerializeField] InputField t_Name;

    [SerializeField] RoomSelectAlertAnimation m_RoomSelectAlertAnimation;

    [SerializeField] BattleModeCardList m_BattleModeCardList;

    [SerializeField] AudioClip BtnSE;

    public static string RoomName;

    public static string PassPhrase;

    public static string Name;

    public static EnumController.RoomSelect RoomType;

    public static double Version;

    SaveUtil m_SaveUtil = new SaveUtil();

    RoomSelectClass()
    {
        RoomName = "";
        PassPhrase = "";
        Name = "";
        RoomType = EnumController.RoomSelect.VOID;
        Version = 0.0001;
    }

    // Start is called before the first frame update
    void Start()
    {
        t_PlayerName.text = SaveData.PlayerName;
        Name = SaveData.PlayerName;
        Load();
    }
    
    public void onCreateDeckButton()
    {
        GetComponent<AudioSource>().PlayOneShot(BtnSE);
        SceneManager.LoadScene("DeckEdit");
    }

    public void onCreateRoomMenuButton()
    {
        GetComponent<AudioSource>().PlayOneShot(BtnSE);
        CreateRoomMenu.SetActive(true);
        Menu.SetActive(false);
    }

    public void onVSButton()
    {
        GetComponent<AudioSource>().PlayOneShot(BtnSE);
        Menu.SetActive(true);
    }

    public void onCloseCreateRoomButton()
    {
        GetComponent<AudioSource>().PlayOneShot(BtnSE);
        CreateRoomMenu.SetActive(false);
    }

    public void onCloseMenuButton()
    {
        GetComponent<AudioSource>().PlayOneShot(BtnSE);
        Menu.SetActive(false);
    }

    public void onCreateRoomButton()
    {
        GetComponent<AudioSource>().PlayOneShot(BtnSE);
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
        RoomType = EnumController.RoomSelect.Private;

        SceneManager.LoadScene("Battle");
    }

    public void onExitButton()
    {
        SceneManager.LoadScene("Menu");
    }

    public void onNameOKButton()
    {
        GetComponent<AudioSource>().PlayOneShot(BtnSE);
        string name = t_Name.text;
        if (name == string.Empty)
        {
            return;
        }
        t_Name.text = "";
        t_PlayerName.text = name;
        Name = name;
        SaveData.PlayerName = Name;
    }

    public void onRandomRoomButton()
    {
        GetComponent<AudioSource>().PlayOneShot(BtnSE);

        bool result = false;
        bool nameResult = false;
        bool deckCountResult = false;

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
            m_RoomSelectAlertAnimation.AnimationStart(deckCountResult, false, false, nameResult);
            return;
        }

        RoomType = EnumController.RoomSelect.Random;

        SceneManager.LoadScene("Battle");
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

    public static double getVersion()
    {
        return Version;
    }

    public void Load()
    {
        string DeckName = "default";
        string filePath = @"./Save";

        List<BattleModeCard> list = new List<BattleModeCard>();

        // ディレクトリがなければreturn
        if (!Directory.Exists(filePath) || !File.Exists(@"./Save/" + DeckName + ".txt"))
        {
            return;
        }

        IEnumerable<string> lines = File.ReadLines(@"./Save/" + DeckName + ".txt");

        // ファイルの行数分ループ
        foreach (string line in lines)
        {
            BattleModeCard temp = m_BattleModeCardList.ConvertStringToCardNo(line);
            if (temp != null)
            {
                list.Add(temp);
            }
            else
            {
                return;
            }
        }

        SaveData.cardInfoList = list;
    }

    public void onInputPasswordDialogEnter(string roomNametxt, string passwordtxt)
    {
        GetComponent<AudioSource>().PlayOneShot(BtnSE);
        string roomName = roomNametxt;
        string passPhrase = passwordtxt;
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
        RoomType = EnumController.RoomSelect.Enter;

        SceneManager.LoadScene("Battle");
    }
}
