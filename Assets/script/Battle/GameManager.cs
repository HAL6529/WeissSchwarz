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
    public List<BattleModeCard> enemyFieldList = new List<BattleModeCard> { null, null, null, null, null };

    public List<BattleModeCard> myMariganList = new List<BattleModeCard>();

    public BattleModeCard ClimaxCard = null;

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
    public bool isTurnPlayer = false;
    public int PlayerLevel = 0;
    private int turn = 1;

    [SerializeField] Phase m_Phase;
    [SerializeField] DummyDeckAnimation m_DummyDeckAnimation;
    [SerializeField] StrixManager m_StrixManager;
    [SerializeField] BattleStrix m_BattleStrix;
    [SerializeField] BattleModeCardList m_BattleModeCardList;
    [SerializeField] DialogManager m_DialogManager;

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
        GetComponent<EnemyClockCardsManager>().updateEnemyClockCards(enemyClockList);
        GetComponent<EnemyStockCardsManager>().updateEnemyStockCards(enemyStockList.Count);
        GetComponent<EnemyLevelCardsManager>().updateEnemyLevelCards(enemyLevelList.Count);
        MyDeckObject.GetComponent<BattleDeckCardUtil>().ChangeFrontAndBack(false);
        MyClimaxCardObject.GetComponent<BattleClimaxCardUtil>().SetClimax(ClimaxCard);
        MyGraveYardObject.GetComponent<BattleGraveYardUtil>().setBattleModeCard(null);
        EnemyDeckObject.GetComponent<BattleDeckCardUtil>().ChangeFrontAndBack(false);
        EnemyClimaxCardObject.GetComponent<BattleClimaxCardUtil>().SetClimax(ClimaxCard);
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
        m_DialogManager.OKDialog(EnumController.OKDialogParamater.Marigan);
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
        turn = 1;

        // 先攻の場合
        if (isFirstAttacker)
        {
            m_BattleStrix.SendMarigan();
        }
        else
        {
            m_BattleStrix.SendDrawPhase();
        }
    }

    public void StandPhaseStart()
    {
        if (isTurnPlayer)
        {
            GetComponent<MyMainCardsManager>().CallStand();
            m_BattleStrix.SendDrawPhase();
        }
    }

    public void DrawPhaseStart()
    {
        DrawPhaseEnd();
    }

    public void DrawPhaseEnd()
    {
        Draw();
        m_BattleStrix.SendClockPhase();
    }

    public void ClockPhaseStart()
    {
        m_DialogManager.OKDialog(EnumController.OKDialogParamater.CLOCK);
    }

    public void ClockPhaseEnd()
    {
        m_BattleStrix.SendMainPhase();
    }

    public void MainStart()
    {

    }

    /// <summary>
    /// クライマックスフェイズに入るときに呼び出す
    /// </summary>
    public void SendClimaxPhase(BattleModeCard m_BattleModeCard)
    {
        ClimaxCard = m_BattleModeCard;
        myHandList.Remove(m_BattleModeCard);
        UpdateMyHandCards();
        MyClimaxCardObject.GetComponent<BattleClimaxCardUtil>().SetClimax(ClimaxCard);
        m_BattleStrix.SendClimaxPhase(m_BattleModeCard, isTurnPlayer);
    }

    public void ClimaxStart(BattleModeCardTemp m_BattleModeCardTemp)
    {
        BattleModeCard b = m_BattleModeCardList.ConvertCardNoToBattleModeCard(m_BattleModeCardTemp.cardNo);
        ClimaxCard = b;
        EnemyClimaxCardObject.GetComponent<BattleClimaxCardUtil>().SetClimax(ClimaxCard);
    }

    /// <summary>
    /// アタックフェイズに入るときに呼び出す
    /// </summary>
    public void SendAttackPhase()
    {
        m_BattleStrix.SendAttackPhase();
    }

    public void AttackStart()
    {
        
    }

    /// <summary>
    /// エンドフェイズに入るときに呼び出す
    /// </summary>
    public void SendEncorePhase()
    {
        m_BattleStrix.SendEncorePhase();
    }

    public void EncoreStart()
    {
        TurnChange();
    }

    public void TurnChange()
    {
        turn++;
        if (isTurnPlayer)
        {
            isTurnPlayer = false;
        }
        else
        {
            isTurnPlayer = true;
        }
        m_BattleStrix.SendStandPhase();
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

    public void UpdateMyStockCards()
    {
        GetComponent<MyStockCardsManager>().updateMyStockCards(myStockList.Count);
    }

    public void UpdateMyClockCards()
    {
        GetComponent<MyClockCardsManager>().updateMyClockCards(myClockList);
        m_BattleStrix.SendUpdateEnemyClock(myClockList, isTurnPlayer);
    }

    public void UpdateEnemyClock(List<BattleModeCardTemp> list)
    {
        enemyClockList = new List<BattleModeCard>();
        for (int i = 0; i < list.Count; i++)
        {
            BattleModeCard b = m_BattleModeCardList.ConvertCardNoToBattleModeCard(list[i].cardNo);
            enemyClockList.Add(b);
        }
        GetComponent<EnemyClockCardsManager>().updateEnemyClockCards(enemyClockList);
    }

    public void UpdateMyMainCards()
    {
        GetComponent<MyMainCardsManager>().updateMyFieldCards(myFieldList);
        m_BattleStrix.SendUpdateMainCards(myFieldList, isTurnPlayer);
    }

    public void UpdateEnemyMainCards(List<BattleModeCardTemp> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] == null)
            {
                enemyFieldList[i] = null;
                continue;
            }
            BattleModeCard b = m_BattleModeCardList.ConvertCardNoToBattleModeCard(list[i].cardNo);
            enemyFieldList[i] = b;
        }
        GetComponent<EnemyMainCardsManager>().updateEnemyFieldCards(enemyFieldList);
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
    }

    public void onDirectAttack(int num)
    {
        int damage = myFieldList[num].soul + 1;
        damage = damage + TrrigerCheck();
        m_BattleStrix.SendDamage(damage, isTurnPlayer);
    }

    public void onFrontAttack(int num)
    {
        int damage = myFieldList[num].soul;
        damage = damage + TrrigerCheck();
        m_BattleStrix.SendDamage(damage, isTurnPlayer);
    }

    public void onSideAttack(int num)
    {
        int damage = myFieldList[num].soul;
        int minus = 0;
        switch (num)
        {
            case 0:
                minus = enemyFieldList[2].level;
                break;
            case 1:
                minus = enemyFieldList[1].level;
                break;
            case 2:
                minus = enemyFieldList[0].level;
                break;
            default:
                minus = 0;
                break;
        }
        damage = damage - minus;
        damage = damage + TrrigerCheck();
        m_BattleStrix.SendDamage(damage, isTurnPlayer);
    }

    private int TrrigerCheck()
    {
        int num = 0;
        switch(myDeckList[0].trigger)
        {
            case EnumController.Trriger.DOUBLE_SOUL:
                num = 2;
                break;
            case EnumController.Trriger.STANDBY:
            case EnumController.Trriger.BOUNCE:
            case EnumController.Trriger.SHOT:
            case EnumController.Trriger.SOUL:
                num = 1;
                break;
            case EnumController.Trriger.COMEBACK:
            case EnumController.Trriger.BOOK:
            case EnumController.Trriger.GATE:
            case EnumController.Trriger.CHOICE:
            case EnumController.Trriger.TREASURE:
            case EnumController.Trriger.POOL:
            case EnumController.Trriger.NONE:
            case EnumController.Trriger.VOID:
                break;
            default:
                break;
        }
        myStockList.Add(myDeckList[0]);
        myDeckList.RemoveAt(0);
        UpdateMyStockCards();
        m_BattleStrix.SendUpdateEnemyStockCards(myStockList, isTurnPlayer);
        return num;
    }

    public void Damage(int num)
    {
        List<BattleModeCard> temp = new List<BattleModeCard>();
        if(num < 0)
        {
            return;
        }

        for (int i = 0; i < num; i++)
        {
            temp.Add(myDeckList[i]);
            if (myDeckList[i].type == EnumController.Type.CLIMAX)
            {
                myDeckList.RemoveAt(i);
                for (int n = 0; n < temp.Count; n++)
                {
                    GraveYardList.Add(temp[n]);
                }
                UpdateMyGraveYardCards();
                return;
            }
            myDeckList.RemoveAt(i);
        }

        for (int n = 0; n < temp.Count; n++)
        {
            myClockList.Add(temp[n]);
        }
        UpdateMyClockCards();
        return;
    }

    public void GameStart()
    {
        if (m_StrixManager.isOwner)
        {
            if (CoinToss())
            {
                isFirstAttacker = true;
                isTurnPlayer = true;
            }
            else
            {
                isFirstAttacker = false;
                isTurnPlayer = false;
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

    public void ChangePhase(EnumController.Turn turn)
    {
          phase = turn;
    }
}
