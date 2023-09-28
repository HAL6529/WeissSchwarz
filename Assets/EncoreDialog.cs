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
    [SerializeField] Sprite Background;
    [SerializeField] DialogManager m_DialogManager;

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
                images[i].sprite = Background;
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

    public void onClick(int num)
    {
        BattleModeCard temp = m_GameManager.myFieldList[num];
        m_GameManager.GraveYardList.Add(m_GameManager.myFieldList[num]);
        m_GameManager.myFieldList[num] = null;


        m_GameManager.UpdateMyMainCards();
        m_BattleStrix.SendUpdateMainCards(m_GameManager.myFieldList, m_GameManager.isTurnPlayer);

        m_GameManager.UpdateMyGraveYardCards();
        m_BattleStrix.SendUpdateEnemyGraveYard(m_GameManager.GraveYardList, m_GameManager.isFirstAttacker);
        this.gameObject.SetActive(false);

        if(m_GameManager.myStockList.Count > 2)
        {
            m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.ENCORE_CONFIRM, temp, num);
        }
        else
        {
            m_DialogManager.EncoreDialog(m_GameManager.myFieldList);
        }
        return;
    }
}
