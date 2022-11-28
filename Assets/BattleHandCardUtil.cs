using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHandCardUtil : MonoBehaviour
{
    private BattleModeCard m_BattleModeCard = null;

    public bool isSelected = false;
    [SerializeField] GameManager m_GameManager;
    [SerializeField] Image image;
    [SerializeField] BattleModeGuide m_BattleModeGuide;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setBattleModeCard(BattleModeCard card)
    {
        m_BattleModeCard = card;
        changeSprite();
    }

    private void changeSprite()
    {
        image.sprite = m_BattleModeCard.sprite;
        if (m_BattleModeCard == null)
        {
            image.color = new Color(1, 1, 1, 0 / 255);
            return;
        }
        image.color = new Color(1, 1, 1, 255 / 255);
    }

    public void onClick()
    {
        m_BattleModeGuide.showImage(m_BattleModeCard);

        if (m_GameManager.MariganMode)
        {
            MariganClick();
        }

        /*if (isSelected)
        {
            isSelected = false;
            image.color = new Color(1, 1, 1, 255 / 255);
        }
        else
        {
            isSelected = true;
            image.color = new Color(1, 1, 1, 168f / 255f);
        }*/
    }

    private void MariganClick()
    {
        if (isSelected)
        {
            m_GameManager.myMariganList.Remove(m_BattleModeCard);
            isSelected = false;
            image.color = new Color(1, 1, 1, 255 / 255);
        }
        else
        {
            m_GameManager.myMariganList.Add(m_BattleModeCard);
            isSelected = true;
            image.color = new Color(1, 1, 1, 125f / 255f);
        }
    }
}
