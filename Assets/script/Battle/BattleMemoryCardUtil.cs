using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleMemoryCardUtil : MonoBehaviour
{
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMemory(BattleModeCard memory)
    {
        if(memory == memory)
        {
            image.color = new Color(1, 1, 1, 0 / 255);
            image.sprite = null;
            return;
        }
        image.color = new Color(1, 1, 1, 255 / 255);
        image.sprite = memory.sprite;
    }
}
