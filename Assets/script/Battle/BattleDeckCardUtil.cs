using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityForge.AnimCallbacks;

public class BattleDeckCardUtil : MonoBehaviour
{
    public Sprite back;
    public Image image;

    [SerializeField] Text DeckCount;
    [SerializeField] Animator animator1;
    [SerializeField] Animator animator2;
    [SerializeField] GameObject Animation1Obj;
    [SerializeField] GameObject Animation2Obj;

    private static string AnimationName1 = "ShuffleAnimation1";
    private static string AnimationName2 = "ShuffleAnimation2";
    private static int ShuffleCount = 5;

    int shuffleCnt = 0;

    private static int NormalAnimationLayerIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        /*animator1.AddClipEndCallback(NormalAnimationLayerIndex, AnimationName1, () => Animation1End());
        animator2.AddClipEndCallback(NormalAnimationLayerIndex, AnimationName2, () => Animation2End());*/
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

    public void ShuffleAnimation()
    {
        Animation2Obj.SetActive(true);
        shuffleCnt = 0;
        animator1.speed = 1;
        animator2.speed = 1;
        animator2.Play(AnimationName2, 0, 0);
    }

    private void Animation1End()
    {
        shuffleCnt++;
        if(shuffleCnt < ShuffleCount)
        {
            animator2.Play(AnimationName2, 0, 0);
        }
        Animation1Obj.SetActive(false);
    }

    private void Animation2End()
    {
        animator1.Play(AnimationName1, 0, 0);
        Animation2Obj.SetActive(false);

    }
}
