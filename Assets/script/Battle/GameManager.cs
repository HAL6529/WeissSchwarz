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
    public List<BattleModeCard> HandOverList = new List<BattleModeCard>();

    public BattleModeCard MyClimaxCard = null;
    public BattleModeCard EnemyClimaxCard = null;

    public BattleModeCard DisCardForHandEncore = null;

    public Effect m_Effect;

    public EnumController.HandCardUtilStatus m_HandCardUtilStatus = EnumController.HandCardUtilStatus.VOID;

    public bool isAnimation = false;
    public bool isFirstAttacker = false;
    public bool isTurnPlayer = false;
    public bool isLevelUpProcess = false;
    public bool isAttackProcess = false;
    public bool isFirstAttacked = false;
    public int turn = 1;
    private static int HAND_LIMIT_NUM = 7;

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
    [SerializeField] WinAndLose m_WinAndLose;
    [SerializeField] DamageAnimationDialog m_DamageAnimationDialog;
    private MyMainCardsManager m_MyMainCardsManager;
    private MyHandCardsManager m_MyHandCardsManager;
    private MyStockCardsManager m_MyStockCardsManager;
    private MyClockCardsManager m_MyClockCardsManager;
    private MyLevelCardsManager m_MyLevelCardsManager;
    private EnemyMainCardsManager m_EnemyMainCardsManager;
    private EnemyHandsCardManager m_EnemyHandsCardManager;
    private EnemyClockCardsManager m_EnemyClockCardsManager;
    private EnemyStockCardsManager m_EnemyStockCardsManager;
    private EnemyLevelCardsManager m_EnemyLevelCardsManager;

    public EnumController.Turn phase = EnumController.Turn.VOID;

    [SerializeField] Text testPhaseText;
    [SerializeField] GameObject GameStartBtn;

    // Start is called before the first frame update
    void Start()
    {
        m_Effect = new Effect(this, m_BattleStrix);
        m_MyMainCardsManager = GetComponent<MyMainCardsManager>();
        m_MyHandCardsManager = GetComponent<MyHandCardsManager>();
        m_MyStockCardsManager = GetComponent<MyStockCardsManager>();
        m_MyClockCardsManager = GetComponent<MyClockCardsManager>();
        m_MyLevelCardsManager = GetComponent<MyLevelCardsManager>();
        m_EnemyMainCardsManager = GetComponent<EnemyMainCardsManager>();
        m_EnemyHandsCardManager = GetComponent<EnemyHandsCardManager>();
        m_EnemyClockCardsManager = GetComponent<EnemyClockCardsManager>();
        m_EnemyStockCardsManager = GetComponent<EnemyStockCardsManager>();
        m_EnemyLevelCardsManager = GetComponent<EnemyLevelCardsManager>();

        Syncronize();
        myBattleDeckCardUtil.ChangeFrontAndBack(false);
        m_EnemyHandsCardManager.updateEnemyHandCards(enemyHandList);
        m_EnemyClockCardsManager.updateEnemyClockCards(enemyClockList);
        m_EnemyStockCardsManager.updateEnemyStockCards(enemyStockList.Count);
        m_EnemyLevelCardsManager.updateEnemyLevelCards(enemyLevelList);
        enemyBattleMemoryCardUtil.setBattleModeCard(null);
        enemyBattleDeckCardUtil.ChangeFrontAndBack(false);
        enemyBattleGraveYardUtil.setBattleModeCard(null);
    }

    public void StandPhaseStart()
    {
        phase = EnumController.Turn.Stand;
        if (!isTurnPlayer || phase == EnumController.Turn.Clock)
        {
            return;
        }
        m_MyMainCardsManager.CallStand();
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
        Syncronize();

        m_BattleStrix.RpcToAll("ChangePhase", EnumController.Turn.Climax);
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
        EncoreStart();
        return;
    }

    public void MainStart()
    {

    }

    public void AttackStart()
    {
        
    }

    public void EncoreStart()
    {
        if (!isTurnPlayer)
        {
            return;
        }
        m_DialogManager.EncoreDialog(myFieldList, false);
        return;
    }

    public void SendEncoreDialogFromRPC()
    {
        m_DialogManager.EncoreDialog(myFieldList, true);
    }

    public void TurnChange()
    {
        SwitchTurnUtil();
        m_BattleStrix.RpcToAll("SendReceiveTurnChange", isFirstAttacker);
    }

    public void ReceiveTurnChange()
    {
        if (myHandList.Count > HAND_LIMIT_NUM)
        {
            m_HandCardUtilStatus = EnumController.HandCardUtilStatus.HAND_OVER;
            m_DialogManager.HandOverDialog(EnumController.HandOverDialogParamater.Active);
            return;
        }
        ReceiveTurnChange2();
    }

    public void HandOver()
    {
        for (int i = 0; i < HandOverList.Count; i++)
        {
            myHandList.Remove(HandOverList[i]);
            GraveYardList.Add(HandOverList[i]);
        }
        HandOverList = new List<BattleModeCard>();
        Syncronize();

        m_HandCardUtilStatus = EnumController.HandCardUtilStatus.VOID;

        ReceiveTurnChange2();
    }

    private void ReceiveTurnChange2()
    {
        DiscardClimaxCard();
        SwitchTurnUtil();
        m_BattleStrix.RpcToAll("SendReceiveReadyOK", isFirstAttacker);
    }

    public void SwitchTurnUtil()
    {
        // ターン終了時まで上がるパワーをリセット
        m_MyMainCardsManager.ExecuteResetPowerUpUntilTurnEnd();
        Syncronize();

        isTurnPlayer = !isTurnPlayer;
        turn++;
    }

    private void DiscardClimaxCard()
    {
        if (MyClimaxCard != null)
        {
            Debug.Log("DiscardClimaxCard");
            GraveYardList.Add(MyClimaxCard);
            SetMyClimaxCard(null);
            Syncronize();
        }
    }
    
    public void ReceiveReadyOK()
    {
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

        Syncronize();

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
        Syncronize();
    }

    public void MariganStart()
    {
        m_HandCardUtilStatus = EnumController.HandCardUtilStatus.MARIGAN_MODE;
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
        Syncronize();

        m_HandCardUtilStatus = EnumController.HandCardUtilStatus.VOID;
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

        Syncronize();
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
        Syncronize();
        ClockPhaseEnd();
        return;
    }

    public void onDirectAttack(int num)
    {
        int damage = m_MyMainCardsManager.GetFieldSoul(num) + 1;
        damage = damage + TrrigerCheck();
        m_BattleStrix.RpcToAll("Damage", damage, isTurnPlayer);
    }

    public void onFrontAttack(int num)
    {
        int damage = m_MyMainCardsManager.GetFieldSoul(num);
        damage = damage + TrrigerCheck();
        m_BattleStrix.RpcToAll("CallOKDialogForCounter", damage, num, isFirstAttacker);          
    }

    public void CounterCheck(int damage, int place)
    {
        for (int i = 0; i < myHandList.Count; i++)
        {
            if (myHandList[i].isCounter && myStockList.Count >= myHandList[i].cost && myLevelList.Count >= myHandList[i].level)
            {
                m_DialogManager.YesOrNoDialog(YesOrNoDialogParamater.CONFIRM_USE_COUNTER, null, damage, place);
                return;
            }
        }
        m_DialogManager.OKDialog(EnumController.OKDialogParamater.Counter_Not_Exist, damage, place);
    }

    public void onSideAttack(int num)
    {
        int damage = m_MyMainCardsManager.GetFieldSoul(num);
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

        Syncronize();

        if (myDeckList.Count == 0)
        {
            Refresh();
        }

        return num;
    }

    public void PowerCheck(int num)
    {
        Debug.Log("PowerCheck");
        int myPower = m_MyMainCardsManager.GetFieldPower(num);
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

        int enemyPower = m_EnemyMainCardsManager.GetFieldPower(enemyPlace);

        if(myPower > enemyPower)
        {
            m_EnemyMainCardsManager.CallReverse(enemyPlace);
            m_BattleStrix.RpcToAll("CallMyReverse", enemyPlace, isTurnPlayer);
            return;
        }
        else if (myPower == enemyPower)
        {
            m_EnemyMainCardsManager.CallReverse(enemyPlace);
            m_BattleStrix.RpcToAll("CallMyReverse", enemyPlace, isTurnPlayer);
            m_MyMainCardsManager.CallOnReverse(num);
            m_BattleStrix.RpcToAll("CallEnemyReverse", num, isTurnPlayer);
            return;
        }
        else
        {
            m_MyMainCardsManager.CallOnReverse(num);
            m_BattleStrix.RpcToAll("CallEnemyReverse", num, isTurnPlayer);
            return;
        }
    }

    public void PowerCheckForLevelUpDialog(int num)
    {
        PowerCheck(num);
        m_BattleStrix.RpcToAll("SetIsAttackProcess", false);
    }

    public void Damage(int num)
    {
        List<BattleModeCard> temp = new List<BattleModeCard>();
        if(num < 0)
        {
            m_BattleStrix.RpcToAll("SetIsAttackProcess", false);
            return;
        }

        for (int i = 0; i < num; i++)
        {
            temp.Add(myDeckList[0]);
            if (myDeckList[0].type == EnumController.Type.CLIMAX)
            {
                myDeckList.RemoveAt(0);
                for (int n = 0; n < temp.Count; n++)
                {
                    GraveYardList.Add(temp[n]);
                }
                Syncronize();
                m_BattleStrix.RpcToAll("SetIsAttackProcess", false);
                return;
            }
            myDeckList.RemoveAt(0);

            Syncronize();
            if (myDeckList.Count == 0)
            {
                Refresh();
            }
        }
        // ダメージアニメーションの再生
        Debug.Log(temp.Count);
        m_DamageAnimationDialog.SetBattleModeCard(temp);

        for (int n = 0; n < temp.Count; n++)
        {
            myClockList.Add(temp[n]);
        }
        Syncronize();

        if (LevelUpCheck())
        {
            m_BattleStrix.RpcToAll("UpdateIsLevelUpProcess", true);
            return;
        }

        m_BattleStrix.RpcToAll("SetIsAttackProcess", false);
        return;
    }

    public void DamageForFrontAttack(int damage, int place)
    {
        List<BattleModeCard> temp = new List<BattleModeCard>();

        int placeNum = -1;
        switch (place)
        {
            case 0:
                placeNum = 2;
                break;
            case 1:
                placeNum = 1;
                break;
            case 2:
                placeNum = 0;
                break;
            default:
                placeNum = 0;
                break;
        }

        if (damage < 0)
        {
            PowerCheck(placeNum);
            m_BattleStrix.RpcToAll("SetIsAttackProcess", false);
            return;
        }

        for (int i = 0; i < damage; i++)
        {
            temp.Add(myDeckList[0]);
            if (myDeckList[0].type == EnumController.Type.CLIMAX)
            {
                myDeckList.RemoveAt(0);
                for (int n = 0; n < temp.Count; n++)
                {
                    GraveYardList.Add(temp[n]);
                }
                Syncronize();

                PowerCheck(placeNum);
                m_BattleStrix.RpcToAll("SetIsAttackProcess", false);
                return;
            }
            myDeckList.RemoveAt(0);

            Syncronize();
            if (myDeckList.Count == 0)
            {
                Refresh();
            }
        }

        for (int n = 0; n < temp.Count; n++)
        {
            myClockList.Add(temp[n]);
        }
        Syncronize();

        if (LevelUpCheck(place))
        {
            m_BattleStrix.RpcToAll("UpdateIsLevelUpProcess", true);
            return;
        }

        PowerCheck(placeNum);

        m_BattleStrix.RpcToAll("SetIsAttackProcess", false);
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
        Syncronize();
    }

    /// <summary>
    /// レベルアップする場合true
    /// </summary>
    /// <returns></returns>
    private bool LevelUpCheck()
    {
        if (myClockList.Count < 7)
        {
            return false;
        }

        if(myLevelList.Count < 3)
        {
            m_DialogManager.LevelUpDialog(myClockList);
            return true;
        }
        m_BattleStrix.RpcToAll("WinAndLose_Win", isFirstAttacker);
        m_WinAndLose.Lose();
        return false;
    }

    /// <summary>
    /// レベルアップする場合true
    /// </summary>
    /// <returns></returns>
    private bool LevelUpCheck(int place)
    {
        if (myClockList.Count < 7)
        {
            return false;
        }

        if (myLevelList.Count < 3)
        {
            m_DialogManager.LevelUpDialog(myClockList);
            return true;
        }

        m_BattleStrix.RpcToAll("WinAndLose_Win", isFirstAttacker);
        m_WinAndLose.Lose();
        return false;
    }

    /// <summary>
    /// 色発生がクリアできているかチェックする
    /// </summary>
    /// <param name="color"></param>
    /// <returns></returns>
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

    public void Syncronize()
    {
        // デッキ枚数の更新
        myBattleDeckCardUtil.SetDeckCount(myDeckList.Count);
        m_BattleStrix.RpcToAll("UpdateEnemyDeckCount", myDeckList.Count, isFirstAttacker);

        // 手札の枚数の更新
        m_MyHandCardsManager.updateMyHandCards(myHandList);
        m_BattleStrix.SendUpdateEnemyHandCards(myHandList, isFirstAttacker);

        // 墓地のカードの更新
        myBattleGraveYardUtil.updateMyGraveYardCards(GraveYardList);
        m_BattleStrix.SendUpdateEnemyGraveYard(GraveYardList, isFirstAttacker);

        // クロックのカードの更新
        m_MyClockCardsManager.updateMyClockCards(myClockList);
        m_BattleStrix.SendUpdateEnemyClock(myClockList, isFirstAttacker);

        // ストックのカードの更新
        m_MyStockCardsManager.updateMyStockCards(myStockList.Count);
        m_BattleStrix.SendUpdateEnemyStockCards(myStockList, isFirstAttacker);

        // レベル置き場のカードの更新
        m_MyLevelCardsManager.updateMyLevelCards(myLevelList);
        m_BattleStrix.SendUpdateLevelCards(myLevelList, isFirstAttacker);

        // 思い出のカードの更新
        myBattleMemoryCardUtil.updateMyMemoryCards(myMemoryList);

        // クライマックスカードの更新
        myBattleClimaxCardUtil.SetClimax(MyClimaxCard);
        enemyBattleClimaxCardUtil.SetClimax(EnemyClimaxCard);
        BattleModeCardTemp MyClimaxTemp = new BattleModeCardTemp(MyClimaxCard);
        BattleModeCardTemp EnemyClimaxTemp = new BattleModeCardTemp(EnemyClimaxCard);
        m_BattleStrix.RpcToAll("UpdateClimaxCard", MyClimaxTemp, EnemyClimaxTemp, isFirstAttacker);

        // メインのカードの更新
        // パワー、レベル、特徴の計算
        m_MyMainCardsManager.FieldPowerAndLevelAndAttributeAndSoulReset();
        m_BattleStrix.SendUpdateMainCards(myFieldList, m_MyMainCardsManager.GetFieldPower(), isFirstAttacker);
    }

    public int GetHAND_LIMIT_NUM()
    {
        return HAND_LIMIT_NUM;
    }

    public void UpdateEnemyDeckCount(int num)
    {
        enemyBattleDeckCardUtil.SetDeckCount(num);
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
        m_EnemyHandsCardManager.updateEnemyHandCards(enemyHandList);
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
        m_EnemyStockCardsManager.updateEnemyStockCards(list.Count);
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
        m_EnemyClockCardsManager.updateEnemyClockCards(enemyClockList);
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
        m_EnemyMainCardsManager.updateEnemyFieldCards(enemyFieldList);
        m_EnemyMainCardsManager.SetFieldPower(FieldPowerList);
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

    public void UpdateEnemyLevelCards(List<BattleModeCardTemp> list)
    {
        enemyLevelList = new List<BattleModeCard>();
        for (int i = 0; i < list.Count; i++)
        {
            BattleModeCard b = m_BattleModeCardList.ConvertCardNoToBattleModeCard(list[i].cardNo);
            enemyLevelList.Add(b);
        }
        m_EnemyLevelCardsManager.updateEnemyLevelCards(enemyLevelList);
    }

    /// <summary>
    /// 相手フィールドのクライマックスを更新する
    /// </summary>
    /// <param name="m_BattleModeCardTemp"></param>
    public void UpdateClimaxCard(BattleModeCardTemp m_enemyClimax, BattleModeCardTemp m_myClimax)
    {
        BattleModeCard mClimax = m_BattleModeCardList.ConvertCardNoToBattleModeCard(m_myClimax.cardNo);
        BattleModeCard eClimax = m_BattleModeCardList.ConvertCardNoToBattleModeCard(m_enemyClimax.cardNo);
        MyClimaxCard = mClimax;
        EnemyClimaxCard = eClimax;
        myBattleClimaxCardUtil.SetClimax(MyClimaxCard);
        enemyBattleClimaxCardUtil.SetClimax(EnemyClimaxCard);
    }
}
