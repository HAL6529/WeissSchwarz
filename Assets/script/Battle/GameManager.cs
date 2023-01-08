using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public List<BattleModeCard> myMainList = new List<BattleModeCard>{null, null, null, null, null};

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
    public bool isAnimation = false;

    [SerializeField] ClockDialog m_ClockDialog;
    [SerializeField] GameObject LordScreen;
    [SerializeField] Phase m_Phase;
    [SerializeField] DummyDeckAnimation m_DummyDeckAnimation;

    public EnumController.Turn phase = EnumController.Turn.VOID;

    public bool isFirstAttacker = false;

    [SerializeField] Text testPhaseText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateMyHandCards();
        UpdateMyClockCards();
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
        testPhaseText.text = "Marigan";
        MariganMode = true;
    }

    public void MariganEnd()
    {
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
        m_ClockDialog.ClockDialogEnd();
        testPhaseText.text = "Draw";
        phase = EnumController.Turn.Player1_Draw;
        m_Phase.AnimationStart(phase);
    }

    public void DrawPhaseEnd()
    {
        Draw();
        testPhaseText.text = "Clock";
        phase = EnumController.Turn.Player1_Clock;
        m_Phase.AnimationStart(phase);
        ClockPhaseStart();
    }

    public void ClockPhaseStart()
    {
        m_ClockDialog.setText("クロックするカードを選択してください");
    }

    public void ClockPhaseEnd()
    {
        m_ClockDialog.ClockDialogEnd();
        MainStart();
    }

    public void MainStart()
    {
        testPhaseText.text = "Main";
        phase = EnumController.Turn.Player1_Main;
    } 

    public void Draw()
    {
        if(myDeckList.Count > 0)
        {
            m_DummyDeckAnimation.AnimationStart();
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

    public void UpdateMyHandCards()
    {
        GetComponent<MyHandCardsManager>().updateMyHandCards(myHandList);
    }

    public void UpdateMyClockCards()
    {
        GetComponent<MyClockCardsManager>().updateMyClockCards(myClockList);
    }

    public void GameStart()
    {
        LordScreen.SetActive(false);
        FirstDraw();
        MariganStart();
    }
}
