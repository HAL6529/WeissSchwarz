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

    private int effectNum = 0;

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
    public void AnimationStart_2(BattleModeCard card, int place)
    {
        this.place = place;
        AnimationStart_2(card);
    }

    /// <summary>
    /// �C�x���g���Đ������v���C���[�p
    /// </summary>
    /// <param name="card"></param>
    public void AnimationStart(BattleModeCard card)
    {
        isFromRPC = false;
        m_gameObject.SetActive(true);
        effectNum = 0;

        m_BattleModeCard = card;
        m_image.sprite = card.sprite;
        m_image2.sprite = card.sprite;
        // �A�j���[�V�����Đ����Đ����邽�߂�speed��1�ɂ���
        animator.speed = 1;
        animator.Play(AnimationName, 0, 0);
    }

    /// <summary>
    /// �C�x���g���Đ������v���C���[�p
    /// </summary>
    /// <param name="card"></param>
    public void AnimationStart_2(BattleModeCard card)
    {
        isFromRPC = false;
        m_gameObject.SetActive(true);
        effectNum = 1;

        m_BattleModeCard = card;
        m_image.sprite = card.sprite;
        m_image2.sprite = card.sprite;
        // �A�j���[�V�����Đ����Đ����邽�߂�speed��1�ɂ���
        animator.speed = 1;
        animator.Play(AnimationName, 0, 0);
    }

    private void AnimationEnd()
    {

        m_gameObject.SetActive(false);
        if (isFromRPC)
        {
            place = -1;
            effectNum = 0;
            return;
        }
        Execute();
        // effectNum = 0;
        place = -1;
    }

    private void Execute()
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
        if(effectNum == 0)
        {
            switch (m_BattleModeCard.cardNo)
            {
                case EnumController.CardNo.AT_WX02_A07:
                    m_DialogManager.SearchDialog(m_GameManager.myDeckList, EnumController.SearchDialogParamater.Search, m_BattleModeCard);
                    return;
                case EnumController.CardNo.DC_W01_01T:
                    // �y�N�z�m���̃J�[�h���y���X�g�z����n ���Ȃ��͎����̃L������1���I�сA���̃^�[�����A�p���[���{1000�B
                    m_MyMainCardsManager.CallOnRest(place);
                    m_GameManager.Syncronize();
                    m_MainPowerUpDialog.SetBattleMordCard(m_BattleModeCard);
                    return;
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
                    return;
                case EnumController.CardNo.DC_W01_04T:
                    m_GameManager.GraveYardList.Add(m_GameManager.myStockList[m_GameManager.myStockList.Count - 1]);
                    m_GameManager.myStockList.RemoveAt(m_GameManager.myStockList.Count - 1);
                    m_MyMainCardsManager.AddPowerUpUntilTurnEnd(place, 2000);
                    m_GameManager.Syncronize();
                    m_GameManager.ExecuteActionList();
                    return;
                case EnumController.CardNo.DC_W01_05T:
                    //�y�N�z�m(1)�n ���Ȃ��͑���̑O��̃L������1���I�сA���̃^�[�����A�p���[���|1000�B
                    for (int i = 0; i < 1; i++)
                    {
                        m_GameManager.GraveYardList.Add(m_GameManager.myStockList[m_GameManager.myStockList.Count - 1]);
                        m_GameManager.myStockList.RemoveAt(m_GameManager.myStockList.Count - 1);
                    }
                    m_GameManager.Syncronize();
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
                    return;
                case EnumController.CardNo.DC_W01_07T:
                    // �y���z ���̃o�g�����Ă��邠�Ȃ��̃L�������y���o�[�X�z�������A���Ȃ��͎����̃L������1���I�сA���̃^�[�����A�p���[���{1000�B
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, -1);
                    return;
                case EnumController.CardNo.DC_W01_10T:
                    // �y���z ���̃J�[�h�ƃo�g�����Ă���L�������y���o�[�X�z�������A���Ȃ��͂��̃L�������R�D�̏�ɒu���Ă悢�B
                    m_BattleStrix.RpcToAll("ToDeckTopFromField", place, m_GameManager.isTurnPlayer);
                    m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
                    m_GameManager.ExecuteActionList();
                    return;
                case EnumController.CardNo.DC_W01_12T:
                    // ���Ȃ��͎����̍T�����̃L������2���܂őI�сA��D�ɖ߂��B
                    for (int i = 0; i < 2; i++)
                    {
                        m_GameManager.GraveYardList.Add(m_GameManager.myStockList[m_GameManager.myStockList.Count - 1]);
                        m_GameManager.myStockList.RemoveAt(m_GameManager.myStockList.Count - 1);
                    }
                    m_GameManager.Syncronize();
                    m_DialogManager.SulvageDialog(m_BattleModeCard, m_GameManager.GraveYardList, EnumController.Type.CHARACTER, 0, 2);
                    return;
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
                    return;
                case EnumController.CardNo.DC_W01_16T:
                    m_EnemyMainCardsManager.CallReverse(enemyPlace);
                    m_BattleStrix.RpcToAll("CallMyReverse", enemyPlace, m_GameManager.isTurnPlayer);
                    m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
                    m_GameManager.ExecuteActionList();
                    return;
                case EnumController.CardNo.DC_W01_18T:
                    // ���Ȃ��̓��x��1�ȉ��̑���̃L������1���I�сA�T�����ɒu���B
                    for (int i = 0; i < 1; i++)
                    {
                        m_GameManager.GraveYardList.Add(m_GameManager.myStockList[m_GameManager.myStockList.Count - 1]);
                        m_GameManager.myStockList.RemoveAt(m_GameManager.myStockList.Count - 1);
                    }
                    m_GameManager.Syncronize();

                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
                    break;
                case EnumController.CardNo.LB_W02_02T:
                    // �y�N�z�m(1)�n ���̃J�[�h���v���o�ɂ���B
                    for (int i = 0; i < 1; i++)
                    {
                        m_GameManager.GraveYardList.Add(m_GameManager.myStockList[m_GameManager.myStockList.Count - 1]);
                        m_GameManager.myStockList.RemoveAt(m_GameManager.myStockList.Count - 1);
                    }
                    m_MyMainCardsManager.CallPutMemoryFromField(place);
                    m_GameManager.ExecuteActionList();
                    return;
                case EnumController.CardNo.DC_W01_02T:
                case EnumController.CardNo.LB_W02_03T:
                    // �y���z ���̃J�[�h���A�^�b�N�������A�N���C�}�b�N�X�u��Ɂu���敗�̃n�~���O�v������Ȃ�A���Ȃ��͎����̎R�D���ォ��1���I�сA
                    // �X�g�b�N�u��ɒu���A���̃^�[�����A���̃J�[�h�̃p���[���{3000�B
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
                    //�y�J�E���^�[�z ���Ȃ��͎����̃L������2���܂őI�сA���̃^�[�����A�p���[���{1000�B
                    for (int i = 0; i < 1; i++)
                    {
                        m_GameManager.GraveYardList.Add(m_GameManager.myStockList[m_GameManager.myStockList.Count - 1]);
                        m_GameManager.myStockList.RemoveAt(m_GameManager.myStockList.Count - 1);
                    }
                    m_GameManager.Syncronize();

                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, -1);
                    break;
                case EnumController.CardNo.LB_W02_05T:
                    // �y�N�z�m(1)�n ���̂��Ȃ��̃L�������ׂĂɁA���̃^�[�����A�s�����t��^����B
                    m_GameManager.GraveYardList.Add(m_GameManager.myStockList[m_GameManager.myStockList.Count - 1]);
                    m_GameManager.myStockList.RemoveAt(m_GameManager.myStockList.Count - 1);
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
                    //�y�N�z�m(1)�n ���Ȃ��͑���̃L������1���I�сA���̃^�[�����A�p���[���|500�B
                    for (int i = 0; i < 1; i++)
                    {
                        m_GameManager.GraveYardList.Add(m_GameManager.myStockList[m_GameManager.myStockList.Count - 1]);
                        m_GameManager.myStockList.RemoveAt(m_GameManager.myStockList.Count - 1);
                    }
                    m_GameManager.Syncronize();
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
                    return;
                case EnumController.CardNo.LB_W02_14T:
                    // �y�N�z�m(2) ���̃J�[�h���y���X�g�z����n ���Ȃ��͎����̃N���b�N���ォ��1���I�сA�T�����ɒu���B
                    for (int i = 0; i < 2; i++)
                    {
                        m_GameManager.GraveYardList.Add(m_GameManager.myStockList[m_GameManager.myStockList.Count - 1]);
                        m_GameManager.myStockList.RemoveAt(m_GameManager.myStockList.Count - 1);
                    }
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
                        for (int i = 0; i < 3; i++)
                        {
                            m_GameManager.GraveYardList.Add(m_GameManager.myStockList[m_GameManager.myStockList.Count - 1]);
                            m_GameManager.myStockList.RemoveAt(m_GameManager.myStockList.Count - 1);
                        }
                        m_GameManager.myMemoryList.Add(m_BattleModeCard);
                        m_GameManager.myHandList.Remove(m_BattleModeCard);
                        m_GameManager.Syncronize();
                        m_GameManager.ExecuteActionList();
                        return;
                    }
                    m_DialogManager.SearchDialog(m_GameManager.myClockList, EnumController.SearchDialogParamater.ClockSulvage, m_BattleModeCard);
                    return;
                case EnumController.CardNo.LB_W02_17T:
                    //�y�N�z�m(1)�n ���Ȃ��́s�����t�̎����̃L������1���I�сA���̃^�[�����A�p���[���{500�B
                    m_GameManager.GraveYardList.Add(m_GameManager.myStockList[m_GameManager.myStockList.Count - 1]);
                    m_GameManager.myStockList.RemoveAt(m_GameManager.myStockList.Count - 1);
                    m_GameManager.Syncronize();
                    m_MainPowerUpDialog.SetBattleMordCard(m_BattleModeCard);
                    return;
                case EnumController.CardNo.LB_W02_19T:
                    // �y���z�m(1)�n ���̃J�[�h�ƃo�g�����Ă��郌�x��2�ȏ�̃L�������y���o�[�X�z�������A���Ȃ��̓R�X�g�𕥂��Ă悢�B����������A���Ȃ���1�������B
                    m_GameManager.GraveYardList.Add(m_GameManager.myStockList[m_GameManager.myStockList.Count - 1]);
                    m_GameManager.myStockList.RemoveAt(m_GameManager.myStockList.Count - 1);
                    m_GameManager.Syncronize();
                    m_GameManager.Draw();
                    m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
                    m_GameManager.ExecuteActionList();
                    return;
                default:
                    break;
            }
            switch (m_BattleModeCard.cardNo)
            {
                case EnumController.CardNo.P3_S01_01T:
                    // �y���z ���̃J�[�h���v���C����ĕ���ɒu���ꂽ���A���̃^�[�����A���̃J�[�h�̃\�E�����{1�B
                    m_MyMainCardsManager.AddSoulUpUntilTurnEnd(place, 1);
                    m_GameManager.Syncronize();
                    m_GameManager.ExecuteActionList();
                    return;
                case EnumController.CardNo.P3_S01_04T:
                    // �y���z ���̃J�[�h���v���C����ĕ���ɒu���ꂽ���A���Ȃ��͎����̃L������1���I�сA
                    // ���̃^�[�����A�p���[���{2000���A�\�E�����{1�B
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, -1);
                    return;
                case EnumController.CardNo.P3_S01_07T:
                    //�y���z ���̃J�[�h���v���C����ĕ���ɒu���ꂽ���A���̃^�[�����A���̃J�[�h�̃p���[���{1500�B
                    m_MyMainCardsManager.AddPowerUpUntilTurnEnd(place, 1500);
                    m_GameManager.Syncronize();
                    m_GameManager.ExecuteActionList();
                    return;
                case EnumController.CardNo.P3_S01_11T:
                    //�y���z ���̃J�[�h���A�^�b�N�������A�N���C�}�b�N�X�u��Ɂu�Ō�̑I���v������Ȃ�A���Ȃ��͑���̃L������1���I�сA��D�ɖ߂��Ă悢�B
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
                    return;
                case EnumController.CardNo.P3_S01_12T:
                    // �y�J�E���^�[�z ���Ȃ��͎����̃L������1���I�сA���̃^�[�����A�p���[���{3000���A�\�E�����{1�B
                    for (int i = 0; i < 2; i++)
                    {
                        m_GameManager.GraveYardList.Add(m_GameManager.myStockList[m_GameManager.myStockList.Count - 1]);
                        m_GameManager.myStockList.RemoveAt(m_GameManager.myStockList.Count - 1);
                    }
                    m_GameManager.Syncronize();
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, -1);
                    return;
                case EnumController.CardNo.P3_S01_16T:
                    // �y�N�z�m(2) ���̃J�[�h���y���X�g�z����n ���Ȃ���1�������B
                    for (int i = 0; i < 2; i++)
                    {
                        m_GameManager.GraveYardList.Add(m_GameManager.myStockList[m_GameManager.myStockList.Count - 1]);
                        m_GameManager.myStockList.RemoveAt(m_GameManager.myStockList.Count - 1);
                    }
                    m_MyMainCardsManager.CallOnRest(place);
                    m_GameManager.Syncronize();
                    m_GameManager.Draw();
                    break;
                default:
                    break;
            }
            int pumpPoint = 0;
            int cost = 0;
            // Counter�p
            switch (m_BattleModeCard.cardNo)
            {
                case EnumController.CardNo.LB_W02_07T:
                case EnumController.CardNo.P3_S01_03T:
                    pumpPoint = 2000;
                    cost = 1;
                    for (int i = 0; i < cost; i++)
                    {
                        BattleModeCard t = m_GameManager.myStockList[m_GameManager.myStockList.Count - 1];
                        m_GameManager.GraveYardList.Add(t);
                        m_GameManager.myStockList.Remove(t);
                    }
                    m_MyMainCardsManager.AddPowerUpUntilTurnEnd(place, pumpPoint);
                    m_GameManager.myHandList.Remove(m_BattleModeCard);
                    m_GameManager.GraveYardList.Add(m_BattleModeCard);
                    m_GameManager.Syncronize();
                    m_GameManager.ExecuteActionList();
                    return;
                case EnumController.CardNo.AT_WX02_A05:
                    pumpPoint = 2500;
                    cost = 1;
                    for (int i = 0; i < cost; i++)
                    {
                        BattleModeCard t = m_GameManager.myStockList[m_GameManager.myStockList.Count - 1];
                        m_GameManager.GraveYardList.Add(t);
                        m_GameManager.myStockList.Remove(t);
                    }
                    m_MyMainCardsManager.AddPowerUpUntilTurnEnd(place, pumpPoint);
                    m_GameManager.myHandList.Remove(m_BattleModeCard);
                    m_GameManager.GraveYardList.Add(m_BattleModeCard);
                    m_GameManager.Syncronize();
                    m_GameManager.ExecuteActionList();
                    return;
                case EnumController.CardNo.DC_W01_17T:
                    pumpPoint = 3000;
                    cost = 1;
                    for (int i = 0; i < cost; i++)
                    {
                        BattleModeCard t = m_GameManager.myStockList[m_GameManager.myStockList.Count - 1];
                        m_GameManager.GraveYardList.Add(t);
                        m_GameManager.myStockList.Remove(t);
                    }
                    m_MyMainCardsManager.AddPowerUpUntilTurnEnd(place, pumpPoint);
                    m_GameManager.myHandList.Remove(m_BattleModeCard);
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
                    // �y���z ���̃J�[�h���v���C����ĕ���ɒu���ꂽ���A���Ȃ��͑���̎�D������B
                    m_BattleStrix.RpcToAll("CallGetHandList", m_GameManager.isTurnPlayer);
                    break;
                case EnumController.CardNo.DC_W01_10T:
                    // �y���z�m(1)�n ���̃J�[�h���A�^�b�N�������A�N���C�}�b�N�X�u��Ɂu���t�̃I���S�[���v������Ȃ�A
                    // ���Ȃ��̓R�X�g�𕥂��Ă悢�B����������A���Ȃ��͎����̍T�����̃L������1���I�сA��D�ɖ߂��B
                    for (int i = 0; i < 1; i++)
                    {
                        m_GameManager.GraveYardList.Add(m_GameManager.myStockList[m_GameManager.myStockList.Count - 1]);
                        m_GameManager.myStockList.RemoveAt(m_GameManager.myStockList.Count - 1);
                    }
                    m_GameManager.Syncronize();
                    m_DialogManager.SulvageDialog(m_BattleModeCard, m_GameManager.GraveYardList, EnumController.Type.CHARACTER, 0, 1);
                    break;
                case EnumController.CardNo.LB_W02_02T:
                    // �y�N�z�m(1)�n ���Ȃ��͎����̃L������1���I�сA���̃^�[�����A�p���[���{1500�B
                    for (int i = 0; i < 1; i++)
                    {
                        m_GameManager.GraveYardList.Add(m_GameManager.myStockList[m_GameManager.myStockList.Count - 1]);
                        m_GameManager.myStockList.RemoveAt(m_GameManager.myStockList.Count - 1);
                    }
                    m_GameManager.Syncronize();
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, -1);
                    break;
                case EnumController.CardNo.LB_W02_14T:
                    Debug.Log("EventAnimationManager:LB_W02_14T");
                    // �y���z ���Ȃ������x���A�b�v�������A���Ȃ��͎����̎R�D���ォ��1���I�сA�X�g�b�N�u��ɒu���B
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
                    // �y���z ���̃J�[�h���A�^�b�N�������A�N���C�}�b�N�X�u��Ɂu���Q�̏I���v������Ȃ�A
                    // ���Ȃ��͑���̃L������1���I�сA��D�ɖ߂��Ă悢�B
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
                    break;
                case EnumController.CardNo.P3_S01_04T:
                    // �y�N�z�m(2) ���̃J�[�h���y���X�g�z����n ���Ȃ��͂��̃J�[�h����D�ɖ߂��B
                    for (int i = 0; i < 2; i++)
                    {
                        m_GameManager.GraveYardList.Add(m_GameManager.myStockList[m_GameManager.myStockList.Count - 1]);
                        m_GameManager.myStockList.RemoveAt(m_GameManager.myStockList.Count - 1);
                    }
                    m_MyMainCardsManager.CallOnRest(place);
                    m_GameManager.ToHandFromField(place);
                    break;
                case EnumController.CardNo.P3_S01_11T:
                    // �y�N�z�m(1)�n ���̃^�[�����A���̃J�[�h�̃\�E�����{1�B
                    for (int i = 0; i < 1; i++)
                    {
                        m_GameManager.GraveYardList.Add(m_GameManager.myStockList[m_GameManager.myStockList.Count - 1]);
                        m_GameManager.myStockList.RemoveAt(m_GameManager.myStockList.Count - 1);
                    }
                    m_MyMainCardsManager.AddSoulUpUntilTurnEnd(place, 1);
                    m_GameManager.Syncronize();
                    m_GameManager.ExecuteActionList();
                    break;
                case EnumController.CardNo.P3_S01_16T:
                    // �y���z ���́s���k��t�̂��Ȃ��̃L�������v���C����ĕ���ɒu���ꂽ���A���Ȃ��͎����̎R�D���ォ��1�����āA�R�D�̏ォ���ɒu���B
                    m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.CONFIRM_CONTROL_DECKTOP, m_BattleModeCard);
                    break;
                default:
                    break;
            }
        }
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
