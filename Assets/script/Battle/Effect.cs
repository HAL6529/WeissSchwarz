using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    private GameManager m_GameManager = null;
    private BattleStrix m_BattleStrix = null;
    private MyMainCardsManager m_MyMainCardsManager;
    private EnemyMainCardsManager m_EnemyMainCardsManager;
    public EventAnimationManager m_EventAnimationManager;

    public Effect(GameManager m_GameManager, BattleStrix m_BattleStrix)
    {
        this.m_GameManager = m_GameManager;
        this.m_BattleStrix = m_BattleStrix;
    }

    public void BondForHandToFild(BattleModeCard card)
    {
        switch (card.cardNo)
        {
            case EnumController.CardNo.AT_WX02_A10:
            case EnumController.CardNo.DC_W01_09T:
            case EnumController.CardNo.P3_S01_003:
            case EnumController.CardNo.P3_S01_032:
            case EnumController.CardNo.P3_S01_051:
            case EnumController.CardNo.P3_S01_082:
            case EnumController.CardNo.LB_W02_002:
                if (ConfirmStockForCost(1))
                {
                    Action action_Bond = new Action(m_GameManager, EnumController.Action.Bond);
                    action_Bond.SetParamaterBattleModeCard(card);
                    m_GameManager.ActionList.Add(action_Bond);
                    break;
                }
                return;
            default:
                return;
        }
    }

    /// <summary>
    /// �u�y���z ���Ȃ������x���A�b�v�������v�̌���
    /// </summary>
    /// <param name="m_BattleModeCard"></param>
    public void WhenLevelUp(BattleModeCard m_BattleModeCard)
    {
        if (m_BattleModeCard == null)
        {
            return;
        }

        switch (m_BattleModeCard.cardNo)
        {
            case EnumController.CardNo.LB_W02_14T:
                Debug.Log(m_BattleModeCard.name);
                Action action_LB_W02_14T = new Action(m_GameManager, EnumController.Action.LB_W02_14T);
                action_LB_W02_14T.SetParamaterEventAnimationManager(m_EventAnimationManager);
                action_LB_W02_14T.SetParamaterBattleStrix(m_BattleStrix);
                action_LB_W02_14T.SetParamaterBattleModeCard(m_BattleModeCard);
                m_GameManager.ActionList.Add(action_LB_W02_14T);
                break;
            default:
                break;
        }
    }

    public void PutGraveYardFromField(BattleMyMainCardAvility m_BattleMyMainCardAvility)
    {
        if (m_BattleMyMainCardAvility.m_BattleModeCard == null)
        {
            return;
        }

        switch (m_BattleMyMainCardAvility.m_BattleModeCard.cardNo)
        {
            //�y���z�m(1)�n ���̃J�[�h�����䂩��T�����ɒu���ꂽ���A���Ȃ��̓R�X�g�𕥂��Ă悢�B����������A���Ȃ��͎����̍T�����́u�������g���X���M�X�g�X�v��1���I�сA��D�ɖ߂��B
            case EnumController.CardNo.P3_S01_065:
                if (ConfirmStockForCost(1))
                {
                    Action action_P3_S01_065 = new Action(m_GameManager, EnumController.Action.P3_S01_065_2);
                    action_P3_S01_065.SetParamaterEventAnimationManager(m_EventAnimationManager);
                    action_P3_S01_065.SetParamaterBattleStrix(m_BattleStrix);
                    action_P3_S01_065.SetParamaterBattleModeCard(m_BattleMyMainCardAvility.m_BattleModeCard);
                    action_P3_S01_065.SetParamaterNum(m_BattleMyMainCardAvility.PlaceNum);
                    m_GameManager.ActionList.Add(action_P3_S01_065);
                }
                return;
            default:
                return;
        }
    }

    /// <summary>
    /// �u�y���z ���̃J�[�h���v���C����ĕ���ɒu���ꂽ���v�̌���
    /// </summary>
    /// <param name="m_BattleModeCard"></param>
    /// <param name="place"></param>
    public void WhenPlaceCardEffect(BattleModeCard m_BattleModeCard, int place)
    {
        if (m_BattleModeCard == null)
        {
            return;
        }

        this.m_MyMainCardsManager = m_GameManager.GetMyMainCardsManager();
        switch (m_BattleModeCard.cardNo)
        {
            case EnumController.CardNo.DC_W01_02T:
                Action action_DC_W01_02T = new Action(m_GameManager, EnumController.Action.DC_W01_02T);
                action_DC_W01_02T.SetParamaterEventAnimationManager(m_EventAnimationManager);
                action_DC_W01_02T.SetParamaterBattleStrix(m_BattleStrix);
                action_DC_W01_02T.SetParamaterBattleModeCard(m_BattleModeCard);
                m_GameManager.ActionList.Add(action_DC_W01_02T);
                break;
            case EnumController.CardNo.P3_S01_01T:
            case EnumController.CardNo.P3_S01_005:
                // �y���z ���̃J�[�h���v���C����ĕ���ɒu���ꂽ���A���̃^�[�����A���̃J�[�h�̃\�E�����{1�B
                Action action_P3_S01_01T = new Action(m_GameManager, EnumController.Action.P3_S01_01T);
                action_P3_S01_01T.SetParamaterEventAnimationManager(m_EventAnimationManager);
                action_P3_S01_01T.SetParamaterBattleStrix(m_BattleStrix);
                action_P3_S01_01T.SetParamaterBattleModeCard(m_BattleModeCard);
                action_P3_S01_01T.SetParamaterMyMainCardsManager(m_MyMainCardsManager);
                action_P3_S01_01T.SetParamaterNum(place);
                m_GameManager.ActionList.Add(action_P3_S01_01T);
                return;
            case EnumController.CardNo.P3_S01_04T:
            case EnumController.CardNo.P3_S01_010:
                // �y���z ���̃J�[�h���v���C����ĕ���ɒu���ꂽ���A���Ȃ��͎����̃L������1���I�сA���̃^�[�����A�p���[���{2000���A�\�E�����{1�B
                Action action_P3_S01_04T = new Action(m_GameManager, EnumController.Action.P3_S01_04T);
                action_P3_S01_04T.SetParamaterEventAnimationManager(m_EventAnimationManager);
                action_P3_S01_04T.SetParamaterBattleStrix(m_BattleStrix);
                action_P3_S01_04T.SetParamaterBattleModeCard(m_BattleModeCard);
                action_P3_S01_04T.SetParamaterMyMainCardsManager(m_MyMainCardsManager);
                action_P3_S01_04T.SetParamaterNum(place);
                m_GameManager.ActionList.Add(action_P3_S01_04T);
                return;
            case EnumController.CardNo.P3_S01_07T:
            case EnumController.CardNo.P3_S01_012:
                // �y���z ���̃J�[�h���v���C����ĕ���ɒu���ꂽ���A���̃^�[�����A���̃J�[�h�̃p���[���{1500�B
                Action action_P3_S01_07T = new Action(m_GameManager, EnumController.Action.P3_S01_07T);
                action_P3_S01_07T.SetParamaterEventAnimationManager(m_EventAnimationManager);
                action_P3_S01_07T.SetParamaterBattleStrix(m_BattleStrix);
                action_P3_S01_07T.SetParamaterBattleModeCard(m_BattleModeCard);
                action_P3_S01_07T.SetParamaterMyMainCardsManager(m_MyMainCardsManager);
                action_P3_S01_07T.SetParamaterNum(place);
                m_GameManager.ActionList.Add(action_P3_S01_07T);
                return;
            case EnumController.CardNo.P3_S01_001:
                // �y���z ���̃J�[�h���v���C����ĕ���ɒu���ꂽ���A���Ȃ��̓��x��1�ȏ�̎����̃L������1���I�сA���̃^�[�����A�\�E�����{1�B
                Action action_P3_S01_001 = new Action(m_GameManager, EnumController.Action.P3_S01_001);
                action_P3_S01_001.SetParamaterEventAnimationManager(m_EventAnimationManager);
                action_P3_S01_001.SetParamaterBattleStrix(m_BattleStrix);
                action_P3_S01_001.SetParamaterBattleModeCard(m_BattleModeCard);
                action_P3_S01_001.SetParamaterMyMainCardsManager(m_MyMainCardsManager);
                action_P3_S01_001.SetParamaterNum(place);
                m_GameManager.ActionList.Add(action_P3_S01_001);
                return;
            case EnumController.CardNo.P3_S01_026:
                // �y���z ���̃J�[�h���v���C����ĕ���ɒu���ꂽ���A���Ȃ��͎����̃L������1���I�сA���̃^�[�����A�p���[���{1000�B
                Action action_P3_S01_026 = new Action(m_GameManager, EnumController.Action.P3_S01_026);
                action_P3_S01_026.SetParamaterEventAnimationManager(m_EventAnimationManager);
                action_P3_S01_026.SetParamaterBattleStrix(m_BattleStrix);
                action_P3_S01_026.SetParamaterBattleModeCard(m_BattleModeCard);
                action_P3_S01_026.SetParamaterMyMainCardsManager(m_MyMainCardsManager);
                action_P3_S01_026.SetParamaterNum(place);
                m_GameManager.ActionList.Add(action_P3_S01_026);
                return;
            case EnumController.CardNo.P3_S01_052:
                // �y���z�m(1)�n ���̃J�[�h���v���C����ĕ���ɒu���ꂽ���A���Ȃ��̓R�X�g�𕥂��Ă悢�B����������A���Ȃ��͎����̍T�����́u�C������ԁv��1���I�сA��D�ɖ߂��B
                if (ConfirmStockForCost(1))
                {
                    Action action_P3_S01_052 = new Action(m_GameManager, EnumController.Action.P3_S01_052);
                    action_P3_S01_052.SetParamaterEventAnimationManager(m_EventAnimationManager);
                    action_P3_S01_052.SetParamaterBattleStrix(m_BattleStrix);
                    action_P3_S01_052.SetParamaterBattleModeCard(m_BattleModeCard);
                    action_P3_S01_052.SetParamaterMyMainCardsManager(m_MyMainCardsManager);
                    action_P3_S01_052.SetParamaterNum(place);
                    m_GameManager.ActionList.Add(action_P3_S01_052);
                }
                return;
            case EnumController.CardNo.P3_S01_057:
                //�y���z ���̃J�[�h���v���C����ĕ���ɒu���ꂽ���A���Ȃ��͑���̍T�����̃C�x���g��1���I�сA�v���o�ɂ��Ă悢�B
                for(int i = 0; i < m_GameManager.enemyGraveYardList.Count; i++)
                {
                    if (m_GameManager.enemyGraveYardList[i].type == EnumController.Type.EVENT)
                    {
                        Action action_P3_S01_057_1 = new Action(m_GameManager, EnumController.Action.P3_S01_057_1);
                        action_P3_S01_057_1.SetParamaterEventAnimationManager(m_EventAnimationManager);
                        action_P3_S01_057_1.SetParamaterBattleStrix(m_BattleStrix);
                        action_P3_S01_057_1.SetParamaterBattleModeCard(m_BattleModeCard);
                        action_P3_S01_057_1.SetParamaterMyMainCardsManager(m_MyMainCardsManager);
                        action_P3_S01_057_1.SetParamaterNum(place);
                        m_GameManager.ActionList.Add(action_P3_S01_057_1);
                        return;
                    }
                }
                return;
            case EnumController.CardNo.P3_S01_060:
                // �y���z�m(1)�n ���̃J�[�h���v���C����ĕ���ɒu���ꂽ���A���Ȃ��̓R�X�g�𕥂��Ă悢�B����������A���Ȃ��̓��x��1�ȉ��̑���̃L������1���I�сA�T�����ɒu���B
                if (ConfirmStockForCost(1))
                {
                    Action action_P3_S01_060 = new Action(m_GameManager, EnumController.Action.P3_S01_060);
                    action_P3_S01_060.SetParamaterEventAnimationManager(m_EventAnimationManager);
                    action_P3_S01_060.SetParamaterBattleStrix(m_BattleStrix);
                    action_P3_S01_060.SetParamaterBattleModeCard(m_BattleModeCard);
                    action_P3_S01_060.SetParamaterMyMainCardsManager(m_MyMainCardsManager);
                    action_P3_S01_060.SetParamaterNum(place);
                    m_GameManager.ActionList.Add(action_P3_S01_060);
                }
                return;
            case EnumController.CardNo.P3_S01_061:
                //�y���z ���̃J�[�h���v���C����ĕ���ɒu���ꂽ���A���Ȃ��͑���̍T�����̃J�[�h��1���I�сA�R�D�̏�ɒu���Ă悢�B
                if(m_GameManager.enemyGraveYardList.Count > 0)
                {
                    Action action_P3_S01_061 = new Action(m_GameManager, EnumController.Action.P3_S01_061);
                    action_P3_S01_061.SetParamaterEventAnimationManager(m_EventAnimationManager);
                    action_P3_S01_061.SetParamaterBattleStrix(m_BattleStrix);
                    action_P3_S01_061.SetParamaterBattleModeCard(m_BattleModeCard);
                    action_P3_S01_061.SetParamaterMyMainCardsManager(m_MyMainCardsManager);
                    action_P3_S01_061.SetParamaterNum(place);
                    m_GameManager.ActionList.Add(action_P3_S01_061);
                }
                return;
            case EnumController.CardNo.P3_S01_065:
                //�y���z ���̃J�[�h���v���C����ĕ���ɒu���ꂽ���A���Ȃ��͂��ׂẴv���C���[�ɁA1�_���[�W��^����B
                Action action_P3_S01_065 = new Action(m_GameManager, EnumController.Action.P3_S01_065_1);
                action_P3_S01_065.SetParamaterEventAnimationManager(m_EventAnimationManager);
                action_P3_S01_065.SetParamaterBattleStrix(m_BattleStrix);
                action_P3_S01_065.SetParamaterBattleModeCard(m_BattleModeCard);
                action_P3_S01_065.SetParamaterMyMainCardsManager(m_MyMainCardsManager);
                action_P3_S01_065.SetParamaterNum(place);
                m_GameManager.ActionList.Add(action_P3_S01_065);
                return;
            case EnumController.CardNo.P3_S01_080:
                //�y���z ���̃J�[�h���v���C����ĕ���ɒu���ꂽ���A���Ȃ���1�������Ă悢�B
                Action action_P3_S01_080_1 = new Action(m_GameManager, EnumController.Action.P3_S01_080_1);
                action_P3_S01_080_1.SetParamaterEventAnimationManager(m_EventAnimationManager);
                action_P3_S01_080_1.SetParamaterBattleStrix(m_BattleStrix);
                action_P3_S01_080_1.SetParamaterBattleModeCard(m_BattleModeCard);
                action_P3_S01_080_1.SetParamaterMyMainCardsManager(m_MyMainCardsManager);
                action_P3_S01_080_1.SetParamaterNum(place);
                m_GameManager.ActionList.Add(action_P3_S01_080_1);
                // �y���z�m(1)�n ���̃J�[�h���v���C����ĕ���ɒu���ꂽ���A���Ȃ��̓R�X�g�𕥂��Ă悢�B����������A���Ȃ��͎����̍T�����́u�x���x�b�g���[���v��1���I�сA��D�ɖ߂��B
                if (ConfirmStockForCost(1))
                {
                    Action action_P3_S01_080_2 = new Action(m_GameManager, EnumController.Action.P3_S01_080_2);
                    action_P3_S01_080_2.SetParamaterEventAnimationManager(m_EventAnimationManager);
                    action_P3_S01_080_2.SetParamaterBattleStrix(m_BattleStrix);
                    action_P3_S01_080_2.SetParamaterBattleModeCard(m_BattleModeCard);
                    action_P3_S01_080_2.SetParamaterMyMainCardsManager(m_MyMainCardsManager);
                    action_P3_S01_080_2.SetParamaterNum(place);
                    m_GameManager.ActionList.Add(action_P3_S01_080_2);
                }
                return;
            case EnumController.CardNo.P3_S01_088:
                //�y���z�m(2)�n ���̃J�[�h���v���C����ĕ���ɒu���ꂽ���A���Ȃ��̓R�X�g�𕥂��Ă悢�B����������A���Ȃ��͎����̃N���b�N���ォ��1���I�сA�T�����ɒu���B
                if (ConfirmStockForCost(2))
                {
                    Action action_P3_S01_088 = new Action(m_GameManager, EnumController.Action.P3_S01_088);
                    action_P3_S01_088.SetParamaterEventAnimationManager(m_EventAnimationManager);
                    action_P3_S01_088.SetParamaterBattleStrix(m_BattleStrix);
                    action_P3_S01_088.SetParamaterBattleModeCard(m_BattleModeCard);
                    action_P3_S01_088.SetParamaterMyMainCardsManager(m_MyMainCardsManager);
                    action_P3_S01_088.SetParamaterNum(place);
                    m_GameManager.ActionList.Add(action_P3_S01_088);
                }
                return;
            default:
                break;
        }
    }

    /// <summary>
    /// ����̃J�[�h�����o�[�X�����Ƃ��ɔ����������
    /// </summary>
    /// <param name="reversedCardPlace">���o�[�X�����L�����̏ꏊ(���o�[�X�����L�����̃R���g���[���[���_)</param>
    /// <param name="reversedCardLevel">���o�[�X�����L�����̃��x��</param>
    public void WhenReverseEnemyCardEffect(BattleModeCard card, int reversedCardPlace, int reversedCardLevel)
    {
        switch (card.cardNo)
        {
            case EnumController.CardNo.AT_WX02_A03:
                if (ConfirmClimaxCombo(EnumController.CardNo.AT_WX02_A08))
                {
                    Action action_AT_WX02_A08 = new Action(m_GameManager, EnumController.Action.AT_WX02_A08);
                    action_AT_WX02_A08.SetParamaterBattleModeCard(card);

                    m_GameManager.ActionList.Add(action_AT_WX02_A08);

                    //m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.CONFIRM_CARD_EFFECT, card);
                }
                return;
            case EnumController.CardNo.DC_W01_10T:
                Action action_DC_W01_10T = new Action(m_GameManager, EnumController.Action.DC_W01_10T);
                action_DC_W01_10T.SetParamaterBattleModeCard(card);
                action_DC_W01_10T.SetParamaterNum(reversedCardPlace);

                m_GameManager.ActionList.Add(action_DC_W01_10T);
                //m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.CONFIRM_CARD_EFFECT, card, reversedCardPlace);
                return;
            case EnumController.CardNo.LB_W02_19T:
                if(reversedCardLevel > 1)
                {
                    Action action_LB_W02_19T = new Action(m_GameManager, EnumController.Action.LB_W02_19T);
                    action_LB_W02_19T.SetParamaterBattleModeCard(card);
                    m_GameManager.ActionList.Add(action_LB_W02_19T);
                }
                return;
            default:
                return;
        }
    }

    /// <summary>
    /// �u�y���z ���̃J�[�h���y���o�[�X�z�������v�ɔ����������
    /// </summary>
    public void WhenReverseMyCardEffect(BattleMyMainCardAvility m_BattleMyMainCardAvility)
    {
        if (m_BattleMyMainCardAvility.m_BattleModeCard == null)
        {
            return;
        }
        this.m_MyMainCardsManager = m_GameManager.GetMyMainCardsManager();
        this.m_EnemyMainCardsManager = m_GameManager.GetEnemyMainCardsManager();


        if (m_BattleMyMainCardAvility.Takaya)
        {
            Action action_P3_S01_062 = new Action(m_GameManager, EnumController.Action.P3_S01_062);
            action_P3_S01_062.SetParamaterEventAnimationManager(m_EventAnimationManager);
            action_P3_S01_062.SetParamaterBattleStrix(m_BattleStrix);
            action_P3_S01_062.SetParamaterBattleModeCard(m_BattleMyMainCardAvility.m_BattleModeCard);
            action_P3_S01_062.SetParamaterNum(m_BattleMyMainCardAvility.PlaceNum);
            m_GameManager.ActionList.Add(action_P3_S01_062);
        }
        int enemyPlace = -1;
        switch (m_BattleMyMainCardAvility.m_BattleModeCard.cardNo)
        {
            // �y���z ���̃J�[�h���y���o�[�X�z�������A���̃J�[�h�ƃo�g�����Ă���L�����̃��x����1�ȉ��Ȃ�A���Ȃ��͂��̃L�������y���o�[�X�z���Ă悢�B
            case EnumController.CardNo.DC_W01_16T:
            case EnumController.CardNo.P3_S01_058:
                switch (m_BattleMyMainCardAvility.PlaceNum)
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
                if (m_EnemyMainCardsManager.GetFieldLevel(enemyPlace) <= 1 && m_EnemyMainCardsManager.GetState(enemyPlace) != EnumController.State.REVERSE)
                {
                    Action action = new Action(m_GameManager, EnumController.Action.DC_W01_16T);
                    action.SetParamaterBattleModeCard(m_BattleMyMainCardAvility.m_BattleModeCard);
                    action.SetParamaterNum(m_BattleMyMainCardAvility.PlaceNum);
                    m_GameManager.ActionList.Add(action);
                }
                return;
            //�y���z ���̃J�[�h���y���o�[�X�z�������A���̃J�[�h�ƃo�g�����Ă���L�����̃��x����0�ȉ��Ȃ�A���Ȃ��͂��̃L�������y���o�[�X�z���Ă悢�B
            case EnumController.CardNo.P3_S01_057:
                switch (m_BattleMyMainCardAvility.PlaceNum)
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
                if (m_EnemyMainCardsManager.GetFieldLevel(enemyPlace) <= 0 && m_EnemyMainCardsManager.GetState(enemyPlace) != EnumController.State.REVERSE)
                {
                    Action action = new Action(m_GameManager, EnumController.Action.P3_S01_057_2);
                    action.SetParamaterBattleModeCard(m_BattleMyMainCardAvility.m_BattleModeCard);
                    action.SetParamaterNum(m_BattleMyMainCardAvility.PlaceNum);
                    m_GameManager.ActionList.Add(action);
                }
                return;
            default:
                return;
        }
    }

    /// <summary>
    /// �u�y���z ���̃o�g�����Ă��邠�Ȃ��̃L�������y���o�[�X�z�������v�ɔ����������
    /// <summary>
    public void EffectWhenMyOtherCardReversed(BattleMyMainCardAvility m_BattleMyMainCardAvility)
    {
        if(m_BattleMyMainCardAvility.m_BattleModeCard == null)
        {
            return;
        }

        switch (m_BattleMyMainCardAvility.m_BattleModeCard.cardNo)
        {
            //�y���z ���̃o�g�����Ă��邠�Ȃ��̃L�������y���o�[�X�z�������A���̃^�[�����A���̃J�[�h�̃p���[���{2000�B
            case EnumController.CardNo.P3_S01_055:
                Action action_P3_S01_055 = new Action(m_GameManager, EnumController.Action.P3_S01_055);
                action_P3_S01_055.SetParamaterEventAnimationManager(m_EventAnimationManager);
                action_P3_S01_055.SetParamaterBattleStrix(m_BattleStrix);
                action_P3_S01_055.SetParamaterBattleModeCard(m_BattleMyMainCardAvility.m_BattleModeCard);
                action_P3_S01_055.SetParamaterNum(m_BattleMyMainCardAvility.PlaceNum);
                m_GameManager.ActionList.Add(action_P3_S01_055);
                return;
            // �y���z ���̃o�g�����Ă��邠�Ȃ��̃L�������y���o�[�X�z�������A���Ȃ��͎����̃L������1���I�сA���̃^�[�����A�p���[���{1000�B
            case EnumController.CardNo.DC_W01_07T:
                Action action_DC_W01_07T = new Action(m_GameManager, EnumController.Action.DC_W01_07T);
                action_DC_W01_07T.SetParamaterBattleModeCard(m_BattleMyMainCardAvility.m_BattleModeCard);
                m_GameManager.ActionList.Add(action_DC_W01_07T);
                return;
            default:
                return;
        }
    }

    /// <summary>
    /// �u�y���z ���̂��Ȃ��̃L�������v���C����ĕ���ɒu���ꂽ���v�ɔ����������
    /// </summary>
    /// <param name="effectCard">���ʂ𔭓�����J�[�h</param>
    /// <param name="placeNum">�v���C���ꂽ�J�[�h�̈ʒu</param>
    /// <param name="effectCardPlaceNum">���ʂ𔭓�����J�[�h�̈ʒu</param>
    public void EffectWhenMyOtherCardPut(BattleModeCard effectCard, int placeNum, int effectCardPlaceNum)
    {
        if (effectCard == null)
        {
            return;
        }
        this.m_MyMainCardsManager = m_GameManager.GetMyMainCardsManager();
        switch (effectCard.cardNo)
        {
            case EnumController.CardNo.P3_S01_040:
                //�y���z�m���̃J�[�h���y���X�g�z����n ���́s�X�|�[�c�t�̂��Ȃ��̃L�������v���C����ĕ���ɒu���ꂽ���A���Ȃ��̓R�X�g�𕥂��Ă悢�B����������A���Ȃ��͎����̎R�D�̏ォ��1�����A�X�g�b�N�u��ɒu���B
                if (m_MyMainCardsManager.HaveAttribute(placeNum, EnumController.Attribute.Sports) && m_MyMainCardsManager.GetState(effectCardPlaceNum) == EnumController.State.STAND)
                {
                    Action action = new Action(m_GameManager, EnumController.Action.P3_S01_040);
                    action.SetParamaterEventAnimationManager(m_EventAnimationManager);
                    action.SetParamaterBattleStrix(m_BattleStrix);
                    action.SetParamaterBattleModeCard(effectCard);
                    action.SetParamaterNum(effectCardPlaceNum);
                    m_GameManager.ActionList.Add(action);
                    return;
                }
                return;
            case EnumController.CardNo.P3_S01_076:
                //�y���z�m(1) ���̃J�[�h���y���X�g�z����n ���́s���k��t�̂��Ȃ��̃L�������v���C����ĕ���ɒu���ꂽ���A���Ȃ��̓R�X�g�𕥂��Ă悢�B����������A���Ȃ���1�������B
                if (m_MyMainCardsManager.HaveAttribute(placeNum, EnumController.Attribute.StudentCouncil) && ConfirmStockForCost(1))
                {
                    Action action = new Action(m_GameManager, EnumController.Action.P3_S01_076);
                    action.SetParamaterEventAnimationManager(m_EventAnimationManager);
                    action.SetParamaterBattleStrix(m_BattleStrix);
                    action.SetParamaterBattleModeCard(effectCard);
                    action.SetParamaterNum(effectCardPlaceNum);
                    m_GameManager.ActionList.Add(action);
                    return;
                }
                return;
            case EnumController.CardNo.P3_S01_16T:
            case EnumController.CardNo.P3_S01_087:
                //�y���z ���́s���k��t�̂��Ȃ��̃L�������v���C����ĕ���ɒu���ꂽ���A���Ȃ��͎����̎R�D���ォ��1�����āA�R�D�̏ォ���ɒu���B
                if (m_MyMainCardsManager.HaveAttribute(placeNum, EnumController.Attribute.StudentCouncil))
                {
                    Action action = new Action(m_GameManager, EnumController.Action.P3_S01_16T);
                    action.SetParamaterEventAnimationManager(m_EventAnimationManager);
                    action.SetParamaterBattleStrix(m_BattleStrix);
                    action.SetParamaterBattleModeCard(effectCard);
                    m_GameManager.ActionList.Add(action);
                    return;
                }
                return;
            default:
                return;
        }
    }

    
    /// ���ʂ𔭓����邽�߂ɕK�v�ȃX�g�b�N�𖞂����Ă��邩
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    private bool ConfirmStockForCost(int num)
    {
        if(m_GameManager.myStockList.Count >= num)
        {
            return true;
        }
        return false;
    }

    private bool ConfirmClimaxCombo(EnumController.CardNo card)
    {
        if (m_GameManager.MyClimaxCard == null)
        {
            return false;
        }
        if (m_GameManager.MyClimaxCard.cardNo == card)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// �N�����ʂ̕���
    /// </summary>
    /// <param name="card"></param>
    /// <param name="num">���C���̂ǂ̏ꏊ�ɂ��Ă邩</param>
    public void CheckEffectForAct(BattleModeCard card, int num)
    {
        switch (card.cardNo)
        {
            //�h���[�W��
            case EnumController.CardNo.AT_WX02_A09:
                if (ConfirmStockForCost(1))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_BRAIN_STORM_FOR_DRAW, card, num);
                }
                return;
            case EnumController.CardNo.DC_W01_01T:
                if (ConfirmStockForCost(0))
                {
                    // �y�N�z�m���̃J�[�h���y���X�g�z����n ���Ȃ��͎����̃L������1���I�сA���̃^�[�����A�p���[���{1000�B
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_DC_W01_01T, card, num);
                }
                return;
            // �y�N�z�m(1)�n ���̃^�[�����A���̃J�[�h�̃p���[���{2000�B
            case EnumController.CardNo.DC_W01_04T:
                if (ConfirmStockForCost(1))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_DC_W01_04T, card, num);
                }
                return;
            // �y�N�z�m(1)�n ���Ȃ��͑���̑O��̃L������1���I�сA���̃^�[�����A�p���[���|1000�B
            case EnumController.CardNo.DC_W01_05T:
                if (ConfirmStockForCost(1))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_DC_W01_05T, card, num);
                }
                return;
            // �y�N�z�m(2) ���̃J�[�h���y���X�g�z����n ���Ȃ��͎����̍T�����̃L������1���I�сA��D�ɖ߂��B
            case EnumController.CardNo.DC_W01_13T:
                if (ConfirmStockForCost(2))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_DC_W01_13T, card, num);
                }
                return;
            // �y�N�z�m(1)�n ���Ȃ��͎����̃L������1���I�сA���̃^�[�����A�p���[���{1500�B
            // �y�N�z�m(1)�n ���̃J�[�h���v���o�ɂ���B
            case EnumController.CardNo.LB_W02_02T:
                List<SelectActEffectDialogContent> LB_W02_02T_List = new List<SelectActEffectDialogContent>();
                if (ConfirmStockForCost(1))
                {
                    // effect1: �y�N�z�m(1)�n ���Ȃ��͎����̃L������1���I�сA���̃^�[�����A�p���[���{1500�B
                    SelectActEffectDialogContent m_effect1 = new SelectActEffectDialogContent(m_GameManager, card, 0);
                    LB_W02_02T_List.Add(m_effect1);

                    // effect2:�y�N�z�m(1)�n ���̃J�[�h���v���o�ɂ���B
                    SelectActEffectDialogContent m_effect2 = new SelectActEffectDialogContent(m_GameManager, card, 1);
                    m_effect2.SetParamaterNum1(num);
                    LB_W02_02T_List.Add(m_effect2);

                    // m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_SEND_MEMORY, card, num);
                }

                if(LB_W02_02T_List.Count > 0)
                {
                    m_GameManager.m_DialogManager.SelectActEffectDialog(LB_W02_02T_List);
                }
                return;
            // �y�N�z�m(1)�n ���̂��Ȃ��̃L�������ׂĂɁA���̃^�[�����A�s�����t��^����B
            case EnumController.CardNo.LB_W02_05T:
                if (ConfirmStockForCost(1))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_LB_W02_05T, card, num);
                }
                return;
            // �y�N�z�m(1)�n ���Ȃ��͑���̃L������1���I�сA���̃^�[�����A�p���[���|500�B
            case EnumController.CardNo.LB_W02_09T:
                if (ConfirmStockForCost(1))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_LB_W02_09T, card, num);
                }
                return;
            case EnumController.CardNo.LB_W02_14T:
                // �y�N�z�m(2) ���̃J�[�h���y���X�g�z����n ���Ȃ��͎����̃N���b�N���ォ��1���I�сA�T�����ɒu���B
                if (ConfirmStockForCost(2))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_LB_W02_14T, card, num);
                }
                return;
            //�y�N�z�m(1)�n ���Ȃ��́s�����t�̎����̃L������1���I�сA���̃^�[�����A�p���[���{500�B
            case EnumController.CardNo.LB_W02_17T:
                if (ConfirmStockForCost(1))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_LB_W02_17T, card, num);
                }
                return;
            case EnumController.CardNo.P3_S01_002:
                // �y�N�z�m(2) ���̃J�[�h���y���X�g�z����n ���̃J�[�h���v���o�ɂ���B���Ȃ��͎����̎�D�́u��l�����^�i�g�X�v���P���I�сA���̃J�[�h�������g�ɒu���B
                if (ConfirmStockForCost(2))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_002, card, num);
                }
                return;
            case EnumController.CardNo.P3_S01_04T:
            case EnumController.CardNo.P3_S01_010:
                // �y�N�z�m(2) ���̃J�[�h���y���X�g�z����n ���Ȃ��͂��̃J�[�h����D�ɖ߂��B
                if (ConfirmStockForCost(2))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_04T, card, num);
                }
                return;
            case EnumController.CardNo.P3_S01_11T:
            case EnumController.CardNo.P3_S01_017:
                //�y�N�z�m(1)�n ���̃^�[�����A���̃J�[�h�̃\�E�����{1�B
                if (ConfirmStockForCost(1))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_11T_2, card, num);
                }
                return;
            case EnumController.CardNo.P3_S01_16T:
            case EnumController.CardNo.P3_S01_087:
                // �y�N�z�m(2) ���̃J�[�h���y���X�g�z����n ���Ȃ���1�������B
                if (ConfirmStockForCost(2))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_16T, card, num);
                }
                return;
            case EnumController.CardNo.P3_S01_028:
                // �y�N�z�m(2)�n ���̃^�[�����A���̃J�[�h�̃p���[���{5000�B
                if (ConfirmStockForCost(2))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_028, card, num);
                }
                return;
            case EnumController.CardNo.P3_S01_034:
                // �y�N�z�m(1)�n ���̃^�[�����A���̃J�[�h�̃p���[���{2000�B
                if (ConfirmStockForCost(1))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_034, card, num);
                }
                return;
            case EnumController.CardNo.P3_S01_051:
                //�y�N�z�m(1)�n ���Ȃ��͎����̃J�[�h���Ɂu�����v���܂ރL�������P���I�сA���̃^�[�����A�p���[���{1000�B
                if (ConfirmStockForCost(1))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_051, card, num);
                }
                return;
            case EnumController.CardNo.P3_S01_052:
                // �y�N�z�m(3)�n ���Ȃ��̓��x��1�ȉ��̑���̑O��̃L������1���I�сA�T�����ɒu���B
                if (ConfirmStockForCost(3))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_052, card, num);
                }
                return;
            case EnumController.CardNo.P3_S01_077:
                // �y�N�z�m(4)�n ���Ȃ��͎����̎R�D�����ăC�x���g��1���܂őI��ő���Ɍ����A��D�ɉ�����B���̎R�D���V���b�t������B
                if (ConfirmStockForCost(4))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_077, card, num);
                }
                return;
            case EnumController.CardNo.P3_S01_080:
                //�y�N�z�m(2) ���̃J�[�h���y���X�g�z����n ���Ȃ��̓N���C�}�b�N�X�ȊO�̎����̍T�����̃J�[�h��1���I�сA���̃J�[�h�Ƃ��̃J�[�h���R�D�ɖ߂��B���̎R�D���V���b�t������B���Ȃ���1�������B
                if (ConfirmStockForCost(2))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_080, card, num);
                }
                return;
            case EnumController.CardNo.P3_S01_081:
                // �y�N�z�m(4)�n ���Ȃ��͎����̃N���b�N��1���I�сA��D�ɖ߂��B
                if (ConfirmStockForCost(4))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_081, card, num);
                }
                return;
            case EnumController.CardNo.P3_S01_091:
                // �y�N�z�m(2) ���̃J�[�h���y���X�g�z����n ���Ȃ��͂��̃J�[�h����D�ɖ߂��B
                if (ConfirmStockForCost(2))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_091, card, num);
                }
                return;
            case EnumController.CardNo.LB_W02_001:
                // �y�N�z�m(2) ���̃J�[�h���y���X�g�z����n ���Ȃ��͎����̎R�D�����ās�X�|�[�c�t�̃L������1���܂őI��ő���Ɍ����A��D�ɉ�����B���̎R�D���V���b�t������B
                if (ConfirmStockForCost(2))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_LB_W02_001, card, num);
                }
                return;
            default:
                return;
        }
    }

    /// <summary>
    /// �����̌��ʂ������Ă��邩���ׂ�
    /// </summary>
    /// <param name="card">BattleModeCard</param>
    /// <returns></returns>
    public PowerInstance.Assist CheckEffectForAssist(BattleModeCard card)
    {
        if(card == null)
        {
            return new PowerInstance.Assist(0);
        }
        switch (card.cardNo)
        {
            // 500����
            case EnumController.CardNo.AT_WX02_A11:
            case EnumController.CardNo.LB_W02_05T:
            case EnumController.CardNo.LB_W02_17T:
            case EnumController.CardNo.P3_S01_02T:
            case EnumController.CardNo.P3_S01_007:
            case EnumController.CardNo.P3_S01_053:
            case EnumController.CardNo.P3_S01_063:
            case EnumController.CardNo.P3_S01_076:
            case EnumController.CardNo.P3_S01_083:
            case EnumController.CardNo.LB_W02_001:
                return new PowerInstance.Assist(500);
            default:
                return new PowerInstance.Assist(0);
        }
    }

    /// <summary>
    /// �A���R�[�� �m��D�̃L������1���T�����ɒu���n�����L�����ւ̉����̌��ʂ������Ă��邩���ׂ�
    /// </summary>
    /// <param name="card">BattleModeCard</param>
    /// <returns></returns>
    public PowerInstance.AssistForHaveEncore CheckEffectForAssistForHaveEncore(BattleModeCard card)
    {
        if (card == null)
        {
            return new PowerInstance.AssistForHaveEncore(0);
        }
        switch (card.cardNo)
        {
            // 1000����
            case EnumController.CardNo.P3_S01_041:
            case EnumController.CardNo.P3_S01_076:
                return new PowerInstance.AssistForHaveEncore(1000);
            default:
                return new PowerInstance.AssistForHaveEncore(0);
        }
    }

    /// <summary>
    /// �S�̉����̌��ʂ������Ă��邩���ׂ�
    /// </summary>
    /// <param name="card"></param>
    /// <returns></returns>
    public PowerInstance.AllAssist CheckEffectForAllAssist(BattleModeCard card)
    {
        List<EnumController.Attribute> AttributeList = new List<EnumController.Attribute>();
        if (card == null)
        {
            return new PowerInstance.AllAssist(0, AttributeList);
        }

        switch (card.cardNo)
        {
            case EnumController.CardNo.P3_S01_084:
                AttributeList.Add(EnumController.Attribute.StudentCouncil);
                return new PowerInstance.AllAssist(500, AttributeList);
            default:
                return new PowerInstance.AllAssist(0, AttributeList);
        }
    }

    /// <summary>
    /// �K�E���̌��ʂ������Ă��邩���ׂ�
    /// </summary>
    /// <param name="card"></param>
    /// <returns></returns>
    public PowerInstance.Gaul CheckEffectForGaul(BattleModeCard card)
    {
        if (card == null)
        {
            return new PowerInstance.Gaul();
        }
        List<EnumController.Attribute> AttributeList = new List<EnumController.Attribute>();

        switch (card.cardNo)
        {
            // �K�E�����ʂ������Ă���
            case EnumController.CardNo.AT_WX02_A12:
                AttributeList.Add(EnumController.Attribute.Ooo);
                return new PowerInstance.Gaul(500, AttributeList);
            default:
                return new PowerInstance.Gaul();
        }
    }

    /// <summary>
    /// ���x�������̌��ʂ������Ă��邩���ׂ�
    /// </summary>
    /// <param name="card">BattleModeCard</param>
    /// <returns></returns>
    public PowerInstance.LevelAssist CheckEffectForLevelAssist(BattleModeCard card)
    {
        if (card == null)
        {
            return new PowerInstance.LevelAssist(0);
        }
        switch (card.cardNo)
        {
            // ���x��*500����
            case EnumController.CardNo.AT_WX02_A06:
                return new PowerInstance.LevelAssist(500);
            default:
                return new PowerInstance.LevelAssist(0);
        }
    }

    /// <summary>
    /// �A�^�b�N�����Ƃ��̌��ʂ������Ă��邩���ׂ�
    /// </summary>
    /// <param name="card"></param>
    public bool CheckWhenAttack(BattleModeCard card, int place, EnumController.Attack status)
    {
        this.m_MyMainCardsManager = m_GameManager.GetMyMainCardsManager();
        switch (card.cardNo)
        {
            case EnumController.CardNo.AT_WX02_A02:
                Action action = new Action(m_GameManager, EnumController.Action.ExecuteAttack2);
                action.SetParamaterMyMainCardsManager(m_MyMainCardsManager);
                action.SetParamaterAttackStatus(status);
                action.SetParamaterNum(place);

                m_GameManager.ActionList.Add(action);

                m_GameManager.m_DialogManager.CharacterSelectDialog(card, true, place);
                return true;
            case EnumController.CardNo.DC_W01_02T:
                // �y���z ���̃J�[�h���A�^�b�N�������A�N���C�}�b�N�X�u��Ɂu�������̉̕P�v������Ȃ�A���Ȃ��͎����̎R�D���ォ��1���I�сA�X�g�b�N�u��ɒu���A���̃^�[�����A���̃J�[�h�̃p���[���{3000�B
                if (m_GameManager.MyClimaxCard == null)
                {
                    return false;
                }

                if (m_GameManager.MyClimaxCard.name == "�������̉̕P")
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_DC_W01_02T, card, place, status);
                    return true;
                }
                return false;
            case EnumController.CardNo.DC_W01_10T:
                // �y���z�m(1)�n ���̃J�[�h���A�^�b�N�������A�N���C�}�b�N�X�u��Ɂu���t�̃I���S�[���v������Ȃ�A���Ȃ��̓R�X�g�𕥂��Ă悢�B����������A���Ȃ��͎����̍T�����̃L������1���I�сA��D�ɖ߂��B
                if (m_GameManager.MyClimaxCard == null)
                {
                    return false;
                }

                if (m_GameManager.MyClimaxCard.name == "���t�̃I���S�[��" && ConfirmStockForCost(1))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_DC_W01_10T, card, place, status);
                    return true;
                }
                return false;
            case EnumController.CardNo.LB_W02_03T:
                // �y���z ���̃J�[�h���A�^�b�N�������A�N���C�}�b�N�X�u��Ɂu���敗�̃n�~���O�v������Ȃ�A���Ȃ��͎����̎R�D���ォ��1���I�сA�X�g�b�N�u��ɒu���A���̃^�[�����A���̃J�[�h�̃p���[���{3000�B
                if (m_GameManager.MyClimaxCard == null)
                {
                    return false;
                }

                if (m_GameManager.MyClimaxCard.name == "���敗�̃n�~���O")
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_LB_W02_03T, card, place, status);
                    return true;
                }
                return false;
            case EnumController.CardNo.P3_S01_004:
                // �y���z ���̃J�[�h���A�^�b�N�������A�N���C�}�b�N�X�u��Ɂu�I�V���C�v������Ȃ�A���Ȃ��͑���̃L������1���I�сA��D�ɖ߂��Ă悢�B
                if (m_GameManager.MyClimaxCard == null)
                {
                    return false;
                }

                if (m_GameManager.MyClimaxCard.name == "�I�V���C")
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_004, card, place, status);
                    return true;
                }
                return false;
            case EnumController.CardNo.P3_S01_01T:
            case EnumController.CardNo.P3_S01_005:
                // �y���z ���̃J�[�h���A�^�b�N�������A�N���C�}�b�N�X�u��Ɂu���Q�̏I���v������Ȃ�A���Ȃ��͑���̃L������1���I�сA��D�ɖ߂��Ă悢�B
                if (m_GameManager.MyClimaxCard == null)
                {
                    return false;
                }

                if (m_GameManager.MyClimaxCard.name == "���Q�̏I���")
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_01T, card, place, status);
                    return true;
                }
                return false;
            case EnumController.CardNo.P3_S01_11T:
            case EnumController.CardNo.P3_S01_017:
                if (m_GameManager.MyClimaxCard == null)
                {
                    return false;
                }

                if (m_GameManager.MyClimaxCard.name == "�Ō�̑I��")
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_11T_1, card, place, status);
                    return true;
                }
                return false;
            case EnumController.CardNo.P3_S01_030:
                // �y���z ���̃J�[�h���A�^�b�N�������A�N���C�}�b�N�X�u��Ɂu�؂�Ȃ��J�v������Ȃ�A���Ȃ��͎����̎R�D�̏ォ��1�����A�X�g�b�N�u��ɒu���A���̃^�[�����A���̃J�[�h�̃p���[���{3000�B
                if (m_GameManager.MyClimaxCard == null)
                {
                    return false;
                }

                if (m_GameManager.MyClimaxCard.name == "�؂�Ȃ��J")
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_030, card, place, status);
                    return true;
                }
                return false;
            case EnumController.CardNo.P3_S01_055:
                //�y���z ���̃J�[�h���A�^�b�N�������A�N���C�}�b�N�X�u��Ɂu���肪�Ƃ��v������Ȃ�A���Ȃ��͎����̍T�����̃L������1���I�сA��D�ɖ߂��B
                if (m_GameManager.MyClimaxCard == null)
                {
                    return false;
                }

                if (m_GameManager.MyClimaxCard.name == "���肪�Ƃ�")
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_055, card, place, status);
                    return true;
                }
                return false;
            case EnumController.CardNo.P3_S01_056:
                // �y���z ���̃J�[�h���A�^�b�N�������A�N���C�}�b�N�X�u��Ɂu�F�ւ̐����v������Ȃ�A���Ȃ��͎����̍T�����̃L������1���I�сA��D�ɖ߂��B
                if (m_GameManager.MyClimaxCard == null)
                {
                    return false;
                }

                if (m_GameManager.MyClimaxCard.name == "�F�ւ̐���")
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_P3_S01_056, card, place, status);
                    return true;
                }
                return false;
            case EnumController.CardNo.P3_S01_061:
                //�y���z ���̃J�[�h���A�^�b�N�������A�N���C�}�b�N�X�u��Ɂu�j���N�X�E�A�o�^�[�v������Ȃ�A���Ȃ��͎����̍T�����̃L������1���I�сA��D�ɖ߂��B
                if (m_GameManager.MyClimaxCard == null)
                {
                    return false;
                }

                if (m_GameManager.GraveYardList.Count > 0 && m_GameManager.MyClimaxCard.name == "�j���N�X�E�A�o�^�[")
                {
                    Action action_P3_S01_061 = new Action(m_GameManager, EnumController.Action.ExecuteAttack2);
                    action_P3_S01_061.SetParamaterMyMainCardsManager(m_MyMainCardsManager);
                    action_P3_S01_061.SetParamaterAttackStatus(status);
                    action_P3_S01_061.SetParamaterNum(place);

                    m_GameManager.ActionList.Add(action_P3_S01_061);
                    m_EventAnimationManager.AnimationStart_2(card, place);
                    m_BattleStrix.EventAnimation(card, m_GameManager.isFirstAttacker);
                    return true;
                }
                return false;
            case EnumController.CardNo.P3_S01_077:
                //�y���z ���̃J�[�h���A�^�b�N�������A�N���C�}�b�N�X�u��Ɂu�ŋ��Ȃ�ҁv������Ȃ�A���Ȃ���1�������B
                if (m_GameManager.MyClimaxCard == null)
                {
                    return false;
                }

                if (m_GameManager.MyClimaxCard.name == "�ŋ��Ȃ��")
                {
                    Action action_P3_S01_077 = new Action(m_GameManager, EnumController.Action.ExecuteAttack2);
                    action_P3_S01_077.SetParamaterMyMainCardsManager(m_MyMainCardsManager);
                    action_P3_S01_077.SetParamaterAttackStatus(status);
                    action_P3_S01_077.SetParamaterNum(place);

                    m_GameManager.ActionList.Add(action_P3_S01_077);
                    m_EventAnimationManager.AnimationStart(card, place);
                    m_BattleStrix.EventAnimation(card, m_GameManager.isFirstAttacker);
                    return true;
                }
                return false;
            case EnumController.CardNo.P3_S01_081:
                //�y���z ���̃J�[�h���A�^�b�N�������A�N���C�}�b�N�X�u��Ɂu���̈�u�v������Ȃ�A���Ȃ���1�������B
                if (m_GameManager.MyClimaxCard == null)
                {
                    return false;
                }

                if (m_GameManager.MyClimaxCard.name == "���̈�u")
                {
                    Action action_P3_S01_081 = new Action(m_GameManager, EnumController.Action.ExecuteAttack2);
                    action_P3_S01_081.SetParamaterMyMainCardsManager(m_MyMainCardsManager);
                    action_P3_S01_081.SetParamaterAttackStatus(status);
                    action_P3_S01_081.SetParamaterNum(place);

                    m_GameManager.ActionList.Add(action_P3_S01_081);
                    m_EventAnimationManager.AnimationStart(card, place);
                    m_BattleStrix.EventAnimation(card, m_GameManager.isFirstAttacker);
                    return true;
                }
                return false;
            case EnumController.CardNo.LB_W02_002:
                //�y���z�m(1)�n ���̃J�[�h���A�^�b�N�������A�N���C�}�b�N�X�u��Ɂu��Ƌ��ɂ�����X�v������Ȃ�A���Ȃ��̓R�X�g�𕥂��Ă悢�B����������A���Ȃ��͑���̃L�������P���I�сA��D�ɖ߂��B
                if (m_GameManager.MyClimaxCard == null)
                {
                    return false;
                }

                if (m_GameManager.MyClimaxCard.name == "��Ƌ��ɂ�����X" && ConfirmStockForCost(1))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_LB_W02_002, card, place, status);
                    return true;
                }
                return false;
            case EnumController.CardNo.LB_W02_004:
                //�y���z�m(1)�n ���̃J�[�h���A�^�b�N�������A�N���C�}�b�N�X�u��Ɂu���[�_�[�̋A�ҁv������Ȃ�A���Ȃ��̓R�X�g�𕥂��Ă悢�B����������A���Ȃ��͑���̃L�������P���I�сA��D�ɖ߂��B
                if (m_GameManager.MyClimaxCard == null)
                {
                    return false;
                }

                if (m_GameManager.MyClimaxCard.name == "���[�_�[�̋A��" && ConfirmStockForCost(1))
                {
                    m_GameManager.m_DialogManager.YesOrNoDialog(EnumController.YesOrNoDialogParamater.COST_CONFIRM_LB_W02_004, card, place, status);
                    return true;
                }
                return false;
            default:
                return false;
        }
    }
}
