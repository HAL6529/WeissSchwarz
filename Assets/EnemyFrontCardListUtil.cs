using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFrontCardListUtil : MonoBehaviour
{
    [SerializeField] List<FrontCardUtil> frontCardUtilList = new List<FrontCardUtil>();

    static readonly int FRONT_CARD_NUM = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateEnemyFrontList(Player player)
    {
        if(player == null)
        {
            for (int i = 0; i < FRONT_CARD_NUM; i++)
            {
                frontCardUtilList[i].updateSprite(null);
            }
            return;
        }
        for (int i = 0; i < FRONT_CARD_NUM; i++)
        {
            frontCardUtilList[i].updateSprite(player.FrontStageList[i]);
        }
    }
}
