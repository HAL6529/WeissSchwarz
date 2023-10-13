using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityForge.AnimCallbacks;

public class TriggerCardAnimationForEnemy : MonoBehaviour
{
    [SerializeField] Image m_Image;
    [SerializeField] GameManager m_GameManager;
    [SerializeField] Animator m_Animator;
    [SerializeField] BattleModeCardList m_BattleModeCardList;
    private BattleModeCard temp;

    // Start is called before the first frame update
    private void Start()
    {
        m_Animator.AddClipCallback(0, "TriggerCheck", 0.2f, () => GetDeckTopSprite());
        m_Animator.AddClipCallback(0, "TriggerCheck", 1.1f, () => AnimationEnd());
    }

    public void Play(BattleModeCardTemp card)
    {
        temp = m_BattleModeCardList.ConvertCardNoToBattleModeCard(card.cardNo);
        this.gameObject.SetActive(true);
        m_GameManager.isAnimation = true;
        m_Animator.Play("TriggerCheck", 0, 0.0f);
    }

    private void GetDeckTopSprite()
    {
        m_Image.sprite = temp.sprite;
    }

    private void AnimationEnd()
    {
        this.gameObject.SetActive(false);
        m_GameManager.isAnimation = false;
    }
}
