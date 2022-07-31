using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDeckListUtil : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] Sprite backImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateSprite(BattleCardInfo m_battleCardInfo)
    {
        if (m_battleCardInfo == null)
        {
            image.sprite = null;
            image.color = new Color(255 / 255, 255 / 255, 255 / 255, 0 / 255);
            return;
        }

        Sprite sprite = m_battleCardInfo.sprite;
        if (sprite != null)
        {
            image.sprite = sprite;
            image.color = new Color(255 / 255, 255 / 255, 255 / 255, 255 / 255);
        }
        else
        {
            image.sprite = null;
            image.color = new Color(255 / 255, 255 / 255, 255 / 255, 0 / 255);
        }
    }
}
