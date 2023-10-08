using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityForge.AnimCallbacks;

public class TriggerCardAnimation : MonoBehaviour
{
    [SerializeField] Image m_Image;
    [SerializeField] GameManager m_GameManager;
    [SerializeField] Animator m_Animator;

    private void Start()
    {
        m_Animator.AddClipCallback(0, "TriggerCheck", 0.2f, () => GetDeckTopSprite());
        m_Animator.AddClipCallback(0, "TriggerCheck", 1.1f, () => AnimationEnd());
    }

    public void Play()
    {
        Debug.Log("Play");
        this.gameObject.SetActive(true);
        m_GameManager.isAnimation = true;
        m_Animator.Play("TriggerCheck", 0, 0.0f);
    }

    private void GetDeckTopSprite()
    {
        Debug.Log("GetDeckTopSprite");
        m_Image.sprite = m_GameManager.myDeckList[0].sprite;
    }

    private void AnimationEnd()
    {
        Debug.Log("AnimationEnd");
        this.gameObject.SetActive(false);
        m_GameManager.isAnimation = false;
    }
}
