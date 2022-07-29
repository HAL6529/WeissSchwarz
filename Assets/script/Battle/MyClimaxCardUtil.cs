using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyClimaxCardUtil : MonoBehaviour
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
            this.gameObject.SetActive(false);
            return;
        }

        if (m_battleCardInfo.isBack)
        {
            image.sprite = backImage;
            this.gameObject.SetActive(true);
            return;
        }

        Sprite sprite = m_battleCardInfo.sprite;
        if (sprite != null)
        {
            image.sprite = sprite;
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
