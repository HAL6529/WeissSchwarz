using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityForge.AnimCallbacks;

public class BattleDeckCardUtil : MonoBehaviour
{
    public Sprite back;
    public Image image;

    [SerializeField] Animator animator;
    [SerializeField] GameObject Deck;
    [SerializeField] GameObject DummyDeck;
    [SerializeField] SEmanager m_SEmanager;
    [SerializeField] Text DeckCount;

    private static string AnimationName = "ShuffleAnimation";
    private static int NormalAnimationLayerIndex = 0;

    bool firstFlg = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChangeFrontAndBack(bool isFront)
    {
        if (isFront)
        {

        }
        else
        {
            image.sprite = back;
        }
    }

    public void SetDeckCount(int num)
    {
        DeckCount.text = num.ToString();
    }

    public void AnimationStart()
    {
        m_SEmanager.ShuffleSE_Play();
        Deck.SetActive(false);
        DummyDeck.SetActive(true);
        if (!firstFlg)
        {
            animator.speed = 2;
            animator.AddClipCallback(0, AnimationName, 1.19f, () => AnimationEnd());
            firstFlg = true;
        }
    }
    public void AnimationEnd()
    {
        Debug.Log("AnimationEnd");
        Deck.SetActive(true);
        DummyDeck.SetActive(false);
    }
}
