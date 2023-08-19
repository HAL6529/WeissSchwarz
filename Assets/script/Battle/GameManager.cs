using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EnumController;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text logText;

    public List<BattleModeCard> myDeckList = new List<BattleModeCard>();
    public List<BattleModeCard> myHandList = new List<BattleModeCard>();
    public List<BattleModeCard> myClockList = new List<BattleModeCard>();
    public List<BattleModeCard> myStockList = new List<BattleModeCard>();
    public List<BattleModeCard> myLevelList = new List<BattleModeCard>();
    public List<BattleModeCard> myMemoryList = new List<BattleModeCard>();
    public List<BattleModeCard> GraveYardList = new List<BattleModeCard>();
    public List<BattleModeCard> myFieldList = new List<BattleModeCard>{null, null, null, null, null};

    public List<BattleModeCard> enemyHandList = new List<BattleModeCard>();
    public List<BattleModeCard> enemyClockList = new List<BattleModeCard>();
    public List<BattleModeCard> enemyStockList = new List<BattleModeCard>();
    public List<BattleModeCard> enemyLevelList = new List<BattleModeCard>();
    public List<BattleModeCard> enemyGraveYardList = new List<BattleModeCard>();

    public List<BattleModeCard> myMariganList = new List<BattleModeCard>();

    public BattleModeCard climaxCard = null;

    public BattleClimaxCardUtil MyClimaxCardObject = null;
    public BattleDeckCardUtil MyDeckObject = null;
    public BattleMemoryCardUtil MyMemoryObject = null;
    public GameObject MyGraveYardObject = null;

    public GameObject EnemyClimaxCardObject = null;
    public GameObject EnemyDeckObject = null;
    public GameObject EnemyMemoryObject = null;
    public GameObject EnemyGraveYardObject = null;

    public bool MariganMode = false;
    public bool isAnimation = false;
    public bool isFirstAttacker = false;

    [SerializeField] OKDialog m_OKDialog;
    [SerializeField] ClockDialog m_ClockDialog;
    [SerializeField] Phase m_Phase;
    [SerializeField] DummyDeckAnimation m_DummyDeckAnimation;
    [SerializeField] StrixManager m_StrixManager;
    [SerializeField] BattleStrix m_BattleStrix;
    [SerializeField] BattleModeCardList m_BattleModeCardList;

    public EnumController.Turn phase = EnumController.Turn.VOID;

    [SerializeField] Text testPhaseText;
    [SerializeField] GameObject GameStartBtn;

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
        MyGraveYardObject.GetComponent<BattleGraveYardUtil>().setBattleModeCard(null);
        EnemyDeckObject.GetComponent<BattleDeckCardUtil>().ChangeFrontAndBack(false);
        EnemyClimaxCardObject.GetComponent<BattleClimaxCardUtil>().SetClimax(climaxCard);
        EnemyGraveYardObject.GetComponent<BattleGraveYardUtil>().setBattleModeCard(null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shuffle()
    {
        for(int i = myDeckList.Count - 1; i > 0; i--)
        {
            int r = Random.Range(0, i + 1);
            BattleModeCard temp = myDeckList[r];
            myDeckList[r] = myDeckList[i];
            myDeckList[i] = temp;
        } 
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
        m_OKDialog.SetParamater(EnumController.DialogParamater.Marigan);
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
        UpdateMyHandCards();
        UpdateMyGraveYardCards();
        m_BattleStrix.SendUpdateEnemyGraveYard(GraveYardList, isFirstAttacker);
        MariganMode = false;

        // 先攻の場合
        if (isFirstAttacker)
        {
            m_BattleStrix.SendMarigan();
        }
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

    public void AttackStart()
    {
        testPhaseText.text = "Attack";
        phase = EnumController.Turn.Player1_Attack;
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

    public void UpdateMyMainCards()
    {
        GetComponent<MyMainCardsManager>().updateMyFieldCards(myFieldList);
    }

    public void UpdateMyGraveYardCards()
    {
        MyGraveYardObject.GetComponent<BattleGraveYardUtil>().updateMyGraveYardCards(GraveYardList);
    }

    public void UpdateEnemyGraveYardCards(List<BattleModeCardTemp> list)
    {
        enemyGraveYardList = new List<BattleModeCard>();
        for(int i = 0; i < list.Count; i++)
        {
            BattleModeCard b = m_BattleModeCardList.ConvertCardNoToBattleModeCard(list[i].cardNo);
            enemyGraveYardList.Add(b);
        }
        EnemyGraveYardObject.GetComponent<BattleGraveYardUtil>().updateMyGraveYardCards(enemyGraveYardList);

        for(int i = 0; i < enemyGraveYardList.Count; i++)
        {
            if(enemyGraveYardList[i].sprite != null)
            {
                Debug.Log(enemyGraveYardList[i].name);
            }          
        }
    }

    public void GameStart()
    {
        if (m_StrixManager.isOwner)
        {
            if (CoinToss())
            {
                isFirstAttacker = true;
                logText.text = "先攻";
            }
            else
            {
                isFirstAttacker = false;
                logText.text = "後攻";
            }
            m_BattleStrix.SendSetIsFirstAttacker(isFirstAttacker);
            m_BattleStrix.SendGameStart();
        }
    }

    public bool CoinToss()
    {
        if (Random.Range(0, 2) == 0)
        {
            return true;
        }
        return false;
    }

    public void SetGameStartBtn()
    {
        // ルームのオーナーでない場合、ゲームスタートボタンを非活性にする
        GameStartBtn.SetActive(false);
    }
}
