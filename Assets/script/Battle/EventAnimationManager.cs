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
    /// �J�p
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
        // �A�j���[�V�����Đ����Đ����邽�߂�speed��1�ɂ���
        animator.speed = 1;
        animator.Play(AnimationName, 0, 0);
        m_BattleStrix.RpcToAll("SEManager_EffectSE_Play");
    }

    /// <summary>
    /// �o�E���X�E�v�[���E�u�b�N�g���K�[�p
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
        // �A�j���[�V�����Đ����Đ����邽�߂�speed��1�ɂ���
        animator.speed = 1;
        animator.Play(AnimationName, 0, 0);
        m_BattleStrix.RpcToAll("SEManager_EffectSE_Play");
    }

    /// <summary>
    /// �C�x���g���Đ������v���C���[�p
    /// </summary>
    /// <param name="card"></param>
    public void AnimationStart(BattleModeCard card)
    {
        AnimationStart(card, -1, -1, 0);
    }

    /// <summary>
    /// �C�x���g���Đ������v���C���[�p
    /// </summary>
    /// <param name="card"></param>
    public void AnimationStart(BattleModeCard card, int place)
    {

        AnimationStart(card, place, -1, 0);
    }

    /// <summary>
    /// �C�x���g���Đ������v���C���[�p
    /// </summary>
    /// <param name="card"></param>
    public void AnimationStart(BattleModeCard card, int place, int handNum)
    {

        AnimationStart(card, place, handNum, 0);
    }

    /// <summary>
    /// �C�x���g���Đ������v���C���[�p
    /// </summary>
    /// <param name="card"></param>
    public void AnimationStart_2(BattleModeCard card)
    {
        AnimationStart(card, -1, -1, 1);
    }

    /// <summary>
    /// �C�x���g���Đ������v���C���[�p
    /// </summary>
    /// <param name="card"></param>
    public void AnimationStart_2(BattleModeCard card, int place)
    {
        AnimationStart(card, place, -1, 1);
    }

    /// <summary>
    /// �C�x���g���Đ������v���C���[�p
    /// </summary>
    /// <param name="card"></param>
    public void AnimationStart_2(BattleModeCard card, int place, int handNum)
    {
        AnimationStart(card, place, handNum, 1);
    }

    /// <summary>
    /// �C�x���g���Đ������v���C���[�p
    /// </summary>
    /// <param name="card"></param>
    public void AnimationStart_3(BattleModeCard card)
    {
        AnimationStart(card, -1, -1, 2);
    }

    /// <summary>
    /// �C�x���g���Đ������v���C���[�p
    /// </summary>
    /// <param name="card"></param>
    public void AnimationStart_3(BattleModeCard card, int place)
    {
        AnimationStart(card, place, -1, 2);
    }

    /// <summary>
    /// �C�x���g���Đ������v���C���[�p
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
        // �A�j���[�V�����Đ����Đ����邽�߂�speed��1�ɂ���
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
        }
        // �J
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
                    m_EffectBondForHandToField.BondForCost(sulvageCardName, cost);
                    return;
                default:
                    break;
            }
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
                    m_DialogManager.SearchDialog(EnumController.SearchDialogParamater.AT_WX02_A07, handNum);
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
                    PayCost(1);
                    m_MyMainCardsManager.AddPowerUpUntilTurnEnd(place, 2000);
                    m_GameManager.Syncronize();
                    m_GameManager.ExecuteActionList();
                    return;
                case EnumController.CardNo.DC_W01_05T:
                    //�y�N�z�m(1)�n ���Ȃ��͑���̑O��̃L������1���I�сA���̃^�[�����A�p���[���|1000�B
                    PayCost(1);
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
                    PayCost(2);
                    m_DialogManager.SulvageDialog(handNum, m_BattleModeCard, m_GameManager.GraveYardList, EnumController.Type.CHARACTER, 0, 2);
                    return;
                case EnumController.CardNo.DC_W01_13T:
                    // �y�N�z�m(2) ���̃J�[�h���y���X�g�z����n ���Ȃ��͎����̍T�����̃L������1���I�сA��D�ɖ߂��B
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
                    // ���Ȃ��̓��x��1�ȉ��̑���̃L������1���I�сA�T�����ɒu���B
                    PayCost(1);
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
                    break;
                case EnumController.CardNo.LB_W02_02T:
                    // �y�N�z�m(1)�n ���̃J�[�h���v���o�ɂ���B
                    PayCost(1);
                    m_MyMainCardsManager.CallPutMemoryFromField(place);
                    m_GameManager.ExecuteActionList();
                    return;
                case EnumController.CardNo.DC_W01_02T:
                case EnumController.CardNo.LB_W02_03T:
                case EnumController.CardNo.P3_S01_030:
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
                    PayCost(1);
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, -1);
                    break;
                case EnumController.CardNo.LB_W02_05T:
                    // �y�N�z�m(1)�n ���̂��Ȃ��̃L�������ׂĂɁA���̃^�[�����A�s�����t��^����B
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
                    //�y�N�z�m(1)�n ���Ȃ��͑���̃L������1���I�сA���̃^�[�����A�p���[���|500�B
                    PayCost(1);
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
                    return;
                case EnumController.CardNo.LB_W02_14T:
                    // �y�N�z�m(2) ���̃J�[�h���y���X�g�z����n ���Ȃ��͎����̃N���b�N���ォ��1���I�сA�T�����ɒu���B
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
                    // ���Ȃ��͎����̃N���b�N��1���I�сA��D�ɖ߂��B���̃J�[�h���v���o�ɂ���B
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
                    //�y�N�z�m(1)�n ���Ȃ��́s�����t�̎����̃L������1���I�сA���̃^�[�����A�p���[���{500�B
                    PayCost(1);
                    m_MainPowerUpDialog.SetBattleMordCard(m_BattleModeCard);
                    return;
                case EnumController.CardNo.LB_W02_19T:
                    // �y���z�m(1)�n ���̃J�[�h�ƃo�g�����Ă��郌�x��2�ȏ�̃L�������y���o�[�X�z�������A���Ȃ��̓R�X�g�𕥂��Ă悢�B����������A���Ȃ���1�������B
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
                    //�y���z ���̃J�[�h���v���C����ĕ���ɒu���ꂽ���A���Ȃ��̓��x��1�ȏ�̎����̃L������1���I�сA���̃^�[�����A�\�E�����{1�B
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, -1);
                    return;
                case EnumController.CardNo.P3_S01_002:
                    //�y�N�z�m(2) ���̃J�[�h���y���X�g�z����n ���̃J�[�h���v���o�ɂ���B���Ȃ��͎����̎�D�́u��l�����^�i�g�X�v���P���I�сA���̃J�[�h�������g�ɒu���B
                    PayCost(2);
                    m_MyMainCardsManager.CallOnRest(place);
                    m_MyMainCardsManager.CallPutMemoryFromField(place);

                    for(int i = 0; i < m_GameManager.myHandList.Count; i++)
                    {
                        if (m_GameManager.myHandList[i].name == "��l�����^�i�g�X")
                        {
                            m_MyMainCardsManager.CallPutFieldFromHandForEffect(place, i, EnumController.State.STAND);
                            return;
                        }
                    }
                    return;
                case EnumController.CardNo.P3_S01_004:
                    //�y���z ���̃J�[�h���A�^�b�N�������A�N���C�}�b�N�X�u��Ɂu�I�V���C�v������Ȃ�A���Ȃ��͑���̃L������1���I�сA��D�ɖ߂��Ă悢�B
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
                    return;
                case EnumController.CardNo.P3_S01_01T:
                case EnumController.CardNo.P3_S01_005:
                    // �y���z ���̃J�[�h���v���C����ĕ���ɒu���ꂽ���A���̃^�[�����A���̃J�[�h�̃\�E�����{1�B
                    m_MyMainCardsManager.AddSoulUpUntilTurnEnd(place, 1);
                    m_GameManager.Syncronize();
                    m_GameManager.ExecuteActionList();
                    return;
                case EnumController.CardNo.P3_S01_026:
                    //�y���z ���̃J�[�h���v���C����ĕ���ɒu���ꂽ���A���Ȃ��͎����̃L������1���I�сA���̃^�[�����A�p���[���{1000�B
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, -1);
                    return;
                case EnumController.CardNo.P3_S01_028:
                    // �y�N�z�m(2)�n ���̃^�[�����A���̃J�[�h�̃p���[���{5000�B
                    PayCost(2);
                    m_MyMainCardsManager.AddPowerUpUntilTurnEnd(place, 5000);
                    m_GameManager.Syncronize();
                    m_GameManager.ExecuteActionList();
                    return;
                case EnumController.CardNo.P3_S01_04T:
                case EnumController.CardNo.P3_S01_010:
                    // �y���z ���̃J�[�h���v���C����ĕ���ɒu���ꂽ���A���Ȃ��͎����̃L������1���I�сA
                    // ���̃^�[�����A�p���[���{2000���A�\�E�����{1�B
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, -1);
                    return;
                case EnumController.CardNo.P3_S01_07T:
                case EnumController.CardNo.P3_S01_012:
                    //�y���z ���̃J�[�h���v���C����ĕ���ɒu���ꂽ���A���̃^�[�����A���̃J�[�h�̃p���[���{1500�B
                    m_MyMainCardsManager.AddPowerUpUntilTurnEnd(place, 1500);
                    m_GameManager.Syncronize();
                    m_GameManager.ExecuteActionList();
                    return;
                case EnumController.CardNo.P3_S01_11T:
                case EnumController.CardNo.P3_S01_017:
                    //�y���z ���̃J�[�h���A�^�b�N�������A�N���C�}�b�N�X�u��Ɂu�Ō�̑I���v������Ȃ�A���Ȃ��͑���̃L������1���I�сA��D�ɖ߂��Ă悢�B
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
                    return;
                case EnumController.CardNo.P3_S01_020:
                    // ���Ȃ��͎����Ƒ���̃L�������ׂĂ��A��D�ɖ߂��B
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
                    // �y�J�E���^�[�z ���Ȃ��͎����̃L������1���I�сA���̃^�[�����A�p���[���{3000���A�\�E�����{1�B
                    PayCost(2);
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, -1);
                    return;
                case EnumController.CardNo.P3_S01_16T:
                case EnumController.CardNo.P3_S01_087:
                    // �y�N�z�m(2) ���̃J�[�h���y���X�g�z����n ���Ȃ���1�������B
                    PayCost(2);
                    m_MyMainCardsManager.CallOnRest(place);
                    m_GameManager.Syncronize();
                    m_GameManager.Draw();
                    break;
                case EnumController.CardNo.P3_S01_018:
                    // ���Ȃ��͑���̃L������1���I�сA���̃^�[�����A���x�����|1�B
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
                    return;
                case EnumController.CardNo.P3_S01_034:
                    // �y�N�z�m(1)�n ���̃^�[�����A���̃J�[�h�̃p���[���{2000�B
                    PayCost(1);
                    m_MyMainCardsManager.AddPowerUpUntilTurnEnd(place, 2000);
                    m_GameManager.Syncronize();
                    return;
                case EnumController.CardNo.P3_S01_040:
                    //�y���z�m���̃J�[�h���y���X�g�z����n ���́s�X�|�[�c�t�̂��Ȃ��̃L�������v���C����ĕ���ɒu���ꂽ���A���Ȃ��̓R�X�g�𕥂��Ă悢�B����������A���Ȃ��͎����̎R�D�̏ォ��1�����A�X�g�b�N�u��ɒu���B
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
                    //�y�J�E���^�[�z ���Ȃ��͎����̃L�������ׂĂɁA���̃^�[�����A�p���[���{1000�B�������鎞�A����̑O��̃L�������ׂĂ��y���X�g�z���Ă���Ȃ�A�����Ƀp���[���{3000�B
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
                    // ���Ȃ��͑���̑O��̃L������2���܂őI�сA���̃^�[�����A�p���[���|1000�B
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
                    return;
                case EnumController.CardNo.P3_S01_047:
                    //���Ȃ��͎����̎R�D�̏ォ��1�����A�X�g�b�N�u��ɒu���B���Ȃ��͎����̃L������1���I�сA���̃^�[�����A�p���[���{1500�B
                    m_GameManager.myStockList.Add(m_GameManager.myDeckList[0]);
                    m_GameManager.myDeckList.RemoveAt(0);
                    m_GameManager.Syncronize();
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, -1);
                    return;
                case EnumController.CardNo.P3_S01_051:
                    //�y�N�z�m(1)�n ���Ȃ��͎����̃J�[�h���Ɂu�����v���܂ރL�������P���I�сA���̃^�[�����A�p���[���{1000�B
                    PayCost(1);
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, -1);
                    return;
                case EnumController.CardNo.P3_S01_052:
                    //�y���z�m(1)�n ���̃J�[�h���v���C����ĕ���ɒu���ꂽ���A���Ȃ��̓R�X�g�𕥂��Ă悢�B����������A���Ȃ��͎����̍T�����́u�C������ԁv��1���I�сA��D�ɖ߂��B
                    PayCost(1);
                    for(int i = 0; i < m_GameManager.GraveYardList.Count; i++)
                    {
                        if (m_GameManager.GraveYardList[i].name == "�C�������")
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
                    //�y���z ���̃J�[�h���A�^�b�N�������A�N���C�}�b�N�X�u��Ɂu���肪�Ƃ��v������Ȃ�A���Ȃ��͎����̍T�����̃L������1���I�сA��D�ɖ߂��B
                    m_DialogManager.SulvageDialog(m_BattleModeCard, m_GameManager.GraveYardList, EnumController.Type.CHARACTER, 0, 1);
                    return;
                case EnumController.CardNo.P3_S01_057:
                    //�y���z ���̃J�[�h���v���C����ĕ���ɒu���ꂽ���A���Ȃ��͑���̍T�����̃C�x���g��1���I�сA�v���o�ɂ��Ă悢�B
                    m_DialogManager.GraveyardSelectDialog(m_BattleModeCard);
                    return;
                case EnumController.CardNo.P3_S01_060:
                    //�y���z�m(1)�n ���̃J�[�h���v���C����ĕ���ɒu���ꂽ���A���Ȃ��̓R�X�g�𕥂��Ă悢�B����������A���Ȃ��̓��x��1�ȉ��̑���̃L������1���I�сA�T�����ɒu���B
                    PayCost(1);
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
                    return;
                case EnumController.CardNo.P3_S01_061:
                    // �y���z ���̃J�[�h���v���C����ĕ���ɒu���ꂽ���A���Ȃ��͑���̍T�����̃J�[�h��1���I�сA�R�D�̏�ɒu���Ă悢�B
                    m_DialogManager.GraveyardSelectDialog(m_BattleModeCard);
                    return;
                case EnumController.CardNo.P3_S01_062:
                    // �y���z�m(1)�n �o�g�����Ă��邱�̃J�[�h���y���o�[�X�z�������A���Ȃ��̓R�X�g�𕥂��Ă悢�B����������A���̃J�[�h����D�ɖ߂��B
                    PayCost(1);
                    m_MyMainCardsManager.CallPutHandFromField(place);
                    m_GameManager.ExecuteActionList();
                    m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
                    return;
                case EnumController.CardNo.P3_S01_065:
                    //�y���z ���̃J�[�h���v���C����ĕ���ɒu���ꂽ���A���Ȃ��͂��ׂẴv���C���[�ɁA1�_���[�W��^����B
                    m_GameManager.Damage_EachPlayer(1);
                    return;
                case EnumController.CardNo.P3_S01_068:
                    // ���Ȃ��͎����̍T�����̃L������1���I�сA��D�ɖ߂��B
                    PayCost(1);
                    m_DialogManager.SulvageDialog(handNum, m_BattleModeCard, m_GameManager.GraveYardList, EnumController.Type.CHARACTER, 1, 1);
                    return;
                case EnumController.CardNo.P3_S01_069:
                    // ���Ȃ��̓��x��2�ȉ��̑���̑O��̃L������1���I�сA�T�����ɒu���B
                    PayCost(1);
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
                    return;
                case EnumController.CardNo.P3_S01_071:
                    // ���Ȃ��͑����1�_���[�W��^����B
                    PayCost(1);
                    m_BattleStrix.RpcToAll("CallDamage",1 ,handNum ,m_GameManager.isFirstAttacker);
                    return;
                case EnumController.CardNo.P3_S01_072:
                    //���Ȃ��̓��x��1�ȉ��̑���̃L������1���I�сA�R�D�̏�ɒu���B
                    PayCost(2);
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
                    return;
                case EnumController.CardNo.P3_S01_076:
                    //�y���z�m(1) ���̃J�[�h���y���X�g�z����n ���́s���k��t�̂��Ȃ��̃L�������v���C����ĕ���ɒu���ꂽ���A���Ȃ��̓R�X�g�𕥂��Ă悢�B����������A���Ȃ���1�������B
                    PayCost(1);
                    m_MyMainCardsManager.CallOnRest(place);
                    m_GameManager.Syncronize();
                    m_GameManager.Draw();
                    m_GameManager.ExecuteActionList();
                    m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
                    return;
                case EnumController.CardNo.P3_S01_080:
                    //�y���z ���̃J�[�h���v���C����ĕ���ɒu���ꂽ���A���Ȃ���1�������Ă悢�B
                    m_GameManager.Draw();
                    m_GameManager.Syncronize();
                    m_GameManager.ExecuteActionList();
                    return;
                case EnumController.CardNo.P3_S01_077:
                case EnumController.CardNo.P3_S01_081:
                    //�y���z ���̃J�[�h���A�^�b�N�������A�N���C�}�b�N�X�u��Ɂu�ŋ��Ȃ�ҁv������Ȃ�A���Ȃ���1�������B
                    //�y���z ���̃J�[�h���A�^�b�N�������A�N���C�}�b�N�X�u��Ɂu���̈�u�v������Ȃ�A���Ȃ���1�������B
                    m_GameManager.Draw();
                    m_GameManager.ExecuteActionList();
                    return;
                case EnumController.CardNo.P3_S01_088:
                    //�y���z�m(2)�n ���̃J�[�h���v���C����ĕ���ɒu���ꂽ���A���Ȃ��̓R�X�g�𕥂��Ă悢�B����������A���Ȃ��͎����̃N���b�N���ォ��1���I�сA�T�����ɒu���B
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
                    // ���Ȃ���1�������B
                    m_GameManager.Draw();
                    m_GameManager.myHandList.RemoveAt(handNum);
                    m_GameManager.GraveYardList.Add(m_BattleModeCard);
                    m_GameManager.Syncronize();
                    return;
                case EnumController.CardNo.P3_S01_094:
                    //�y�J�E���^�[�z ���Ȃ��͑���̃L������1���I�сA�y���X�g�z����B
                    PayCost(4);
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
                    return;
                case EnumController.CardNo.P3_S01_095:
                    // ���Ȃ��͎����̃N���b�N���ׂĂ��A��D�ɖ߂��B���̃J�[�h���v���o�ɂ���B
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
            // Counter�p
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
                    // �y���z ���̃J�[�h���v���C����ĕ���ɒu���ꂽ���A���Ȃ��͑���̎�D������B
                    m_BattleStrix.RpcToAll("CallGetHandList", m_GameManager.isTurnPlayer);
                    break;
                case EnumController.CardNo.DC_W01_10T:
                    // �y���z�m(1)�n ���̃J�[�h���A�^�b�N�������A�N���C�}�b�N�X�u��Ɂu���t�̃I���S�[���v������Ȃ�A
                    // ���Ȃ��̓R�X�g�𕥂��Ă悢�B����������A���Ȃ��͎����̍T�����̃L������1���I�сA��D�ɖ߂��B
                    PayCost(1);
                    m_DialogManager.SulvageDialog(m_BattleModeCard, m_GameManager.GraveYardList, EnumController.Type.CHARACTER, 1, 1);
                    break;
                case EnumController.CardNo.LB_W02_02T:
                    // �y�N�z�m(1)�n ���Ȃ��͎����̃L������1���I�сA���̃^�[�����A�p���[���{1500�B
                    PayCost(1);
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, -1);
                    break;
                case EnumController.CardNo.LB_W02_14T:
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
                case EnumController.CardNo.P3_S01_005:
                    // �y���z ���̃J�[�h���A�^�b�N�������A�N���C�}�b�N�X�u��Ɂu���Q�̏I���v������Ȃ�A
                    // ���Ȃ��͑���̃L������1���I�сA��D�ɖ߂��Ă悢�B
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
                    break;
                case EnumController.CardNo.P3_S01_04T:
                case EnumController.CardNo.P3_S01_010:
                    // �y�N�z�m(2) ���̃J�[�h���y���X�g�z����n ���Ȃ��͂��̃J�[�h����D�ɖ߂��B
                    PayCost(2);
                    m_MyMainCardsManager.CallOnRest(place);
                    m_GameManager.ToHandFromField(place);
                    break;
                case EnumController.CardNo.P3_S01_11T:
                case EnumController.CardNo.P3_S01_017:
                    // �y�N�z�m(1)�n ���̃^�[�����A���̃J�[�h�̃\�E�����{1�B
                    PayCost(1);
                    m_MyMainCardsManager.AddSoulUpUntilTurnEnd(place, 1);
                    m_GameManager.Syncronize();
                    m_GameManager.ExecuteActionList();
                    break;
                case EnumController.CardNo.P3_S01_052:
                    // �y�N�z�m(3)�n ���Ȃ��̓��x��1�ȉ��̑���̑O��̃L������1���I�сA�T�����ɒu���B
                    PayCost(3);
                    m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
                    return;
                case EnumController.CardNo.P3_S01_055:
                    //�y���z ���̃o�g�����Ă��邠�Ȃ��̃L�������y���o�[�X�z�������A���̃^�[�����A���̃J�[�h�̃p���[���{2000�B
                    m_MyMainCardsManager.AddPowerUpUntilTurnEnd(place, 2000);
                    m_GameManager.Syncronize();
                    m_GameManager.ExecuteActionList();
                    return;
                case EnumController.CardNo.P3_S01_057:
                    //�y���z ���̃J�[�h���y���o�[�X�z�������A���̃J�[�h�ƃo�g�����Ă���L�����̃��x����0�ȉ��Ȃ�A���Ȃ��͂��̃L�������y���o�[�X�z���Ă悢�B
                    m_EnemyMainCardsManager.CallReverse(enemyPlace);
                    m_BattleStrix.RpcToAll("CallMyReverse", enemyPlace, m_GameManager.isTurnPlayer);
                    m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
                    m_GameManager.ExecuteActionList();
                    return;
                case EnumController.CardNo.P3_S01_061:
                    //�y���z ���̃J�[�h���A�^�b�N�������A�N���C�}�b�N�X�u��Ɂu�j���N�X�E�A�o�^�[�v������Ȃ�A���Ȃ��͎����̍T�����̃L������1���I�сA��D�ɖ߂��B
                    m_DialogManager.SulvageDialog(m_BattleModeCard, m_GameManager.GraveYardList, EnumController.Type.CHARACTER, 1, 1);
                    return;
                case EnumController.CardNo.P3_S01_065:
                    //�y���z�m(1)�n ���̃J�[�h�����䂩��T�����ɒu���ꂽ���A���Ȃ��̓R�X�g�𕥂��Ă悢�B����������A���Ȃ��͎����̍T�����́u�������g���X���M�X�g�X�v��1���I�сA��D�ɖ߂��B
                    PayCost(1);
                    m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
                    for (int i = 0; i < m_GameManager.GraveYardList.Count; i++)
                    {
                        if (m_GameManager.GraveYardList[i].name == "�������g���X���M�X�g�X")
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
                    //�y�N�z�m(4)�n ���Ȃ��͎����̎R�D�����ăC�x���g��1���܂őI��ő���Ɍ����A��D�ɉ�����B���̎R�D���V���b�t������B
                    PayCost(4);
                    m_DialogManager.SearchDialog(EnumController.SearchDialogParamater.P3_S01_077);
                    return;
                case EnumController.CardNo.P3_S01_080:
                    //�y���z�m(1)�n ���̃J�[�h���v���C����ĕ���ɒu���ꂽ���A���Ȃ��̓R�X�g�𕥂��Ă悢�B����������A���Ȃ��͎����̍T�����́u�x���x�b�g���[���v��1���I�сA��D�ɖ߂��B
                    PayCost(1);
                    for (int i = 0; i < m_GameManager.GraveYardList.Count; i++)
                    {
                        if (m_GameManager.GraveYardList[i].name == "�x���x�b�g���[��")
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
                    //�y�N�z�m(4)�n ���Ȃ��͎����̃N���b�N��1���I�сA��D�ɖ߂��B
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
                    // �y���z ���́s���k��t�̂��Ȃ��̃L�������v���C����ĕ���ɒu���ꂽ���A���Ȃ��͎����̎R�D���ォ��1�����āA�R�D�̏ォ���ɒu���B
                    m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.CONFIRM_CONTROL_DECKTOP, m_BattleModeCard);
                    break;
                case EnumController.CardNo.P3_S01_091:
                    // �y�N�z�m(2) ���̃J�[�h���y���X�g�z����n ���Ȃ��͂��̃J�[�h����D�ɖ߂��B
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
                    //�y�N�z�m(2) ���̃J�[�h���y���X�g�z����n ���Ȃ��̓N���C�}�b�N�X�ȊO�̎����̍T�����̃J�[�h��1���I�сA���̃J�[�h�Ƃ��̃J�[�h���R�D�ɖ߂��B���̎R�D���V���b�t������B���Ȃ���1�������B
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
