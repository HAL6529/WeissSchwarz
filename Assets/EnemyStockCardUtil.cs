using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStockCardUtil : MonoBehaviour
{
    [SerializeField] List<StockCardUtil> stockCardUtilList = new List<StockCardUtil>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateEnemyStockList(Player player)
    {
        if(player == null)
        {
            for (int i = 0; i < stockCardUtilList.Count; i++)
            {
                stockCardUtilList[i].m_battleCardInfo = null;
                stockCardUtilList[i].updateSprite();
            }
            return;
        }

        int num = player.StockList.Count;
        if (num <= 11)
        {
            for (int i = 0; i < num; i++)
            {
                stockCardUtilList[i].m_battleCardInfo = player.StockList[i];
            }
            for (int i = num; i < stockCardUtilList.Count; i++)
            {
                stockCardUtilList[i].m_battleCardInfo = null;
            }
        }
        else
        {
            for (int i = num; i < 11; i++)
            {
                stockCardUtilList[i].m_battleCardInfo = player.StockList[i];
            }
        }

        for (int i = 0; i < stockCardUtilList.Count; i++)
        {
            stockCardUtilList[i].updateSprite();
        }
    }
}
