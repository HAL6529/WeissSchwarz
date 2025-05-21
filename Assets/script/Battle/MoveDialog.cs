using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveDialog : MonoBehaviour
{
    [SerializeField] List<GameObject> buttons = new List<GameObject>();
    [SerializeField] List<Image> images = new List<Image>();
    [SerializeField] GameManager m_GameManager;
    [SerializeField] MyHandCardsManager m_MyHandCardsManager;
    [SerializeField] MyMainCardsManager m_MyMainCardsManager;
    [SerializeField] BattleStrix m_BattleStrix;
    [SerializeField] GameObject OKButton;

    private List<bool> isSelected = new List<bool> { false, false, false, false, false };
    /// <summary>
    /// MoveDialog���ŉ����ꂽ�J�[�h�̈ʒu
    /// </summary>
    private int place = -1;

    /// <summary>
    /// �ړ�������J�[�h�̏��
    /// </summary>
    private BattleModeCard m_BattleModeCard = null;

    /// <summary>
    /// �X�e�[�W�ŉ����ꂽ�J�[�h�̏ꏊ
    /// </summary>
    private int selectedPlace = -1;

    public void Open(int num, BattleModeCard m_BattleModeCard)
    {
        selectedPlace = num;
        ResetSelectZone();
        this.m_BattleModeCard = m_BattleModeCard;
        this.gameObject.SetActive(true);
    }

    public void onOkClick()
    {
        if (place == -1)
        {
            return;
        }

        if (m_BattleModeCard != null)
        {
            BattleModeCard temp = m_GameManager.myFieldList[place];
            m_GameManager.myFieldList[place] = m_BattleModeCard;
            m_GameManager.myFieldList[selectedPlace] = temp;

            EnumController.State placeStatus = m_MyMainCardsManager.GetState(place);
            EnumController.State selectedPlaceStatus = m_MyMainCardsManager.GetState(selectedPlace);

            m_MyMainCardsManager.setBattleModeCard(place, m_BattleModeCard, selectedPlaceStatus);
            m_MyMainCardsManager.setBattleModeCard(selectedPlace, temp, placeStatus);

            PowerInstance.PowerUpUntilTurnEnd t_PowerUpUntilTurnEnd = m_MyMainCardsManager.GetPowerUpUntilTurnEnd(selectedPlace);
            m_MyMainCardsManager.SetPowerUpUntilTurnEnd(selectedPlace, m_MyMainCardsManager.GetPowerUpUntilTurnEnd(place));
            m_MyMainCardsManager.SetPowerUpUntilTurnEnd(place, t_PowerUpUntilTurnEnd);

            AttributeInstance.AttributeUpUntilTurnEnd t_AttributeUpUntilTurnEnd = m_MyMainCardsManager.GetAttributeUpUntilTurnEnd(selectedPlace);
            m_MyMainCardsManager.SetAttributeUpUntilTurnEnd(selectedPlace, m_MyMainCardsManager.GetAttributeUpUntilTurnEnd(place));
            m_MyMainCardsManager.SetAttributeUpUntilTurnEnd(place, t_AttributeUpUntilTurnEnd);

            SoulInstance.SoulUpUntilTurnEnd t_SoulUpUntilTurnEnd = m_MyMainCardsManager.GetSoulUpUntilTurnEnd(selectedPlace);
            m_MyMainCardsManager.SetSoulUpUntilTurnEnd(selectedPlace, m_MyMainCardsManager.GetSoulUpUntilTurnEnd(place));
            m_MyMainCardsManager.SetSoulUpUntilTurnEnd(place, t_SoulUpUntilTurnEnd);

            m_GameManager.Syncronize();
        }
        OffMainDialog();
        m_MyHandCardsManager.CallNotShowPlayButton();
        m_MyMainCardsManager.CallNotShowMoveButton();
    }

    public void onCloseButton()
    {
        OffMainDialog();
        m_MyHandCardsManager.CallNotShowPlayButton();
        m_MyMainCardsManager.CallNotShowMoveButton();
    }

    /// <summary>
    /// ���C���_�C�A���O�����
    /// </summary>
    public void OffMainDialog()
    {
        this.gameObject.SetActive(false);
    }

    private void ResetSelectZone()
    {
        for (int i = 0; i < images.Count; i++)
        {
            images[i].color = new Color(1, 1, 255 / 255, 255 / 255);
        }
        images[selectedPlace].color = new Color(145 / 255, 145 / 255, 145 / 255, 60 / 255);
        OKButton.SetActive(false);
        isSelected = new List<bool> { false, false, false, false, false };
        place = -1;
    }

    public void onClick(int pressedPlace)
    {
        if(pressedPlace == selectedPlace)
        {
            return;
        }

        // ���ɑI�΂�Ă���ꍇ
        if (isSelected[pressedPlace])
        {
            OKButton.SetActive(false);
            images[pressedPlace].color = new Color(1, 1, 255 / 255, 255 / 255);
            isSelected[pressedPlace] = false;
            return;
        }

        // �I�΂�Ă��Ȃ��ꍇ
        for (int i = 0; i < images.Count; i++)
        {
            OKButton.SetActive(true);
            images[i].color = new Color(1, 1, 255 / 255, 255 / 255);
            isSelected[i] = false;
        }
        images[pressedPlace].color = new Color(1, 1, 0 / 255, 255 / 255);
        images[selectedPlace].color = new Color(145 / 255, 145 / 255, 145 / 255, 60 / 255);
        isSelected[pressedPlace] = true;
        place = pressedPlace;
    }
}
