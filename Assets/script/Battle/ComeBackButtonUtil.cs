using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComeBackButtonUtil : MonoBehaviour
{
    [SerializeField] BattleModeGuide m_BattleModeGuide;
    [SerializeField] ComeBackDetail m_ComeBackDetail;
    [SerializeField] Image image;
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
            m_ComeBackDetail.ResetComeBackButtonUtilsIsSelected();
            image.color = new Color(1, 1, 1, 255 / 255);
            m_ComeBackDetail.Setm_BattleModeCard(null);
            isSelected = false;
        }
        else
        {
            m_ComeBackDetail.ResetComeBackButtonUtilsIsSelected();
            image.color = new Color(1, 1, 1, 100f / 255f);
            m_ComeBackDetail.Setm_BattleModeCard(m_BattleModeCard);
            isSelected = true;
        }
        m_BattleModeGuide.showImage(m_BattleModeCard);
    }

    public void FalseIsSelected()
    {
        isSelected = false;
        changeSprite();
    }
}
