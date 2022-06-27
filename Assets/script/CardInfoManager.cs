using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInfoManager : MonoBehaviour
{
    public List<cardInfo> cardInfoList = new List<cardInfo>();
    public List<GameObject> searchCardList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        InitializeSearchCardList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitializeSearchCardList()
    {
        for(int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            searchCardList.Add(this.gameObject.transform.GetChild(i).gameObject);
        }
    }
}
