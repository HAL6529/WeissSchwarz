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
    public List<BattleModeCard> enemyMemoryList = new List<BattleModeCard>();
    public List<BattleModeCard> enemyGraveYardList = new List<BattleModeCard>();
    public List<BattleModeCard> enemyFieldList = new List<BattleModeCard> { null, null, null, null, null };

    public List<BattleModeCard> myMariganList = new List<BattleModeCard>();

    public BattleModeCard MyClimaxCard = null;
    public BattleModeCard EnemyClimaxCard = null;

    public Effect m_Effect;

    public bool MariganMode = false;
    public bool isAnimation = false;
    public bool isFirstAttacker = false;
    public bool isTurnPlayer = false;
    public bool isLevelUpProcess = false;
    public bool isMyReady = false;
    public bool isEnemyReady = false;
    public bool enemyWait = false;
    public int PlayerLevel = 0;
    public int turn = 1;

    [SerializeField] Phase m_Phase;
    [SerializeField] DummyDeckAnimation m_DummyDeckAnimation;
    [SerializeField] StrixManager m_StrixManager;
    [SerializeField] BattleStrix m_BattleStrix;
    [SerializeField] BattleModeCardList m_BattleModeCardList;
    public DialogManager m_DialogManager;
    [SerializeField] BattleDeckCardUtil myBattleDeckCardUtil;
    [SerializeField] BattleDeckCardUtil enemyBattleDeckCardUtil;
    [SerializeField] BattleGraveYardUtil myBattleGraveYardUtil;
    [SerializeField] BattleGraveYardUtil enemyBattleGraveYardUtil;
    [SerializeField] BattleMemoryCardUtil myBattleMemoryCardUtil;
    [SerializeField] BattleMemoryCardUtil enemyBattleMemoryCardUtil;
    [SerializeField] BattleClimaxCardUtil myBattleClimaxCardUtil;
    [SerializeField] BattleClimaxCardUtil enemyBattleClimaxCardUtil;

    public EnumController.Turn phase = EnumController.Turn.VOID;

    [SerializeField] Text testPhaseText;
    [SerializeField] GameObject GameStartBtn;

    // Start is called before the first frame update
    void Start()
    {
        m_Effect = new Effect(this, m_BattleStrix);
        UpdateMyHandCards();
        UpdateMyClockCards();
        UpdateMyMemoryCards();
        UpdateMyStockCards();
        UpdateMyLevelCards();
        UpdateMyGraveYardCards();
        myBattleDeckCardUtil.ChangeFrontAndBack(false);
        GetComponent<EnemyHandsCardManager>().updateEnemyHandCards(enemyHandList);
        GetComponent<EnemyClockCardsManager>().updateEnemyClockCards(enemyClockList);
        GetComponent<EnemyStockCardsManager>().updateEnemyStockCards(enemyStockList.Count);
        GetComponent<EnemyLevelCardsManager>().updateEnemyLevelCards(enemyLevelList);
        myBattleClimaxCardUtil.SetClimax(MyClimaxCard);
        enemyBattleMemoryCardUtil.setBattleModeCard(null);
        enemyBattleDeckCardUtil.ChangeFrontAndBack(false);
        enemyBattleClimaxCardUtil.SetClimax(EnemyClimaxCard);
        enemyBattleGraveYardUtil.setBattleModeCard(null);
    }

    public void StandPhaseStart()
    {
        phase = EnumController.Turn.Stand;
        m_BattleStrix.RpcToAll("SetEnemyWait", isFirstAttacker);
        if (!isTurnPlayer || phase == EnumController.Turn.Clock)
        {
            return;
        }
        while (enemyWait)
        {
            break;
        }

        GetComponent<MyMainCardsManager>().CallStand();
        m_BattleStrix.RpcToAll("ChangePhase", EnumController.Turn.Draw);
        m_BattleStrix.RpcToAll("DrawPhase");
    }

    public void DrawPhaseStart()
    {
        DrawPhaseEnd();
    }

    public void DrawPhaseEnd()
    {
        if (!isTurnPlayer)
        {
            return;
        }
        Debug.Log("DrawPhaseEnd");
        Draw();
        m_BattleStrix.RpcToAll("ChangePhase", EnumController.Turn.Clock);
        m_BattleStrix.RpcToAll("ClockPhase");
    }

    public void ClockPhaseStart()
    {
        if (!isTurnPlayer)
        {
            return;
        }
        m_DialogManager.OKDialog(EnumController.OKDialogParamater.CLOCK);
    }

    public void ClockPhaseEnd()
    {
        if (!isTurnPlayer)
        {
            return;
        }
        m_BattleStrix.RpcToAll("ChangePhase", EnumController.Turn.Main);
        m_BattleStrix.RpcToAll("MainPhase");
    }

    /// <summary>
    /// クライマックスフェイズに入るときに呼び出す
    /// </summary>
    public void SendClimaxPhase(BattleModeCard m_BattleModeCard)
    {
        if (!isTurnPlayer || isLevelUpProcess)
        {
            return;
        }
        SetMyClimaxCard(m_BattleModeCard);
        myHandList.Remove(m_BattleModeCard);

        UpdateMyHandCards();
        m_BattleStrix.SendUpdateEnemyHandCards(myHandList, isTurnPlayer);

        myBattleClimaxCardUtil.SetClimax(MyClimaxCard);
        enemyBattleClimaxCardUtil.SetClimax(EnemyClimaxCard);
        BattleModeCardTemp temp = new BattleModeCardTemp(m_BattleModeCard);
        m_BattleStrix.RpcToAll("ChangePhase", EnumController.Turn.Climax);
        m_BattleStrix.RpcToAll("UpdateClimaxCard", temp, isTurnPlayer);
    }

    private void SetMyClimaxCard(BattleModeCard m_BattleModeCard)
    {
        MyClimaxCard = m_BattleModeCard;
        EnemyClimaxCard = null;
    }

    private void SetEnemyClimaxCard(BattleModeCard m_BattleModeCard)
    {
        MyClimaxCard = null;
        EnemyClimaxCard = m_BattleModeCard;
    }

    /// <summary>
    /// アタックフェイズに入るときに呼び出す
    /// </summary>
    public void SendAttackPhase()
    {
        if (!isTurnPlayer || isLevelUpProcess)
        {
            return;
        }
        m_BattleStrix.RpcToAll("ChangePhase", EnumController.Turn.Attack);
        m_BattleStrix.RpcToAll("AttackPhase");
    }

    /// <summary>
    /// アンコールフェイズに入るときに呼び出す
    /// </summary>
    public void SendEncorePhase()
    {
        if (!isTurnPlayer || isLevelUpProcess)
        {
            return;
        }
        m_BattleStrix.RpcToAll("ChangePhase", EnumController.Turn.Encore);
        m_BattleStrix.RpcToAll("EncorePhase");
        return;
    }

    /// <summary>
    /// 相手フィールドのクライマックスを更新する
    /// </summary>
    /// <param name="m_BattleModeCardTemp"></param>
    public void UpdateClimaxCard(BattleModeCardTemp m_BattleModeCardTemp)
    {
        BattleModeCard b = m_BattleModeCardList.ConvertCardNoToBattleModeCard(m_BattleModeCardTemp.cardNo);
        SetEnemyClimaxCard(b);
        myBattleClimaxCardUtil.SetClimax(MyClimaxCard);
        enemyBattleClimaxCardUtil.SetClimax(EnemyClimaxCard);
    }

    public void MainStart()
    {

    }

    public void AttackStart()
    {
        
    }

    public void EncoreStart()
    {
        Debug.Log("EncoreStart");
        if (!isTurnPlayer)
        {
            return;
        }
        m_DialogManager.EncoreDialog(myFieldList);
        return;
    }

    public void SendEncoreDialog()
    {
        m_DialogManager.EncoreDialog(myFieldList);
    }

    public void TurnChange()
    {
        if(MyClimaxCard != null)
        {
            GraveYardList.Add(MyClimaxCard);
            UpdateMyGraveYardCards();
            m_BattleStrix.SendUpdateEnemyGraveYard(GraveYardList, isFirstAttacker);

            SetMyClimaxCard(null);
            myBattleClimaxCardUtil.SetClimax(MyClimaxCard);
            enemyBattleClimaxCardUtil.SetClimax(EnemyClimaxCard);
            BattleModeCardTemp temp = new BattleModeCardTemp(null);
            m_BattleStrix.RpcToAll("UpdateClimaxCard", temp, isTurnPlayer);

            // パワー、レベル、特徴の計算
            GetComponent<MyMainCardsManager>().FieldPowerAndLevelAndAttributeReset();
            m_BattleStrix.SendUpdateMainCards(myFieldList, GetComponent<MyMainCardsManager>().GetFieldPower(), isTurnPlayer);
        }
        enemyWait = true;
        Invoke("TurnChange2", 1.0f);
    }

    private void TurnChange2()
    {
        isTurnPlayer = !isTurnPlayer;
        turn++;
        StandPhaseStart();
    }

    public void Shuffle()
    {
        for (int i = myDeckList.Count - 1; i > 0; i--)
        {
            int r = Random.Range(0, i + 1);
            BattleModeCard temp = myDeckList[r];
            myDeckList[r] = myDeckList[i];
            myDeckList[i] = temp;
        }
    }

    public void Refresh()
    {
        for(int i = 0; i < GraveYardList.Count; i++)
        {
            myDeckList.Add(GraveYardList[i]);
        }
        GraveYardList = new List<BattleModeCard>();
        Shuffle();
        myClockList.Add(myDeckList[0]);
        myDeckList.RemoveAt(0);

        UpdateMyClockCards();

        UpdateMyDeckCount();
        m_BattleStrix.RpcToAll("UpdateEnemyDeckCount", myDeckList.Count, isTurnPlayer);

        UpdateMyGraveYardCards();
        m_BattleStrix.SendUpdateEnemyGraveYard(GraveYardList, isFirstAttacker);

        if (LevelUpCheck())
        {
            m_BattleStrix.RpcToAll("UpdateIsLevelUpProcess", true);
            m_DialogManager.SetIsClockAndTwoDrawProcessOfLevelUpDialog();
            return;
        }
    }

    public void FirstDraw()
    {
        for (int i = 0; i < 5; i++)
        {
            myHandList.Add(myDeckList[0]);
            myDeckList.RemoveAt(0);
        }
        UpdateMyDeckCount();
        m_BattleStrix.RpcToAll("UpdateEnemyDeckCount", myDeckList.Count, isTurnPlayer);

        GetComponent<MyHandCardsManager>().updateMyHandCards(myHandList);
        m_BattleStrix.SendUpdateEnemyHandCards(myHandList, isTurnPlayer);
    }

    public void MariganStart()
    {
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
        UpdateMyDeckCount();
        m_BattleStrix.RpcToAll("UpdateEnemyDeckCount", myDeckList.Count, isTurnPlayer);

        UpdateMyHandCards();
        m_BattleStrix.SendUpdateEnemyHandCards(myHandList, isTurnPlayer);

        UpdateMyGraveYardCards();
        m_BattleStrix.SendUpdateEnemyGraveYard(GraveYardList, isFirstAttacker);

        MariganMode = false;
        turn = 1;

        // 先攻の場合
        if (isFirstAttacker)
        {
            m_BattleStrix.RpcToAll("MariganStart");
        }
        else
        {
            m_BattleStrix.RpcToAll("ChangePhase", EnumController.Turn.Draw);
            m_BattleStrix.RpcToAll("DrawPhase");
        }
    }

    public void Draw()
    {
        myHandList.Add(myDeckList[0]);
        myDeckList.RemoveAt(0);
        if (myDeckList.Count == 0)
        {
            Refresh();
        }

        UpdateMyDeckCount();
        m_BattleStrix.RpcToAll("UpdateEnemyDeckCount", myDeckList.Count, isTurnPlayer);

        UpdateMyHandCards();
        m_BattleStrix.SendUpdateEnemyHandCards(myHandList, isTurnPlayer);
    }

    public void ClockAndTwoDraw(BattleModeCard m_BattleModeCard)
    {
        if (m_BattleModeCard != null)
        {
            myClockList.Add(m_BattleModeCard);
            myHandList.Remove(m_BattleModeCard);

            if (LevelUpCheck())
            {
                m_BattleStrix.RpcToAll("UpdateIsLevelUpProcess", true);
                m_DialogManager.SetIsClockAndTwoDrawProcessOfLevelUpDialog();
                return;
            }

            ClockAndTwoDraw2();
            return;
        }
        else
        {
            ClockPhaseEnd();
            return;
        }
    }

    public void ClockAndTwoDraw2()
    {
        Draw();
        Draw();
        UpdateMyClockCards();
        ClockPhaseEnd();
        return;
    }

    public void onDirectAttack(int num)
    {
        int damage = myFieldList[num].soul + 1;
        damage = damage + TrrigerCheck();
        m_BattleStrix.RpcToAll("Damage", damage, isTurnPlayer);
    }

    public void onFrontAttack(int num)
    {
        int damage = myFieldList[num].soul;
        damage = damage + TrrigerCheck();
        m_BattleStrix.RpcToAll("Damage", damage, isTurnPlayer);
        PowerCheck(num);            
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
        m_BattleStrix.RpcToAll("Damage", damage, isTurnPlayer);
    }

    private int TrrigerCheck()
    {
        int num = 0;
        switch (myDeckList[0].trigger)
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

        UpdateMyDeckCount();
        m_BattleStrix.RpcToAll("UpdateEnemyDeckCount", myDeckList.Count, isTurnPlayer);

        UpdateMyStockCards();
        m_BattleStrix.SendUpdateEnemyStockCards(myStockList, isTurnPlayer);

        if(myDeckList.Count == 0)
        {
            Refresh();
        }

        return num;
    }

    private void PowerCheck(int num)
    {
        int myPower = GetComponent<MyMainCardsManager>().GetFieldPower(num);
        int enemyPlace = -1;

        switch (num)
        {
            case 0:
                enemyPlace = 2; 
                break;
            case 1:
                enemyPlace = 1;
                break;
            case 2:
                enemyPlace = 0;
                break;
            default : 
                break;
        }

        int enemyPower = GetComponent<EnemyMainCardsManager>().GetFieldPower(enemyPlace);

        if(myPower > enemyPower)
        {
            GetComponent<EnemyMainCardsManager>().CallReverse(enemyPlace);
            m_BattleStrix.RpcToAll("CallMyReverse", enemyPlace, isTurnPlayer);
            return;
        }
        else if (myPower == enemyPower)
        {
            GetComponent<EnemyMainCardsManager>().CallReverse(enemyPlace);
            m_BattleStrix.RpcToAll("CallMyReverse", enemyPlace, isTurnPlayer);
            GetComponent<MyMainCardsManager>().CallOnReverse(num);
            m_BattleStrix.RpcToAll("CallEnemyReverse", num, isTurnPlayer);
            return;
        }
        else
        {
            GetComponent<MyMainCardsManager>().CallOnReverse(num);
            m_BattleStrix.RpcToAll("CallEnemyReverse", num, isTurnPlayer);
            return;
        }
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
                m_BattleStrix.SendUpdateEnemyGraveYard(GraveYardList, isFirstAttacker);

                UpdateMyDeckCount();
                m_BattleStrix.RpcToAll("UpdateEnemyDeckCount", myDeckList.Count, isTurnPlayer);
                return;
            }
            myDeckList.RemoveAt(i);

            UpdateMyDeckCount();
            m_BattleStrix.RpcToAll("UpdateEnemyDeckCount", myDeckList.Count, isTurnPlayer);
            if (myDeckList.Count == 0)
            {
                Refresh();
            }
        }

        for (int n = 0; n < temp.Count; n++)
        {
            myClockList.Add(temp[n]);
        }
        UpdateMyClockCards();

        if (LevelUpCheck())
        {
            m_BattleStrix.RpcToAll("UpdateIsLevelUpProcess", true);
        }

        return;
    }

    public void GameStart()
    {
        if (m_StrixManager.isOwner)
        {
            GameStartBtn.SetActive(false);
            if (CoinToss())
            {
                isFirstAttacker = true;
                isTurnPlayer = true;
                m_BattleStrix.RpcToAll("SetIsFirstAttacker", false);
            }
            else
            {
                isFirstAttacker = false;
                isTurnPlayer = false;
                m_BattleStrix.RpcToAll("SetIsFirstAttacker", true);
            }

            m_BattleStrix.RpcToAll(nameof(GameStart));
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

    public void LevelUp(int num)
    {
        myLevelList.Add(myClockList[num]);
        myClockList.RemoveAt(num);
        for (int i = 0; i < 6; i++)
        {
            GraveYardList.Add(myClockList[0]);
            myClockList.RemoveAt(0);
        }
        PlayerLevel++;

        UpdateMyClockCards();

        UpdateMyGraveYardCards();
        m_BattleStrix.SendUpdateEnemyGraveYard(GraveYardList, isFirstAttacker);

        UpdateMyLevelCards();
        m_BattleStrix.SendUpdateLevelCards(myLevelList, isFirstAttacker);
    }

    private bool LevelUpCheck()
    {
        if (myClockList.Count < 7)
        {
            return false;
        }
        m_DialogManager.LevelUpDialog(myClockList);
        return true;
    }

    public bool ColorCheck(EnumController.CardColor color)
    {
        for(int i = 0; i < myLevelList.Count; i++)
        {
            if (myLevelList[i].color == color)
            {
                return true;
            }
        }

        for (int i = 0; i < myClockList.Count; i++)
        {
            if (myClockList[i].color == color)
            {
                return true;
            }
        }
        return false;
    }

    public void UpdateMyDeckCount()
    {
        myBattleDeckCardUtil.SetDeckCount(myDeckList.Count);
        return;
    }

    public void UpdateEnemyDeckCount(int num)
    {
        enemyBattleDeckCardUtil.SetDeckCount(num);
        return;
    }

    public void UpdateMyHandCards()
    {
        GetComponent<MyHandCardsManager>().updateMyHandCards(myHandList);
        return;
    }

    public void UpdateMyStockCards()
    {
        GetComponent<MyStockCardsManager>().updateMyStockCards(myStockList.Count);
        return;
    }

    public void UpdateMyMemoryCards()
    {
        myBattleMemoryCardUtil.updateMyMemoryCards(myMemoryList);
        return;
    }

    public void UpdateEnemyHandCards(List<BattleModeCardTemp> list)
    {
        enemyHandList = new List<BattleModeCard>();
        for (int i = 0; i < list.Count; i++)
        {
            BattleModeCard b = m_BattleModeCardList.ConvertCardNoToBattleModeCard(list[i].cardNo);
            enemyHandList.Add(b);
        }
        GetComponent<EnemyHandsCardManager>().updateEnemyHandCards(enemyHandList);
        return;
    }

    public void UpdateEnemyStockCards(List<BattleModeCardTemp> list)
    {
        enemyStockList = new List<BattleModeCard>();
        for (int i = 0; i < list.Count; i++)
        {
            BattleModeCard b = m_BattleModeCardList.ConvertCardNoToBattleModeCard(list[i].cardNo);
            enemyStockList.Add(b);
        }
        GetComponent<EnemyStockCardsManager>().updateEnemyStockCards(list.Count);
        return;
    }

    public void UpdateMyClockCards()
    {
        GetComponent<MyClockCardsManager>().updateMyClockCards(myClockList);
        m_BattleStrix.SendUpdateEnemyClock(myClockList, isTurnPlayer);
        return;
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
        return;
    }

    public void UpdateMyMainCards()
    {
        GetComponent<MyMainCardsManager>().updateMyFieldCards(myFieldList);
        return;
    }

    public void UpdateEnemyMainCards(List<BattleModeCardTemp> list, List<int> FieldPowerList)
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
        GetComponent<EnemyMainCardsManager>().SetFieldPower(FieldPowerList);
    }

    public void UpdateMyGraveYardCards()
    {
        myBattleGraveYardUtil.updateMyGraveYardCards(GraveYardList);
    }

    public void UpdateEnemyGraveYardCards(List<BattleModeCardTemp> list)
    {
        enemyGraveYardList = new List<BattleModeCard>();
        for (int i = 0; i < list.Count; i++)
        {
            BattleModeCard b = m_BattleModeCardList.ConvertCardNoToBattleModeCard(list[i].cardNo);
            enemyGraveYardList.Add(b);
        }
        enemyBattleGraveYardUtil.updateMyGraveYardCards(enemyGraveYardList);
    }

    public void UpdateMyLevelCards()
    {
        GetComponent<MyLevelCardsManager>().updateMyLevelCards(myLevelList);
    }

    public void UpdateEnemyLevelCards(List<BattleModeCardTemp> list)
    {
        enemyLevelList = new List<BattleModeCard>();
        for (int i = 0; i < list.Count; i++)
        {
            BattleModeCard b = m_BattleModeCardList.ConvertCardNoToBattleModeCard(list[i].cardNo);
            enemyLevelList.Add(b);
        }
        GetComponent<EnemyLevelCardsManager>().updateEnemyLevelCards(enemyLevelList);
    }
}
