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
            BattleModeCard temp = m_GameManager.myFieldList[place];
            m_GameManager.myFieldList[place] = m_BattleModeCard;
            m_GameManager.myFieldList[selectedPlace] = temp;

            m_GameManager.UpdateMyMainCards();
            // パワー、レベル、特徴の計算
            m_MyMainCardsManager.FieldPowerAndLevelAndAttributeReset();
            m_BattleStrix.SendUpdateMainCards(m_GameManager.myFieldList, m_MyMainCardsManager.GetFieldPower(), m_GameManager.isTurnPlayer);

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
