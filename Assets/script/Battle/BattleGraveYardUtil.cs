using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleGraveYardUtil : MonoBehaviour
{
    private BattleModeCard m_BattleModeCard = null;
    [SerializeField] Image image;
    [SerializeField] BattleModeGuide m_BattleModeGuide;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
            m_BattleModeCard = list[0];
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
    }
}
