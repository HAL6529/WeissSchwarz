using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMainCardsManager : MonoBehaviour
{
    private List<BattleModeCard> enemyFieldList = new List<BattleModeCard>();
    public List<BattleEnemyMainCardUtil> CardList = new List<BattleEnemyMainCardUtil>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateEnemyFieldCards(List<BattleModeCard> list)
    {
        enemyFieldList = list;
        for (int i = 0; i < CardList.Count; i++)
        {
            CardList[i].setBattleModeCard(enemyFieldList[i]);
        }
    }
}
