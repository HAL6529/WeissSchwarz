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
    [SerializeField] Text GraveYardCount;
    [SerializeField] MyHandCardsManager m_MyHandCardsManager;
    [SerializeField] PhaseDialog m_PhaseDialog;
    public BattleGraveYardUtil m_BattleGraveYardUtil;

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
        SetGraveYardCount(list.Count);
    }

    public void onClick()
    {
        if(m_BattleModeCard == null)
        {
            return;
        }
        m_BattleModeGuide.showImage(m_BattleModeCard);

        // �����t�B�[���h�̃f�b�L�̍T���ڍ׃{�^�����������ꍇ�͑���t�B�[���h�̍T���ڍ׃{�^�����\���ɂ���
        // ����t�B�[���h�̃f�b�L�̍T���ڍ׃{�^�����������ꍇ�͎����t�B�[���h�̍T���ڍ׃{�^�����\���ɂ���
        m_BattleGraveYardUtil.OffBtn();
        // �t�F�[�Y�_�C�A���O���\���ɂ���
        m_PhaseDialog.onCloseButton();
        // ��D�̃v���C�{�^�����\���ɂ���
        m_MyHandCardsManager.CallNotShowPlayButton();
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

    // ��������T���ڍו\���{�^��
    public void onClickShowMyGraveYardButton()
    {
        m_GraveYardDetail.UpdateList(m_GameManager.GraveYardList);
        isActiveShowGraveYardBtn = false;
        ShowButton.SetActive(false);
    }

    public void onClickShowEnemyGraveYardButton()
    {
        m_GraveYardDetail.UpdateList(m_GameManager.enemyGraveYardList);
        isActiveShowGraveYardBtn = false;
        ShowButton.SetActive(false);
    }

    private void SetGraveYardCount(int num)
    {
        GraveYardCount.text = num.ToString();
    }

    public void OffBtn()
    {
        isActiveShowGraveYardBtn = false;
        ShowButton.SetActive(false);
    }
}
