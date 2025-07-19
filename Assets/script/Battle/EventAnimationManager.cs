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
        this.paramater = EnumController.YesOrNoDialogParamater.VOID;
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
    /// バウンストリガー用
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
    public void AnimationStart(BattleModeCard card, int place, int handNum)
    {
        this.handNum = handNum;
        AnimationStart(card, place);
    }

    /// <summary>
    /// イベントを再生したプレイヤー用
    /// </summary>
    /// <param name="card"></param>
    public void AnimationStart(BattleModeCard card, int place)
    {
        this.place = place;
        AnimationStart(card);
    }

    /// <summary>
    /// イベントを再生したプレイヤー用
    /// </summary>
    /// <param name="card"></param>
    public void AnimationStart_2(BattleModeCard card, int place)
    {
        this.place = place;
        AnimationStart_2(card);
    }

    /// <summary>
    /// イベントを再生したプレイヤー用
    /// </summary>
    /// <param name="card"></param>
    public void AnimationStart(BattleModeCard card)
    {
        this.paramater = EnumController.YesOrNoDialogParamater.VOID;
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
    /// イベントを再生したプレイヤー用
    /// </summary>
    /// <param name="card"></param>
    public void AnimationStart_2(BattleModeCard card)
    {
        this.paramater = EnumController.YesOrNoDialogParamater.VOID;
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
        place = -1;
        damage = -1;
    }

    private void Execute()
    {
        if(paramater == EnumController.YesOrNoDialogParamater.CONFIRM_BOUNCE_TRIGGER_FRONT || paramater == EnumController.YesOrNoDialogParamater.CONFIRM_BOUNCE_TRIGGER_SIDE || paramater == EnumController.YesOrNoDialogParamater.CONFIRM_BOUNCE_TRIGGER_DIRECT)
        {
            m_DialogManager.CharacterSelectDialog(damage, place, paramater);
            return;
        }
        // 絆
        switch (m_BattleModeCard.cardNo)
        {
            case EnumController.CardNo.AT_WX02_A10:
            case EnumController.CardNo.DC_W01_09T:
            case EnumController.CardNo.P3_S01_003:
            case EnumController.CardNo.P3_S01_032:
                m_EffectBondForHandToField.BondForCost(sulvageCardName, cost);
                return;
            default: 
                break;
        }

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
                    m_DialogManager.SearchDialog(m_GameManager.myDeckList, EnumController.SearchDialogParamater.Search, m_BattleModeCard);
                    return;
                case EnumController.CardNo.DC_W01_01T:
                    // 【起】［このカードを【レスト】する］ あなたは自分のキャラを1枚選び、そのターン中、パワーを＋1000。
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
                    PayCost(1);
                    m_MyMainCardsManager.AddPowerUpUntilTurnEnd(place, 2000);
                    m_GameManager.Syncronize();
                    m_GameManager.ExecuteActionList();
                    return;
                case EnumController.CardNo.DC_W01_05T:
                    //【起】［(1)］ あなたは相手の前列のキャラを1枚選び、そのターン中、パワーを－1000。
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
                    PayCost(2);
                    m_MyMainCardsManager.CallOnRest(place);
                    m_GameManager.Syncronize();
                    m_DialogManager.SulvageDialog(m_BattleModeCard, m_GameManager.GraveYardList, EnumController.Type.CHARACTER, 0, 1);
                    return;
                case EnumController.CardNo.DC_W01_16T:
                case EnumController.CardNo.P3_S01_058:
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
                    // 【起】［(1)］ このカードを思い出にする。
                    PayCost(1);
                    m_MyMainCardsManager.CallPutMemoryFromField(place);
                    m_GameManager.ExecuteActionList();
                    return;
                case EnumController.CardNo.DC_W01_02T:
                case EnumController.CardNo.LB_W02_03T:
                case EnumController.CardNo.P3_S01_030:
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
                    //【カウンター】 あなたは自分のキャラを2枚まで選び、そのターン中、パワーを＋1000。
                    PayCost(1);
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, -1);
                    break;
                case EnumController.CardNo.LB_W02_05T:
                    // 【起】［(1)］ 他のあなたのキャラすべてに、そのターン中、《動物》を与える。
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
                    //【起】［(1)］ あなたは相手のキャラを1枚選び、そのターン中、パワーを－500。
                    PayCost(1);
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
                    return;
                case EnumController.CardNo.LB_W02_14T:
                    // 【起】［(2) このカードを【レスト】する］ あなたは自分のクロックを上から1枚選び、控え室に置く。
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
                    if (m_GameManager.myClockList.Count == 0)
                    {
                        PayCost(3);
                        m_GameManager.myMemoryList.Add(m_BattleModeCard);
                        m_GameManager.myHandList.Remove(m_BattleModeCard);
                        m_GameManager.Syncronize();
                        m_GameManager.ExecuteActionList();
                        return;
                    }
                    m_DialogManager.SearchDialog(m_GameManager.myClockList, EnumController.SearchDialogParamater.ClockSulvage, m_BattleModeCard);
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
                    PayCost(2);
                    m_MyMainCardsManager.CallOnRest(place);
                    m_GameManager.Syncronize();
                    m_GameManager.Draw();
                    break;
                case EnumController.CardNo.P3_S01_018:
                    // あなたは相手のキャラを1枚選び、そのターン中、レベルを－1。
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
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
                            return;
                        }
                    }
                    return;
                case EnumController.CardNo.P3_S01_060:
                    //【自】［(1)］ このカードがプレイされて舞台に置かれた時、あなたはコストを払ってよい。そうしたら、あなたはレベル1以下の相手のキャラを1枚選び、控え室に置く。
                    PayCost(1);
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
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
            int pumpPoint = 0;
            int cost = 0;
            // Counter用
            switch (m_BattleModeCard.cardNo)
            {
                case EnumController.CardNo.LB_W02_07T:
                case EnumController.CardNo.P3_S01_03T:
                case EnumController.CardNo.P3_S01_009:
                case EnumController.CardNo.P3_S01_033:
                case EnumController.CardNo.P3_S01_091:
                    pumpPoint = 2000;
                    PayCost(1);
                    m_MyMainCardsManager.AddPowerUpUntilTurnEnd(place, pumpPoint);
                    m_GameManager.myHandList.RemoveAt(handNum);
                    m_GameManager.GraveYardList.Add(m_BattleModeCard);
                    m_GameManager.Syncronize();
                    m_GameManager.ExecuteActionList();
                    return;
                case EnumController.CardNo.AT_WX02_A05:
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
                    m_DialogManager.SulvageDialog(m_BattleModeCard, m_GameManager.GraveYardList, EnumController.Type.CHARACTER, 0, 1);
                    break;
                case EnumController.CardNo.LB_W02_02T:
                    // 【起】［(1)］ あなたは自分のキャラを1枚選び、そのターン中、パワーを＋1500。
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
                    PayCost(2);
                    m_MyMainCardsManager.CallOnRest(place);
                    m_GameManager.ToHandFromField(place);
                    break;
                case EnumController.CardNo.P3_S01_11T:
                case EnumController.CardNo.P3_S01_017:
                    // 【起】［(1)］ そのターン中、このカードのソウルを＋1。
                    PayCost(1);
                    m_MyMainCardsManager.AddSoulUpUntilTurnEnd(place, 1);
                    m_GameManager.Syncronize();
                    m_GameManager.ExecuteActionList();
                    break;
                case EnumController.CardNo.P3_S01_052:
                    // 【起】［(3)］ あなたはレベル1以下の相手の前列のキャラを1枚選び、控え室に置く。
                    PayCost(3);
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
                    return;
                case EnumController.CardNo.P3_S01_16T:
                case EnumController.CardNo.P3_S01_087:
                    // 【自】 他の《生徒会》のあなたのキャラがプレイされて舞台に置かれた時、あなたは自分の山札を上から1枚見て、山札の上か下に置く。
                    m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.CONFIRM_CONTROL_DECKTOP, m_BattleModeCard);
                    break;
                case EnumController.CardNo.P3_S01_091:
                    // 【起】［(2) このカードを【レスト】する］ あなたはこのカードを手札に戻す。
                    PayCost(2);
                    m_MyMainCardsManager.CallOnRest(place);
                    m_MyMainCardsManager.CallPutHandFromField(place);
                    m_GameManager.Syncronize();
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
}
