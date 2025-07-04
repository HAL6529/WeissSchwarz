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

    int shuffleCnt = 0;

    private static int NormalAnimationLayerIndex = 0;

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
}
