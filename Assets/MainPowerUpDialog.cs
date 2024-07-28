using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPowerUpDialog : MonoBehaviour
{
    [SerializeField] List<Button> buttons = new List<Button>();
    [SerializeField] List<Image> images = new List<Image>();
    [SerializeField] GameManager m_GameManager;
    [SerializeField] MyHandCardsManager m_MyHandCardsManager;
    [SerializeField] MyMainCardsManager m_MyMainCardsManager;
    [SerializeField] BattleStrix m_BattleStrix;
    [SerializeField] GameObject OKButton;
    [SerializeField] Sprite backImage;
    [SerializeField] DialogManager m_DialogManager;

    private List<bool> isSelected = new List<bool> { false, false, false, false, false };
    private int place = -1;
    private BattleModeCard m_BattleModeCard = null;
    public Effect m_Effect;

    void Start()
    {
        m_Effect = new Effect(m_GameManager, m_BattleStrix);
    }

    public void onClick(int num)
    {
        // 既に選ばれている場合
        if (isSelected[num])
        {
            OKButton.SetActive(false);
            images[num].color = new Color(1, 1, 255 / 255, 255 / 255);
            isSelected[num] = false;
            return;
        }

        // 選ばれていない場合
        for (int i = 0; i < images.Count; i++)
        {
            OKButton.SetActive(true);
            images[i].color = new Color(1, 1, 255 / 255, 255 / 255);
            isSelected[i] = false;
        }
        images[num].color = new Color(1, 1, 0 / 255, 255 / 255);
        isSelected[num] = true;
        place = num;
    }

    public void SetBattleMordCard(BattleModeCard card)
    {
        ResetSelectZone();
        m_BattleModeCard = card;
        for (int i = 0; i < m_GameManager.myFieldList.Count; i++)
        {
            if (m_GameManager.myFieldList[i] == null)
            {
                images[i].sprite = backImage;
                buttons[i].interactable = false;
            }
            else
            {
                images[i].sprite = m_GameManager.myFieldList[i].sprite;
                buttons[i].interactable = true;
            }
        }

        switch (m_BattleModeCard.cardNo)
        {
            case EnumController.CardNo.LB_W02_17T:
                for (int i = 0; i < m_GameManager.myFieldList.Count; i++)
                {
                    // 動物の特徴を持っていないキャラを非活性に
                    if (!m_MyMainCardsManager.HaveAttribute(i, EnumController.Attribute.Animal))
                    {
                        buttons[i].interactable = false;
                    }
                }
                break;
            default: 
                break;
        }
        this.gameObject.SetActive(true);
    }

    /// <summary>
    /// メインダイアログを閉じる
    /// </summary>
    public void OffDialog()
    {
        this.gameObject.SetActive(false);
    }

    private void ResetSelectZone()
    {
        for (int i = 0; i < images.Count; i++)
        {
            images[i].color = new Color(1, 1, 255 / 255, 255 / 255);
            isSelected[i] = false;
        }
        OKButton.SetActive(false);
        isSelected = new List<bool> { false, false, false, false, false };
        place = -1;
    }

    public void onOkClick()
    {
        if (place == -1)
        {
            return;
        }

        switch (m_BattleModeCard.cardNo)
        {
            case EnumController.CardNo.DC_W01_01T:
                m_MyMainCardsManager.AddPowerUpUntilTurnEnd(place, 1000);
                m_GameManager.Syncronize();
                break;
            case EnumController.CardNo.LB_W02_17T:
                m_MyMainCardsManager.AddPowerUpUntilTurnEnd(place, 500);
                m_GameManager.Syncronize();
                break;
            default:
                break;
        }
        m_DialogManager.CloseAllDialog();
    }
}
