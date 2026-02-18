using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmSearchOrSulvageCardDialogsBtnUtil : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] BattleModeGuide m_BattleModeGuide;

    private BattleModeCard m_BattleModeCard;

    public void SetBattleModeCard(BattleModeCard card)
    {
        image.sprite = null;
        m_BattleModeCard = null;
        this.gameObject.SetActive(false);

        if (card == null)
        {
            return;
        }
        image.sprite = card.GetSprite();
        m_BattleModeCard = card;
        this.gameObject.SetActive(true);
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
