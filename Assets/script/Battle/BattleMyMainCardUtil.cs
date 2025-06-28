using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleMyMainCardUtil : MonoBehaviour
{
    private BattleModeCard m_BattleModeCard = null;
    [SerializeField] GameManager m_GameManager;
    [SerializeField] Image image;
    [SerializeField] BattleModeGuide m_BattleModeGuide;
    [SerializeField] EventAnimationManager m_EventAnimationManager;
    [SerializeField] GameObject ActButton;
    [SerializeField] GameObject MoveButton;
    [SerializeField] GameObject ActButton_Beside;
    [SerializeField] GameObject MoveButton_Beside;
    [SerializeField] GameObject FrontAttackButton;
    [SerializeField] GameObject SideAttackButton;
    [SerializeField] GameObject DirectAttackButton;
    [SerializeField] GameObject Power;
    [SerializeField] MyHandCardsManager m_MyHandCardsManager;
    [SerializeField] MyMainCardsManager m_MyMainCardsManager;
    [SerializeField] EnemyMainCardsManager m_EnemyMainCardsManager;
    [SerializeField] DialogManager m_DialogManager;
    [SerializeField] BattleStrix m_BattleStrix;
    [SerializeField] Text PowerText;
    [SerializeField] int PlaceNum;
    [SerializeField] TriggerCardAnimation m_TriggerCardAnimation;

    /// <summary>
    /// �t�B�[���h��ł̃p���[
    /// </summary>
    public int FieldPower = 0;

    /// <summary>
    /// �t�B�[���h��ł̃\�E��
    /// </summary>
    public int FieldSoul = 0;

    /// <summary>
    /// �t�B�[���h��ł̃��x��
    /// </summary>
    public int FieldLevel = 0;

    /// <summary>
    /// �t�B�[���h��Ŏ�D�A���R�[���������Ă��邩
    /// </summary>
    public bool HandEncore = false;
    
    /// <summary>
    /// �t�B�[���h���2�X�g�b�N�A���R�[���������Ă��邩
    /// </summary>
    public bool TwoStockEncore = false;

    /// <summary>
    /// �t�B�[���h��ŃN���b�N�A���R�[���������Ă��邩
    /// </summary>
    public bool ClockEncore = false;

    /// <summary>
    /// �^�[���I�����܂Œǉ����������N���X
    /// </summary>
    public AttributeInstance.AttributeUpUntilTurnEnd m_AttributeUpUntilTurnEnd = new AttributeInstance.AttributeUpUntilTurnEnd();

    /// <summary>
    /// �t�B�[���h��ł̓���
    /// </summary>
    public List<EnumController.Attribute> AttributeList = new List<EnumController.Attribute>();

    /// <summary>
    /// �t�B�[���h��ł̃X�e�[�^�X
    /// </summary>
    private EnumController.State state = EnumController.State.STAND;

    /// <summary>
    /// �劈��������Ă��邩
    /// </summary>
    public bool isGreatPerformance = false;

    private bool isMoveButton = false;

    public Effect m_Effect;

    /// <summary>
    /// �N�����ʂ������Ă��邩�`�F�b�N�N���X
    /// </summary>
    private CheckHaveActAvility m_CheckHaveActAvility;

    /// <summary>
    /// �����N���X
    /// </summary>
    public PowerInstance.Assist m_Assist = new PowerInstance.Assist(0);

    /// <summary>
    /// �S�̃p���[�A�b�v�N���X
    /// </summary>
    public PowerInstance.AllAssist m_AllAssist = new PowerInstance.AllAssist(0, null);

    /// <summary>
    /// �K�E�����ʃN���X
    /// </summary>
    public PowerInstance.Gaul m_Gaul = new PowerInstance.Gaul();

    /// <summary>
    /// ���x�������N���X
    /// </summary>
    public PowerInstance.LevelAssist m_LevelAssist = new PowerInstance.LevelAssist(0);

    /// <summary>
    /// �^�[���I�����܂ŃA�b�v����p���[�N���X
    /// </summary>
    public PowerInstance.PowerUpUntilTurnEnd m_PowerUpUntilTurnEnd = new PowerInstance.PowerUpUntilTurnEnd(0);

    /// <summary>
    /// �^�[���I�����܂ŃA�b�v����\�E���N���X
    /// </summary>
    public SoulInstance.SoulUpUntilTurnEnd m_SoulUpUntilTurnEnd = new SoulInstance.SoulUpUntilTurnEnd(0);

    /// <summary>
    /// �N���C�}�b�N�XUtil
    /// </summary>
    private ClimaxUtil m_ClimaxUtil = new ClimaxUtil();

    // Start is called before the first frame update
    void Start()
    {
        changeSprite();
        m_Effect = new Effect(m_GameManager, m_BattleStrix);
        m_Effect.m_EventAnimationManager = m_EventAnimationManager;
        m_CheckHaveActAvility = new CheckHaveActAvility();
    }

    public void setBattleModeCard(BattleModeCard card, EnumController.State state)
    {
        switch (state)
        {
            case EnumController.State.STAND:
                Stand();
                break;
            case EnumController.State.REST:
                onRest();
                m_BattleStrix.RpcToAll("CallEnemyRest", PlaceNum, m_GameManager.isTurnPlayer);
                break;
            case EnumController.State.REVERSE:
                onReverse();
                m_BattleStrix.RpcToAll("CallEnemyReverse", PlaceNum, m_GameManager.isTurnPlayer);
                break;
            default:
                onReset();
                break;
        }
        AttributeList = new List<EnumController.Attribute>();
        isGreatPerformance = false;

        m_BattleModeCard = card;
        if(card != null)
        {
            AttributeListReset();
            isGreatPerformance = card.isGreatPerformance;
        }

        // �����̃J�[�h�Ȃ�\�͕t�^
        m_Assist = m_Effect.CheckEffectForAssist(m_BattleModeCard);
        // �K�E���̃J�[�h�Ȃ�\�͕t�^
        m_Gaul = m_Effect.CheckEffectForGaul(m_BattleModeCard);
        // ���x�������̃J�[�h�Ȃ�\�͕t�^
        m_LevelAssist = m_Effect.CheckEffectForLevelAssist(m_BattleModeCard);
        changeSprite();
    }

    private void changeSprite()
    {
        if (m_BattleModeCard == null)
        {
            image.sprite = null;
            image.color = new Color(1, 1, 1, 0 / 255);
            Power.SetActive(false);
            return;
        }
        image.sprite = m_BattleModeCard.sprite;
        image.color = new Color(1, 1, 1, 255 / 255);

        Power.SetActive(true);
        PowerText.text = FieldPower.ToString();
    }

    public void onClick()
    {
        if (m_BattleModeCard == null)
        {
            return;
        }
        bool temp = isMoveButton;
        m_MyHandCardsManager.CallResetSelected();
        m_MyHandCardsManager.CallNotShowPlayButton();
        m_MyMainCardsManager.CallNotShowMoveButton();
        m_MyMainCardsManager.CallNotShowDirectAttackButton();
        m_MyMainCardsManager.CallNotShowFrontAndSideButton();

        // ---��������J�[�h�̃K�C�h�p---
        BattleModeCard t_BattleModeCard = new BattleModeCard();
        t_BattleModeCard.power = FieldPower;
        t_BattleModeCard.soul = FieldSoul;
        t_BattleModeCard.level = FieldLevel;
        t_BattleModeCard.attribute = AttributeList;

        m_BattleModeGuide.showImage(m_BattleModeCard, t_BattleModeCard);
        // ---�����܂ŃJ�[�h�̃K�C�h�p---

        m_DialogManager.CloseAllDialog2();

        if (m_GameManager.isLevelUpProcess || m_GameManager.isAttackProcess)
        {
            return;
        }

        if (m_GameManager.phase == EnumController.Turn.Main && m_GameManager.isTurnPlayer)
        {
            if (isMoveButton)
            {
                isMoveButton = false;
            }
            else
            {
                if(state == EnumController.State.REST)
                {
                    MoveButton_Beside.SetActive(true);
                }
                else
                {
                    MoveButton.SetActive(true);
                }

                int minCost = m_CheckHaveActAvility.Check(m_BattleModeCard.cardNo, state);
                if (minCost > -1 && m_GameManager.myStockList.Count >= minCost)
                {
                    if (state == EnumController.State.REST)
                    {
                        ActButton_Beside.SetActive(true);
                    }
                    else
                    {
                        ActButton.SetActive(true);
                    }           
                }
                isMoveButton = true;
            }
        }
        else if (m_GameManager.phase == EnumController.Turn.Attack && m_GameManager.isTurnPlayer)
        {
            // ��U��1�L���������A�^�b�N�ł��Ȃ�
            if (m_GameManager.isFirstAttacked && m_GameManager.turn == 1)
            {
                return;
            }

            if (PlaceNum > 2 || m_BattleModeCard == null || state != EnumController.State.STAND)
            {
                return;
            }

            // �����̘g�ɑ劈��̃L���������Ȃ����`�F�b�N
            if (m_EnemyMainCardsManager.GetIsGreatProcessList(1) && m_EnemyMainCardsManager.GetState(1) != EnumController.State.REVERSE)
            {
                FrontAttackButton.SetActive(true);
                SideAttackButton.SetActive(false);
                return;
            }

            if (PlaceNum == 0 && m_GameManager.enemyFieldList[2] == null ||
               PlaceNum == 1 && m_GameManager.enemyFieldList[1] == null ||
               PlaceNum == 2 && m_GameManager.enemyFieldList[0] == null)
            {
                DirectAttackButton.SetActive(true);
                return;
            }
            FrontAttackButton.SetActive(true);
            SideAttackButton.SetActive(true);
            return;
        }
    }

    public void Stand()
    {
        this.gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        m_BattleStrix.RpcToAll("CallEnemyStand", PlaceNum, m_GameManager.isTurnPlayer);
        state = EnumController.State.STAND;
    }

    public void NotShowMoveButton()
    {
        MoveButton.SetActive(false);
        ActButton.SetActive(false);
        MoveButton_Beside.SetActive(false);
        ActButton_Beside.SetActive(false);
        isMoveButton = false;
    }

    public void onMoveButton()
    {
        m_DialogManager.MoveDialog(PlaceNum, m_BattleModeCard);
    }


    public void onActButton()
    {
        NotShowMoveButton();
        m_Effect.CheckEffectForAct(m_BattleModeCard, PlaceNum);
    }

    public void NotShowFrontAndSideButton()
    {
        FrontAttackButton.SetActive(false);
        SideAttackButton.SetActive(false);
    }

    public void NotShowDirectAttackButton()
    {
        DirectAttackButton.SetActive(false);
    }

    public void onDirectAttack()
    {
        // ��U��1�L���������A�^�b�N�ł��Ȃ����邽�߂Ƀt���O��ύX
        if(!m_GameManager.isFirstAttacked && m_GameManager.turn == 1)
        {
            m_GameManager.isFirstAttacked = true;
        }
        m_BattleStrix.RpcToAll("SetIsAttackProcess", true);
        onRest();
        m_BattleStrix.RpcToAll("CallEnemyRest", PlaceNum, m_GameManager.isTurnPlayer);
        m_BattleStrix.RpcToAll("SEManager_AttackSE_Play");
        if (m_Effect.CheckWhenAttack(m_BattleModeCard, PlaceNum, EnumController.Attack.DIRECT_ATTACK))
        {
            return;
        }
        m_BattleStrix.CallPlayEnemyTriggerAnimation(m_GameManager.myDeckList[0], m_GameManager.isTurnPlayer);
        m_TriggerCardAnimation.Play(EnumController.Attack.DIRECT_ATTACK, PlaceNum, GetEnemyLevel());
    }

    public void onFrontAttack()
    {
        m_BattleStrix.RpcToAll("SetIsAttackProcess", true);
        onRest();
        m_BattleStrix.RpcToAll("CallEnemyRest", PlaceNum, m_GameManager.isTurnPlayer);
        m_BattleStrix.RpcToAll("SEManager_AttackSE_Play");
        if (m_Effect.CheckWhenAttack(m_BattleModeCard, PlaceNum, EnumController.Attack.FRONT_ATTACK))
        {
            return;
        }

        // �g���K�[�̃e�X�g�p(BattleModeDeck�Ńg���K�[����J�[�h��ݒ�)
        // m_GameManager.myDeckList[0] = m_GameManager.testTrigger;

        m_BattleStrix.CallPlayEnemyTriggerAnimation(m_GameManager.myDeckList[0], m_GameManager.isTurnPlayer);
        m_TriggerCardAnimation.Play(EnumController.Attack.FRONT_ATTACK, PlaceNum, GetEnemyLevel());
    }

    public void onSideAttack()
    {
        m_BattleStrix.RpcToAll("SetIsAttackProcess", true);
        onRest();
        m_BattleStrix.RpcToAll("CallEnemyRest", PlaceNum, m_GameManager.isTurnPlayer);
        m_BattleStrix.RpcToAll("SEManager_AttackSE_Play");
        if (m_Effect.CheckWhenAttack(m_BattleModeCard, PlaceNum, EnumController.Attack.SIDE_ATTACK))
        {
            return;
        }
        m_BattleStrix.CallPlayEnemyTriggerAnimation(m_GameManager.myDeckList[0], m_GameManager.isTurnPlayer);
        m_TriggerCardAnimation.Play(EnumController.Attack.SIDE_ATTACK, PlaceNum, GetEnemyLevel());
    }

    public void Attack2(EnumController.Attack status)
    {
        switch (status)
        {
            case EnumController.Attack.DIRECT_ATTACK:
                m_BattleStrix.RpcToAll("SetIsAttackProcess", true);
                onRest();
                m_BattleStrix.RpcToAll("CallEnemyRest", PlaceNum, m_GameManager.isTurnPlayer);
                m_BattleStrix.CallPlayEnemyTriggerAnimation(m_GameManager.myDeckList[0], m_GameManager.isTurnPlayer);
                m_TriggerCardAnimation.Play(EnumController.Attack.DIRECT_ATTACK, PlaceNum, GetEnemyLevel());
                break;
            case EnumController.Attack.FRONT_ATTACK:
                m_BattleStrix.RpcToAll("SetIsAttackProcess", true);
                onRest();
                m_BattleStrix.RpcToAll("CallEnemyRest", PlaceNum, m_GameManager.isTurnPlayer);
                m_BattleStrix.CallPlayEnemyTriggerAnimation(m_GameManager.myDeckList[0], m_GameManager.isTurnPlayer);
                m_TriggerCardAnimation.Play(EnumController.Attack.FRONT_ATTACK, PlaceNum, GetEnemyLevel());
                break;
            case EnumController.Attack.SIDE_ATTACK:
                m_BattleStrix.RpcToAll("SetIsAttackProcess", true);
                onRest();
                m_BattleStrix.RpcToAll("CallEnemyRest", PlaceNum, m_GameManager.isTurnPlayer);
                m_BattleStrix.CallPlayEnemyTriggerAnimation(m_GameManager.myDeckList[0], m_GameManager.isTurnPlayer);
                m_TriggerCardAnimation.Play(EnumController.Attack.SIDE_ATTACK, PlaceNum, GetEnemyLevel());
                break;
            default:
                break;
        }
    }

    private int GetEnemyLevel()
    {
        if (m_EnemyMainCardsManager.GetIsGreatProcessList(1))
        {
            return m_EnemyMainCardsManager.GetFieldLevel(1);
        }
        else
        {
            switch (PlaceNum)
            {
                case 0:
                    return m_EnemyMainCardsManager.GetFieldLevel(2);
                case 1:
                    return m_EnemyMainCardsManager.GetFieldLevel(1);
                case 2:
                    return m_EnemyMainCardsManager.GetFieldLevel(0);
                default:
                    return 0;
            }
        }
    }

    /// <summary>
    /// �u�y���z ���Ȃ������x���A�b�v�������v�̌���
    /// </summary>
    public void WhenLevelUp()
    {
        m_Effect.WhenLevelUp(m_BattleModeCard);
    }

    /// <summary>
    /// ��������o�[�X�����Ƃ��̌���
    /// </summary>
    public void WhenReverseEnemyCard(int reversedCardPlace, int reversedCardLevel)
    {
        m_Effect.WhenReverseEnemyCardEffect(m_BattleModeCard, reversedCardPlace, reversedCardLevel);
    }

    /// <summary>
    /// ���o�[�X�����Ƃ��ɃJ�[�h�̌����ƃX�e�[�^�X��ύX
    /// </summary>
    public void onReverse()
    {
        state = EnumController.State.REVERSE;
        this.gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);
        m_MyMainCardsManager.ConfirmEffectWhenMyCardReversed(PlaceNum);
        m_Effect.WhenReverseMyCardEffect(m_BattleModeCard, PlaceNum);
    }

    /// <summary>
    /// �u�y���z ���̂��Ȃ��̃L�������v���C����ĕ���ɒu���ꂽ���v�ɔ���������ʂ������Ă���J�[�h����ɂȂ����m�F����
    /// <param name="placeNum">�v���C���ꂽ�J�[�h�̈ʒu</param>
    /// </summary>
    public void EffectWhenMyOtherCardPut(int placeNum)
    {
        m_Effect.EffectWhenMyOtherCardPut(m_BattleModeCard, placeNum);
    }

    /// <summary>
    /// �u�y���z ���̃o�g�����Ă��邠�Ȃ��̃L�������y���o�[�X�z�������v�̌��ʂ������Ă��Ȃ����m�F����
    /// </summary>
    public void EffectWhenMyOtherCardReversed()
    {
        m_Effect.EffectWhenMyOtherCardReversed(m_BattleModeCard);
    }

    /// <summary>
    /// ���X�g��ԂɂȂ����Ƃ��ɃJ�[�h�̌����ƃX�e�[�^�X��ύX
    /// </summary>
    public void onRest()
    {
        state = EnumController.State.REST;
        this.gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
        NotShowFrontAndSideButton();
        NotShowDirectAttackButton();
    }

    public void onReset()
    {
        Stand();
        m_BattleModeCard = null;
    }

    public void ResetPowerUpUntilTurnEnd()
    {
        m_PowerUpUntilTurnEnd = new PowerInstance.PowerUpUntilTurnEnd(0);
    }

    public void ResetAttributeUpUntilTurnEnd()
    {
        m_AttributeUpUntilTurnEnd = new AttributeInstance.AttributeUpUntilTurnEnd();
    }

    public void ResetSoulUpUntilTurnEnd()
    {
        m_SoulUpUntilTurnEnd = new SoulInstance.SoulUpUntilTurnEnd(0);
    }

    /// <summary>
    /// �t�B�[���h��̓����̌v�Z
    /// </summary>
    public void AttributeUpdate()
    {
        if (m_BattleModeCard == null)
        {
            AttributeList = new List<EnumController.Attribute>();
            return;
        }

        AttributeListReset();
        for (int i = 0; i < m_AttributeUpUntilTurnEnd.AttributeList.Count; i++)
        {
            if (!HaveAttribute(m_AttributeUpUntilTurnEnd.AttributeList[i]))
            {
                AttributeList.Add(m_AttributeUpUntilTurnEnd.AttributeList[i]);
                Debug.Log("added" + m_AttributeUpUntilTurnEnd.AttributeList[i]);
            }
        }
    }

    /// <summary>
    /// �t�B�[���h��̃��x���̌v�Z
    /// </summary>
    public void LevelUpdate()
    {
        if (m_BattleModeCard == null)
        {
            FieldLevel = 0;
            return;
        }

        FieldLevel = m_BattleModeCard.level;
    }

    /// <summary>
    /// �t�B�[���h��ł̃p���[�̌v�Z
    /// </summary>
    public void PowerUpdate()
    {
        if(m_BattleModeCard == null)
        {
            FieldPower = 0;
            Power.SetActive(false);
            return;
        }

        FieldPower = m_BattleModeCard.power;
        FieldPower += m_PowerUpUntilTurnEnd.GetUpPower();

        // �K�E���̌��ʂ������Ă��邩�`�F�b�N
        FieldPower += m_MyMainCardsManager.GetGaulPower(PlaceNum, m_Gaul.GetAttributeList());

        if (PlaceNum == 0)
        {
            // �����̌��ʂ��󂯂��邩�`�F�b�N
            FieldPower += m_MyMainCardsManager.GetAssistPower(3);
            // ���x���������󂯂��邩�`�F�b�N
            FieldPower += m_MyMainCardsManager.GetLevelAssistPower(3, FieldLevel);
        }
        else if (PlaceNum == 1)
        {
            // �����̌��ʂ��󂯂��邩�`�F�b�N
            FieldPower += m_MyMainCardsManager.GetAssistPower(3);
            FieldPower += m_MyMainCardsManager.GetAssistPower(4);
            // ���x���������󂯂��邩�`�F�b�N
            FieldPower += m_MyMainCardsManager.GetLevelAssistPower(3, FieldLevel);
            FieldPower += m_MyMainCardsManager.GetLevelAssistPower(4, FieldLevel);
        }
        else if (PlaceNum == 2)
        {
            // �����̌��ʂ��󂯂��邩�`�F�b�N
            FieldPower += m_MyMainCardsManager.GetAssistPower(4);
            // ���x���������󂯂��邩�`�F�b�N
            FieldPower += m_MyMainCardsManager.GetLevelAssistPower(4, FieldLevel);
        }

        // "�����L�h���X���̌���
        if (m_BattleModeCard.cardNo == EnumController.CardNo.LB_W02_09T)
        {
            List<EnumController.CardNo> cardNoList = new List<EnumController.CardNo>();
            cardNoList.Add(EnumController.CardNo.LB_W02_07T);
            FieldPower += 1000 * m_MyMainCardsManager.GetNumFieldCardNo(cardNoList);
        }

        // HM - A06�^ �~�i�c�̌���
        // ���́s�o�i�i�t�̂��Ȃ��̃L����������Ȃ�A���̃J�[�h�̃p���[���{1500�B
        if (m_BattleModeCard.cardNo == EnumController.CardNo.DC_W01_13T)
        {
            List<EnumController.Attribute> attributeList = new List<EnumController.Attribute>();
            attributeList.Add(EnumController.Attribute.Banana);
            if (m_MyMainCardsManager.GetNumFieldAttribute(PlaceNum, attributeList) >= 1)
            {
                FieldPower += 1500;
            }
        }

        // �䂸���T�̌���
        // ���́s���y�t�̂��Ȃ��̃L������2���ȏア��Ȃ�A���̃J�[�h�̃p���[���{1000�B
        if (m_BattleModeCard.cardNo == EnumController.CardNo.DC_W01_16T)
        {
            List<EnumController.Attribute> attributeList = new List<EnumController.Attribute>();
            attributeList.Add(EnumController.Attribute.Music);
            if (m_MyMainCardsManager.GetNumFieldAttribute(PlaceNum, attributeList) >= 2)
            {
                FieldPower += 1000;
            }
        }

        // ���� ��̌���
        // �y�i�z ���̂��Ȃ��̃J�[�h���Ɂu���t�v���܂ރL�������ׂĂɁA�p���[���{500�B
        if (m_BattleModeCard.cardNo == EnumController.CardNo.DC_W01_10T)
        {
            List<EnumController.CardNo> cardNoList = new List<EnumController.CardNo>();
            cardNoList.Add(EnumController.CardNo.DC_W01_09T);
            FieldPower += 500 * m_MyMainCardsManager.GetNumFieldCardNo(cardNoList);
        }

        // ���q�̌���
        //�y�i�z ���Ȃ��̃^�[�����A���̂��Ȃ��̃L�������ׂĂɁA�p���[���{500�B
        if (m_GameManager.isTurnPlayer)
        {
            List<EnumController.CardNo> cardNoList = new List<EnumController.CardNo>();
            cardNoList.Add(EnumController.CardNo.P3_S01_09T);
            cardNoList.Add(EnumController.CardNo.P3_S01_015);
            FieldPower += 500 * m_MyMainCardsManager.GetNumFieldCardNo(cardNoList);
            if (m_BattleModeCard.cardNo == EnumController.CardNo.P3_S01_09T || m_BattleModeCard.cardNo == EnumController.CardNo.P3_S01_015)
            {
                // ���̃L�����N�^�[�Ƀp���[���{���邽�߁BGetNumFieldCardNo�͂��ׂẴL�����N�^�[���Q�Ƃ��Ă��܂�
                FieldPower = FieldPower - 500;
            }
        }
        // ���߁��y���e�V���A�̌���
        // �y�i�z ����̃^�[�����A���̃J�[�h�̃p���[���{1000�B
        if (!m_GameManager.isTurnPlayer && m_BattleModeCard.cardNo == EnumController.CardNo.P3_S01_15T)
        {
            FieldPower += 1000;
        }

        if (m_GameManager.MyClimaxCard != null)
        {
            // 1000/1�̃N���C�}�b�N�X���g�p����Ă��邩�`�F�b�N
            if (m_ClimaxUtil.GetClimaxType(m_GameManager.MyClimaxCard.cardNo) == EnumController.ClimaxType.POWER_THOUSAND_AND_SOUL_ONE)
            {
                FieldPower += 1000;
            }
        }
        Power.SetActive(true);
        PowerText.text = FieldPower.ToString();
    }

    /// <summary>
    /// �t�B�[���h��ł̃\�E���v�Z
    /// </summary>
    public void SoulUpdate()
    {
        if (m_BattleModeCard == null)
        {
            FieldSoul = 0;
            return;
        }

        FieldSoul = m_BattleModeCard.soul;
        FieldSoul += m_SoulUpUntilTurnEnd.GetUpSoul();

        if (m_GameManager.MyClimaxCard != null)
        {
            // 1000/1�̃N���C�}�b�N�X���g�p����Ă��邩�`�F�b�N
            if (m_ClimaxUtil.GetClimaxType(m_GameManager.MyClimaxCard.cardNo) == EnumController.ClimaxType.POWER_THOUSAND_AND_SOUL_ONE)
            {
                FieldSoul += 1;
            }
            // �\�E���{2���g�p����Ă��邩�`�F�b�N
            else if (m_ClimaxUtil.GetClimaxType(m_GameManager.MyClimaxCard.cardNo) == EnumController.ClimaxType.SOUL_PLUS_TWO)
            {
                FieldSoul += 2;
            }
        }
    }

    public int GetFieldLevel()
    {
        return FieldLevel;
    }

    public int GetFieldPower()
    {
        return FieldPower;
    }

    public int GetFieldSoul()
    {
        return FieldSoul;
    }

    public EnumController.State GetState()
    {
        return state;
    }

    /// <summary>
    /// �t�B�[���h��Ō����Ώۂ̓����������Ă��邩���ׂ�
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    public bool HaveAttribute(List<EnumController.Attribute> list)
    {
        for(int i = 0; i < list.Count; i++)
        {
            for(int r = 0; r < AttributeList.Count; r++)
            {
                if(AttributeList[r] == list[i])
                {
                    return true;
                }
            }
        }

        return false;
    }

    /// <summary>
    /// �t�B�[���h��Ō����Ώۂ̓����������Ă��邩���ׂ�
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    public bool HaveAttribute(EnumController.Attribute attribute)
    {
        for (int r = 0; r < AttributeList.Count; r++)
        {
            if (AttributeList[r] == attribute)
            {
                return true;
            }
        }
        return false;
    }

    private void AttributeListReset()
    {
        AttributeList = new List<EnumController.Attribute>();
        for (int i = 0; i < m_BattleModeCard.attribute.Count; i++)
        {
            if (!HaveAttribute(m_BattleModeCard.attribute[i]))
            {
                AttributeList.Add(m_BattleModeCard.attribute[i]);
            }
        }
    }

    public BattleModeCard getBattleModeCard()
    {
        return m_BattleModeCard;
    }

    /// <summary>
    /// �t�B�[���h����f�b�L�g�b�v�ɒu�����Ƃ��ɌĂ΂��
    /// </summary>
    public void PutDeckTopFromField()
    {
        List<BattleModeCard> tempList = new List<BattleModeCard>();
        tempList.Add(m_BattleModeCard);

        for (int i = 0; i < m_GameManager.myDeckList.Count; i++)
        {
            tempList.Add(m_GameManager.myDeckList[i]);
        }

        m_GameManager.myDeckList = tempList;
        m_GameManager.myFieldList[PlaceNum] = null;
        m_GameManager.Syncronize();

        m_PowerUpUntilTurnEnd = new PowerInstance.PowerUpUntilTurnEnd(0);
        m_SoulUpUntilTurnEnd = new SoulInstance.SoulUpUntilTurnEnd(0);
        setBattleModeCard(null, EnumController.State.STAND);
    }

    /// <summary>
    /// �T�����畑��ɒu�����Ƃ��ɌĂ΂��
    /// </summary>
    public void PutFieldFromGraveYard(BattleModeCard card, EnumController.State state)
    {
        if (m_GameManager.myFieldList[PlaceNum] != null)
        {
            m_GameManager.GraveYardList.Add(m_GameManager.myFieldList[PlaceNum]);
        }
        m_GameManager.GraveYardList.Remove(card);
        m_GameManager.myFieldList[PlaceNum] = card;
        setBattleModeCard(card, state);
        m_GameManager.Syncronize();
    }

    /// <summary>
    /// ��D���畑��ɒu����鎞�ɌĂ΂��
    /// </summary>
    public void PutFieldFromHand(int num, EnumController.State state)
    {
        BattleModeCard card = m_GameManager.myHandList[num];
        if (m_GameManager.myFieldList[PlaceNum] != null)
        {
            m_GameManager.GraveYardList.Add(m_GameManager.myFieldList[PlaceNum]);
        }
        m_GameManager.myFieldList[PlaceNum] = card;
        m_GameManager.myHandList.RemoveAt(num);
        m_PowerUpUntilTurnEnd = new PowerInstance.PowerUpUntilTurnEnd(0);
        m_SoulUpUntilTurnEnd = new SoulInstance.SoulUpUntilTurnEnd(0);
        setBattleModeCard(card, state);
        m_GameManager.Syncronize();

        // �J�[�h�̓o�ꎞ�̌��ʋN��
        m_Effect.BondForHandToFild(m_BattleModeCard);
        m_Effect.WhenPlaceCardEffect(m_BattleModeCard, PlaceNum);

        // �p���[�A���x���A�����A�\�E���̌v�Z
        m_MyMainCardsManager.FieldPowerAndLevelAndAttributeAndSoulReset();

        // ��D�A���R�[���̕t�^
        HandEncore = isHandEncore();

        // �N���b�N�A���R�[���̕t�^
        ClockEncore = isClockEncore();

        // �u�y���z ���̂��Ȃ��̃L�������v���C����ĕ���ɒu���ꂽ���v�ɔ���������ʂ������Ă���J�[�h����ɂȂ����m�F����
        m_MyMainCardsManager.ConfirmEffectWhenMyCardPut(PlaceNum);
    }

    /// <summary>
    /// �t�B�[���h����T���ɒu����鎞�ɌĂ΂��
    /// </summary>
    public void PutGraveYardFromField()
    {
        m_GameManager.myFieldList[PlaceNum] = null;
        m_GameManager.GraveYardList.Add(m_BattleModeCard);
        m_GameManager.Syncronize();

        m_PowerUpUntilTurnEnd = new PowerInstance.PowerUpUntilTurnEnd(0);
        m_SoulUpUntilTurnEnd = new SoulInstance.SoulUpUntilTurnEnd(0);
        setBattleModeCard(null, EnumController.State.STAND);
    }

    /// <summary>
    /// �t�B�[���h�����D�ɖ߂����ɌĂ΂��
    /// </summary>
    public void PutHandFromField()
    {
        m_GameManager.myHandList.Add(m_GameManager.myFieldList[PlaceNum]);
        m_GameManager.myFieldList[PlaceNum] = null;
        m_GameManager.Syncronize();

        m_PowerUpUntilTurnEnd = new PowerInstance.PowerUpUntilTurnEnd(0);
        m_SoulUpUntilTurnEnd = new SoulInstance.SoulUpUntilTurnEnd(0);
        setBattleModeCard(null, EnumController.State.STAND);
    }

    /// <summary>
    /// �t�B�[���h����v���o�ɒu����鎞�ɌĂ΂��
    /// </summary>
    public void PutMemoryFromField()
    {
        m_GameManager.myMemoryList.Add(m_GameManager.myFieldList[PlaceNum]);
        m_GameManager.myFieldList[PlaceNum] = null;
        m_GameManager.Syncronize();

        m_PowerUpUntilTurnEnd = new PowerInstance.PowerUpUntilTurnEnd(0);
        m_SoulUpUntilTurnEnd = new SoulInstance.SoulUpUntilTurnEnd(0);
        setBattleModeCard(null, EnumController.State.STAND);
    }

    /// <summary>
    /// ��D�A���R�[���������Ă���J�[�h�����ׂ�
    /// </summary>
    /// <returns></returns>
    private bool isHandEncore()
    {
        switch (m_BattleModeCard.cardNo)
        {
            case EnumController.CardNo.AT_WX02_A04:
            case EnumController.CardNo.LB_W02_03T:
            case EnumController.CardNo.P3_S01_07T:
            case EnumController.CardNo.P3_S01_15T:
            case EnumController.CardNo.P3_S01_012:
                return true;
            default:
                return false;
        }
    }

    /// <summary>
    /// �N���b�N�A���R�[���������Ă��邩���ׂ�
    /// </summary>
    /// <returns></returns>
    private bool isClockEncore()
    {
        switch (m_BattleModeCard.cardNo)
        {
            default:
                return false;
        }
    }
}
