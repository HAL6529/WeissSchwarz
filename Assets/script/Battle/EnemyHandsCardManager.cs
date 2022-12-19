using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHandsCardManager : MonoBehaviour
{
    public List<GameObject> CardList = new List<GameObject>();
    private List<BattleModeCard> handList = new List<BattleModeCard>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateEnemyHandCards(List<BattleModeCard> list)
    {
        handList = list;
        if(handList.Count > CardList.Count)
        {
            for(int i = 0; i < CardList.Count; i++)
            {
                CardList[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < CardList.Count; i++)
            {
                if (i < handList.Count)
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
}
