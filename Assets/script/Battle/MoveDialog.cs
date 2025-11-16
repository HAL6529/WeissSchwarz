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
    /// MoveDialog内で押されたカードの位置
    /// </summary>
    private int place = -1;

    /// <summary>
    /// 移動させるカードの情報
    /// </summary>
    private BattleModeCard m_BattleModeCard = null;

    /// <summary>
    /// ステージで押されたカードの場所
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
            m_BattleStrix.RpcToAll("SEManager_DrawSE_Play");

            BattleModeCard temp = m_GameManager.myFieldList[place];
            m_GameManager.myFieldList[place] = m_BattleModeCard;
            m_GameManager.myFieldList[selectedPlace] = temp;

            EnumController.State placeStatus = m_MyMainCardsManager.GetState(place);
            EnumController.State selectedPlaceStatus = m_MyMainCardsManager.GetState(selectedPlace);

            m_MyMainCardsManager.setBattleModeCard(place, m_BattleModeCard, selectedPlaceStatus);
            m_MyMainCardsManager.setBattleModeCard(selectedPlace, temp, placeStatus);

            int ActEffectCount = m_MyMainCardsManager.CheckActEffectCount(selectedPlace);
            m_MyMainCardsManager.SetActEffectCount(selectedPlace, m_MyMainCardsManager.CheckActEffectCount(place));
            m_MyMainCardsManager.SetActEffectCount(place, ActEffectCount);

            bool isHandEncore = m_MyMainCardsManager.isHandEncore(selectedPlace);
            m_MyMainCardsManager.SetHandEncore(selectedPlace, m_MyMainCardsManager.isHandEncore(place));
            m_MyMainCardsManager.SetHandEncore(place, isHandEncore);

            bool TwoStockEncore = m_MyMainCardsManager.isTwoStockEncore(selectedPlace);
            m_MyMainCardsManager.SetTwoStockEncore(selectedPlace, m_MyMainCardsManager.isTwoStockEncore(place));
            m_MyMainCardsManager.SetTwoStockEncore(place, TwoStockEncore);

            bool ClockEncore = m_MyMainCardsManager.isClockEncore(selectedPlace);
            m_MyMainCardsManager.SetClockEncore(selectedPlace, m_MyMainCardsManager.isClockEncore(place));
            m_MyMainCardsManager.SetClockEncore(place, ClockEncore);

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
    /// メインダイアログを閉じる
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

        // 既に選ばれている場合
        if (isSelected[pressedPlace])
        {
            OKButton.SetActive(false);
            images[pressedPlace].color = new Color(1, 1, 255 / 255, 255 / 255);
            isSelected[pressedPlace] = false;
            return;
        }

        // 選ばれていない場合
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
