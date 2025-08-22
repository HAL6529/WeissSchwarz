using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraveyardSelectDialogBtnUtil : MonoBehaviour
{
    public Button button;
    [SerializeField] GraveyardSelectDialog m_GraveyardSelectDialog;
    [SerializeField] GameManager m_GameManager;
    [SerializeField] Image image;
    public BattleModeCard m_BattleModeCard;
    public bool isSelected = false;

    public void SetBattleModeCard(BattleModeCard m_BattleModeCard)
    {
        this.m_BattleModeCard = m_BattleModeCard;
        isSelected = false;
        changeSprite();
    }

    private void changeSprite()
    {
        if(m_BattleModeCard == null)
        {
            this.gameObject.SetActive(false);
            return;
        }
        image.sprite = m_BattleModeCard.sprite;
        this.gameObject.SetActive(true);
    }

    public void onClick()
    {
        if (isSelected)
        {
            isSelected = false;
            image.color = new Color(1, 1, 1, 1);
        }
        else
        {
            isSelected = true;
            image.color = new Color(145f / 255f, 145f / 255f, 145f / 255f, 255 / 255);
        }
        m_GraveyardSelectDialog.switchOKBtn();
    }
}
