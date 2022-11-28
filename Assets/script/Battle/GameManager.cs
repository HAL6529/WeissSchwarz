using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumController;

public class GameManager : MonoBehaviour
{
    public List<BattleModeCard> myDeckList = new List<BattleModeCard>();
    public List<BattleModeCard> myHandList = new List<BattleModeCard>();
    public List<BattleModeCard> myClockList = new List<BattleModeCard>();
    public List<BattleModeCard> myStockList = new List<BattleModeCard>();
    public List<BattleModeCard> myLevelList = new List<BattleModeCard>();
    public List<BattleModeCard> myMemoryList = new List<BattleModeCard>();
    public List<BattleModeCard> GraveYardList = new List<BattleModeCard>();

    public List<BattleModeCard> myMariganList = new List<BattleModeCard>();

    public BattleModeCard climaxCard = null;

    public GameObject MyClimaxCardObject = null;
    public GameObject MyDeckObject = null;
    public GameObject MyMemoryObject = null;

    public bool MariganMode = false;

    [SerializeField] GameObject dialog;
    private int turn = 0;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MyHandCardsManager>().updateMyHandCards(myHandList);
        GetComponent<MyClockCardsManager>().updateMyClockCards(myClockList.Count);
        GetComponent<MyStockCardsManager>().updateMyStockCards(myStockList.Count);
        GetComponent<MyLevelCardsManager>().updateMyLevelCards(myStockList.Count);
        MyDeckObject.GetComponent<BattleDeckCardUtil>().ChangeFrontAndBack(false);
        MyClimaxCardObject.GetComponent<BattleClimaxCardUtil>().SetClimax(climaxCard);
        MyMemoryObject.GetComponent<BattleMemoryCardUtil>().ChangeMemory(null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FirstDraw()
    {
        for(int i = 0; i < 5; i++)
        {
            myHandList.Add(myDeckList[0]);
            myDeckList.RemoveAt(0);
        }
        GetComponent<MyHandCardsManager>().updateMyHandCards(myHandList);
    }

    public void MariganStart()
    {
        MariganMode = true;
        dialog.SetActive(true);
    }

    public void MariganEnd()
    {
        dialog.SetActive(false);
        int num = myMariganList.Count;
        for (int i = 0; i < num; i++)
        {
            myHandList.Remove(myMariganList[i]);
            GraveYardList.Add(myMariganList[i]);
        }

        for (int i = 0; i < num; i++)
        {
            myHandList.Add(myDeckList[0]);
            myDeckList.RemoveAt(0);
        }
        myMariganList = new List<BattleModeCard>();
        GetComponent<MyHandCardsManager>().updateMyHandCards(myHandList);
        MariganMode = false;
    }
}
