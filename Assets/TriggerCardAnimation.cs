using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerCardAnimation : MonoBehaviour
{
    [SerializeField] Image m_Image;
    [SerializeField] GameManager m_GameManager;
    [SerializeField] Animator m_Animator;

    public void Play()
    {
        Debug.Log("Play");
        this.gameObject.SetActive(true);
        m_GameManager.isAnimation = true;
        m_Animator.Play("TriggerCheck", 0, 0.0f);
    }

    public void GetDeckTopSprite()
    {
        m_Image.sprite = m_GameManager.myDeckList[0].sprite;
    }
}
