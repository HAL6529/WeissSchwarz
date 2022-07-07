using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchFilter : MonoBehaviour
{
    public bool isLevelZero;
    public bool isLevelOne;
    public bool isLevelTwo;
    public bool isLevelThree;

    public bool isColorRed;
    public bool isColorBlue;
    public bool isColorGreen;
    public bool isColorYellow;
    public bool isColorPurple;

    public bool isTypeCharacter;
    public bool isTypeEvent;
    public bool isTypeClimax;

    SearchFilter()
    {
        isLevelZero = true;
        isLevelOne = true;
        isLevelTwo = true;
        isLevelThree = true;
        isColorRed = true;
        isColorBlue = true;
        isColorGreen = true;
        isColorYellow = true;
        isColorPurple = true;
        isTypeCharacter = true;
        isTypeEvent = true;
        isTypeClimax = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onLevelFilterChanged(int index)
    {
        if(index > 3)
        {
            return;
        }
        switch (index)
        {
            case 0:
                if (isLevelZero)
                {
                    isLevelZero = false;
                }
                else
                {
                    isLevelZero = true;
                }
                break;
            case 1:
                if (isLevelOne)
                {
                    isLevelOne = false;
                }
                else
                {
                    isLevelOne = true;
                }
                break;
            case 2:
                if (isLevelTwo)
                {
                    isLevelTwo = false;
                }
                else
                {
                    isLevelTwo = true;
                }
                break;
            case 3:
                if (isLevelThree)
                {
                    isLevelThree = false;
                }
                else
                {
                    isLevelThree = true;
                }
                break;
            default:
                break;
        }
    }

    public void onColorFilterChanged(int index)
    {
        if (index > 4)
        {
            return;
        }
        switch (index)
        {
            case 0:
                if (isColorRed)
                {
                    isColorRed = false;
                }
                else
                {
                    isColorRed = true;
                }
                break;
            case 1:
                if (isColorBlue)
                {
                    isColorBlue = false;
                }
                else
                {
                    isColorBlue = true;
                }
                break;
            case 2:
                if (isColorGreen)
                {
                    isColorGreen = false;
                }
                else
                {
                    isColorGreen = true;
                }
                break;
            case 3:
                if (isColorYellow)
                {
                    isColorYellow = false;
                }
                else
                {
                    isColorYellow = true;
                }
                break;
            case 4:
                if (isColorPurple)
                {
                    isColorPurple = false;
                }
                else
                {
                    isColorPurple = true;
                }
                break;
            default:
                break;
        }
    }

    public void onTypeFilterChanged(int index)
    {
        if (index > 2)
        {
            return;
        }
        switch (index)
        {
            case 0:
                if (isTypeCharacter)
                {
                    isTypeCharacter = false;
                }
                else
                {
                    isTypeCharacter = true;
                }
                break;
            case 1:
                if (isTypeEvent)
                {
                    isTypeEvent = false;
                }
                else
                {
                    isTypeEvent = true;
                }
                break;
            case 2:
                if (isTypeClimax)
                {
                    isTypeClimax = false;
                }
                else
                {
                    isTypeClimax = true;
                }
                break;
            default:
                break;
        }
    }
}
