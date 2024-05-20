using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityForge.AnimCallbacks;

public class EventAnimationManager : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] BattleModeCardList m_BattleModeCardList;
    [SerializeField] DialogManager m_DialogManager;
    [SerializeField] GameManager m_GameManager;
    [SerializeField] Image m_image;
    [SerializeField] Image m_image2;
    [SerializeField] GameObject m_gameObject;

    private static string AnimationName = "EventAnimation";
    private static int NormalAnimationLayerIndex = 0;

    private BattleModeCard m_BattleModeCard = null;

    /// <summary>
    /// �C�x���g���Đ������v���C���[�p
    /// </summary>
    /// <param name="card"></param>
    public void AnimationStart(BattleModeCard card)
    {
        m_gameObject.SetActive(true);

        m_BattleModeCard = card;
        m_image.sprite = card.sprite;
        m_image2.sprite = card.sprite;
        animator.AddClipEndCallback(NormalAnimationLayerIndex, AnimationName, () => AnimationEnd());
        // �A�j���[�V�����Đ����Đ����邽�߂�speed��1�ɂ���
        animator.speed = 1;
        animator.Play(AnimationName, 0, 0);
    }

    private void AnimationEnd()
    {
        m_gameObject.SetActive(false);
        m_DialogManager.SearchDialog(m_GameManager.myDeckList, EnumController.SearchDialogParamater.Search, m_BattleModeCard);
    }

    /// <summary>
    /// �C�x���g��ł��ꂽ�v���C���[�p
    /// </summary>
    /// <param name="card"></param>
    public void AnimationStartForRPC(BattleModeCardTemp card)
    {
        BattleModeCard b = m_BattleModeCardList.ConvertCardNoToBattleModeCard(card.cardNo);

        m_gameObject.SetActive(true);

        m_BattleModeCard = b;
        m_image.sprite = b.sprite;
        m_image2.sprite = b.sprite;
        animator.AddClipEndCallback(NormalAnimationLayerIndex, AnimationName, () => AnimationEndForRPC());
        // �A�j���[�V�����Đ����Đ����邽�߂�speed��1�ɂ���
        animator.speed = 1;
        animator.Play(AnimationName, 0, 0);
    }

    private void AnimationEndForRPC()
    {
        m_gameObject.SetActive(false);
    }
}
