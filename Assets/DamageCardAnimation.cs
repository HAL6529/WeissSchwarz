using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityForge.AnimCallbacks;

public class DamageCardAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] Image m_image;
    [SerializeField] GameObject gameObject;
    [SerializeField] DamageAnimationDialog m_DamageAnimationDialog;

    private static float delay = 0.5f;
    private static int NormalAnimationLayerIndex = 0;
    private static string AnimationName = "DamageAnimation";

    public void AnimationStart(int num, BattleModeCard card, bool isEnd)
    {
        gameObject.SetActive(true);
        if (isEnd)
        {
            animator.AddClipEndCallback(NormalAnimationLayerIndex, AnimationName, () => AnimationEnd());
        }
        m_image.sprite = card.sprite;
        Invoke("Animation", delay * num);
    }

    private void Animation()
    {  
        animator.Play("DamageAnimation", 0, 0);
    }

    private void AnimationEnd()
    {
        m_DamageAnimationDialog.OffDialog();
    }

    public void NotAnimation()
    {
        gameObject.SetActive(false);
    }
}
