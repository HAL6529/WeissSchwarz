using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchButtonUtil : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] Button button;
    [SerializeField] SearchDialog m_SearchDialog;
    [SerializeField] int num;

    public BattleModeCard m_BattleModeCard = null;
    public bool isSelected = false;

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
        if (m_BattleModeCard == null)
        {
            this.gameObject.SetActive(false);
            return;
        }
        this.gameObject.SetActive(true);
        image.sprite = m_BattleModeCard.sprite;
        image.color = new Color(1, 1, 1, 255 / 255);
    }

    public void onClick()
    {
        if (isSelected)
        {
            OffSelected();
        }
        else
        {
            isSelected = true;
            image.color = new Color(145f / 255f, 145f / 255f, 145f / 255f, 255 / 255);
        }
        m_SearchDialog.SwitchOKButton();
    }

    public void OffSelected()
    {
        isSelected = false;
        image.color = new Color(1, 1, 1, 255 / 255);
    }
}
