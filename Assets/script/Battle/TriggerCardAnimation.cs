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
    [SerializeField] Sprite back;
    private EnumController.Attack paramater;
    private int PlaceNum;
    private int enemyLevel;

    private void Start()
    {
        m_Animator.AddClipCallback(0, "TriggerCheck", 0.2f, () => GetDeckTopSprite());
        m_Animator.AddClipCallback(0, "TriggerCheck", 1.1f, () => AnimationEnd());
    }

    public void Play(EnumController.Attack paramater, int PlaceNum, int enemyLevel)
    {
        m_Image.sprite = back;
        this.paramater = paramater;
        this.PlaceNum = PlaceNum;
        this.enemyLevel = enemyLevel;
        this.gameObject.SetActive(true);
        m_GameManager.isTriggerAnimation = true;
        m_Animator.Play("TriggerCheck", 0, 0.0f);
    }

    private void GetDeckTopSprite()
    {
        m_Image.sprite = m_GameManager.myDeckList[0].sprite;
    }

    private void AnimationEnd()
    {
        this.gameObject.SetActive(false);
        m_GameManager.isTriggerAnimation = false;
        switch (paramater)
        {
            case EnumController.Attack.VOID:
            case EnumController.Attack.DIRECT_ATTACK:
                m_GameManager.onDirectAttack(PlaceNum);
                return;
            case EnumController.Attack.FRONT_ATTACK:
                m_GameManager.onFrontAttack(PlaceNum);
                return;
            case EnumController.Attack.SIDE_ATTACK:
                m_GameManager.onSideAttack(PlaceNum, enemyLevel);
                return;
        }
    }
}
