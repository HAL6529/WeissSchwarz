using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleGraveYardUtil : MonoBehaviour
{
    private bool isActiveShowGraveYardBtn = false;
    private BattleModeCard m_BattleModeCard = null;
    [SerializeField] Image image;
    [SerializeField] BattleModeGuide m_BattleModeGuide;
    [SerializeField] GraveYardDetail m_GraveYardDetail;
    [SerializeField] GameManager m_GameManager;
    [SerializeField] GameObject ShowButton;


    public void setBattleModeCard(BattleModeCard card)
    {
        m_BattleModeCard = card;
        changeSprite();
    }

    private void changeSprite()
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

    public void updateMyGraveYardCards(List<BattleModeCard> list)
    {
        if (list.Count == 0)
        {
            m_BattleModeCard = null;
        }
        else
        {
            m_BattleModeCard = list[list.Count - 1];
        }
        changeSprite();
    }

    public void onClick()
    {
        if(m_BattleModeCard == null)
        {
            return;
        }
        m_BattleModeGuide.showImage(m_BattleModeCard);

        if (isActiveShowGraveYardBtn)
        {
            isActiveShowGraveYardBtn = false;
            ShowButton.SetActive(false);
        }
        else
        {
            isActiveShowGraveYardBtn = true;
            ShowButton.SetActive(true);
        }
    }

    // Ç±Ç±Ç©ÇÁçTé∫è⁄ç◊ï\é¶É{É^Éì
    public void onClickShowMyGraveYardButton()
    {
        m_GraveYardDetail.UpdateList(m_GameManager.GraveYardList);
    }

    public void onClickShowEnemyGraveYardButton()
    {
        m_GraveYardDetail.UpdateList(m_GameManager.enemyGraveYardList);
    }
}
