using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityForge.AnimCallbacks;

public class ShuffleDeckAnimationController : MonoBehaviour
{
    [SerializeField] Animator animator0;
    [SerializeField] GameManager m_GameManager;
    [SerializeField] BattleStrix m_BattleStrix;
    [SerializeField] GameObject DeckTop;
    [SerializeField] GameObject Animation;
    [SerializeField] GameObject DeckBottom;
    [SerializeField] GameObject Deck;
    [SerializeField] SEmanager m_SEmanager;

    private static string AnimationName = "ShuffleAnimationAnimator";
    private static int NormalAnimationLayerIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator0.AddClipCallback(NormalAnimationLayerIndex, AnimationName, 0.10f, () => SwitchDeckTop(false));
        animator0.AddClipCallback(NormalAnimationLayerIndex, AnimationName, 0.20f, () => SwitchDeckTop(true));
        animator0.AddClipCallback(NormalAnimationLayerIndex, AnimationName, 0.30f, () => SwitchDeckTop(false));
        animator0.AddClipCallback(NormalAnimationLayerIndex, AnimationName, 0.40f, () => SwitchDeckTop(true));
        animator0.AddClipCallback(NormalAnimationLayerIndex, AnimationName, 0.50f, () => SwitchDeckTop(false));
        animator0.AddClipCallback(NormalAnimationLayerIndex, AnimationName, 0.60f, () => SwitchDeckTop(true));
        animator0.AddClipCallback(NormalAnimationLayerIndex, AnimationName, 0.70f, () => SwitchDeckTop(false));
        animator0.AddClipCallback(NormalAnimationLayerIndex, AnimationName, 0.80f, () => SwitchDeckTop(true));
        animator0.AddClipCallback(NormalAnimationLayerIndex, AnimationName, 0.80f, () => AnimationEnd());
        AnimationEnd();
    }

    public void AnimationStart()
    {
        m_SEmanager.ShuffleSE_Play();
        Deck.SetActive(false);
        DeckBottom.SetActive(true);
        Animation.SetActive(true);
        SwitchDeckTop(true);
        animator0.speed = 1;
        animator0.Play(AnimationName, 0, 0);
    }

    private void AnimationEnd()
    {
        Deck.SetActive(true);
        DeckBottom.SetActive(false);
        SwitchDeckTop(false);
        Animation.SetActive(false);
    }

    private void SwitchDeckTop(bool b)
    {
        DeckTop.SetActive(b);
    }
}
