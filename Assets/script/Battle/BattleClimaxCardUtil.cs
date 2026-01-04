using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleClimaxCardUtil : MonoBehaviour
{
    [SerializeField] BattleModeGuide m_BattleModeGuide;

    public Image image;
    private BattleModeCard m_BattleModeCard = null;

    public void SetClimax(BattleModeCard climax)
    {
        m_BattleModeCard = climax;

        if (climax == null)
        {
            image.color = new Color(1, 1, 1, 0 / 255);
            image.sprite = null;
            return;
        }

        image.color = new Color(1, 1, 1, 255 / 255);
        image.sprite = climax.GetSprite();
    }

    public void onClick()
    {
        if (m_BattleModeCard == null)
        {
            return;
        }
        m_BattleModeGuide.showImage(m_BattleModeCard);
    }
}
