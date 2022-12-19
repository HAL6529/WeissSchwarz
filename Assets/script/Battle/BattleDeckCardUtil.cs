using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleDeckCardUtil : MonoBehaviour
{
    public Sprite back;
    public Image image;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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
}
