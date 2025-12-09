using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityForge.AnimCallbacks;

public class EventAnimationManager : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] BattleModeCardList m_BattleModeCardList;
    [SerializeField] DialogManager m_DialogManager;
    [SerializeField] ComeBackDetail m_ComeBackDetail;
    [SerializeField] GameManager m_GameManager;
    [SerializeField] MyMainCardsManager m_MyMainCardsManager;
    [SerializeField] EffectBondForHandToField m_EffectBondForHandToField;
    [SerializeField] EnemyMainCardsManager m_EnemyMainCardsManager;
    [SerializeField] MainPowerUpDialog m_MainPowerUpDialog;
    [SerializeField] Image m_image;
    [SerializeField] Image m_image2;
    [SerializeField] GameObject m_gameObject;
    [SerializeField] BattleStrix m_BattleStrix;
    [SerializeField] WinAndLose m_WinAndLose;

    private static string AnimationName = "EventAnimation";
    private static int NormalAnimationLayerIndex = 0;

    private BattleModeCard m_BattleModeCard = null;

    private int place = -1;

    private int handNum = -1;

    private int effectNum = 0;

    private bool isFromRPC = false;

    private EnumController.YesOrNoDialogParamater paramater;

    private int damage = -1;

    private string sulvageCardName = "";

    private int cost = -1;

    // Start is called before the first frame update
    void Start()
    {
        animator.AddClipEndCallback(NormalAnimationLayerIndex, AnimationName, () => AnimationEnd());
    }

    /// <summary>
    /// 絆用
    /// </summary>
    public void AnimationStartForBond(BattleModeCard card, string sulvageCardName, int cost)
    {
        this.paramater = EnumController.YesOrNoDialogParamater.COST_CONFIRM_BOND_FOR_HAND_TO_FIELD;
        this.sulvageCardName = sulvageCardName;
        this.cost = cost;
        isFromRPC = false;
        m_gameObject.SetActive(true);
        effectNum = 0;

        m_BattleModeCard = card;
        m_image.sprite = card.sprite;
        m_image2.sprite = card.sprite;
        // アニメーション再生を再生するためにspeedを1にする
        animator.speed = 1;
        animator.Play(AnimationName, 0, 0);
        m_BattleStrix.RpcToAll("SEManager_EffectSE_Play");
    }

    /// <summary>
    /// バウンス・プール・ブックトリガー用
    /// </summary>
    /// <param name="card"></param>
    /// <param name="paramater"></param>
    public void AnimationStartForBounceTrigger(BattleModeCard card, int damage, int place, EnumController.YesOrNoDialogParamater paramater)
    {
        this.paramater = paramater;
        this.place = place;
        this.damage = damage;
        isFromRPC = false;
        m_gameObject.SetActive(true);
        effectNum = 1;

        m_BattleModeCard = card;
        m_image.sprite = card.sprite;
        m_image2.sprite = card.sprite;
        // アニメーション再生を再生するためにspeedを1にする
        animator.speed = 1;
        animator.Play(AnimationName, 0, 0);
        m_BattleStrix.RpcToAll("SEManager_EffectSE_Play");
    }

    /// <summary>
    /// イベントを再生したプレイヤー用
    /// </summary>
    /// <param name="card"></param>
    public void AnimationStart(BattleModeCard card)
    {
        AnimationStart(card, -1, -1, 0);
    }

    /// <summary>
    /// イベントを再生したプレイヤー用
    /// </summary>
    /// <param name="card"></param>
    public void AnimationStart(BattleModeCard card, int place)
    {

        AnimationStart(card, place, -1, 0);
    }

    /// <summary>
    /// イベントを再生したプレイヤー用
    /// </summary>
    /// <param name="card"></param>
    public void AnimationStart(BattleModeCard card, int place, int handNum)
    {

        AnimationStart(card, place, handNum, 0);
    }

    /// <summary>
    /// イベントを再生したプレイヤー用
    /// </summary>
    /// <param name="card"></param>
    public void AnimationStart_2(BattleModeCard card)
    {
        AnimationStart(card, -1, -1, 1);
    }

    /// <summary>
    /// イベントを再生したプレイヤー用
    /// </summary>
    /// <param name="card"></param>
    public void AnimationStart_2(BattleModeCard card, int place)
    {
        AnimationStart(card, place, -1, 1);
    }

    /// <summary>
    /// イベントを再生したプレイヤー用
    /// </summary>
    /// <param name="card"></param>
    public void AnimationStart_2(BattleModeCard card, int place, int handNum)
    {
        AnimationStart(card, place, handNum, 1);
    }

    /// <summary>
    /// イベントを再生したプレイヤー用
    /// </summary>
    /// <param name="card"></param>
    public void AnimationStart_3(BattleModeCard card)
    {
        AnimationStart(card, -1, -1, 2);
    }

    /// <summary>
    /// イベントを再生したプレイヤー用
    /// </summary>
    /// <param name="card"></param>
    public void AnimationStart_3(BattleModeCard card, int place)
    {
        AnimationStart(card, place, -1, 2);
    }

    /// <summary>
    /// イベントを再生したプレイヤー用
    /// </summary>
    /// <param name="card"></param>
    public void AnimationStart(BattleModeCard card, int place, int handNum, int effectNum)
    {
        this.paramater = EnumController.YesOrNoDialogParamater.VOID;
        this.place = place;
        this.handNum = handNum;
        this.effectNum = effectNum;
        isFromRPC = false;
        m_gameObject.SetActive(true);

        m_BattleModeCard = card;
        m_image.sprite = card.sprite;
        m_image2.sprite = card.sprite;
        // アニメーション再生を再生するためにspeedを1にする
        animator.speed = 1;
        animator.Play(AnimationName, 0, 0);
        m_BattleStrix.RpcToAll("SEManager_EffectSE_Play");
    }

    private void AnimationEnd()
    {

        m_gameObject.SetActive(false);
        if (isFromRPC)
        {
            place = -1;
            damage = -1;
            effectNum = 0;
            return;
        }
        Execute();
        // effectNum = 0;
        // place = -1;
        damage = -1;
    }

    private void Execute()
    {
        if(paramater == EnumController.YesOrNoDialogParamater.CONFIRM_BOUNCE_TRIGGER_FRONT || paramater == EnumController.YesOrNoDialogParamater.CONFIRM_BOUNCE_TRIGGER_SIDE || paramater == EnumController.YesOrNoDialogParamater.CONFIRM_BOUNCE_TRIGGER_DIRECT)
        {
            m_DialogManager.CharacterSelectDialog(damage, place, paramater);
            return;
        }
        if(paramater == EnumController.YesOrNoDialogParamater.CONFIRM_POOL_TRIGGER_FRONT || paramater == EnumController.YesOrNoDialogParamater.CONFIRM_POOL_TRIGGER_SIDE || paramater == EnumController.YesOrNoDialogParamater.CONFIRM_POOL_TRIGGER_DIRECT)
        {
            if (m_GameManager.myDeckList.Count <= 1)
            {
                BattleModeCard temp = m_GameManager.myDeckList[0];
                m_GameManager.myDeckList.RemoveAt(0);
                m_GameManager.Refresh();
                m_GameManager.myStockList.Add(m_GameManager.myDeckList[0]);
                m_GameManager.myDeckList.RemoveAt(0);
                m_GameManager.myStockList.Add(temp);
            }
            else
            {
                m_GameManager.myStockList.Add(m_GameManager.myDeckList[1]);
                m_GameManager.myDeckList.RemoveAt(1);
                m_GameManager.myStockList.Add(m_GameManager.myDeckList[0]);
                m_GameManager.myDeckList.RemoveAt(0);
            }
            m_GameManager.Syncronize();

            switch (paramater)
            {
                case EnumController.YesOrNoDialogParamater.CONFIRM_POOL_TRIGGER_DIRECT:
                    m_BattleStrix.RpcToAll("Damage", damage, m_GameManager.isFirstAttacker, EnumController.Damage.DIRECT_ATTACK, m_GameManager.SendShotList);
                    break;
                case EnumController.YesOrNoDialogParamater.CONFIRM_POOL_TRIGGER_SIDE:
                    m_BattleStrix.RpcToAll("Damage", damage, m_GameManager.isFirstAttacker, EnumController.Damage.SIDE_ATTACK, m_GameManager.SendShotList);
                    break;
                case EnumController.YesOrNoDialogParamater.CONFIRM_POOL_TRIGGER_FRONT:
                    // ("CallOKDialogForCounter",int damage, int place, m_GameManager.isFirstAttacker,List<EnumController.Shot> ReceiveShotList)
                    m_BattleStrix.RpcToAll("CallOKDialogForCounter", damage, place, m_GameManager.isFirstAttacker, m_GameManager.SendShotList);
                    break;
                default:
                    break;
            }
            return;
        }

        if(paramater == EnumController.YesOrNoDialogParamater.CONFIRM_BOOK_TRIGGER_FRONT || paramater == EnumController.YesOrNoDialogParamater.CONFIRM_BOOK_TRIGGER_SIDE || paramater == EnumController.YesOrNoDialogParamater.CONFIRM_BOOK_TRIGGER_DIRECT)
        {
            m_GameManager.myStockList.Add(m_GameManager.myDeckList[0]);
            m_GameManager.myDeckList.RemoveAt(0);
            m_GameManager.Syncronize();

            if (m_GameManager.myDeckList.Count == 0)
            {
                m_GameManager.Refresh();
            }
            m_GameManager.Syncronize();
            m_GameManager.Draw();

            switch (paramater)
            {
                case EnumController.YesOrNoDialogParamater.CONFIRM_BOOK_TRIGGER_DIRECT:
                    m_BattleStrix.RpcToAll("Damage", damage, m_GameManager.isFirstAttacker, EnumController.Damage.DIRECT_ATTACK, m_GameManager.SendShotList);
                    break;
                case EnumController.YesOrNoDialogParamater.CONFIRM_BOOK_TRIGGER_SIDE:
                    m_BattleStrix.RpcToAll("Damage", damage, m_GameManager.isFirstAttacker, EnumController.Damage.SIDE_ATTACK, m_GameManager.SendShotList);
                    break;
                case EnumController.YesOrNoDialogParamater.CONFIRM_BOOK_TRIGGER_FRONT:
                    // ("CallOKDialogForCounter",int damage, int place, m_GameManager.isFirstAttacker,List<EnumController.Shot> ReceiveShotList)
                    m_BattleStrix.RpcToAll("CallOKDialogForCounter", damage, place, m_GameManager.isFirstAttacker, m_GameManager.SendShotList);
                    break;
                default:
                    break;
            }
            return;
        }

        if(paramater == EnumController.YesOrNoDialogParamater.CONFIRM_COMEBACK_TRIGGER_FRONT || paramater == EnumController.YesOrNoDialogParamater.CONFIRM_COMEBACK_TRIGGER_SIDE || paramater == EnumController.YesOrNoDialogParamater.CONFIRM_COMEBACK_TRIGGER_DIRECT)
        {
            switch (paramater)
            {
                case EnumController.YesOrNoDialogParamater.CONFIRM_COMEBACK_TRIGGER_FRONT:
                    m_ComeBackDetail.SetBattleModeCard(m_GameManager.GraveYardList, damage, place, m_GameManager.isFirstAttacker, m_GameManager.SendShotList);
                    break;
                case EnumController.YesOrNoDialogParamater.CONFIRM_COMEBACK_TRIGGER_SIDE:
                    m_ComeBackDetail.SetBattleModeCard(m_GameManager.GraveYardList, damage, m_GameManager.isFirstAttacker, EnumController.Damage.SIDE_ATTACK, m_GameManager.SendShotList);
                    break;
                case EnumController.YesOrNoDialogParamater.CONFIRM_COMEBACK_TRIGGER_DIRECT: 
                    m_ComeBackDetail.SetBattleModeCard(m_GameManager.GraveYardList, damage, m_GameManager.isFirstAttacker, EnumController.Damage.DIRECT_ATTACK, m_GameManager.SendShotList);
                    break;
            }
            return;
        }

        // 絆
        if(paramater == EnumController.YesOrNoDialogParamater.COST_CONFIRM_BOND_FOR_HAND_TO_FIELD)
        {
            switch (m_BattleModeCard.cardNo)
            {
                case EnumController.CardNo.AT_WX02_A10:
                case EnumController.CardNo.DC_W01_09T:
                case EnumController.CardNo.P3_S01_003:
                case EnumController.CardNo.P3_S01_032:
                case EnumController.CardNo.P3_S01_051:
                case EnumController.CardNo.P3_S01_082:
                case EnumController.CardNo.LB_W02_002:
                    m_EffectBondForHandToField.BondForCost(sulvageCardName, cost);
                    return;
                default:
                    break;
            }
        }

        int CheckActEffectCount = 0;
        int enemyPlace = -1;
        switch (place)
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
        if(effectNum == 0)
        {
            switch (m_BattleModeCard.cardNo)
            {
                case EnumController.CardNo.AT_WX02_A07:
                    // Search your deck for up to 1 《Ooo》 character, reveal it to your opponent, put it into your hand, and shuffle your deck.
                    m_DialogManager.SearchDialog(EnumController.SearchDialogParamater.AT_WX02_A07, handNum);
                    return;
                case EnumController.CardNo.DC_W01_01T:
                    // 【起】［このカードを【レスト】する］ あなたは自分のキャラを1枚選び、そのターン中、パワーを＋1000。
                    EffectWhenAct(m_BattleModeCard);
                    m_MyMainCardsManager.CallOnRest(place);
                    m_GameManager.Syncronize();
                    m_MainPowerUpDialog.SetBattleMordCard(m_BattleModeCard);
                    return;
                case EnumController.CardNo.DC_W01_03T:
                    // あなたは自分の山札を上から1枚選び、ストック置場に置く。あなたは自分のキャラを1枚選び、そのターン中、パワーを＋500。
                    m_GameManager.myStockList.Add(m_GameManager.myDeckList[0]);
                    m_GameManager.myDeckList.RemoveAt(0);
                    m_GameManager.Syncronize();

                    if (m_GameManager.myDeckList.Count == 0)
                    {
                        if (m_GameManager.GraveYardList.Count == 0)
                        {
                            // 控室が0枚なら負け扱い
                            m_BattleStrix.RpcToAll("WinAndLose_Win", m_GameManager.isFirstAttacker);
                            m_WinAndLose.Lose();
                            return;
                        }

                        for (int n = 0; n < m_GameManager.GraveYardList.Count; n++)
                        {
                            m_GameManager.myDeckList.Add(m_GameManager.GraveYardList[n]);
                        }
                        m_GameManager.GraveYardList = new List<BattleModeCard>();
                        m_GameManager.Shuffle();
                        m_GameManager.Syncronize();
                        Action action1 = new Action(m_GameManager, EnumController.Action.DamageRefresh);
                        action1.SetParamaterBattleStrix(m_BattleStrix);
                        action1.SetParamaterWinAndLose(m_WinAndLose);

                        m_GameManager.ActionList.Add(action1);
                    }
                    Action action2 = new Action(m_GameManager, EnumController.Action.EventAnimationManager);
                    action2.SetParamaterBattleModeCard(m_BattleModeCard);
                    m_GameManager.ActionList.Add(action2);
                    m_MainPowerUpDialog.SetBattleMordCard(m_BattleModeCard);
                    return;
                case EnumController.CardNo.DC_W01_04T:
                    //【起】［(1)］ そのターン中、このカードのパワーを＋2000。
                    EffectWhenAct(m_BattleModeCard);
                    PayCost(1);
                    m_MyMainCardsManager.AddPowerUpUntilTurnEnd(place, 2000);
                    m_GameManager.Syncronize();
                    m_GameManager.ExecuteActionList();
                    return;
                case EnumController.CardNo.DC_W01_05T:
                    //【起】［(1)］ あなたは相手の前列のキャラを1枚選び、そのターン中、パワーを－1000。
                    EffectWhenAct(m_BattleModeCard);
                    PayCost(1);
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
                    return;
                case EnumController.CardNo.DC_W01_07T:
                    // 【自】 他のバトルしているあなたのキャラが【リバース】した時、あなたは自分のキャラを1枚選び、そのターン中、パワーを＋1000。
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, -1);
                    return;
                case EnumController.CardNo.DC_W01_10T:
                    // 【自】 このカードとバトルしているキャラが【リバース】した時、あなたはそのキャラを山札の上に置いてよい。
                    m_BattleStrix.RpcToAll("ToDeckTopFromField", place, m_GameManager.isTurnPlayer);
                    m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
                    m_GameManager.ExecuteActionList();
                    return;
                case EnumController.CardNo.DC_W01_12T:
                    // あなたは自分の控え室のキャラを2枚まで選び、手札に戻す。
                    PayCost(2);
                    m_DialogManager.SulvageDialog(handNum, m_BattleModeCard, m_GameManager.GraveYardList, EnumController.Type.CHARACTER, 0, 2);
                    return;
                case EnumController.CardNo.DC_W01_13T:
                    // 【起】［(2) このカードを【レスト】する］ あなたは自分の控え室のキャラを1枚選び、手札に戻す。
                    EffectWhenAct(m_BattleModeCard);
                    PayCost(2);
                    m_MyMainCardsManager.CallOnRest(place);
                    m_GameManager.Syncronize();
                    m_DialogManager.SulvageDialog(m_BattleModeCard, m_GameManager.GraveYardList, EnumController.Type.CHARACTER, 0, 1);
                    return;
                case EnumController.CardNo.DC_W01_16T:
                case EnumController.CardNo.P3_S01_058:
                    // 【自】 このカードが【リバース】した時、このカードとバトルしているキャラのレベルが1以下なら、あなたはそのキャラを【リバース】してよい。
                    m_EnemyMainCardsManager.CallReverse(enemyPlace);
                    m_BattleStrix.RpcToAll("CallMyReverse", enemyPlace, m_GameManager.isTurnPlayer);
                    m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
                    m_GameManager.ExecuteActionList();
                    return;
                case EnumController.CardNo.DC_W01_18T:
                    // あなたはレベル1以下の相手のキャラを1枚選び、控え室に置く。
                    PayCost(1);
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
                    break;
                case EnumController.CardNo.LB_W02_02T:
                case EnumController.CardNo.LB_W02_033:
                    // 【起】［(1)］ このカードを思い出にする。
                    EffectWhenAct(m_BattleModeCard);
                    PayCost(1);
                    m_MyMainCardsManager.CallPutMemoryFromField(place);
                    m_GameManager.ExecuteActionList();
                    return;
                case EnumController.CardNo.DC_W01_02T:
                case EnumController.CardNo.LB_W02_03T:
                case EnumController.CardNo.P3_S01_030:
                case EnumController.CardNo.LB_W02_031:
                case EnumController.CardNo.LB_W02_036:
                    // 【自】 このカードがアタックした時、クライマックス置場に「そよ風のハミング」があるなら、あなたは自分の山札を上から1枚選び、
                    // ストック置場に置き、そのターン中、このカードのパワーを＋3000。
                    m_GameManager.myStockList.Add(m_GameManager.myDeckList[0]);
                    m_GameManager.myDeckList.RemoveAt(0);
                    m_GameManager.Syncronize();
                    m_MyMainCardsManager.AddPowerUpUntilTurnEnd(place, 3000);
                    if (m_GameManager.myDeckList.Count == 0)
                    {
                        m_GameManager.Refresh();
                    }
                    else
                    {
                        m_GameManager.ExecuteActionList();
                        return;
                    }
                    return;
                case EnumController.CardNo.LB_W02_04T:
                case EnumController.CardNo.LB_W02_044:
                    //【カウンター】 あなたは自分のキャラを2枚まで選び、そのターン中、パワーを＋1000。
                    PayCost(1);
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, -1);
                    break;
                case EnumController.CardNo.LB_W02_05T:
                case EnumController.CardNo.LB_W02_037:
                    // 【起】［(1)］ 他のあなたのキャラすべてに、そのターン中、《動物》を与える。
                    EffectWhenAct(m_BattleModeCard);
                    PayCost(1);
                    for (int i = 0; i < m_GameManager.myFieldList.Count; i++)
                    {
                        if (m_GameManager.myFieldList[i] != null)
                        {
                            m_MyMainCardsManager.SetAttributeUpUntilTurnEnd(i, EnumController.Attribute.Animal);
                        }
                    }
                    m_GameManager.Syncronize();
                    m_GameManager.ExecuteActionList();
                    return;
                case EnumController.CardNo.LB_W02_09T:
                case EnumController.CardNo.LB_W02_042:
                    //【起】［(1)］ あなたは相手のキャラを1枚選び、そのターン中、パワーを－500。
                    EffectWhenAct(m_BattleModeCard);
                    PayCost(1);
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
                    return;
                case EnumController.CardNo.LB_W02_14T:
                    // 【起】［(2) このカードを【レスト】する］ あなたは自分のクロックを上から1枚選び、控え室に置く。
                    EffectWhenAct(m_BattleModeCard);
                    PayCost(2);
                    m_MyMainCardsManager.CallOnRest(place);
                    m_GameManager.Syncronize();

                    if (m_GameManager.myClockList.Count == 0)
                    {
                        return;
                    }
                    m_GameManager.GraveYardList.Add(m_GameManager.myClockList[m_GameManager.myClockList.Count - 1]);
                    m_GameManager.myClockList.RemoveAt(m_GameManager.myClockList.Count - 1);
                    m_GameManager.Syncronize();
                    return;
                case EnumController.CardNo.LB_W02_16T:
                case EnumController.CardNo.LB_W02_094:
                    //※イベント
                    // あなたは自分のクロックを1枚選び、手札に戻す。このカードを思い出にする。
                    PayCost(3);
                    if (m_GameManager.myClockList.Count == 0)
                    {
                        m_GameManager.myMemoryList.Add(m_BattleModeCard);
                        m_GameManager.myHandList.Remove(m_BattleModeCard);
                        m_GameManager.Syncronize();
                        m_GameManager.ExecuteActionList();
                        return;
                    }
                    m_DialogManager.SearchDialog(EnumController.SearchDialogParamater.LB_W02_16T, handNum);
                    return;
                case EnumController.CardNo.LB_W02_17T:
                    //【起】［(1)］ あなたは《動物》の自分のキャラを1枚選び、そのターン中、パワーを＋500。
                    PayCost(1);
                    m_MainPowerUpDialog.SetBattleMordCard(m_BattleModeCard);
                    return;
                case EnumController.CardNo.LB_W02_19T:
                    // 【自】［(1)］ このカードとバトルしているレベル2以上のキャラが【リバース】した時、あなたはコストを払ってよい。そうしたら、あなたは1枚引く。
                    PayCost(1);
                    m_GameManager.Draw();
                    m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
                    m_GameManager.ExecuteActionList();
                    return;
                default:
                    break;
            }
            switch (m_BattleModeCard.cardNo)
            {
                case EnumController.CardNo.P3_S01_001:
                    //【自】 このカードがプレイされて舞台に置かれた時、あなたはレベル1以上の自分のキャラを1枚選び、そのターン中、ソウルを＋1。
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, -1);
                    return;
                case EnumController.CardNo.P3_S01_002:
                    //【起】［(2) このカードを【レスト】する］ このカードを思い出にする。あなたは自分の手札の「主人公＆タナトス」を１枚選び、このカードがいた枠に置く。
                    EffectWhenAct(m_BattleModeCard);
                    PayCost(2);
                    m_MyMainCardsManager.CallOnRest(place);
                    m_MyMainCardsManager.CallPutMemoryFromField(place);

                    for(int i = 0; i < m_GameManager.myHandList.Count; i++)
                    {
                        if (m_GameManager.myHandList[i].name == "主人公＆タナトス")
                        {
                            m_MyMainCardsManager.CallPutFieldFromHandForEffect(place, i, EnumController.State.STAND);
                            return;
                        }
                    }
                    return;
                case EnumController.CardNo.P3_S01_004:
                    //【自】 このカードがアタックした時、クライマックス置場に「露天風呂」があるなら、あなたは相手のキャラを1枚選び、手札に戻してよい。
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
                    return;
                case EnumController.CardNo.P3_S01_01T:
                case EnumController.CardNo.P3_S01_005:
                    // 【自】 このカードがプレイされて舞台に置かれた時、そのターン中、このカードのソウルを＋1。
                    m_MyMainCardsManager.AddSoulUpUntilTurnEnd(place, 1);
                    m_GameManager.Syncronize();
                    m_GameManager.ExecuteActionList();
                    return;
                case EnumController.CardNo.P3_S01_026:
                    //【自】 このカードがプレイされて舞台に置かれた時、あなたは自分のキャラを1枚選び、そのターン中、パワーを＋1000。
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, -1);
                    return;
                case EnumController.CardNo.P3_S01_028:
                    // 【起】［(2)］ そのターン中、このカードのパワーを＋5000。
                    EffectWhenAct(m_BattleModeCard);
                    PayCost(2);
                    m_MyMainCardsManager.AddPowerUpUntilTurnEnd(place, 5000);
                    m_GameManager.Syncronize();
                    m_GameManager.ExecuteActionList();
                    return;
                case EnumController.CardNo.P3_S01_04T:
                case EnumController.CardNo.P3_S01_010:
                    // 【自】 このカードがプレイされて舞台に置かれた時、あなたは自分のキャラを1枚選び、
                    // そのターン中、パワーを＋2000し、ソウルを＋1。
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, -1);
                    return;
                case EnumController.CardNo.P3_S01_07T:
                case EnumController.CardNo.P3_S01_012:
                    //【自】 このカードがプレイされて舞台に置かれた時、そのターン中、このカードのパワーを＋1500。
                    m_MyMainCardsManager.AddPowerUpUntilTurnEnd(place, 1500);
                    m_GameManager.Syncronize();
                    m_GameManager.ExecuteActionList();
                    return;
                case EnumController.CardNo.P3_S01_11T:
                case EnumController.CardNo.P3_S01_017:
                    //【自】 このカードがアタックした時、クライマックス置場に「最後の選択」があるなら、あなたは相手のキャラを1枚選び、手札に戻してよい。
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
                    return;
                case EnumController.CardNo.P3_S01_020:
                    // あなたは自分と相手のキャラすべてを、手札に戻す。
                    PayCost(6);
                    for(int i = 0; i < m_GameManager.myFieldList.Count; i++)
                    {
                        if (m_GameManager.myFieldList[i] != null)
                        {
                            m_MyMainCardsManager.CallPutHandFromField(i);
                        }

                    }

                    for (int i = 0; i < m_GameManager.enemyFieldList.Count; i++)
                    {
                        if (m_GameManager.enemyFieldList[i] != null)
                        {
                            m_BattleStrix.RpcToAll("ToHandFromField", i, m_GameManager.isTurnPlayer);
                        }

                    }

                    m_GameManager.myHandList.RemoveAt(handNum);
                    m_GameManager.GraveYardList.Add(m_BattleModeCard);
                    m_GameManager.Syncronize();
                    return;
                case EnumController.CardNo.P3_S01_12T:
                case EnumController.CardNo.P3_S01_022:
                    // 【カウンター】 あなたは自分のキャラを1枚選び、そのターン中、パワーを＋3000し、ソウルを＋1。
                    PayCost(2);
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, -1);
                    return;
                case EnumController.CardNo.P3_S01_16T:
                case EnumController.CardNo.P3_S01_087:
                    // 【起】［(2) このカードを【レスト】する］ あなたは1枚引く。
                    EffectWhenAct(m_BattleModeCard);
                    PayCost(2);
                    m_MyMainCardsManager.CallOnRest(place);
                    m_GameManager.Syncronize();
                    m_GameManager.Draw();
                    break;
                case EnumController.CardNo.P3_S01_018:
                    // あなたは相手のキャラを1枚選び、そのターン中、レベルを－1。
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
                    return;
                case EnumController.CardNo.P3_S01_034:
                    // 【起】［(1)］ そのターン中、このカードのパワーを＋2000。
                    EffectWhenAct(m_BattleModeCard);
                    PayCost(1);
                    m_MyMainCardsManager.AddPowerUpUntilTurnEnd(place, 2000);
                    m_GameManager.Syncronize();
                    return;
                case EnumController.CardNo.P3_S01_040:
                    //【自】［このカードを【レスト】する］ 他の《スポーツ》のあなたのキャラがプレイされて舞台に置かれた時、あなたはコストを払ってよい。そうしたら、あなたは自分の山札の上から1枚を、ストック置場に置く。
                    m_MyMainCardsManager.CallOnRest(place);
                    m_GameManager.myStockList.Add(m_GameManager.myDeckList[0]);
                    m_GameManager.myDeckList.RemoveAt(0);
                    m_GameManager.Syncronize();
                    m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
                    if (m_GameManager.myDeckList.Count == 0)
                    {
                        m_GameManager.Refresh();
                    }
                    else
                    {
                        m_GameManager.ExecuteActionList();
                        return;
                    }
                    return;
                case EnumController.CardNo.P3_S01_043:
                    //【カウンター】 あなたは自分のキャラすべてに、そのターン中、パワーを＋1000。そうする時、相手の前列のキャラすべてが【レスト】しているなら、かわりにパワーを＋3000。
                    PayCost(3);
                    int count = 0;
                    int power = 1000;
                    for(int i = 0; i < 2; i++)
                    {
                        if (m_EnemyMainCardsManager.GetState(i) == EnumController.State.STAND || m_GameManager.enemyFieldList[i] == null)
                        {
                            count++;
                        }
                    }

                    if (count >= 3)
                    {
                        power = 3000;
                    }

                    for(int i = 0; i < m_GameManager.myFieldList.Count; i++)
                    {
                        if (m_GameManager.myFieldList[i] != null)
                        {
                            m_MyMainCardsManager.AddPowerUpUntilTurnEnd(i, power);
                        }
                    }
                    m_GameManager.GraveYardList.Add(m_GameManager.myHandList[handNum]);
                    m_GameManager.myHandList.RemoveAt(handNum);
                    m_GameManager.Syncronize();
                    m_GameManager.ExecuteActionList();
                    return;
                case EnumController.CardNo.P3_S01_045:
                    // あなたは相手の前列のキャラを2枚まで選び、そのターン中、パワーを－1000。
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
                    return;
                case EnumController.CardNo.P3_S01_047:
                    //あなたは自分の山札の上から1枚を、ストック置場に置く。あなたは自分のキャラを1枚選び、そのターン中、パワーを＋1500。
                    m_GameManager.myStockList.Add(m_GameManager.myDeckList[0]);
                    m_GameManager.myDeckList.RemoveAt(0);
                    m_GameManager.Syncronize();
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, -1);
                    return;
                case EnumController.CardNo.P3_S01_051:
                    //【起】［(1)］ あなたは自分のカード名に「順平」を含むキャラを１枚選び、そのターン中、パワーを＋1000。
                    EffectWhenAct(m_BattleModeCard);
                    PayCost(1);
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, -1);
                    return;
                case EnumController.CardNo.P3_S01_052:
                    //【自】［(1)］ このカードがプレイされて舞台に置かれた時、あなたはコストを払ってよい。そうしたら、あなたは自分の控え室の「辰巳東交番」を1枚選び、手札に戻す。
                    PayCost(1);
                    for(int i = 0; i < m_GameManager.GraveYardList.Count; i++)
                    {
                        if (m_GameManager.GraveYardList[i].name == "辰巳東交番")
                        {
                            m_GameManager.myHandList.Add(m_GameManager.GraveYardList[i]);
                            m_GameManager.GraveYardList.RemoveAt(i);
                            m_GameManager.Syncronize();
                            m_GameManager.ExecuteActionList();
                            return;
                        }
                    }
                    return;
                case EnumController.CardNo.P3_S01_055:
                case EnumController.CardNo.P3_S01_056:
                    //【自】 このカードがアタックした時、クライマックス置場に「ありがとう」があるなら、あなたは自分の控え室のキャラを1枚選び、手札に戻す。
                    m_DialogManager.SulvageDialog(m_BattleModeCard, m_GameManager.GraveYardList, EnumController.Type.CHARACTER, 0, 1);
                    return;
                case EnumController.CardNo.P3_S01_057:
                    //【自】 このカードがプレイされて舞台に置かれた時、あなたは相手の控え室のイベントを1枚選び、思い出にしてよい。
                    m_DialogManager.GraveyardSelectDialog(m_BattleModeCard);
                    return;
                case EnumController.CardNo.P3_S01_060:
                    //【自】［(1)］ このカードがプレイされて舞台に置かれた時、あなたはコストを払ってよい。そうしたら、あなたはレベル1以下の相手のキャラを1枚選び、控え室に置く。
                    PayCost(1);
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
                    return;
                case EnumController.CardNo.P3_S01_061:
                    // 【自】 このカードがプレイされて舞台に置かれた時、あなたは相手の控え室のカードを1枚選び、山札の上に置いてよい。
                    m_DialogManager.GraveyardSelectDialog(m_BattleModeCard);
                    return;
                case EnumController.CardNo.P3_S01_062:
                    // 【自】［(1)］ バトルしているこのカードが【リバース】した時、あなたはコストを払ってよい。そうしたら、このカードを手札に戻す。
                    PayCost(1);
                    m_MyMainCardsManager.CallPutHandFromField(place);
                    m_GameManager.ExecuteActionList();
                    m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
                    return;
                case EnumController.CardNo.P3_S01_065:
                    //【自】 このカードがプレイされて舞台に置かれた時、あなたはすべてのプレイヤーに、1ダメージを与える。
                    m_GameManager.Damage_EachPlayer(1);
                    return;
                case EnumController.CardNo.P3_S01_068:
                    // あなたは自分の控え室のキャラを1枚選び、手札に戻す。
                    PayCost(1);
                    m_DialogManager.SulvageDialog(handNum, m_BattleModeCard, m_GameManager.GraveYardList, EnumController.Type.CHARACTER, 1, 1);
                    return;
                case EnumController.CardNo.P3_S01_069:
                    // あなたはレベル2以下の相手の前列のキャラを1枚選び、控え室に置く。
                    PayCost(1);
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
                    return;
                case EnumController.CardNo.P3_S01_071:
                    // あなたは相手に1ダメージを与える。
                    PayCost(1);
                    m_BattleStrix.RpcToAll("CallDamage",1 ,handNum ,m_GameManager.isFirstAttacker);
                    return;
                case EnumController.CardNo.P3_S01_072:
                    //あなたはレベル1以下の相手のキャラを1枚選び、山札の上に置く。
                    PayCost(2);
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
                    return;
                case EnumController.CardNo.P3_S01_076:
                    //【自】［(1) このカードを【レスト】する］ 他の《生徒会》のあなたのキャラがプレイされて舞台に置かれた時、あなたはコストを払ってよい。そうしたら、あなたは1枚引く。
                    PayCost(1);
                    m_MyMainCardsManager.CallOnRest(place);
                    m_GameManager.Syncronize();
                    m_GameManager.Draw();
                    m_GameManager.ExecuteActionList();
                    m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
                    return;
                case EnumController.CardNo.P3_S01_080:
                    //【自】 このカードがプレイされて舞台に置かれた時、あなたは1枚引いてよい。
                    m_GameManager.Draw();
                    m_GameManager.Syncronize();
                    m_GameManager.ExecuteActionList();
                    return;
                case EnumController.CardNo.P3_S01_077:
                case EnumController.CardNo.P3_S01_081:
                    //【自】 このカードがアタックした時、クライマックス置場に「最強なる者」があるなら、あなたは1枚引く。
                    //【自】 このカードがアタックした時、クライマックス置場に「父の遺志」があるなら、あなたは1枚引く。
                    m_GameManager.Draw();
                    m_GameManager.ExecuteActionList();
                    return;
                case EnumController.CardNo.P3_S01_088:
                    //【自】［(2)］ このカードがプレイされて舞台に置かれた時、あなたはコストを払ってよい。そうしたら、あなたは自分のクロックを上から1枚選び、控え室に置く。
                    PayCost(2);
                    int cnt = m_GameManager.myClockList.Count;
                    if (cnt == 0)
                    {
                        return;
                    }
                    m_GameManager.GraveYardList.Add(m_GameManager.myClockList[cnt - 1]);
                    m_GameManager.myClockList.RemoveAt(cnt - 1);
                    m_GameManager.Syncronize();
                    m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
                    return;
                case EnumController.CardNo.P3_S01_093:
                    // あなたは1枚引く。
                    m_GameManager.Draw();
                    m_GameManager.myHandList.RemoveAt(handNum);
                    m_GameManager.GraveYardList.Add(m_BattleModeCard);
                    m_GameManager.Syncronize();
                    return;
                case EnumController.CardNo.P3_S01_094:
                    //【カウンター】 あなたは相手のキャラを1枚選び、【レスト】する。
                    PayCost(4);
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
                    return;
                case EnumController.CardNo.P3_S01_095:
                    // あなたは自分のクロックすべてを、手札に戻す。このカードを思い出にする。
                    PayCost(8);
                    for (int i = 0; i < m_GameManager.myClockList.Count; i++)
                    {
                        m_GameManager.myHandList.Add(m_GameManager.myClockList[i]);
                    }
                    m_GameManager.myClockList = new List<BattleModeCard>();
                    m_GameManager.myHandList.RemoveAt(handNum);
                    m_GameManager.myMemoryList.Add(m_BattleModeCard);
                    m_GameManager.Syncronize();
                    return;
                default:
                    break;
            }
            switch (m_BattleModeCard.cardNo)
            {
                case EnumController.CardNo.LB_W02_001:
                    //【起】［(2) このカードを【レスト】する］ あなたは自分の山札を見て《スポーツ》のキャラを1枚まで選んで相手に見せ、手札に加える。その山札をシャッフルする。
                    EffectWhenAct(m_BattleModeCard);
                    PayCost(2);
                    m_MyMainCardsManager.CallOnRest(place);
                    m_DialogManager.SearchDialog(EnumController.SearchDialogParamater.LB_W02_001, handNum);
                    return;
                case EnumController.CardNo.LB_W02_002:
                case EnumController.CardNo.LB_W02_004:
                    //【自】［(1)］ このカードがアタックした時、クライマックス置場に「鈴と共にある日々」があるなら、あなたはコストを払ってよい。そうしたら、あなたは相手のキャラを１枚選び、手札に戻す。
                    //【自】［(1)］ このカードがアタックした時、クライマックス置場に「リーダーの帰還」があるなら、あなたはコストを払ってよい。そうしたら、あなたは相手のキャラを１枚選び、手札に戻す。
                    PayCost(1);
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
                    return;
                case EnumController.CardNo.LB_W02_003:
                    //【自】 この能力は、1ターンにつき2回しか使えない。あなたが【起】を使った時、あなたは自分のキャラを1枚選び、そのターン中、パワーを＋500。
                    CheckActEffectCount = m_MyMainCardsManager.CheckActEffectCount(place) + 1;
                    m_MyMainCardsManager.SetActEffectCount(place, CheckActEffectCount);

                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, -1);
                    return;
                case EnumController.CardNo.LB_W02_007:
                    //【起】［(2)］ あなたはレベル0以下の相手のキャラを1枚選び、手札に戻す。
                    PayCost(2);
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
                    return;
                case EnumController.CardNo.LB_W02_018:
                    //※イベント
                    //あなたはレベル0以下の相手の前列のキャラを1枚選び、手札に戻す。このカードをストック置場に置く。
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
                    return;
                case EnumController.CardNo.LB_W02_019:
                    //※イベント
                    //あなたはレベル1以下の相手のキャラを1枚選び、ストック置場に置く。
                    PayCost(1);
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
                    return;
                case EnumController.CardNo.LB_W02_022:
                    //※イベント
                    //あなたは自分のキャラを2枚まで選び、そのターン中、パワーを＋2000。
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, -1);
                    return;
                case EnumController.CardNo.LB_W02_031:
                    //【自】 このカードとバトルしているレベル2以上のキャラが【リバース】した時、あなたは自分の山札の上から1枚を、ストック置場に置いてよい。
                    m_GameManager.myStockList.Add(m_GameManager.myDeckList[0]);
                    m_GameManager.myDeckList.RemoveAt(0);
                    m_GameManager.Syncronize();
                    if (m_GameManager.myDeckList.Count == 0)
                    {
                        m_GameManager.Refresh();
                    }
                    else
                    {
                        m_GameManager.ExecuteActionList();
                        return;
                    }
                    return;
                case EnumController.CardNo.LB_W02_038:
                    //【起】［このカードを【レスト】する］ あなたは自分のキャラを1枚選び、ストック置場に置く
                    EffectWhenAct(m_BattleModeCard);
                    m_MyMainCardsManager.CallOnRest(place);
                    m_GameManager.Syncronize();
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, -1);
                    return;
                case EnumController.CardNo.LB_W02_043:
                    //※イベント
                    //あなたは自分のキャラすべてに、そのターン中、パワーを＋1500。
                    int count = 0;
                    int power = 1500;

                    for (int i = 0; i < m_GameManager.myFieldList.Count; i++)
                    {
                        if (m_GameManager.myFieldList[i] != null)
                        {
                            m_MyMainCardsManager.AddPowerUpUntilTurnEnd(i, power);
                        }
                    }
                    m_GameManager.GraveYardList.Add(m_GameManager.myHandList[handNum]);
                    m_GameManager.myHandList.RemoveAt(handNum);
                    m_GameManager.Syncronize();
                    m_GameManager.ExecuteActionList();
                    return;
                case EnumController.CardNo.LB_W02_054:
                    //【起】［(2) このカードを【レスト】する］ あなたは相手に1ダメージを与える。
                    EffectWhenAct(m_BattleModeCard);
                    PayCost(2);
                    m_MyMainCardsManager.CallOnRest(place);
                    m_GameManager.Syncronize();
                    m_BattleStrix.RpcToAll("CallDamage", 1, handNum, m_GameManager.isFirstAttacker);
                    return;
                case EnumController.CardNo.LB_W02_055:
                    //【自】［(1)］ このカードがアタックした時、クライマックス置場に「リトルバスターズ！」があるなら、あなたはコストを払ってよい。そうしたら、自分の控え室のキャラを1枚選び、手札に戻す。
                    PayCost(1);
                    m_DialogManager.SulvageDialog(m_BattleModeCard, m_GameManager.GraveYardList, EnumController.Type.CHARACTER, 0, 1);
                    return;
                case EnumController.CardNo.LB_W02_062:
                    //【自】 この能力は、1ターンにつき2回しか使えない。あなたが【起】を使った時、そのターン中、このカードのパワーを＋1500。
                    CheckActEffectCount = m_MyMainCardsManager.CheckActEffectCount(place) + 1;
                    m_MyMainCardsManager.SetActEffectCount(place, CheckActEffectCount);

                    m_MyMainCardsManager.AddPowerUpUntilTurnEnd(place, 1500);
                    m_GameManager.Syncronize();
                    m_GameManager.ExecuteActionList();
                    return;
                case EnumController.CardNo.LB_W02_069:
                    //※イベント
                    //あなたは相手の前列のキャラを1枚選び、控え室に置く。
                    PayCost(2);
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
                    return;
                case EnumController.CardNo.LB_W02_12T:
                case EnumController.CardNo.LB_W02_093:
                    //※イベント
                    //あなたは自分の山札を見て《動物》のキャラを1枚まで選んで相手に見せ、手札に加える。その山札をシャッフルする。
                    PayCost(1);
                    m_DialogManager.SearchDialog(EnumController.SearchDialogParamater.LB_W02_093, handNum);
                    return;
                default:
                    break;
            }
            int pumpPoint = 0;
            // Counter用
            switch (m_BattleModeCard.cardNo)
            {
                case EnumController.CardNo.LB_W02_07T:
                case EnumController.CardNo.P3_S01_03T:
                case EnumController.CardNo.P3_S01_009:
                case EnumController.CardNo.P3_S01_033:
                case EnumController.CardNo.P3_S01_091:
                case EnumController.CardNo.LB_W02_040:
                    EffectWhenAct(m_BattleModeCard);
                    pumpPoint = 2000;
                    PayCost(1);
                    m_MyMainCardsManager.AddPowerUpUntilTurnEnd(place, pumpPoint);
                    m_GameManager.myHandList.RemoveAt(handNum);
                    m_GameManager.GraveYardList.Add(m_BattleModeCard);
                    m_GameManager.Syncronize();
                    m_GameManager.ExecuteActionList();
                    return;
                case EnumController.CardNo.AT_WX02_A05:
                    EffectWhenAct(m_BattleModeCard);
                    pumpPoint = 2500;
                    PayCost(1);
                    m_MyMainCardsManager.AddPowerUpUntilTurnEnd(place, pumpPoint);
                    m_GameManager.myHandList.RemoveAt(handNum);
                    m_GameManager.GraveYardList.Add(m_BattleModeCard);
                    m_GameManager.Syncronize();
                    m_GameManager.ExecuteActionList();
                    return;
                case EnumController.CardNo.DC_W01_17T:
                case EnumController.CardNo.P3_S01_067:
                    EffectWhenAct(m_BattleModeCard);
                    pumpPoint = 3000;
                    PayCost(1);
                    m_MyMainCardsManager.AddPowerUpUntilTurnEnd(place, pumpPoint);
                    m_GameManager.myHandList.RemoveAt(handNum);
                    m_GameManager.GraveYardList.Add(m_BattleModeCard);
                    m_GameManager.Syncronize();
                    m_GameManager.ExecuteActionList();
                    return;
                default: 
                    break;
            }
        }else if(effectNum == 1)
        {
            switch (m_BattleModeCard.cardNo)
            {
                case EnumController.CardNo.DC_W01_02T:
                    // 【自】 このカードがプレイされて舞台に置かれた時、あなたは相手の手札を見る。
                    m_BattleStrix.RpcToAll("CallGetHandList", m_GameManager.isTurnPlayer);
                    break;
                case EnumController.CardNo.DC_W01_10T:
                    // 【自】［(1)］ このカードがアタックした時、クライマックス置場に「美春のオルゴール」があるなら、
                    // あなたはコストを払ってよい。そうしたら、あなたは自分の控え室のキャラを1枚選び、手札に戻す。
                    PayCost(1);
                    m_DialogManager.SulvageDialog(m_BattleModeCard, m_GameManager.GraveYardList, EnumController.Type.CHARACTER, 1, 1);
                    break;
                case EnumController.CardNo.LB_W02_02T:
                case EnumController.CardNo.LB_W02_033:
                    // 【起】［(1)］ あなたは自分のキャラを1枚選び、そのターン中、パワーを＋1500。
                    EffectWhenAct(m_BattleModeCard);
                    PayCost(1);
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, -1);
                    break;
                case EnumController.CardNo.LB_W02_14T:
                    // 【自】 あなたがレベルアップした時、あなたは自分の山札を上から1枚選び、ストック置場に置く。
                    m_GameManager.myStockList.Add(m_GameManager.myDeckList[0]);
                    m_GameManager.myDeckList.RemoveAt(0);
                    m_GameManager.Syncronize();
                    if (m_GameManager.myDeckList.Count == 0)
                    {
                        m_GameManager.Refresh();
                    }
                    else
                    {
                        m_GameManager.ExecuteActionList();
                        return;
                    }
                    return;
                case EnumController.CardNo.P3_S01_01T:
                case EnumController.CardNo.P3_S01_005:
                    // 【自】 このカードがアタックした時、クライマックス置場に「復讐の終わり」があるなら、
                    // あなたは相手のキャラを1枚選び、手札に戻してよい。
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
                    break;
                case EnumController.CardNo.P3_S01_04T:
                case EnumController.CardNo.P3_S01_010:
                    // 【起】［(2) このカードを【レスト】する］ あなたはこのカードを手札に戻す。
                    EffectWhenAct(m_BattleModeCard);
                    PayCost(2);
                    m_MyMainCardsManager.CallOnRest(place);
                    m_GameManager.ToHandFromField(place);
                    break;
                case EnumController.CardNo.P3_S01_11T:
                case EnumController.CardNo.P3_S01_017:
                    // 【起】［(1)］ そのターン中、このカードのソウルを＋1。
                    EffectWhenAct(m_BattleModeCard);
                    PayCost(1);
                    m_MyMainCardsManager.AddSoulUpUntilTurnEnd(place, 1);
                    m_GameManager.Syncronize();
                    m_GameManager.ExecuteActionList();
                    break;
                case EnumController.CardNo.P3_S01_052:
                    // 【起】［(3)］ あなたはレベル1以下の相手の前列のキャラを1枚選び、控え室に置く。
                    EffectWhenAct(m_BattleModeCard);
                    PayCost(3);
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
                    return;
                case EnumController.CardNo.P3_S01_055:
                    //【自】 他のバトルしているあなたのキャラが【リバース】した時、そのターン中、このカードのパワーを＋2000。
                    m_MyMainCardsManager.AddPowerUpUntilTurnEnd(place, 2000);
                    m_GameManager.Syncronize();
                    m_GameManager.ExecuteActionList();
                    return;
                case EnumController.CardNo.P3_S01_057:
                    //【自】 このカードが【リバース】した時、このカードとバトルしているキャラのレベルが0以下なら、あなたはそのキャラを【リバース】してよい。
                    m_EnemyMainCardsManager.CallReverse(enemyPlace);
                    m_BattleStrix.RpcToAll("CallMyReverse", enemyPlace, m_GameManager.isTurnPlayer);
                    m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
                    m_GameManager.ExecuteActionList();
                    return;
                case EnumController.CardNo.P3_S01_061:
                    //【自】 このカードがアタックした時、クライマックス置場に「ニュクス・アバター」があるなら、あなたは自分の控え室のキャラを1枚選び、手札に戻す。
                    m_DialogManager.SulvageDialog(m_BattleModeCard, m_GameManager.GraveYardList, EnumController.Type.CHARACTER, 1, 1);
                    return;
                case EnumController.CardNo.P3_S01_065:
                    //【自】［(1)］ このカードが舞台から控え室に置かれた時、あなたはコストを払ってよい。そうしたら、あなたは自分の控え室の「順平＆トリスメギストス」を1枚選び、手札に戻す。
                    PayCost(1);
                    m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
                    for (int i = 0; i < m_GameManager.GraveYardList.Count; i++)
                    {
                        if (m_GameManager.GraveYardList[i].name == "順平＆トリスメギストス")
                        {
                            m_GameManager.myHandList.Add(m_GameManager.GraveYardList[i]);
                            m_GameManager.GraveYardList.RemoveAt(i);
                            m_GameManager.Syncronize();
                            m_GameManager.ExecuteActionList();
                            return;
                        }
                    }
                    m_GameManager.ExecuteActionList();
                    return;
                case EnumController.CardNo.P3_S01_077:
                    //【起】［(4)］ あなたは自分の山札を見てイベントを1枚まで選んで相手に見せ、手札に加える。その山札をシャッフルする。
                    EffectWhenAct(m_BattleModeCard);
                    PayCost(4);
                    m_DialogManager.SearchDialog(EnumController.SearchDialogParamater.P3_S01_077);
                    return;
                case EnumController.CardNo.P3_S01_080:
                    //【自】［(1)］ このカードがプレイされて舞台に置かれた時、あなたはコストを払ってよい。そうしたら、あなたは自分の控え室の「ベルベットルーム」を1枚選び、手札に戻す。
                    PayCost(1);
                    for (int i = 0; i < m_GameManager.GraveYardList.Count; i++)
                    {
                        if (m_GameManager.GraveYardList[i].name == "ベルベットルーム")
                        {
                            m_GameManager.myHandList.Add(m_GameManager.GraveYardList[i]);
                            m_GameManager.GraveYardList.RemoveAt(i);
                            m_GameManager.Syncronize();
                            m_GameManager.ExecuteActionList();
                            return;
                        }
                    }
                    m_GameManager.ExecuteActionList();
                    return;
                case EnumController.CardNo.P3_S01_081:
                    //【起】［(4)］ あなたは自分のクロックを1枚選び、手札に戻す。
                    EffectWhenAct(m_BattleModeCard);
                    PayCost(4);
                    if (m_GameManager.myClockList.Count == 0)
                    {
                        m_GameManager.ExecuteActionList();
                        return;
                    }
                    m_DialogManager.SearchDialog(EnumController.SearchDialogParamater.P3_S01_081);
                    return;
                case EnumController.CardNo.P3_S01_16T:
                case EnumController.CardNo.P3_S01_087:
                    // 【自】 他の《生徒会》のあなたのキャラがプレイされて舞台に置かれた時、あなたは自分の山札を上から1枚見て、山札の上か下に置く。
                    m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.CONFIRM_CONTROL_DECKTOP, m_BattleModeCard);
                    break;
                case EnumController.CardNo.P3_S01_091:
                    // 【起】［(2) このカードを【レスト】する］ あなたはこのカードを手札に戻す。
                    EffectWhenAct(m_BattleModeCard);
                    PayCost(2);
                    m_MyMainCardsManager.CallOnRest(place);
                    m_MyMainCardsManager.CallPutHandFromField(place);
                    m_GameManager.Syncronize();
                    return;
                default:
                    break;
            }
        }
        else if (effectNum == 2)
        {
            switch (m_BattleModeCard.cardNo)
            {
                case EnumController.CardNo.P3_S01_080:
                    //【起】［(2) このカードを【レスト】する］ あなたはクライマックス以外の自分の控え室のカードを1枚選び、そのカードとこのカードを山札に戻す。その山札をシャッフルする。あなたは1枚引く。
                    EffectWhenAct(m_BattleModeCard);
                    PayCost(2);
                    m_MyMainCardsManager.CallOnRest(place);
                    for(int i = 0; i < m_GameManager.myDeckList.Count; i++)
                    {
                        if (m_GameManager.myDeckList[i].type != EnumController.Type.CLIMAX)
                        {
                            m_DialogManager.GraveyardSelectDialog(m_BattleModeCard, place);
                            return;
                        }
                    }
                    return;
                default:
                    break;
            }
        }
    }

    /// <summary>
    /// イベントを打たれたプレイヤー用
    /// </summary>
    /// <param name="card"></param>
    public void AnimationStartForRPC(BattleModeCardTemp card)
    {
        BattleModeCard b = m_BattleModeCardList.ConvertCardNoToBattleModeCard(card.cardNo);
        isFromRPC = true;
        m_gameObject.SetActive(true);

        m_BattleModeCard = b;
        m_image.sprite = b.sprite;
        m_image2.sprite = b.sprite;
        // アニメーション再生を再生するためにspeedを1にする
        animator.speed = 1;
        animator.Play(AnimationName, 0, 0);
    }

    private void AnimationEndForRPC()
    {
        m_gameObject.SetActive(false);
    }

    private void PayCost(int num)
    {
        for (int i = 0; i < num; i++)
        {
            m_GameManager.GraveYardList.Add(m_GameManager.myStockList[m_GameManager.myStockList.Count - 1]);
            m_GameManager.myStockList.RemoveAt(m_GameManager.myStockList.Count - 1);
        }
        m_GameManager.Syncronize();
    }

    /// <summary>
    /// あなたが【起】を使った時の効果のためのメソッド
    /// </summary>
    private void EffectWhenAct(BattleModeCard card)
    {
        Action action = new Action(m_GameManager, EnumController.Action.EffectWhenAct);
        action.SetParamaterEventAnimationManager(this);
        action.SetParamaterMyMainCardsManager(m_MyMainCardsManager);
        action.SetParamaterBattleStrix(m_BattleStrix);
        action.SetParamaterBattleModeCard(card);
        m_GameManager.ActionList.Add(action);
    }
}
