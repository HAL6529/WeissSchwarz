using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EnumController;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text logText;

    [SerializeField] AudioClip DrawSE;

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

    public bool isTriggerAnimation = false;
    public bool isTriggerAnimationForEnemy = false;
    public bool isPhaseAnimation = false;
    public bool isDamageAnimation = false;

    public bool isFirstAttacker = false;
    public bool isTurnPlayer = false;
    public bool isLevelUpProcess = false;
    public bool isAttackProcess = false;
    public bool isFirstAttacked = false;
    public bool isEncoreDialogProcess = false;

    public bool executeActionList = false;

    /// <summary>
    /// 扉アイコンのためのトリガーがデッキ残り1枚でトリガーしたかの判定用
    /// </summary>
    private bool isLastTrigger = false;

    public int turn = 1;
    private static int HAND_LIMIT_NUM = 7;

    [SerializeField] Phase m_Phase;
    [SerializeField] DummyDeckAnimation m_DummyDeckAnimation;
    [SerializeField] StrixManager m_StrixManager;
    public BattleStrix m_BattleStrix;
    public BattleModeCardList m_BattleModeCardList;
    public DialogManager m_DialogManager;
    [SerializeField] BattleDeckCardUtil myBattleDeckCardUtil;
    [SerializeField] BattleDeckCardUtil enemyBattleDeckCardUtil;
    [SerializeField] BattleGraveYardUtil myBattleGraveYardUtil;
    [SerializeField] BattleGraveYardUtil enemyBattleGraveYardUtil;
    [SerializeField] BattleMemoryCardUtil myBattleMemoryCardUtil;
    [SerializeField] BattleEnemyMemoryCardUtil enemyBattleMemoryCardUtil;
    [SerializeField] BattleClimaxCardUtil myBattleClimaxCardUtil;
    [SerializeField] BattleClimaxCardUtil enemyBattleClimaxCardUtil;
    [SerializeField] WinAndLose m_WinAndLose;
    [SerializeField] ComeBackDetail m_ComeBackDetail;
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

    /// <summary>
    /// トリガーチェック時に次に行う処理の判別のために使用
    /// </summary>
    private EnumController.Trigger trigger = EnumController.Trigger.VOID;

    /// <summary>
    /// テストの際に使うトリガー用 BattleModeDeckで書き換える
    /// </summary>
    public BattleModeCard testTrigger = null;

    /// <summary>
    /// ダメージを受けた時どれだけショット効果が蓄積されているか
    /// </summary>
    public List<EnumController.Shot> ReceiveShotList = new List<EnumController.Shot>();

    public List<EnumController.Shot> SendShotList = new List<EnumController.Shot>();

    /// <summary>
    /// 次に行うActionList
    /// </summary>
    public List<Action> ActionList = new List<Action>();

    public ExecuteAction m_ExecuteAction = new ExecuteAction();

    [SerializeField] Text testPhaseText;

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
        enemyBattleMemoryCardUtil.updateEnemyMemoryCards(enemyMemoryList);
        enemyBattleDeckCardUtil.ChangeFrontAndBack(false);
        enemyBattleGraveYardUtil.setBattleModeCard(null);
    }

    public void AttackStart()
    {

    }

    public void ChangePhase(EnumController.Turn turn)
    {
        phase = turn;
    }

    public void ClockAndTwoDraw(BattleModeCard m_BattleModeCard)
    {
        if (m_BattleModeCard != null)
        {
            myClockList.Add(m_BattleModeCard);
            myHandList.Remove(m_BattleModeCard);

            if (LevelUpCheck())
            {
                ActionList.Add(new Action(this, EnumController.Action.ClockAndTwoDraw));
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

    public void CounterCheck(int damage, int place, List<EnumController.Shot> ReceiveShotList)
    {
        this.ReceiveShotList = ReceiveShotList;
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

    private void DiscardClimaxCard()
    {
        if (MyClimaxCard != null)
        {
            GraveYardList.Add(MyClimaxCard);
            SetMyClimaxCard(null);
            Syncronize();
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

    public void Draw()
    {
        GetComponent<AudioSource>().PlayOneShot(DrawSE);
        myHandList.Add(myDeckList[0]);
        myDeckList.RemoveAt(0);
        Syncronize();
        if (myDeckList.Count == 0)
        {
            Refresh();
        }
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
        Draw();
        m_BattleStrix.RpcToAll("ChangePhase", EnumController.Turn.Clock);
        m_BattleStrix.RpcToAll("ClockPhase");
    }

    public void EncoreStart()
    {
        if (!isTurnPlayer)
        {
            return;
        }
        m_DialogManager.EncoreDialog(myFieldList, EnumController.EncoreDialog.EncorePhase);
        return;
    }

    public void ExecuteActionList()
    {
        if (ActionList.Count > 0)
        {
            m_DialogManager.SelectActionDialog(ActionList);
            return;
        }

        if (executeActionList)
        {
            m_BattleStrix.RpcToAll("ChanggeExecuteActionList", false);
            return;
        }
        else
        {
            m_BattleStrix.RpcToAll("ExecuteActionListForLast", isTurnPlayer);
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

    public void GameStart()
    {
        m_BattleStrix.RpcToAll("CloseWaitDialog");
        if (m_StrixManager.isOwner)
        {
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

    public int GetHAND_LIMIT_NUM()
    {
        return HAND_LIMIT_NUM;
    }

    public EnemyMainCardsManager GetEnemyMainCardsManager()
    {
        return m_EnemyMainCardsManager;
    }

    public MyMainCardsManager GetMyMainCardsManager()
    {
        return m_MyMainCardsManager;
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

        Debug.Log("LevelUp");
        m_MyMainCardsManager.CallLevelUp();
        // ExecuteActionListはLevelUpDialogクラスで実行されるため不要
    }

    public void PowerCheck(int num, EnumController.PowerCheck paramater)
    {
        int myPlace = num;
        int myPower = m_MyMainCardsManager.GetFieldPower(num);
        int enemyPlace = -1;
        int enemyPower = -1;
        int enemyLevel = -1;

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
            default:
                break;
        }
        enemyPower = m_EnemyMainCardsManager.GetFieldPower(enemyPlace);
        enemyLevel = m_EnemyMainCardsManager.GetFieldLevel(enemyPlace);
        int myLevel = m_MyMainCardsManager.GetFieldLevel(myPlace);
        // 相手の中央枠に大活躍のキャラがいる場合
        if (m_MyMainCardsManager.GetIsGreatPerformance(1))
        {
            if (m_MyMainCardsManager.GetState(1) == EnumController.State.STAND || m_MyMainCardsManager.GetState(1) == EnumController.State.REST)
            {
                myPlace = 1;
                myPower = m_MyMainCardsManager.GetFieldPower(myPlace);
                Debug.Log("myPlace:" + myPlace);
                Debug.Log("enemyPlace:" + enemyPlace);
                if (myPower > enemyPower)
                {
                    Debug.Log("MyPowerIsBiggerThanEnemyPower");
                    m_EnemyMainCardsManager.CallReverse(enemyPlace);
                    m_MyMainCardsManager.CallWhenReverseEnemyCard(myPlace, enemyPlace, enemyLevel);
                    m_BattleStrix.RpcToAll("MyPowerIsBiggerThanEnemyPower", enemyPlace, paramater, isTurnPlayer);
                    return;
                }
                else if (myPower == enemyPower)
                {
                    m_EnemyMainCardsManager.CallReverse(enemyPlace);
                    m_MyMainCardsManager.CallOnReverse(myPlace);
                    m_MyMainCardsManager.CallWhenReverseEnemyCard(myPlace, enemyPlace, enemyLevel);
                    m_BattleStrix.RpcToAll("MyPowerEqualEnemyPower", myPlace, num, enemyPlace, myLevel, paramater, isTurnPlayer);
                    return;
                }
                else
                {
                    m_MyMainCardsManager.CallOnReverse(myPlace);
                    m_BattleStrix.RpcToAll("EnemyPowerIsBiggerThanMyPower", myPlace, num, enemyPlace, myLevel, paramater, isTurnPlayer);
                    return;
                }
            }
        }

        if (myPower > enemyPower)
        {
            Debug.Log("MyPowerIsBiggeThanEnemyPower");
            m_EnemyMainCardsManager.CallReverse(enemyPlace);
            m_MyMainCardsManager.CallWhenReverseEnemyCard(myPlace, enemyPlace, enemyLevel);
            m_BattleStrix.RpcToAll("MyPowerIsBiggerThanEnemyPower", enemyPlace, paramater, isTurnPlayer);
            return;
        }
        else if (myPower == enemyPower)
        {
            m_EnemyMainCardsManager.CallReverse(enemyPlace);
            m_MyMainCardsManager.CallOnReverse(myPlace);
            m_MyMainCardsManager.CallWhenReverseEnemyCard(myPlace, enemyPlace, enemyLevel);
            m_BattleStrix.RpcToAll("MyPowerEqualEnemyPower", myPlace, num, enemyPlace, myLevel, paramater, isTurnPlayer);
            return;
        }
        else
        {
            m_MyMainCardsManager.CallOnReverse(myPlace);
            m_BattleStrix.RpcToAll("EnemyPowerIsBiggerThanMyPower", myPlace, num, enemyPlace, myLevel, paramater, isTurnPlayer);
            return;
        }
    }

    public void PowerCheck2(EnumController.PowerCheck paramater)
    {
        Debug.Log("PowerCheck2");
        switch (paramater)
        {
            case EnumController.PowerCheck.DamageForFrontAttack:
                m_BattleStrix.RpcToAll("SetIsAttackProcess", false);
                break;
            case EnumController.PowerCheck.DamageForFrontAttack2ForCancel:
                if (ReceiveShotList.Count > 0)
                {
                    ReceiveShotList.RemoveAt(0);
                    m_BattleStrix.RpcToAll("Shot", 1, ReceiveShotList, isFirstAttacker);
                    return;
                }

                m_BattleStrix.RpcToAll("SetIsAttackProcess", false);
                m_BattleStrix.RpcToAll("ChanggeExecuteActionList", false);
                m_BattleStrix.RpcToAll("ExecuteActionList", isTurnPlayer);
                break;
            case EnumController.PowerCheck.DamageForFrontAttack2ForDamaged:
                m_BattleStrix.RpcToAll("SetIsAttackProcess", false);
                m_BattleStrix.RpcToAll("ChanggeExecuteActionList", false);
                m_BattleStrix.RpcToAll("ExecuteActionList", isTurnPlayer);
                break;
            case EnumController.PowerCheck.PowerCheckForLevelUpDialog:
                m_BattleStrix.RpcToAll("SetIsAttackProcess", false);
                break;
        }
    }

    public void PowerCheckForLevelUpDialog(int place)
    {
        if(place > -1)
        {
            PowerCheck(place, EnumController.PowerCheck.PowerCheckForLevelUpDialog);
            return;
        }
        m_BattleStrix.RpcToAll("SetIsAttackProcess", false);
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

    public void TurnChange()
    {
        SwitchTurnUtil();
        m_BattleStrix.RpcToAll("SendReceiveTurnChange", isFirstAttacker);
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

    public void ReceiveReadyOK()
    {
        Debug.Log("ReceiveReadyOK");
        StandPhaseStart();
    }

    public void ReceiveTurnChange()
    {
        Debug.Log("ReceiveTurnChange");
        if (myHandList.Count > HAND_LIMIT_NUM)
        {
            m_HandCardUtilStatus = EnumController.HandCardUtilStatus.HAND_OVER;
            m_DialogManager.HandOverDialog(EnumController.HandOverDialogParamater.Active);
            return;
        }
        ReceiveTurnChange2();
    }

    private void ReceiveTurnChange2()
    {
        Debug.Log("ReceiveTurnChange2+");
        DiscardClimaxCard();
        SwitchTurnUtil();
        m_BattleStrix.RpcToAll("SendReceiveReadyOK", isFirstAttacker);
    }

    public void Refresh()
    {
        for (int i = 0; i < GraveYardList.Count; i++)
        {
            myDeckList.Add(GraveYardList[i]);
        }
        GraveYardList = new List<BattleModeCard>();
        Shuffle();
        Syncronize();

        Action action = new Action(this, EnumController.Action.DamageRefresh);
        action.SetParamaterBattleStrix(m_BattleStrix);
        action.SetParamaterWinAndLose(m_WinAndLose);

        ActionList.Add(action);

        ExecuteActionList();
    }

    public void SendEncoreDialogFromRPC(EnumController.EncoreDialog p)
    {
        m_DialogManager.EncoreDialog(myFieldList, p);
    }

    public void SwitchTurnUtil()
    {
        Debug.Log("SwitchTurnUtil");
        // ターン終了時まで上がるパワーをリセット
        m_MyMainCardsManager.ExecuteResetPowerUpUntilTurnEnd();
        // ターン終了時まで上がる特徴をリセット
        m_MyMainCardsManager.ExecuteResetAttributeUpUntilTurnEnd();
        Syncronize();

        isTurnPlayer = !isTurnPlayer;
        turn++;
    }

    public void onDirectAttack(int num)
    {
        int damage = m_MyMainCardsManager.GetFieldSoul(num) + 1;
        damage = damage + TriggerCheck();
        this.SendShotList = new List<EnumController.Shot>();
        switch (trigger)
        {
            case EnumController.Trigger.COMEBACK:
                if (!isLastTrigger)
                {
                    m_ComeBackDetail.SetBattleModeCard(GraveYardList, damage, isFirstAttacker, EnumController.Damage.DIRECT_ATTACK, SendShotList);
                }
                return;
            case EnumController.Trigger.SHOT:
                SendShotList.Add(EnumController.Shot.SHOT);
                break;
            case EnumController.Trigger.POOL:
                m_DialogManager.YesOrNoDialog(YesOrNoDialogParamater.CONFIRM_POOL_TRIGGER_DIRECT, null, damage);
                return;
            default:
                break;
        }
        TriggerAfter();
        m_BattleStrix.RpcToAll("Damage", damage, isFirstAttacker, EnumController.Damage.DIRECT_ATTACK, SendShotList);
    }

    public void onFrontAttack(int num)
    {
        int damage = m_MyMainCardsManager.GetFieldSoul(num);
        damage = damage + TriggerCheck();
        this.SendShotList = new List<EnumController.Shot>();
        switch (trigger)
        {
            case EnumController.Trigger.COMEBACK:
                if (!isLastTrigger)
                {
                    m_ComeBackDetail.SetBattleModeCard(GraveYardList, damage, num, isFirstAttacker, SendShotList);
                }
                return;
            case EnumController.Trigger.SHOT:
                SendShotList.Add(EnumController.Shot.SHOT);
                break;
            case EnumController.Trigger.POOL:
                m_DialogManager.YesOrNoDialog(YesOrNoDialogParamater.CONFIRM_POOL_TRIGGER_FRONT, null, damage, num);
                return;
            default:
                break;
        }
        TriggerAfter();
        m_BattleStrix.RpcToAll("CallOKDialogForCounter", damage, num, isFirstAttacker, SendShotList);
    }

    public void onSideAttack(int num)
    {
        Debug.Log("SideAttack");
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
        damage = damage + TriggerCheck();

        this.SendShotList = new List<EnumController.Shot>();
        switch (trigger)
        {
            case EnumController.Trigger.COMEBACK:
                if (!isLastTrigger)
                {
                    m_ComeBackDetail.SetBattleModeCard(GraveYardList, damage, isFirstAttacker, EnumController.Damage.SIDE_ATTACK, SendShotList);
                    return;
                }
                break;
            case EnumController.Trigger.SHOT:
                SendShotList.Add(EnumController.Shot.SHOT);
                break;
            case EnumController.Trigger.POOL:
                m_DialogManager.YesOrNoDialog(YesOrNoDialogParamater.CONFIRM_POOL_TRIGGER_SIDE, null, damage);
                return;
            default:
                break;
        }
        TriggerAfter();
        m_BattleStrix.RpcToAll("Damage", damage, isFirstAttacker, EnumController.Damage.SIDE_ATTACK, SendShotList);
    }

    /// <summary>
    /// フィールドの特定の場所のキャラをデッキトップに送る
    /// </summary>
    /// <param name="place"></param>
    public void ToDeckTopFromField(int place)
    {

        Debug.Log(place);
        if (myFieldList[place] == null)
        {
            return;
        }

        List<BattleModeCard> tempList = new List<BattleModeCard>();
        tempList.Add(myFieldList[place]);

        for(int i = 0; i < myDeckList.Count; i++)
        {
            tempList.Add(myDeckList[i]);
        }

        myDeckList = tempList;
        myFieldList[place] = null;
        m_MyMainCardsManager.setBattleModeCard(place, null, EnumController.State.STAND);
        Syncronize();
    }


    /// <summary>
    /// フィールドの特定の場所のキャラを控室に送る
    /// </summary>
    /// <param name="place"></param>
    public void ToGraveYardFromField(int place)
    {
        Debug.Log("ToGraveYardFromField" + place);
        if (myFieldList[place] == null)
        {
            return;
        }
        GraveYardList.Add(myFieldList[place]);
        myFieldList[place] = null;
        m_MyMainCardsManager.setBattleModeCard(place, null, EnumController.State.STAND);
        Syncronize();
    }

    private int TriggerCheck()
    {
        isLastTrigger = false;
        int num = 0;
        this.trigger = myDeckList[0].trigger;
        switch (myDeckList[0].trigger)
        {
            case EnumController.Trigger.DOUBLE_SOUL:
                num = 2;
                break;
            case EnumController.Trigger.STANDBY:
            case EnumController.Trigger.BOUNCE:
            case EnumController.Trigger.SHOT:
            case EnumController.Trigger.SOUL:
                num = 1;
                break;
            case EnumController.Trigger.COMEBACK:
            case EnumController.Trigger.BOOK:
            case EnumController.Trigger.GATE:
            case EnumController.Trigger.CHOICE:
            case EnumController.Trigger.TREASURE:
            case EnumController.Trigger.POOL:
            case EnumController.Trigger.NONE:
            case EnumController.Trigger.VOID:
                break;
            default:
                break;
        }
        if (myDeckList.Count == 0)
        {
            isLastTrigger = true;
        }
        return num;
    }

    public void TriggerAfter()
    {
        myStockList.Add(myDeckList[0]);
        myDeckList.RemoveAt(0);

        Syncronize();

        if (myDeckList.Count == 0)
        {
            Refresh();
        }
        isLastTrigger = false;
    }

    public void DamageForFrontAttack(int damage, int place, EnumController.Damage damageParamater, List<EnumController.Shot> ReceiveShotList)
    {
        // ここからテスト用
        // リフレッシュ後の機能を確認するテスト
        /*for(int m = 0; m < myDeckList.Count - 1; m++)
        {
            GraveYardList.Add(myDeckList[m]);
        }
        List<BattleModeCard> t = new List<BattleModeCard>();
        t.Add(myDeckList[myDeckList.Count - 1]);
        myDeckList = t;
        Syncronize();*/
        // ここまでテスト用
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
                placeNum = -1;
                break;
        }
        Debug.Log("placeNum:" + placeNum);
        if (damage <= 0 && placeNum > -1)
        {
            PowerCheck(placeNum, EnumController.PowerCheck.DamageForFrontAttack);
            return;
        }

        for (int i = 0; i < damage; i++)
        {
            temp.Add(myDeckList[0]);
            if (myDeckList[0].type == EnumController.Type.CLIMAX)
            {
                // ダメージアニメーションの再生
                m_BattleStrix.SendDamageAnimationDialog_SetBattleModeCardForTurnPlayer(temp, isFirstAttacker);
                if(placeNum == -1)
                {
                    // SideAttackまたはDirectAttack用
                    m_DamageAnimationDialog.SetBattleModeCard(temp, -1);
                    return;
                }else
                {
                    // FrontAttack用
                    m_DamageAnimationDialog.SetBattleModeCard(temp, place);
                    return;
                }
            }
            myDeckList.RemoveAt(0);

            Syncronize();
            if (myDeckList.Count == 0)
            {
                if (GraveYardList.Count == 0)
                {
                    // 控室が0枚なら負け扱い
                    m_BattleStrix.RpcToAll("WinAndLose_Win", isFirstAttacker);
                    m_WinAndLose.Lose();
                    return;
                }

                for (int n = 0; n < GraveYardList.Count; n++)
                {
                    myDeckList.Add(GraveYardList[n]);
                }
                GraveYardList = new List<BattleModeCard>();
                Shuffle();
                Syncronize();
                Action action = new Action(this, EnumController.Action.DamageRefresh);
                action.SetParamaterBattleStrix(m_BattleStrix);
                action.SetParamaterWinAndLose(m_WinAndLose);

                ActionList.Add(action);
            }
        }
        // ダメージアニメーションの再生
        m_BattleStrix.SendDamageAnimationDialog_SetBattleModeCardForTurnPlayer(temp, isFirstAttacker);
        if (placeNum == -1)
        {
            // SideAttackまたはDirectAttack用
            m_DamageAnimationDialog.SetBattleModeCard(temp, -1);
            this.ReceiveShotList = new List<EnumController.Shot>();
            return;
        }
        else
        {
            // FrontAttack用
            m_DamageAnimationDialog.SetBattleModeCard(temp, place);
            this.ReceiveShotList = new List<EnumController.Shot>();
            return;
        }
    }

    /// <summary>
    /// ダメージアニメーションが呼ばれた後呼ばれる処理（ダメージキャンセル処理）(フロントアタック用)
    /// </summary>
    /// <param name="tempList"></param>
    /// <param name="place"></param>
    public void DamageForFrontAttack2ForCancel(List<BattleModeCard> tempList, int place)
    {
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
                placeNum = -1;
                break;
        }

        myDeckList.RemoveAt(0);
        for (int n = 0; n < tempList.Count; n++)
        {
            GraveYardList.Add(tempList[n]);
        }
        Syncronize();

        Action action = new Action(this, EnumController.Action.DamageForFrontAttack2ForCancel);
        action.SetParamaterNum(placeNum);
        action.SetParamaterBattleStrix(m_BattleStrix);
        ActionList.Add(action);

        if (myDeckList.Count == 0)
        {
            Refresh();
            return;
        }
        ExecuteActionList();
    }

    /// <summary>
    /// ダメージアニメーションが呼ばれた後呼ばれる処理（ダメージを受ける処理）(フロントアタック用)
    /// </summary>
    /// <param name="tempList"></param>
    /// <param name="place"></param>
    public void DamageForFrontAttack2ForDamaged(List<BattleModeCard> tempList, int place)
    {
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
                placeNum = -1;
                break;
        }

        Action action = new Action(this, EnumController.Action.DamageForFrontAttack2ForDamaged);
        action.SetParamaterNum(placeNum);
        action.SetParamaterBattleStrix(m_BattleStrix);
        ActionList.Add(action);
        for (int n = 0; n < tempList.Count; n++)
        {
            myClockList.Add(tempList[n]);
        }
        Syncronize();

        if (myDeckList.Count == 0)
        {
            Refresh();
            return;
        }

        ExecuteActionList();
    }

    public void Shot(int shotDamageNum, List<EnumController.Shot> ShotList)
    {
        m_BattleStrix.RpcToAll("Damage", shotDamageNum, isFirstAttacker, EnumController.Damage.SHOT, ShotList);
    }

    /// <summary>
    /// 色発生がクリアできているかチェックする
    /// </summary>
    /// <param name="color"></param>
    /// <returns></returns>
    public bool ColorCheck(EnumController.CardColor color)
    {
        for (int i = 0; i < myLevelList.Count; i++)
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

    /// <summary>
    /// アニメーションが再生中かチェックする
    /// </summary>
    /// <returns></returns>
    public bool isAnimation()
    {
        if (isTriggerAnimation)
        {
            return true;
        }
        if (isPhaseAnimation)
        {
            return true;
        }
        if (isTriggerAnimationForEnemy)
        {
            return true;
        }
        if (isDamageAnimation)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// レベルアップする場合true
    /// </summary>
    /// <returns></returns>
    public bool LevelUpCheck()
    {
        if (myClockList.Count < 7)
        {
            return false;
        }

        if (myLevelList.Count < 3)
        {
            m_BattleStrix.RpcToAll("UpdateIsLevelUpProcess", true);
            m_DialogManager.LevelUpDialog(myClockList);
            return true;
        }
        m_BattleStrix.RpcToAll("WinAndLose_Win", isFirstAttacker);
        m_WinAndLose.Lose();
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
        m_BattleStrix.SendUpdateEnemyMemoryCards(myMemoryList, isFirstAttacker);

        // クライマックスカードの更新
        myBattleClimaxCardUtil.SetClimax(MyClimaxCard);
        enemyBattleClimaxCardUtil.SetClimax(EnemyClimaxCard);
        BattleModeCardTemp MyClimaxTemp = new BattleModeCardTemp(MyClimaxCard);
        BattleModeCardTemp EnemyClimaxTemp = new BattleModeCardTemp(EnemyClimaxCard);
        m_BattleStrix.RpcToAll("UpdateClimaxCard", MyClimaxTemp, EnemyClimaxTemp, isFirstAttacker);

        // メインのカードの更新
        // パワー、レベル、特徴の計算
        m_MyMainCardsManager.FieldPowerAndLevelAndAttributeAndSoulReset();
        m_BattleStrix.SendUpdateMainCards(myFieldList, m_MyMainCardsManager.GetFieldLevel(), m_MyMainCardsManager.GetFieldPower(), m_MyMainCardsManager.GetFieldSoul(), m_MyMainCardsManager.GetIsGreatPerformance(), isFirstAttacker);
        // 特徴の同期
        m_BattleStrix.SendUpdateMainCardsAttribute(m_MyMainCardsManager.GetFieldAttributeList(), isFirstAttacker);

        // ステータスの同期
        List<EnumController.State> stateList = new List<EnumController.State>();
        for (int i = 0; i < 5; i++)
        {
            stateList.Add(m_MyMainCardsManager.GetState(i));
        }
        m_BattleStrix.RpcToAll("UpdateMainCardsState", stateList, isFirstAttacker);
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

    public void UpdateEnemyMainCards(List<BattleModeCardTemp> list, List<int> FieldLevelList, List<int> FieldPowerList, List<int> FieldSoulList, List<bool> IsGreatProcessList)
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
        m_EnemyMainCardsManager.SetFieldLevel(FieldLevelList);
        m_EnemyMainCardsManager.SetFieldPower(FieldPowerList);
        m_EnemyMainCardsManager.SetFieldSoul(FieldSoulList);
        m_EnemyMainCardsManager.SetIsGreatProcessList(IsGreatProcessList);
    }

    public void UpdateEnemyMainCardsAttribute(List<EnumController.Attribute> list, int place)
    {
        m_EnemyMainCardsManager.SetFieldAttribute(list, place);
    }

    public void UpdateEnemyMainCardsState(List<EnumController.State> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] == EnumController.State.REST)
            {
                m_EnemyMainCardsManager.CallRest(i);
            }
            else if (list[i] == EnumController.State.REVERSE)
            {
                m_EnemyMainCardsManager.CallReverse(i);
            }
            else
            {
                m_EnemyMainCardsManager.CallStand(i);
            }
        }
    }

    public void UpdateEnemyMemoryCards(List<BattleModeCardTemp> list)
    {
        enemyMemoryList = new List<BattleModeCard>();
        for (int i = 0; i < list.Count; i++)
        {
            BattleModeCard b = m_BattleModeCardList.ConvertCardNoToBattleModeCard(list[i].cardNo);
            enemyMemoryList.Add(b);
        }
        enemyBattleMemoryCardUtil.updateEnemyMemoryCards(enemyMemoryList);
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
