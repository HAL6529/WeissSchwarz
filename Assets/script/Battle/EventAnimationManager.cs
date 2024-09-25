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
    /// �C�x���g���Đ������v���C���[�p
    /// </summary>
    /// <param name="card"></param>
    public void AnimationStart(BattleModeCard card, int place)
    {
        this.place = place;
        AnimationStart(card);
    }

    /// <summary>
    /// �C�x���g���Đ������v���C���[�p
    /// </summary>
    /// <param name="card"></param>
    public void AnimationStart(BattleModeCard card)
    {
        isFromRPC = false;
        m_gameObject.SetActive(true);

        m_BattleModeCard = card;
        m_image.sprite = card.sprite;
        m_image2.sprite = card.sprite;
        // �A�j���[�V�����Đ����Đ����邽�߂�speed��1�ɂ���
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
                // �y�N�z�m���̃J�[�h���y���X�g�z����n ���Ȃ��͎����̃L������1���I�сA���̃^�[�����A�p���[���{1000�B
                m_MyMainCardsManager.CallOnRest(place);
                m_GameManager.Syncronize();
                m_MainPowerUpDialog.SetBattleMordCard(m_BattleModeCard);
                break;
            case EnumController.CardNo.DC_W01_03T:
                // ���Ȃ��͎����̎R�D���ォ��1���I�сA�X�g�b�N�u��ɒu���B���Ȃ��͎����̃L������1���I�сA���̃^�[�����A�p���[���{500�B
                m_GameManager.myStockList.Add(m_GameManager.myDeckList[0]);
                m_GameManager.myDeckList.RemoveAt(0);
                m_GameManager.Syncronize();

                if (m_GameManager.myDeckList.Count == 0)
                {
                    if (m_GameManager.GraveYardList.Count == 0)
                    {
                        // �T����0���Ȃ畉������
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
                // �y���z ���̃J�[�h�ƃo�g�����Ă���L�������y���o�[�X�z�������A���Ȃ��͂��̃L�������R�D�̏�ɒu���Ă悢�B
                m_BattleStrix.RpcToAll("ToDeckTopFromField", place, m_GameManager.isTurnPlayer);
                break;
            case EnumController.CardNo.DC_W01_12T:
                // ���Ȃ��͎����̍T�����̃L������2���܂őI�сA��D�ɖ߂��B
                for (int i = 0; i < 2; i++)
                {
                    m_GameManager.GraveYardList.Add(m_GameManager.myStockList[m_GameManager.myStockList.Count - 1]);
                    m_GameManager.myStockList.RemoveAt(m_GameManager.myStockList.Count - 1);
                }
                m_GameManager.Syncronize();
                m_DialogManager.SulvageDialog(m_BattleModeCard, m_GameManager.GraveYardList, EnumController.Type.CHARACTER, 0, 2);
                break;
            case EnumController.CardNo.DC_W01_13T:
                // �y�N�z�m(2) ���̃J�[�h���y���X�g�z����n ���Ȃ��͎����̍T�����̃L������1���I�сA��D�ɖ߂��B
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
                // �y���z ���̃J�[�h���A�^�b�N�������A�N���C�}�b�N�X�u��Ɂu���敗�̃n�~���O�v������Ȃ�A���Ȃ��͎����̎R�D���ォ��1���I�сA
                // �X�g�b�N�u��ɒu���A���̃^�[�����A���̃J�[�h�̃p���[���{3000�B
                /*m_GameManager.myStockList.Add(m_GameManager.myDeckList[0]);
                m_GameManager.myDeckList.RemoveAt(0);
                m_GameManager.Syncronize();
                if (m_GameManager.myDeckList.Count == 0)
                {
                    m_GameManager.Refresh();
                }*/
                break;
            case EnumController.CardNo.LB_W02_05T:
                // �y�N�z�m(1)�n ���̂��Ȃ��̃L�������ׂĂɁA���̃^�[�����A�s�����t��^����B
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
                //�y�N�z�m(1)�n ���Ȃ��́s�����t�̎����̃L������1���I�сA���̃^�[�����A�p���[���{500�B
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
    /// �C�x���g��ł��ꂽ�v���C���[�p
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
        // �A�j���[�V�����Đ����Đ����邽�߂�speed��1�ɂ���
        animator.speed = 1;
        animator.Play(AnimationName, 0, 0);
    }

    private void AnimationEndForRPC()
    {
        m_gameObject.SetActive(false);
    }
}
