using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleDeckCardUtil : MonoBehaviour
{
    public Sprite back;
    public Image image;

    [SerializeField] Text DeckCount;

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
