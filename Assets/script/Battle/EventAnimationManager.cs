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

    private bool isFromRPC = false;

    private EffectAbstract m_EffectAbstract;

    private EnumController.YesOrNoDialogParamater paramater;

    private EnumController.EventAnimation EventAnimationParamater;

    private int damage = -1;

    // Start is called before the first frame update
    void Start()
    {
        animator.AddClipEndCallback(NormalAnimationLayerIndex, AnimationName, () => AnimationEnd());
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

        m_BattleModeCard = card;
        m_image.sprite = card.GetSprite();
        m_image2.sprite = card.GetSprite();
        // アニメーション再生を再生するためにspeedを1にする
        animator.speed = 1;
        animator.Play(AnimationName, 0, 0);
        m_BattleStrix.RpcToAll("SEManager_EffectSE_Play");
    }

    /// <summary>
    /// イベントを再生したプレイヤー用
    /// </summary>
    public void ActAnimationStart(BattleModeCard card, EffectAbstract m_EffectAbstract)
    {
        EventAnimationParamater = EnumController.EventAnimation.Act;
        this.m_EffectAbstract = m_EffectAbstract;
        AnimationStart(card);
    }

    /// <summary>
    /// イベントを再生したプレイヤー用
    /// </summary>
    public void AutoAnimationStart(BattleModeCard card, EffectAbstract m_EffectAbstract)
    {
        EventAnimationParamater = EnumController.EventAnimation.Auto;
        this.m_EffectAbstract = m_EffectAbstract;
        AnimationStart(card);
    }

    public void CounterAnimationStart(BattleModeCard card, EffectAbstract m_EffectAbstract)
    {
        EventAnimationParamater = EnumController.EventAnimation.Counter;
        this.m_EffectAbstract = m_EffectAbstract;
        AnimationStart(card);
    }

    public void EventAnimationStart(BattleModeCard card, EffectAbstract m_EffectAbstract)
    {
        EventAnimationParamater = EnumController.EventAnimation.Event;
        this.m_EffectAbstract = m_EffectAbstract;
        AnimationStart(card);
    }

    public void KizunaAnimationStart(BattleModeCard card, EffectAbstract m_EffectAbstract)
    {
        EventAnimationParamater = EnumController.EventAnimation.Kizuna;
        this.m_EffectAbstract = m_EffectAbstract;
        AnimationStart(card);
    }

    /// <summary>
    /// イベントを再生したプレイヤー用
    /// </summary>
    /// <param name="card"></param>
    private void AnimationStart(BattleModeCard card)
    {
        this.paramater = EnumController.YesOrNoDialogParamater.VOID;
        isFromRPC = false;
        m_gameObject.SetActive(true);

        m_BattleModeCard = card;
        m_image.sprite = card.GetSprite();
        m_image2.sprite = card.GetSprite();
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

        switch (EventAnimationParamater)
        {
            case EnumController.EventAnimation.Act:
                m_EffectAbstract.ActExecute();
                break;
            case EnumController.EventAnimation.Auto:
                m_EffectAbstract.AutoExecute();
                break;
            case EnumController.EventAnimation.Counter:
                m_EffectAbstract.CounterExecute();
                break;
            case EnumController.EventAnimation.Event:
                m_EffectAbstract.EventExecute();
                break;
            case EnumController.EventAnimation.Kizuna:
                m_EffectAbstract.KizunaExecute();
                break;
            default:
                break;
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
        m_image.sprite = b.GetSprite();
        m_image2.sprite = b.GetSprite();
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

    /// <summary>
    /// 【自】 あなたが『助太刀』を使った時の効果のためのメソッド
    /// </summary>
    /// <param name="card"></param>
    private void EffectWhenCounter(BattleModeCard card, int BattlePlace)
    {
        Action action = new Action(m_GameManager, EnumController.Action.EffectWhenCounter);
        action.SetParamaterEventAnimationManager(this);
        action.SetParamaterMyMainCardsManager(m_MyMainCardsManager);
        action.SetParamaterBattleStrix(m_BattleStrix);
        action.SetParamaterBattleModeCard(card);
        action.SetParamaterNum(BattlePlace);
        m_GameManager.ActionList.Add(action);
    }
}
