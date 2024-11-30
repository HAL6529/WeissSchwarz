using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Jake: Bacon Pancakesのために使われている

public class CharacterSelectDialog : MonoBehaviour
{
    [SerializeField] List<Image> images = new List<Image>();
    [SerializeField] List<Button> buttons = new List<Button>();
    [SerializeField] MyMainCardsManager m_MyMainCardsManager;
    [SerializeField] GameObject m_OKButton;
    [SerializeField] Sprite BackImage;
    [SerializeField] GameManager m_GameManager;
    private int place = -1;

    /// <summary>
    /// 複数のカードを選ぶ可能性がある場合はtrue,なければfalse
    /// </summary>
    private bool isMultiple = false;

    private int ButtonSelectedNum = -1;
    private List<bool> ButtonSelectedNumList = new List<bool> { false, false, false, false, false, };
    private EnumController.Attack status = EnumController.Attack.VOID;
    private BattleModeCard m_BattleModeCard = null;

    public void Open(BattleModeCard card, List<BattleModeCard> list, int place)
    {
        m_OKButton.SetActive(false);
        ButtonSelectedNum = -1;
        ButtonSelectedNumList = new List<bool> { false, false, false, false, false, };
        this.place = place;
        this.status = status;
        m_BattleModeCard = card;
        int cnt = 0;

        // 複数のカードを選ぶ可能性がある場合はここで設定
        switch (m_BattleModeCard.cardNo)
        {
            case EnumController.CardNo.AT_WX02_A02:
                isMultiple = false;
                break;
            default:
                isMultiple = false;
                break;
        }


        for (int i = 0; i < images.Count; i++)
        {
            if (list[i] == null)
            {
                images[i].sprite = BackImage;
                cnt++;
                buttons[i].interactable = false;
            }
            else
            {
                images[i].sprite = list[i].sprite;
                if (i == place)
                {
                    buttons[i].interactable = false;
                }
                else
                {
                    buttons[i].interactable = true;
                }
            }
        }

        // ほかにキャラクターがいなければreturnする
        switch (m_BattleModeCard.cardNo)
        {
            case EnumController.CardNo.AT_WX02_A02:
                if (cnt >= 4)
                {
                    m_MyMainCardsManager.ExecuteAttack2(place, status);
                    return;
                }
                else
                {
                    this.gameObject.SetActive(true);
                }
                break;
            default:
                break;
        }
    }

    public void ButtonClick(int num)
    {
        if (isMultiple)
        {
            if (ButtonSelectedNumList[num])
            {
                images[num].color = new Color(1, 255 / 255, 255 / 255, 255 / 255);
                ButtonSelectedNumList[num] = false;
            }
            else
            {
                images[num].color = new Color(145f / 255f, 145f / 255f, 145f / 255f, 145f / 255f);
                ButtonSelectedNumList[num] = true;
            }
        }
        else
        {
            for (int i = 0; i < images.Count; i++)
            {
                images[i].color = new Color(1, 255 / 255, 255 / 255, 255 / 255);
            }

            if (ButtonSelectedNum == num)
            {
                ButtonSelectedNum = -1;
                m_OKButton.SetActive(false);
                return;
            }
            ButtonSelectedNum = num;
            images[num].color = new Color(145f / 255f, 145f / 255f, 145f / 255f, 145f / 255f);
            m_OKButton.SetActive(true);
        }
    }

    public void OffDialog()
    {
        this.gameObject.SetActive(false);
        for (int i = 0; i < images.Count; i++)
        {
            images[i].color = new Color(1, 255 / 255, 255 / 255, 255 / 255);
        }
        status = EnumController.Attack.VOID;
        place = -1;
        ButtonSelectedNum = -1;
    }

    public void OKButton()
    {
        m_MyMainCardsManager.AddPowerUpUntilTurnEnd(ButtonSelectedNum, 1500);
        m_GameManager.Syncronize();
        m_GameManager.ExecuteActionList();
        /*switch (m_BattleModeCard.cardNo)
        {
            case EnumController.CardNo.AT_WX02_A02:
                m_MyMainCardsManager.AddPowerUpUntilTurnEnd(ButtonSelectedNum, 1500);
                m_GameManager.Syncronize();
                m_MyMainCardsManager.ExecuteAttack2(place, status);
                break;
            default:
                break;
        }*/
        OffDialog();
    }
}