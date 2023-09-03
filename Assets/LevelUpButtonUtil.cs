using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpButtonUtil : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] Button button;
    [SerializeField] LevelUpDialog m_LevelUpDialog;
    [SerializeField] int num;

    private BattleModeCard m_BattleModeCard = null;
    private bool isSelected = false;

    public void SetBattleModeCard(BattleModeCard card, bool IsInteractable)
    {
        m_BattleModeCard = card;
        changeSprite(IsInteractable);
    }

    private void changeSprite(bool IsInteractable)
    {
        if (m_BattleModeCard == null)
        {
            this.gameObject.SetActive(false);
            return;
        }
        this.gameObject.SetActive(true);
        image.sprite = m_BattleModeCard.sprite;
        image.color = new Color(1, 1, 1, 255 / 255);
        button.interactable = IsInteractable;
    }

    private void changeSprite()
    {
        image.sprite = m_BattleModeCard.sprite;
        image.color = new Color(1, 1, 1, 255 / 255);
    }

    public void onClick()
    {
        if (isSelected)
        {
            isSelected = false;
            image.color = new Color(1, 1, 1, 255 / 255);
            m_LevelUpDialog.num = -1;
        }
        else
        {
            isSelected = true;
            image.color = new Color(145 / 255, 145 / 255, 145 / 255, 60 / 255);
            m_LevelUpDialog.num = num;
        }
        changeSprite();
    }

    public void OffSelected()
    {
        isSelected = false;
        image.color = new Color(1, 1, 1, 255 / 255);
    }

}
