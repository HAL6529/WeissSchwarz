using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SulvageDialogBtnUtil : MonoBehaviour
{
    [SerializeField] BattleModeGuide m_BattleModeGuide;
    [SerializeField] Image image;
    [SerializeField] SulvageDialog m_SulvageDialog;
    private BattleModeCard m_BattleModeCard = null;
    private bool isSelected = false;

    public void setBattleModeCard(BattleModeCard card)
    {
        isSelected = false;
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

        image.sprite = m_BattleModeCard.GetSprite();
        image.color = new Color(1, 1, 1, 255 / 255);
    }

    public void onClick()
    {
        if (m_BattleModeCard == null)
        {
            return;
        }
        if (isSelected)
        {
            image.color = new Color(1, 1, 1, 255 / 255);
            m_SulvageDialog.RemoveBattleModeCard(m_BattleModeCard);
            isSelected = false;
        }
        else
        {
            image.color = new Color(1, 1, 1, 100f / 255f);
            m_SulvageDialog.AddBattleModeCard(m_BattleModeCard);
            isSelected = true;
        }
        m_BattleModeGuide.showImage(m_BattleModeCard);
    }
}
