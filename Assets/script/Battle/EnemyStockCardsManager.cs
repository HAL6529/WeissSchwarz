using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStockCardsManager : MonoBehaviour
{
    public List<GameObject> CardList = new List<GameObject>();
    public GameObject onlyEleven;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateEnemyStockCards(int num)
    {
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
