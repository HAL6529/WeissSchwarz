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

    // Start is called before the first frame update
    void Start()
    {
        animator.AddClipEndCallback(NormalAnimationLayerIndex, AnimationName, () => AnimationEnd());
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
    public void AnimationStart(BattleModeCard card)
    {
        isFromRPC = false;
        m_gameObject.SetActive(true);

        m_BattleModeCard = card;
        m_image.sprite = card.sprite;
        m_image2.sprite = card.sprite;
        // アニメーション再生を再生するためにspeedを1にする
        animator.speed = 1;
        animator.Play(AnimationName, 0, 0);
    }

    private void AnimationEnd()
    {
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
        m_gameObject.SetActive(false);
        if (isFromRPC)
        {
            place = -1;
            return;
        }
        switch (m_BattleModeCard.cardNo)
        {
            case EnumController.CardNo.AT_WX02_A07:
                m_DialogManager.SearchDialog(m_GameManager.myDeckList, EnumController.SearchDialogParamater.Search, m_BattleModeCard);
                break;
            case EnumController.CardNo.DC_W01_01T:
                // 【起】［このカードを【レスト】する］ あなたは自分のキャラを1枚選び、そのターン中、パワーを＋1000。
                m_MyMainCardsManager.CallOnRest(place);
                m_GameManager.Syncronize();
                m_MainPowerUpDialog.SetBattleMordCard(m_BattleModeCard);
                break;
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
                break;
            case EnumController.CardNo.DC_W01_04T:
                m_GameManager.GraveYardList.Add(m_GameManager.myStockList[m_GameManager.myStockList.Count - 1]);
                m_GameManager.myStockList.RemoveAt(m_GameManager.myStockList.Count - 1);
                m_MyMainCardsManager.AddPowerUpUntilTurnEnd(place, 2000);
                m_GameManager.Syncronize();
                break;
            case EnumController.CardNo.DC_W01_10T:
                // 【自】 このカードとバトルしているキャラが【リバース】した時、あなたはそのキャラを山札の上に置いてよい。
                m_BattleStrix.RpcToAll("ToDeckTopFromField", place, m_GameManager.isTurnPlayer);
                break;
            case EnumController.CardNo.DC_W01_12T:
                // あなたは自分の控え室のキャラを2枚まで選び、手札に戻す。
                for (int i = 0; i < 2; i++)
                {
                    m_GameManager.GraveYardList.Add(m_GameManager.myStockList[m_GameManager.myStockList.Count - 1]);
                    m_GameManager.myStockList.RemoveAt(m_GameManager.myStockList.Count - 1);
                }
                m_GameManager.Syncronize();
                m_DialogManager.SulvageDialog(m_BattleModeCard, m_GameManager.GraveYardList, EnumController.Type.CHARACTER, 0, 2);
                break;
            case EnumController.CardNo.DC_W01_13T:
                // 【起】［(2) このカードを【レスト】する］ あなたは自分の控え室のキャラを1枚選び、手札に戻す。
                for (int i = 0; i < 2; i++)
                {
                    m_GameManager.GraveYardList.Add(m_GameManager.myStockList[m_GameManager.myStockList.Count - 1]);
                    m_GameManager.myStockList.RemoveAt(m_GameManager.myStockList.Count - 1);
                }
                m_MyMainCardsManager.CallOnRest(place);
                m_GameManager.Syncronize();
                m_DialogManager.SulvageDialog(m_BattleModeCard, m_GameManager.GraveYardList, EnumController.Type.CHARACTER, 0, 1);
                break;
            case EnumController.CardNo.DC_W01_16T:
                m_EnemyMainCardsManager.CallReverse(enemyPlace);
                m_BattleStrix.RpcToAll("CallMyReverse", enemyPlace, m_GameManager.isTurnPlayer);
                break;
            case EnumController.CardNo.LB_W02_03T:
                // 【自】 このカードがアタックした時、クライマックス置場に「そよ風のハミング」があるなら、あなたは自分の山札を上から1枚選び、
                // ストック置場に置き、そのターン中、このカードのパワーを＋3000。
                /*m_GameManager.myStockList.Add(m_GameManager.myDeckList[0]);
                m_GameManager.myDeckList.RemoveAt(0);
                m_GameManager.Syncronize();
                if (m_GameManager.myDeckList.Count == 0)
                {
                    m_GameManager.Refresh();
                }*/
                break;
            case EnumController.CardNo.LB_W02_05T:
                // 【起】［(1)］ 他のあなたのキャラすべてに、そのターン中、《動物》を与える。
                m_GameManager.GraveYardList.Add(m_GameManager.myStockList[m_GameManager.myStockList.Count - 1]);
                m_GameManager.myStockList.RemoveAt(m_GameManager.myStockList.Count - 1);
                for(int i = 0; i < m_GameManager.myFieldList.Count; i++)
                {
                    if (m_GameManager.myFieldList[i] != null)
                    {
                        m_MyMainCardsManager.SetAttributeUpUntilTurnEnd(i, EnumController.Attribute.Animal);
                    }
                }
                m_GameManager.Syncronize();
                break;
            case EnumController.CardNo.LB_W02_16T:
                if (m_GameManager.myClockList.Count == 0)
                {
                    for(int i = 0;i < 3; i++)
                    {
                        m_GameManager.GraveYardList.Add(m_GameManager.myStockList[m_GameManager.myStockList.Count - 1]);
                        m_GameManager.myStockList.RemoveAt(m_GameManager.myStockList.Count - 1);
                    }
                    m_GameManager.myMemoryList.Add(m_BattleModeCard);
                    m_GameManager.myHandList.Remove(m_BattleModeCard);
                    m_GameManager.Syncronize();
                    return;
                }
                m_DialogManager.SearchDialog(m_GameManager.myClockList, EnumController.SearchDialogParamater.ClockSulvage, m_BattleModeCard);
                break;
            case EnumController.CardNo.LB_W02_17T:
                //【起】［(1)］ あなたは《動物》の自分のキャラを1枚選び、そのターン中、パワーを＋500。
                m_GameManager.GraveYardList.Add(m_GameManager.myStockList[m_GameManager.myStockList.Count - 1]);
                m_GameManager.myStockList.RemoveAt(m_GameManager.myStockList.Count - 1);
                m_GameManager.Syncronize();
                m_MainPowerUpDialog.SetBattleMordCard(m_BattleModeCard);
                break;
            default:
                break;
        }

        place = -1;
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
}
