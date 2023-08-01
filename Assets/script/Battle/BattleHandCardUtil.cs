using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EnumController;

public class BattleHandCardUtil : MonoBehaviour
{
    private BattleModeCard m_BattleModeCard = null;

    public bool isSelected = false;

    private bool isMainSelected = false;
    [SerializeField] GameManager m_GameManager;
    [SerializeField] Image image;
    [SerializeField] BattleModeGuide m_BattleModeGuide;
    [SerializeField] ClockDialog m_ClockDialog;
    [SerializeField] MyHandCardsManager m_MyHandCardsManager;
    [SerializeField] MyMainCardsManager m_MyMainCardsManager;
    [SerializeField] GameObject PlayButton;
    [SerializeField] GameObject DummyHandCard;
    [SerializeField] MainDialog m_MainDialog;
    [SerializeField] DialogManager m_DialogManager;
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
            image.color = new Color(1, 1, 1, 0 / 255);
            return;
        }
        image.sprite = m_BattleModeCard.sprite;
        image.color = new Color(1, 1, 1, 255 / 255);
    }

    public void onClick()
    {
        if (m_GameManager.isAnimation)
        {
            return;
        }
        m_MyMainCardsManager.CallNotShowMoveButton();
        m_BattleModeGuide.showImage(m_BattleModeCard);
        // m_DialogManager.CloseAllDialog();
        if (m_GameManager.MariganMode && m_GameManager.phase == EnumController.Turn.VOID)
        {
            MariganClick();
            return;
        }

        if (m_GameManager.phase == EnumController.Turn.Player1_Clock)
        {
            ClockClick();
            return;
        }

        if (m_GameManager.phase == EnumController.Turn.Player1_Main)
        {
            MainClick();
            return;
        }
    }

    public void ResetSelected()
    {
        isSelected = false;
        image.color = new Color(1, 1, 1, 255 / 255);
    }

    public void NotShowPlayButton()
    {
        isMainSelected = false;
        PlayButton.SetActive(false);
    }

    private void MariganClick()
    {
        if (isSelected)
        {
            m_GameManager.myMariganList.Remove(m_BattleModeCard);
            isSelected = false;
            image.color = new Color(1, 1, 1, 255 / 255);
        }
        else
        {
            m_GameManager.myMariganList.Add(m_BattleModeCard);
            isSelected = true;
            image.color = new Color(1, 1, 1, 125f / 255f);
        }
    }

    private void ClockClick()
    {
        if (isSelected)
        {
            isSelected = false;
            image.color = new Color(1, 1, 1, 255 / 255);
            m_ClockDialog.setBattleModeCard(null);
        }
        else
        {
            m_MyHandCardsManager.CallResetSelected();
            isSelected = true;
            image.color = new Color(1, 1, 1, 125f / 255f);
            m_ClockDialog.setBattleModeCard(m_BattleModeCard);
        }
    }

    private void MainClick()
    {
        bool temp = isMainSelected;
        m_MainDialog.OffMainDialog();
        m_MyHandCardsManager.CallNotShowPlayButton();
        if (temp)
        {
            isMainSelected = false;
        }
        else
        {
            PlayButton.SetActive(true);
            isMainSelected = true;
        }
    }

    public void onPlayButton()
    {
        m_MainDialog.SetBattleMordCard(m_BattleModeCard);
    }

    // rightCardがクリックされたとき
    public void onRightCardClick()
    {
        if (m_GameManager.isAnimation)
        {
            return;
        }
        m_MyHandCardsManager.cursorNum++;
        m_GameManager.UpdateMyHandCards();
    }

    // leftCardがクリックされたとき
    public void onLeftCardClick()
    {
        if (m_GameManager.isAnimation)
        {
            return;
        }
        m_MyHandCardsManager.cursorNum--;
        m_GameManager.UpdateMyHandCards();
    }
}
