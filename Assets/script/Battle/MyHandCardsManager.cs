using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MyHandCardsManager : MonoBehaviour
{
    public GameObject leftCard;
    [SerializeField] GameManager m_GameManager;
    [SerializeField] HandOverDialog m_HandOverDialog;
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
            rightCard.GetComponent<BattleHandCardUtil>().setBattleModeCard(handList[HAND_DISPLAY_NUM - 1]);
        }
        // カードの枚数が12枚以上で表示カーソルが一番右のとき
        else if (num > 11 && cursorNum > 0 && cursorNum > num - HAND_DISPLAY_NUM)
        {
            cursorNum = num - HAND_DISPLAY_NUM + 1;
            leftCard.SetActive(true);
            leftCard.GetComponent<BattleHandCardUtil>().setBattleModeCard(handList[num - HAND_DISPLAY_NUM]);
            for (int i = 0; i < CardList.Count; i++)
            {
                CardList[i].SetActive(true);
                CardList[i].GetComponent<BattleHandCardUtil>().setBattleModeCard(handList[cursorNum + i]);
            }
            onlyEleven.SetActive(false);
            rightCard.SetActive(false);
        }
        // カードの枚数が12枚以上で表示カーソルが真ん中のとき
        else if (num > 11 && cursorNum > 0 && num - HAND_DISPLAY_NUM >= cursorNum)
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
            rightCard.GetComponent<BattleHandCardUtil>().setBattleModeCard(handList[cursorNum + HAND_DISPLAY_NUM - 1]);
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

    public void CallResetSelected2()
    {
        for (int i = 0; i < CardList.Count; i++)
        {
            CardList[i].GetComponent<BattleHandCardUtil>().ResetSelected(m_HandOverDialog.HandOverBoolList[cursorNum + i]);
        }

        if(cursorNum > 0)
        {
            leftCard.GetComponent<BattleHandCardUtil>().ResetSelected(m_HandOverDialog.HandOverBoolList[cursorNum - 1]);
        }

        if(handList.Count - HAND_DISPLAY_NUM >= cursorNum)
        {
            rightCard.GetComponent<BattleHandCardUtil>().ResetSelected(m_HandOverDialog.HandOverBoolList[cursorNum + HAND_DISPLAY_NUM - 1]);
        }
    }

    public void CallNotShowPlayButton()
    {
        for (int i = 0; i < CardList.Count; i++)
        {
            CardList[i].GetComponent<BattleHandCardUtil>().NotShowPlayButton();
        }
        onlyEleven.GetComponent<BattleHandCardUtil>().NotShowPlayButton();
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
            if(i > m_GameManager.myHandList.Count - 1)
            {
                break;
            }

            if (m_GameManager.myHandList[i].isCounter && m_GameManager.myStockList.Count >= m_GameManager.myHandList[i].cost && m_GameManager.myLevelList.Count >= m_GameManager.myHandList[i].level)
            {
                buttons[i].interactable = true;
            }
            else
            {
                buttons[i].interactable = false;
            }
        }
    }

    /// <summary>
    /// 手札のキャラクターカード以外を非活性にする
    /// </summary>
    public void canCharacterCard()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            if (i > m_GameManager.myHandList.Count - 1)
            {
                break;
            }

            if (m_GameManager.myHandList[i].type == EnumController.Type.CHARACTER)
            {
                buttons[i].interactable = true;
            }
            else
            {
                buttons[i].interactable = false;
            }
        }
    }

    /// <summary>
    /// 手札のカードすべてを活性状態にする
    /// </summary>
    public void ActiveAllMyHand()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].interactable = true;
        }
    }
}
