using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    [SerializeField] DeckListManager m_DeckListManager;

    [SerializeField] AudioClip BtnSE;

    public void TransitionToMenu()
    {
        GetComponent<AudioSource>().PlayOneShot(BtnSE);
        SaveData.cardInfoList = m_DeckListManager.cardInfoList;
        SceneManager.LoadScene("RoomSelect");
    }
}
