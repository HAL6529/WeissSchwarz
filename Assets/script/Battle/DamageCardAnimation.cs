using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityForge.AnimCallbacks;

public class DamageCardAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Image m_image;
    [SerializeField] Sprite backImage;
    [SerializeField] GameObject gameObject;
    [SerializeField] DamageAnimationDialog m_DamageAnimationDialog;

    private static float delay = 0.5f;
    private static int NormalAnimationLayerIndex = 0;
    private static string AnimationName = "DamageAnimation";
    private bool isEnd = false;

    public void AnimationStart(int num, BattleModeCard card, bool isEnd)
    {
        // アニメーション再生を停止するためにspeedを0にする
        animator.speed = 0;
        gameObject.SetActive(true);
        m_image.sprite = backImage;
        this.isEnd = isEnd;
        animator.AddClipCallback(NormalAnimationLayerIndex, AnimationName, 0.25f, () => { m_image.sprite = card.sprite; });
        animator.AddClipEndCallback(NormalAnimationLayerIndex, AnimationName, () => AnimationEnd());
        Invoke("Animation", delay * num);
    }

    private void Animation()
    {
        // アニメーション再生を再生するためにspeedを1にする
        animator.speed = 1;
        animator.Play("DamageAnimation", 0, 0);
    }

    private void AnimationEnd()
    {
        if (isEnd)
        {
            m_DamageAnimationDialog.OffDialog();
            m_DamageAnimationDialog.NextAction();
        }

    }

    public void NotAnimation()
    {
        this.isEnd = false;
        gameObject.SetActive(false);
    }
}
