using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumController;

public class BattleModeDeck : MonoBehaviour
{
    private List<BattleModeCard> myDeckList = new List<BattleModeCard>();
    public List<EnumController.CardNo> cardNoList = new List<EnumController.CardNo>();

    [SerializeField] GameManager m_GameManager = null;
    [SerializeField] BattleModeCardList m_BattleModeCardList;
    // Start is called before the first frame update
    void Start()
    {
        SetDeckList();
        m_GameManager.myDeckList = myDeckList;

        // テストの際に使うトリガー用
        // m_GameManager.testTrigger = m_BattleModeCardList.GetComponent<BattleModeCardList>().ConvertCardNoToBattleModeCard(EnumController.CardNo.LB_W02_10T);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetDeckList()
    {
        if(SaveData.cardInfoList.Count < 50)
        {
            return;
        }
        for(int i = 0; i < cardNoList.Count; i++)
        {
            myDeckList.Add(m_BattleModeCardList.GetComponent<BattleModeCardList>().ConvertCardNoToBattleModeCard(SaveData.cardInfoList[i].cardNo));
        }
        /*for (int i = 0; i < cardNoList.Count; i++)
        {
            myDeckList.Add(m_BattleModeCardList.GetComponent<BattleModeCardList>().ConvertCardNoToBattleModeCard(cardNoList[i]));
        }*/
        // テスト用
        // m_GameManager.test = m_BattleModeCardList.GetComponent<BattleModeCardList>().ConvertCardNoToBattleModeCard(cardNoList[49]);
    }
}
