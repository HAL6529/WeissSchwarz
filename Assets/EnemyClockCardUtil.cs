using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClockCardUtil : MonoBehaviour
{
    [SerializeField] List<ClockCardUtil> clockCardUtilList = new List<ClockCardUtil>();
    static readonly int CLOCK_NUM = 7;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateEnemyClockList(Player player)
    {
        if(player == null)
        {
            for (int i = 0; i < CLOCK_NUM; i++)
            {
                clockCardUtilList[i].m_battleCardInfo = null;
                clockCardUtilList[i].updateSprite();
            }
            return;
        }

        int num = player.ClockList.Count;
        if (num <= CLOCK_NUM)
        {
            for (int i = 0; i < num; i++)
            {
                clockCardUtilList[i].m_battleCardInfo = player.ClockList[i];
            }
            for (int i = num; i < CLOCK_NUM; i++)
            {
                clockCardUtilList[i].m_battleCardInfo = null;
            }
        }
        else
        {
            for (int i = 0; i < CLOCK_NUM; i++)
            {
                clockCardUtilList[i].m_battleCardInfo = player.ClockList[i];
            }
        }

        for (int i = 0; i < clockCardUtilList.Count; i++)
        {
            clockCardUtilList[i].updateSprite();
        }
    }
}
