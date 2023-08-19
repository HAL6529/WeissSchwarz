using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClockCardsManager : MonoBehaviour
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

    public void updateEnemyClockCards(List<BattleModeCard> list)
    {
        int num = list.Count;
        for (int i = 0; i < CardList.Count; i++)
        {
            if (i < num)
            {
                CardList[i].SetActive(true);
                CardList[i].GetComponent<BattleClockCardUtil>().setBattleModeCard(list[i]);
            }
            else
            {
                CardList[i].SetActive(false);
                //CardList[i].GetComponent<BattleClockCardUtil>().setBattleModeCard(null);
            }
        }
    }
}
