using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyLevelCardsManager : MonoBehaviour
{
    public List<GameObject> CardList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateMyLevelCards(int num)
    {
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
