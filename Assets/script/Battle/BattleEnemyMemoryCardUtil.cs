using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleEnemyMemoryCardUtil : MonoBehaviour
{
    private bool isActiveShowMemoryBtn = false;
    private BattleModeCard m_BattleModeCard = null;

    [SerializeField] Image image;
    [SerializeField] BattleModeGuide m_BattleModeGuide;
    [SerializeField] GraveYardDetail m_GraveYardDetail;
    [SerializeField] BattleGraveYardUtil my_BattleGraveYardUtil;
    [SerializeField] BattleGraveYardUtil enemy_BattleGraveYardUtil;
    [SerializeField] GameManager m_GameManager;
    [SerializeField] GameObject ShowButton;
    [SerializeField] Text MemoryCount;
    [SerializeField] MyHandCardsManager m_MyHandCardsManager;
    [SerializeField] MyMainCardsManager m_MyMainCardsManager;

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

    public void updateEnemyMemoryCards(List<BattleModeCard> list)
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
        // 手札のプレイボタンを非表示にする
        m_MyHandCardsManager.CallNotShowPlayButton();
        // フィールドのムーヴボタンを非表示にする
        m_MyMainCardsManager.CallNotShowMoveButton();
        // 控室詳細ボタンを非表示にする
        my_BattleGraveYardUtil.OffBtn();
        enemy_BattleGraveYardUtil.OffBtn();

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

    public void onClickShowEnemyMemoryButton()
    {
        m_GraveYardDetail.UpdateList(m_GameManager.enemyMemoryList);
    }

    private void SetMemoryCount(int num)
    {
        MemoryCount.text = num.ToString();
    }

    public void OffBtn()
    {
        isActiveShowMemoryBtn = false;
        ShowButton.SetActive(false);
    }
}
