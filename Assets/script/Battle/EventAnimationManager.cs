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
    [SerializeField] MainPowerUpDialog m_MainPowerUpDialog;
    [SerializeField] Image m_image;
    [SerializeField] Image m_image2;
    [SerializeField] GameObject m_gameObject;

    private static string AnimationName = "EventAnimation";
    private static int NormalAnimationLayerIndex = 0;

    private BattleModeCard m_BattleModeCard = null;

    private int place = -1;

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
        m_gameObject.SetActive(true);

        m_BattleModeCard = card;
        m_image.sprite = card.sprite;
        m_image2.sprite = card.sprite;
        animator.AddClipEndCallback(NormalAnimationLayerIndex, AnimationName, () => AnimationEnd());
        // アニメーション再生を再生するためにspeedを1にする
        animator.speed = 1;
        animator.Play(AnimationName, 0, 0);
    }

    private void AnimationEnd()
    {
        m_gameObject.SetActive(false);
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

        m_gameObject.SetActive(true);

        m_BattleModeCard = b;
        m_image.sprite = b.sprite;
        m_image2.sprite = b.sprite;
        animator.AddClipEndCallback(NormalAnimationLayerIndex, AnimationName, () => AnimationEndForRPC());
        // アニメーション再生を再生するためにspeedを1にする
        animator.speed = 1;
        animator.Play(AnimationName, 0, 0);
    }

    private void AnimationEndForRPC()
    {
        m_gameObject.SetActive(false);
    }
}
