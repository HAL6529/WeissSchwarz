using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandCardUtil : MonoBehaviour
{
    [SerializeField] List<GameObject> handList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateEnemyHand(int enemyHandNum)
    {
        int num = enemyHandNum;
        if (num > 10)
        {
            for (int i = 0; i < handList.Count; i++)
            {
                handList[i].SetActive(true);
            }
            return;
        }

        for (int i = 0; i < num; i++)
        {
            handList[i].SetActive(true);
        }
        for (int i = num; i < handList.Count; i++)
        {
            handList[i].SetActive(false);
        }
    }
}
