using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityForge.AnimCallbacks;

public class RoomSelectAlertAnimation : MonoBehaviour
{
    [SerializeField] Animator BackGround;
    [SerializeField] Animator DeckCountError;
    [SerializeField] Animator InputRoomName;
    [SerializeField] Animator InputPassword;
    [SerializeField] Animator InputPlayerName;
    [SerializeField] Animator NotFound;
    [SerializeField] Animator AlreadyRoomCreated;
    [SerializeField] GameObject t_DeckCountError;
    [SerializeField] GameObject t_InputRoomName;
    [SerializeField] GameObject t_InputPassword;
    [SerializeField] GameObject t_InputPlayerName;
    [SerializeField] GameObject t_NotFound;
    [SerializeField] GameObject t_AlreadyRoomCreated;

    public void AnimationStart(bool DeckCountError, bool InputRoomName, bool InputPassword, bool InputPlayerName)
    {
        this.gameObject.SetActive(true);
        t_DeckCountError.SetActive(DeckCountError);
        t_InputRoomName.SetActive(InputRoomName);
        t_InputPassword.SetActive(InputPassword);
        t_InputPlayerName.SetActive(InputPlayerName);
        t_NotFound.SetActive(false);
        t_AlreadyRoomCreated.SetActive(false);

        this.BackGround.AddClipEndCallback(0, "RoomSelectAlert", () => this.gameObject.SetActive(false));

        this.BackGround.Play("RoomSelectAlert", 0, 0);
        this.DeckCountError.Play("RoomSelectAlertForText", 0, 0);
        this.InputRoomName.Play("RoomSelectAlertForText", 0, 0);
        this.InputPassword.Play("RoomSelectAlertForText", 0, 0);
        this.InputPlayerName.Play("RoomSelectAlertForText", 0, 0);
    }

    public void AnimationStart(bool NotFound)
    {
        this.gameObject.SetActive(true);
        t_DeckCountError.SetActive(false);
        t_InputRoomName.SetActive(false);
        t_InputPassword.SetActive(false);
        t_InputPlayerName.SetActive(false);
        t_NotFound.SetActive(NotFound);
        t_AlreadyRoomCreated.SetActive(false);

        this.BackGround.AddClipEndCallback(0, "RoomSelectAlert", () => this.gameObject.SetActive(false));

        this.BackGround.Play("RoomSelectAlert", 0, 0);
        this.NotFound.Play("RoomSelectAlertForText", 0, 0);
    }

    public void AnimationStart()
    {
        this.gameObject.SetActive(true);
        t_DeckCountError.SetActive(false);
        t_InputRoomName.SetActive(false);
        t_InputPassword.SetActive(false);
        t_InputPlayerName.SetActive(false);
        t_NotFound.SetActive(false);
        t_AlreadyRoomCreated.SetActive(true);

        this.BackGround.AddClipEndCallback(0, "RoomSelectAlert", () => this.gameObject.SetActive(false));

        this.BackGround.Play("RoomSelectAlert", 0, 0);
        this.AlreadyRoomCreated.Play("RoomSelectAlertForText", 0, 0);
    }
}
