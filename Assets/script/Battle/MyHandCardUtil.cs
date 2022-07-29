using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyHandCardUtil : MonoBehaviour
{
    [SerializeField] List<HandCardUtil> handCardUtilList = new List<HandCardUtil>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateMyHandList(Player player)
    {
        int num = player.HandList.Count;
        if (num < 11)
        {
            for (int i = 0; i < num; i++)
            {
                handCardUtilList[i].m_battleCardInfo = player.HandList[i];
            }
            for(int i = num; i < handCardUtilList.Count; i++)
            {
                handCardUtilList[i].m_battleCardInfo = null;
            }
        }

        for (int i = 0; i < handCardUtilList.Count; i++)
        {
            handCardUtilList[i].updateSprite();
        }
    }
}
