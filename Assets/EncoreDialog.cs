using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EncoreDialog : MonoBehaviour
{
    [SerializeField] List<Button> buttons = new List<Button>();
    [SerializeField] List<Image> images = new List<Image>();
    [SerializeField] GameManager m_GameManager;
    [SerializeField] MyMainCardsManager m_MyMainCardsManager;
    [SerializeField] BattleStrix m_BattleStrix;
    [SerializeField] GameObject OKButton;

    private void Open()
    {
        this.gameObject.SetActive(true);
    }

    public void SetBattleModeCard(List<BattleModeCard> list)
    {
        int count = 0;
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] == null)
            {
                images[i].sprite = null;
                buttons[i].interactable = false;
                continue;
            }

            images[i].sprite = list[i].sprite;
            if (m_MyMainCardsManager.GetIsReverse(i))
            {
                buttons[i].interactable = true;
                count++;
                continue;
            }
            buttons[i].interactable = false;
        }
        Debug.Log(count);
        if(count == 0)
        {
            m_BattleStrix.RpcToAll("TurnChange");
            return;
        }
        Open();
    }

    public void OffDialog()
    {
        this.gameObject.SetActive(false);
    }
}
