using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStockCardsManager : MonoBehaviour
{
    public List<GameObject> CardList = new List<GameObject>();
    public GameObject onlyEleven;
    [SerializeField] GameObject StockCounter;
    [SerializeField] Text m_Text;

    public void updateEnemyStockCards(int num)
    {
        if (num > 11)
        {
            StockCounter.SetActive(true);
            m_Text.text = num.ToString();
        }
        else
        {
            StockCounter.SetActive(false);
        }

        if (num == 11)
        {
            for (int i = 0; i < CardList.Count; i++)
            {
                CardList[i].SetActive(true);
            }
            onlyEleven.SetActive(true);
            return;
        }

        onlyEleven.SetActive(false);
        for (int i = 0; i < CardList.Count; i++)
        {
            if (i < num)
            {
                CardList[i].SetActive(true);
            }
            else
            {
                CardList[i].SetActive(false);
            }
        }
    }
}
