using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleMemoryCardUtil : MonoBehaviour
{
    private bool isActiveShowMemoryBtn = false;
    private BattleModeCard m_BattleModeCard = null;

    [SerializeField] Image image;
    [SerializeField] BattleModeGuide m_BattleModeGuide;
    [SerializeField] GraveYardDetail m_GraveYardDetail;
    [SerializeField] GameManager m_GameManager;
    [SerializeField] GameObject ShowButton;
    [SerializeField] Text MemoryCount;

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

    public void updateMyMemoryCards(List<BattleModeCard> list)
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
        SetMemoryCount(list.Count);
    }

    public void onClick()
    {
        if (m_BattleModeCard == null)
        {
            return;
        }
        m_BattleModeGuide.showImage(m_BattleModeCard);

        if (isActiveShowMemoryBtn)
        {
            isActiveShowMemoryBtn = false;
            ShowButton.SetActive(false);
        }
        else
        {
            isActiveShowMemoryBtn = true;
            ShowButton.SetActive(true);
        }
    }

    // Ç±Ç±Ç©ÇÁçTé∫è⁄ç◊ï\é¶É{É^Éì
    public void onClickShowMyMemoryButton()
    {
        m_GraveYardDetail.UpdateList(m_GameManager.myMemoryList);
    }

    private void SetMemoryCount(int num)
    {
        MemoryCount.text = num.ToString();
    }
}
