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
    [SerializeField] MyHandCardsManager m_MyHandCardsManager;
    [SerializeField] MyMainCardsManager m_MyMainCardsManager;
    [SerializeField] GameObject PlayButton;
    [SerializeField] GameObject DummyHandCard;
    [SerializeField] DialogManager m_DialogManager;

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

        if (m_GameManager.isLevelUpProcess)
        {
            return;
        }

        if(m_GameManager.isHandOver && m_GameManager.phase == EnumController.Turn.Encore)
        {
            HandOverClick();
            return;
        }

        if (m_GameManager.MariganMode && m_GameManager.phase == EnumController.Turn.VOID)
        {
            MariganClick();
            return;
        }

        if (m_GameManager.phase == EnumController.Turn.Clock && m_GameManager.isTurnPlayer)
        {
            ClockClick();
            return;
        }

        if (m_GameManager.phase == EnumController.Turn.Main && m_GameManager.isTurnPlayer)
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

    private void HandOverClick()
    {
        if (isSelected)
        {
            m_GameManager.HandOverList.Remove(m_BattleModeCard);
            isSelected = false;
            image.color = new Color(1, 1, 1, 255 / 255);
        }
        else
        {
            m_GameManager.HandOverList.Add(m_BattleModeCard);
            isSelected = true;
            image.color = new Color(1, 1, 1, 125f / 255f);
        }
        m_DialogManager.HandOverDialog(EnumController.HandOverDialogParamater.Confirm);
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
            m_DialogManager.OKDialog(null);
        }
        else
        {
            m_MyHandCardsManager.CallResetSelected();
            isSelected = true;
            image.color = new Color(1, 1, 1, 125f / 255f);
            m_DialogManager.OKDialog(m_BattleModeCard);
        }
    }

    private void MainClick()
    {
        bool temp = isMainSelected;
        m_DialogManager.CloseAllDialog();
        m_MyHandCardsManager.CallNotShowPlayButton();

        if(m_GameManager.PlayerLevel < m_BattleModeCard.level)
        {
            return;
        }

        //色条件がクリアできているかチェック
        if(m_BattleModeCard.level > 0 && !m_GameManager.ColorCheck(m_BattleModeCard.color) && m_BattleModeCard.type == EnumController.Type.CHARACTER)
        {
            return;
        }
        if(!m_GameManager.ColorCheck(m_BattleModeCard.color) && m_BattleModeCard.type != EnumController.Type.CHARACTER)
        {
            return;
        }

        // コストが支払えるかチェック
        if(m_BattleModeCard.cost > m_GameManager.myStockList.Count && m_BattleModeCard.type != EnumController.Type.CLIMAX)
        {
            return;
        }


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
        switch (m_BattleModeCard.type)
        {
            case EnumController.Type.CHARACTER:
                m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_HAND_TO_FIELD, m_BattleModeCard);
                return;
            case EnumController.Type.EVENT:
                if (ConfirmStockForCost(1))
                {
                    m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.EVENT_CONFIRM, m_BattleModeCard);
                }
                return;
            case EnumController.Type.CLIMAX:
                m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.CLIMAX_PHASE, m_BattleModeCard);
                return;
            case EnumController.Type.VOID:
                return;
            default: return;
        }
    }

    // rightCardがクリックされたとき
    public void onRightCardClick()
    {
        if (m_GameManager.isAnimation)
        {
            return;
        }
        m_MyHandCardsManager.cursorNum++;
        m_GameManager.Syncronize();
    }

    // leftCardがクリックされたとき
    public void onLeftCardClick()
    {
        if (m_GameManager.isAnimation)
        {
            return;
        }
        m_MyHandCardsManager.cursorNum--;
        m_GameManager.Syncronize();
    }

    private bool ConfirmStockForCost(int num)
    {
        if (m_GameManager.myStockList.Count >= num)
        {
            return true;
        }
        return false;
    }
}
