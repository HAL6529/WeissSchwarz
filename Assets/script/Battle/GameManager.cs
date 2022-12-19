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

    public List<BattleModeCard> enemyHandList = new List<BattleModeCard>();
    public List<BattleModeCard> enemyClockList = new List<BattleModeCard>();
    public List<BattleModeCard> enemyStockList = new List<BattleModeCard>();
    public List<BattleModeCard> enemyLevelList = new List<BattleModeCard>();

    public List<BattleModeCard> myMariganList = new List<BattleModeCard>();

    public BattleModeCard climaxCard = null;

    public GameObject MyClimaxCardObject = null;
    public GameObject MyDeckObject = null;
    public GameObject MyMemoryObject = null;
    public GameObject MyGraveYardObject = null;

    public GameObject EnemyClimaxCardObject = null;
    public GameObject EnemyDeckObject = null;
    public GameObject EnemyMemoryObject = null;
    public GameObject EnemyGraveYardObject = null;

    public bool MariganMode = false;

    [SerializeField] GameObject dialog;
    [SerializeField] GameObject LordScreen;
    [SerializeField] GameObject PhaseObject;
    private Dialog m_Dialog;
    private int turn = 0;
    public EnumController.Turn phase = EnumController.Turn.VOID;

    public bool isFirstAttacker = false;

    // Start is called before the first frame update
    void Start()
    {
        m_Dialog = dialog.GetComponent<Dialog>();
        GetComponent<MyHandCardsManager>().updateMyHandCards(myHandList);
        GetComponent<MyClockCardsManager>().updateMyClockCards(myClockList.Count);
        GetComponent<MyStockCardsManager>().updateMyStockCards(myStockList.Count);
        GetComponent<MyLevelCardsManager>().updateMyLevelCards(myStockList.Count);
        GetComponent<EnemyHandsCardManager>().updateEnemyHandCards(enemyHandList);
        GetComponent<EnemyClockCardsManager>().updateEnemyClockCards(enemyClockList.Count);
        GetComponent<EnemyStockCardsManager>().updateEnemyStockCards(enemyStockList.Count);
        GetComponent<EnemyLevelCardsManager>().updateEnemyLevelCards(enemyLevelList.Count);
        MyDeckObject.GetComponent<BattleDeckCardUtil>().ChangeFrontAndBack(false);
        MyClimaxCardObject.GetComponent<BattleClimaxCardUtil>().SetClimax(climaxCard);
        MyMemoryObject.GetComponent<BattleMemoryCardUtil>().ChangeMemory(null);
        MyGraveYardObject.GetComponent<BattleGraveYardUtil>().setBattleModeCard(null);
        EnemyDeckObject.GetComponent<BattleDeckCardUtil>().ChangeFrontAndBack(false);
        EnemyClimaxCardObject.GetComponent<BattleClimaxCardUtil>().SetClimax(climaxCard);
        EnemyMemoryObject.GetComponent<BattleMemoryCardUtil>().ChangeMemory(null);
        EnemyGraveYardObject.GetComponent<BattleGraveYardUtil>().setBattleModeCard(null);
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

    public void DrawPhaseStart()
    {
        phase = EnumController.Turn.Player1_Draw;
        PhaseObject.GetComponent<Phase>().AnimationStart(phase);
        Draw();
        DrawPhaseEnd();
    }

    public void DrawPhaseEnd()
    {
        ClockPhaseStart();
    }

    public void ClockPhaseStart()
    {
        phase = EnumController.Turn.Player1_Clock;
        dialog.SetActive(true);
        m_Dialog.setText("Please Choice Clock Card");
        ClockPhaseEnd();
    }

    public void ClockPhaseEnd()
    {
        dialog.SetActive(false);
        MainStart();
    }

    public void MainStart()
    {
        phase = EnumController.Turn.Player1_Main;
    } 

    public void Draw()
    {
        if(myDeckList.Count > 0)
        {
            myHandList.Add(myDeckList[0]);
            myDeckList.RemoveAt(0);
        }
        else
        {
            myDeckList = GraveYardList;
            GraveYardList = new List<BattleModeCard>();
            MyGraveYardObject.GetComponent<BattleGraveYardUtil>().setBattleModeCard(null);

            myHandList.Add(myDeckList[0]);
            myDeckList.RemoveAt(0);
        }
        GetComponent<MyHandCardsManager>().updateMyHandCards(myHandList);
    }

    public void GameStart()
    {
        LordScreen.SetActive(false);
        FirstDraw();
        MariganStart();
    }
}
