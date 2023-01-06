using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MyHandCardsManager : MonoBehaviour
{
    public GameObject leftCard;
    public List<GameObject> CardList = new List<GameObject>();
    private List<BattleModeCard> handList = new List<BattleModeCard>();
    public GameObject onlyEleven;
    public GameObject rightCard;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
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
            onlyEleven.GetComponent<BattleHandCardUtil>().setBattleModeCard(handList[11]);
            rightCard.SetActive(false);
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
        }
        else
        {
            leftCard.SetActive(true);
            for (int i = 0; i < CardList.Count; i++)
            {
                CardList[i].SetActive(true);
                CardList[i].GetComponent<BattleHandCardUtil>().setBattleModeCard(handList[i]);
            }
            onlyEleven.SetActive(false);
            rightCard.SetActive(true);
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
}
