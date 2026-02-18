using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainDialog : MonoBehaviour
{
    [SerializeField] List<GameObject> buttons = new List<GameObject>();
    [SerializeField] List<Image> images = new List<Image>();
    [SerializeField] EventAnimationManager m_EventAnimationManager;
    [SerializeField] GameManager m_GameManager;
    [SerializeField] MyHandCardsManager m_MyHandCardsManager;
    [SerializeField] MyMainCardsManager m_MyMainCardsManager;
    [SerializeField] BattleStrix m_BattleStrix;
    [SerializeField] GameObject OKButton;

    private List<bool> isSelected = new List<bool>{false, false, false, false, false };
    private int place = -1;
    private int HandNum = -1;
    private BattleModeCard m_BattleModeCard = null;
    public Effect m_Effect;

    void Start()
    {
        m_Effect = new Effect(m_GameManager, m_BattleStrix);
        m_Effect.m_EventAnimationManager = m_EventAnimationManager;
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

    public void onOkClick()
    {
        if (place == -1)
        {
            return;
        }
        if (m_BattleModeCard != null)
        {
            m_BattleStrix.RpcToAll("SEManager_PlaySE_Play");
            for (int i = 0; i < m_BattleModeCard.GetCost(); i++)
            {
                BattleModeCard temp = m_GameManager.myStockList[m_GameManager.myStockList.Count - 1];
                m_GameManager.GraveYardList.Add(temp);
                m_GameManager.myStockList.Remove(temp);
            }
            m_MyMainCardsManager.CallPutFieldFromHand(place, HandNum, EnumController.State.STAND);
        }
        m_MyHandCardsManager.CallNotShowPlayButton();
        OffMainDialog();

        m_GameManager.ExecuteActionList();
    }

    public void onCloseButton()
    {
        OffMainDialog();
        m_MyHandCardsManager.CallNotShowPlayButton();
        m_MyMainCardsManager.CallNotShowMoveButton();
    }

    public void SetBattleMordCard(BattleModeCard card, int HandNum)
    {
        ResetSelectZone();
        this.gameObject.SetActive(true);
        m_BattleModeCard = card;
        this.HandNum = HandNum;

        for(int i = 0; i < images.Count; i++)
        {
            if(m_GameManager.myFieldList[i] == null)
            {
                images[i].sprite = null;
            }
            else
            {
                images[i].sprite = m_GameManager.myFieldList[i].GetSprite();
            }
            
        }
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
            isSelected[i] = false;
        }
        OKButton.SetActive(false);
        isSelected = new List<bool> { false, false, false, false, false };
        place = -1;
        HandNum = -1;
    }
}
