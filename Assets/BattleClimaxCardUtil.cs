using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleClimaxCardUtil : MonoBehaviour
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

    public void SetClimax(BattleModeCard climax)
    {
        if (climax == null)
        {
            image.color = new Color(1, 1, 1, 0 / 255);
            image.sprite = null;
            return;
        }
        image.color = new Color(1, 1, 1, 255 / 255);
        image.sprite = climax.sprite;
    }
}
