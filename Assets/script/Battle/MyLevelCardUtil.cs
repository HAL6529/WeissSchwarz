using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyLevelCardUtil : MonoBehaviour
{
    [SerializeField] List<LevelCardUtil> levelCardUtilList = new List<LevelCardUtil>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateMyLevelList(Player player)
    {
        int num = player.LevelList.Count;
        if (num <= 3)
        {
            for (int i = 0; i < num; i++)
            {
                levelCardUtilList[i].m_battleCardInfo = player.LevelList[i];
            }
            for (int i = num; i < levelCardUtilList.Count; i++)
            {
                levelCardUtilList[i].m_battleCardInfo = null;
            }
        }
        else
        {
            for (int i = num; i < 3; i++)
            {
                levelCardUtilList[i].m_battleCardInfo = player.LevelList[i];
            }
        }

        for (int i = 0; i < levelCardUtilList.Count; i++)
        {
            levelCardUtilList[i].updateSprite();
        }
    }
}
