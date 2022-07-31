using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBackCardListUtil : MonoBehaviour
{
    [SerializeField] List<BackCardUtil> backCardUtilList = new List<BackCardUtil>();

    static readonly int BACK_CARD_NUM = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateMyBackList(Player player)
    {
        for (int i = 0; i < BACK_CARD_NUM; i++)
        {
            backCardUtilList[i].updateSprite(player.BackStageList[i]);
        }
    }
}
