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

    SaveUtil m_SaveUtil = new SaveUtil();

    RoomSelectClass()
    {
        RoomName = "";
        PassPhrase = "";
        Name = "";
    }

    // Start is called before the first frame update
    void Start()
    {
        t_PlayerName.text = SaveData.PlayerName;
        Name = SaveData.PlayerName;
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }

    public void onCloseCreateRoomButton()
    {
        GetComponent<AudioSource>().PlayOneShot(BtnSE);
        CreateRoomMenu.SetActive(false);
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
}
