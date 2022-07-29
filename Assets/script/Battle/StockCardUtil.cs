using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StockCardUtil : MonoBehaviour
{
    public BattleCardInfo m_battleCardInfo;
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

    public void updateSprite()
    {
        if (m_battleCardInfo == null || m_battleCardInfo.sprite == null)
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

        image.sprite = m_battleCardInfo.sprite;
        this.gameObject.SetActive(true);
    }
}
