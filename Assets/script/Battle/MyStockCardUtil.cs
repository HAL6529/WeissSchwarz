using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyStockCardUtil : MonoBehaviour
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

    public void updateMyStockList(Player player)
    {
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
