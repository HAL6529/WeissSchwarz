using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinAndLose : MonoBehaviour
{
    [SerializeField] Text text;

    public void Win()
    {
        this.gameObject.SetActive(true);
        text.text = "Win";
    }

    public void Lose()
    {
        this.gameObject.SetActive(true);
        text.text = "Lose";
    }
}
