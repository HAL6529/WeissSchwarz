using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCardUtil : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] BattleModeGuide m_BattleModeGuide;

    private BattleModeCard m_BattleModeCard = null;

    public void SetBattleModeCard(BattleModeCard card)
    {
        m_BattleModeCard = card;
        changeSprite();
    }

    private void changeSprite()
    {
        if (m_BattleModeCard == null)
        {
            image.sprite = null;
            this.gameObject.SetActive(false);
            return;
        }
        image.sprite = m_BattleModeCard.GetSprite();
        this.gameObject.SetActive(true);
    }
}
