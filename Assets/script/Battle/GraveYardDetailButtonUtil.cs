using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraveYardDetailButtonUtil : MonoBehaviour
{
    [SerializeField] BattleModeGuide m_BattleModeGuide;
    [SerializeField] Image image;
    private BattleModeCard m_BattleModeCard = null;

    public void setBattleModeCard(BattleModeCard card)
    {
        m_BattleModeCard = card;
        changeSprite();
    }

    public void changeSprite()
    {
        if (m_BattleModeCard == null)
        {
            image.sprite = null;
            image.color = new Color(1, 1, 1, 0 / 255);
            return;
        }

        image.sprite = m_BattleModeCard.sprite;
        image.color = new Color(1, 1, 1, 255 / 255);
    }

    public void onClick()
    {
        m_BattleModeGuide.showImage(m_BattleModeCard);
    }
}
