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
    [SerializeField] GameObject t_DeckCountError;
    [SerializeField] GameObject t_InputRoomName;
    [SerializeField] GameObject t_InputPassword;
    [SerializeField] GameObject t_InputPlayerName;

    public void AnimationStart(bool DeckCountError, bool InputRoomName, bool InputPassword, bool InputPlayerName)
    {
        this.gameObject.SetActive(true);
        t_DeckCountError.SetActive(DeckCountError);
        t_InputRoomName.SetActive(InputRoomName);
        t_InputPassword.SetActive(InputPassword);
        t_InputPlayerName.SetActive(InputPlayerName);

        this.BackGround.AddClipEndCallback(0, "RoomSelectAlert", () => this.gameObject.SetActive(false));

        this.BackGround.Play("RoomSelectAlert", 0, 0);
        this.DeckCountError.Play("RoomSelectAlertForText", 0, 0);
        this.InputRoomName.Play("RoomSelectAlertForText", 0, 0);
        this.InputPassword.Play("RoomSelectAlertForText", 0, 0);
        this.InputPlayerName.Play("RoomSelectAlertForText", 0, 0);
    }
}
