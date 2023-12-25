using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectDialog : MonoBehaviour
{
    [SerializeField] List<Image> images = new List<Image>();
    [SerializeField] List<Button> buttons = new List<Button>();
    [SerializeField] MyMainCardsManager m_MyMainCardsManager;
    [SerializeField] GameObject m_OKButton;
    [SerializeField] Sprite BackImage;
    private int place = -1;
    private int ButtonSelectedNum = -1;
    private EnumController.AttackStatus status = EnumController.AttackStatus.VOID;

    public void Open(List<BattleModeCard> list, int place, EnumController.AttackStatus status)
    {
        m_OKButton.SetActive(false);
        ButtonSelectedNum = -1;
        this.place = place;
        this.status = status;
        int cnt = 0;
        for (int i = 0; i < images.Count; i++)
        {
            if (list[i] == null)
            {
                images[i].sprite = BackImage;
                cnt++;
            }
            else
            {
                images[i].sprite = list[i].sprite;
            }

            if (i == place)
            {
                buttons[i].interactable = false;
            }
            else
            {
                buttons[i].interactable = true;
            }
        }

        Debug.Log(cnt);
        // ほかにキャラクターがいなければreturnする
        if (cnt > 3)
        {
            m_MyMainCardsManager.ExecuteAttack2(place, status);
            return;
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }

    public void ButtonClick(int num)
    {
        for(int i = 0; i < images.Count; i++)
        {
            images[i].color = new Color(1, 255 / 255, 255 / 255, 255 / 255);
        }

        if(ButtonSelectedNum == num)
        {
            ButtonSelectedNum = -1;
            m_OKButton.SetActive(false);
            return;
        }
        ButtonSelectedNum = num;
        images[num].color = new Color(145f / 255f, 145f / 255f, 145f / 255f, 145f / 255f);
        m_OKButton.SetActive(true);
    }

    public void OffDialog()
    {
        this.gameObject.SetActive(false);
        status = EnumController.AttackStatus.VOID;
        place = -1;
        ButtonSelectedNum = -1;
    }

    public void OKButton()
    {
        m_MyMainCardsManager.AddPowerUpUntilTurnEnd(ButtonSelectedNum, 1500);
        m_MyMainCardsManager.ExecuteAttack2(place, status);
        OffDialog();
    }
}