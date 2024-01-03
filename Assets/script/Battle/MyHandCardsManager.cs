using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MyHandCardsManager : MonoBehaviour
{
    public GameObject leftCard;
    [SerializeField] GameManager m_GameManager;
    public List<GameObject> CardList = new List<GameObject>();
    [SerializeField] List<Button> buttons = new List<Button>();
    private List<BattleModeCard> handList = new List<BattleModeCard>();
    public GameObject onlyEleven;
    public GameObject rightCard;
    public int cursorNum = 0;

    private static int HAND_DISPLAY_NUM = 11;
    
    public void updateMyHandCards(List<BattleModeCard> list)
    {
        handList = list;
        int num = handList.Count;
        if (num == 11)
        {
            leftCard.SetActive(false);
            for (int i = 0; i < CardList.Count; i++)
            {
                CardList[i].SetActive(true);
                CardList[i].GetComponent<BattleHandCardUtil>().setBattleModeCard(handList[i]);
            }
            onlyEleven.SetActive(true);
            onlyEleven.GetComponent<BattleHandCardUtil>().setBattleModeCard(handList[10]);
            rightCard.SetActive(false);
            cursorNum = 0;
        }
        else if(num < 11)
        {
            leftCard.SetActive(false);
            for (int i = 0; i < CardList.Count; i++)
            {
                if(i < num)
                {
                    CardList[i].SetActive(true);
                    CardList[i].GetComponent<BattleHandCardUtil>().setBattleModeCard(handList[i]);
                }
                else
                {
                    CardList[i].SetActive(false);
                }

            }
            onlyEleven.SetActive(false);
            rightCard.SetActive(false);
            cursorNum = 0;
        }
        // カードの枚数が12枚以上で表示カーソルが一番左のとき
        else if (num > 11 && 0 >= cursorNum)
        {
            cursorNum = 0;
            leftCard.SetActive(false);
            for (int i = 0; i < CardList.Count; i++)
            {
                CardList[i].SetActive(true);
                CardList[i].GetComponent<BattleHandCardUtil>().setBattleModeCard(handList[i]);
            }
            onlyEleven.SetActive(false);
            rightCard.SetActive(true);
            rightCard.GetComponent<BattleHandCardUtil>().setBattleModeCard(handList[HAND_DISPLAY_NUM]);
        }
        // カードの枚数が12枚以上で表示カーソルが一番右のとき
        else if (num > 11 && cursorNum > 0 && cursorNum >= num - HAND_DISPLAY_NUM)
        {
            leftCard.SetActive(true);
            leftCard.GetComponent<BattleHandCardUtil>().setBattleModeCard(handList[num - HAND_DISPLAY_NUM - 1]);
            for (int i = 0; i < CardList.Count; i++)
            {
                CardList[i].SetActive(true);
                CardList[i].GetComponent<BattleHandCardUtil>().setBattleModeCard(handList[cursorNum + i + 1]);
            }
            onlyEleven.SetActive(false);
            rightCard.SetActive(false);
            cursorNum = num - HAND_DISPLAY_NUM;
        }
        // カードの枚数が12枚以上で表示カーソルが真ん中のとき
        else if (num > 11 && cursorNum > 0 && num - HAND_DISPLAY_NUM > cursorNum)
        {
            leftCard.SetActive(true);
            leftCard.GetComponent<BattleHandCardUtil>().setBattleModeCard(handList[cursorNum - 1]);
            for (int i = 0; i < CardList.Count; i++)
            {
                CardList[i].SetActive(true);
                CardList[i].GetComponent<BattleHandCardUtil>().setBattleModeCard(handList[cursorNum + i]);
            }
            onlyEleven.SetActive(false);
            rightCard.SetActive(true);
            rightCard.GetComponent<BattleHandCardUtil>().setBattleModeCard(handList[cursorNum + HAND_DISPLAY_NUM]);
        }
        CallResetSelected();
        onlyEleven.GetComponent<BattleHandCardUtil>().isSelected = false;
    }

    public void CallResetSelected()
    {
        for (int i = 0; i < CardList.Count; i++)
        {
            CardList[i].GetComponent<BattleHandCardUtil>().ResetSelected();
        }
    }

    public void CallNotShowPlayButton()
    {
        for (int i = 0; i < CardList.Count; i++)
        {
            CardList[i].GetComponent<BattleHandCardUtil>().NotShowPlayButton();
        }
    }

    public int GetIsSelectedNum()
    {
        int num = 0;
        for (int i = 0; i < CardList.Count; i++)
        {
            if (CardList[i].GetComponent<BattleHandCardUtil>().isSelected)
            {
                num++;
            }
        }
        return num;
    }

    /// <summary>
    /// 手札のカウンターカード以外を非活性にする
    /// </summary>
    public void canUseCounter()
    {
        for(int i = 0; i < buttons.Count; i++)
        {
            /* if(handList[i].isCounter && m_GameManager.PlayerLevel >= handList[i].level && handList[i].cost >= m_GameManager.myStockList.Count)
            {
                buttons[i].interactable = true;
            }
            else
            {
                buttons[i].interactable = false;
            } */
            buttons[i].interactable = false;
        }

    }
}
