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
    /// フィールド上でのパワー
    /// </summary>
    public int FieldPower = 0;

    /// <summary>
    /// フィールド上でのソウル
    /// </summary>
    public int FieldSoul = 0;

    /// <summary>
    /// フィールド上でのレベル
    /// </summary>
    public int FieldLevel = 0;

    /// <summary>
    /// フィールド上で手札アンコールを持っているか
    /// </summary>
    public bool HandEncore = false;
    
    /// <summary>
    /// フィールド上で2ストックアンコールを持っているか
    /// </summary>
    public bool TwoStockEncore = false;

    /// <summary>
    /// フィールド上でクロックアンコールを持っているか
    /// </summary>
    public bool ClockEncore = false;

    /// <summary>
    /// ターン終了時まで追加される特徴クラス
    /// </summary>
    public AttributeInstance.AttributeUpUntilTurnEnd m_AttributeUpUntilTurnEnd = new AttributeInstance.AttributeUpUntilTurnEnd();

    /// <summary>
    /// フィールド上での特徴
    /// </summary>
    public List<EnumController.Attribute> AttributeList = new List<EnumController.Attribute>();

    /// <summary>
    /// フィールド上でのステータス
    /// </summary>
    private EnumController.State state = EnumController.State.STAND;

    /// <summary>
    /// 大活躍をもっているか
    /// </summary>
    public bool isGreatPerformance = false;

    /// <summary>
    /// タカヤの効果を持っているか
    /// 【自】［(1)］ バトルしているこのカードが【リバース】した時、あなたはコストを払ってよい。そうしたら、このカードを手札に戻す。
    /// </summary>
    public bool Takaya = false;

    /// <summary>
    /// 1ターンにつきX回しか使えない効果のカウント
    /// </summary>
    public int ActEffectCount = 0;

    private bool isMoveButton = false;

    public Effect m_Effect;

    /// <summary>
    /// 起動効果を持っているかチェッククラス
    /// </summary>
    private CheckHaveActAvility m_CheckHaveActAvility;

    /// <summary>
    /// 応援クラス
    /// </summary>
    public PowerInstance.Assist m_Assist = new PowerInstance.Assist(0);

    /// <summary>
    /// アンコール ［手札のキャラを1枚控え室に置く］を持つキャラへの応援クラス
    /// </summary>
    public PowerInstance.AssistForHaveEncore m_AssistForHaveEncore = new PowerInstance.AssistForHaveEncore(0);

    /// <summary>
    /// 全体パワーアップクラス
    /// </summary>
    public PowerInstance.AllAssist m_AllAssist = new PowerInstance.AllAssist(0, null);

    /// <summary>
    /// ガウル効果クラス
    /// </summary>
    public PowerInstance.Gaul m_Gaul = new PowerInstance.Gaul();

    /// <summary>
    /// レベル応援クラス
    /// </summary>
    public PowerInstance.LevelAssist m_LevelAssist = new PowerInstance.LevelAssist(0);

    /// <summary>
    /// ターン終了時までアップするレベルクラス
    /// </summary>
    public LevelInstance.LevelUpUntilTurnEnd m_LevelUpUntilTurnEnd = new LevelInstance.LevelUpUntilTurnEnd(0);

    /// <summary>
    /// ターン終了時までアップするパワークラス
    /// </summary>
    public PowerInstance.PowerUpUntilTurnEnd m_PowerUpUntilTurnEnd = new PowerInstance.PowerUpUntilTurnEnd(0);

    /// <summary>
    /// ターン終了時までアップするソウルクラス
    /// </summary>
    public SoulInstance.SoulUpUntilTurnEnd m_SoulUpUntilTurnEnd = new SoulInstance.SoulUpUntilTurnEnd(0);

    /// <summary>
    /// クライマックスUtil
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

        //1ターンにつきX回しか使えない。効果のリセット
        ActEffectCount = 0;
        //全体応援のカードなら能力付与
        m_AllAssist = m_Effect.CheckEffectForAllAssist(m_BattleModeCard);
        // 応援のカードなら能力付与
        m_Assist = m_Effect.CheckEffectForAssist(m_BattleModeCard);
        // アンコール ［手札のキャラを1枚控え室に置く］を持つキャラへの応援効果を持つカードなら能力付与
        m_AssistForHaveEncore = m_Effect.CheckEffectForAssistForHaveEncore(m_BattleModeCard);
        // ガウルのカードなら能力付与
        m_Gaul = m_Effect.CheckEffectForGaul(m_BattleModeCard);
        // レベル応援のカードなら能力付与
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
        m_MyHandCardsManager.OffShowMemoryButton();
        m_MyMainCardsManager.CallNotShowMoveButton();
        m_MyMainCardsManager.CallNotShowDirectAttackButton();
        m_MyMainCardsManager.CallNotShowFrontAndSideButton();
        m_MyMainCardsManager.CallOffShowGraveYardButton();

        // ---ここからカードのガイド用---
        BattleModeCard t_BattleModeCard = new BattleModeCard();
        t_BattleModeCard.power = FieldPower;
        t_BattleModeCard.soul = FieldSoul;
        t_BattleModeCard.level = FieldLevel;
        t_BattleModeCard.attribute = AttributeList;

        m_BattleModeGuide.showImage(m_BattleModeCard, t_BattleModeCard);
        // ---ここまでカードのガイド用---

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
            // 先攻は1キャラしかアタックできない
            if (m_GameManager.isFirstAttacked && m_GameManager.turn == 1)
            {
                return;
            }

            if (PlaceNum > 2 || m_BattleModeCard == null || state != EnumController.State.STAND)
            {
                return;
            }

            // 中央の枠に大活躍のキャラがいないかチェック
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
        // 先攻は1キャラしかアタックできなくするためにフラグを変更
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
        if (m_EnemyMainCardsManager.GetIsGreatProcessList(1) && m_EnemyMainCardsManager.GetState(1) == EnumController.State.STAND)
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
    /// 「あなたが【起】を使った時、」の効果
    /// </summary>
    public void WhenAct()
    {
        m_Effect.WhenAct(m_BattleModeCard, PlaceNum);
    }

    /// <summary>
    /// 「【自】 あなたがレベルアップした時」の効果
    /// </summary>
    public void WhenLevelUp()
    {
        m_Effect.WhenLevelUp(m_BattleModeCard);
    }

    /// <summary>
    /// 相手をリバースしたときの効果
    /// </summary>
    public void WhenReverseEnemyCard(int reversedCardPlace, int reversedCardLevel)
    {
        m_Effect.WhenReverseEnemyCardEffect(m_BattleModeCard, reversedCardPlace, reversedCardLevel);
    }

    /// <summary>
    /// リバースしたときにカードの向きとステータスを変更
    /// </summary>
    public void onReverse()
    {
        state = EnumController.State.REVERSE;
        this.gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);
        m_MyMainCardsManager.ConfirmEffectWhenMyCardReversed(PlaceNum);
        BattleMyMainCardAvility m_BattleMyMainCardAvility = new BattleMyMainCardAvility(
            m_BattleModeCard, PlaceNum, FieldPower, FieldSoul,
            FieldLevel, HandEncore, TwoStockEncore, ClockEncore, m_AttributeUpUntilTurnEnd,
            AttributeList, state, isGreatPerformance, Takaya, m_Assist, m_AssistForHaveEncore,
            m_AllAssist, m_Gaul, m_LevelAssist, m_LevelUpUntilTurnEnd, m_PowerUpUntilTurnEnd, m_SoulUpUntilTurnEnd);
        m_Effect.WhenReverseMyCardEffect(m_BattleMyMainCardAvility);
    }

    /// <summary>
    /// 「【自】 他のあなたのキャラがプレイされて舞台に置かれた時」に発動する効果を持っているカードが場にないか確認する
    /// <param name="placeNum">プレイされたカードの位置</param>
    /// </summary>
    public void EffectWhenMyOtherCardPut(int placeNum, int effectCardPlaceNum)
    {
        m_Effect.EffectWhenMyOtherCardPut(m_BattleModeCard, placeNum, effectCardPlaceNum);
    }

    /// <summary>
    /// 「【自】 他のバトルしているあなたのキャラが【リバース】した時」の効果を持っていないか確認する
    /// </summary>
    public void EffectWhenMyOtherCardReversed()
    {
        EnumController.State m_state = state;
        BattleMyMainCardAvility m_BattleMyMainCardAvility = new BattleMyMainCardAvility(
            m_BattleModeCard, PlaceNum, FieldPower, FieldSoul,
            FieldLevel, HandEncore, TwoStockEncore, ClockEncore, m_AttributeUpUntilTurnEnd,
            AttributeList, m_state, isGreatPerformance, Takaya, m_Assist, m_AssistForHaveEncore,
            m_AllAssist, m_Gaul, m_LevelAssist, m_LevelUpUntilTurnEnd, m_PowerUpUntilTurnEnd, m_SoulUpUntilTurnEnd);
        m_Effect.EffectWhenMyOtherCardReversed(m_BattleMyMainCardAvility);
    }

    /// <summary>
    /// レスト状態になったときにカードの向きとステータスを変更
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

    public void ResetLevelUpUntilTurnEnd()
    {
        m_LevelUpUntilTurnEnd = new LevelInstance.LevelUpUntilTurnEnd(0);
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
    /// フィールド上の特徴の計算
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
            }
        }
    }

    /// <summary>
    /// フィールド上のレベルの計算
    /// </summary>
    public void LevelUpdate()
    {
        if (m_BattleModeCard == null)
        {
            FieldLevel = 0;
            return;
        }

        FieldLevel = m_BattleModeCard.level;
        FieldLevel += m_LevelUpUntilTurnEnd.GetUpLevel();
    }

    /// <summary>
    /// フィールド上でのパワーの計算
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

        // ガウルの効果を持っているかチェック
        FieldPower += m_MyMainCardsManager.GetGaulPower(PlaceNum, m_Gaul.GetAttributeList());

        if (PlaceNum == 0)
        {
            // 応援の効果を受けられるかチェック
            FieldPower += m_MyMainCardsManager.GetAssistPower(3);
            // レベル応援を受けられるかチェック
            FieldPower += m_MyMainCardsManager.GetLevelAssistPower(3, FieldLevel);
        }
        else if (PlaceNum == 1)
        {
            // 応援の効果を受けられるかチェック
            FieldPower += m_MyMainCardsManager.GetAssistPower(3);
            FieldPower += m_MyMainCardsManager.GetAssistPower(4);
            // レベル応援を受けられるかチェック
            FieldPower += m_MyMainCardsManager.GetLevelAssistPower(3, FieldLevel);
            FieldPower += m_MyMainCardsManager.GetLevelAssistPower(4, FieldLevel);
        }
        else if (PlaceNum == 2)
        {
            // 応援の効果を受けられるかチェック
            FieldPower += m_MyMainCardsManager.GetAssistPower(4);
            // レベル応援を受けられるかチェック
            FieldPower += m_MyMainCardsManager.GetLevelAssistPower(4, FieldLevel);
        }

        for(int i = 0; i < m_MyMainCardsManager.CardList.Count; i++)
        {
            if(i == PlaceNum)
            {
                continue;
            }
            //全体応援の効果を受けられるかチェック
            FieldPower += m_MyMainCardsManager.GetAllAssist(i, AttributeList);
        }

        if(HandEncore && PlaceNum == 0)
        {
            // アンコール ［手札のキャラを1枚控え室に置く］を持つキャラへの応援の効果を受けられるかチェック
            FieldPower += m_MyMainCardsManager.GetAssistForHaveEncorePower(3);
        }
        else if(HandEncore && PlaceNum == 1)
        {
            // アンコール ［手札のキャラを1枚控え室に置く］を持つキャラへの応援の効果を受けられるかチェック
            FieldPower += m_MyMainCardsManager.GetAssistForHaveEncorePower(3);
            FieldPower += m_MyMainCardsManager.GetAssistForHaveEncorePower(4);
        }
        else if (HandEncore && PlaceNum == 2)
        {
            // アンコール ［手札のキャラを1枚控え室に置く］を持つキャラへの応援の効果を受けられるかチェック
            FieldPower += m_MyMainCardsManager.GetAssistForHaveEncorePower(4);
        }

        // "女王猫”佐々美の効果
        if (m_BattleModeCard.cardNo == EnumController.CardNo.LB_W02_09T)
        {
            List<EnumController.CardNo> cardNoList = new List<EnumController.CardNo>();
            cardNoList.Add(EnumController.CardNo.LB_W02_07T);
            FieldPower += 1000 * m_MyMainCardsManager.GetNumFieldCardNo(cardNoList);
        }

        // HM - A06型 ミナツの効果
        // 他の《バナナ》のあなたのキャラがいるなら、このカードのパワーを＋1500。
        if (m_BattleModeCard.cardNo == EnumController.CardNo.DC_W01_13T)
        {
            List<EnumController.Attribute> attributeList = new List<EnumController.Attribute>();
            attributeList.Add(EnumController.Attribute.Banana);
            if (m_MyMainCardsManager.GetNumFieldAttribute(PlaceNum, attributeList) >= 1)
            {
                FieldPower += 1500;
            }
        }

        // ゆず＆慎の効果
        // 他の《音楽》のあなたのキャラが2枚以上いるなら、このカードのパワーを＋1000。
        if (m_BattleModeCard.cardNo == EnumController.CardNo.DC_W01_16T)
        {
            List<EnumController.Attribute> attributeList = new List<EnumController.Attribute>();
            attributeList.Add(EnumController.Attribute.Music);
            if (m_MyMainCardsManager.GetNumFieldAttribute(PlaceNum, attributeList) >= 2)
            {
                FieldPower += 1000;
            }
        }

        // 白河 暦の効果
        // 【永】 他のあなたのカード名に「美春」を含むキャラすべてに、パワーを＋500。
        if (m_BattleModeCard.cardNo == EnumController.CardNo.DC_W01_10T)
        {
            List<EnumController.CardNo> cardNoList = new List<EnumController.CardNo>();
            cardNoList.Add(EnumController.CardNo.DC_W01_09T);
            FieldPower += 500 * m_MyMainCardsManager.GetNumFieldCardNo(cardNoList);
        }

        // 舞子の効果
        // “気高き子猫”鈴の効果
        //【永】 あなたのターン中、他のあなたのキャラすべてに、パワーを＋500。
        if (m_GameManager.isTurnPlayer)
        {
            List<EnumController.CardNo> cardNoList = new List<EnumController.CardNo>();
            cardNoList.Add(EnumController.CardNo.P3_S01_09T);
            cardNoList.Add(EnumController.CardNo.P3_S01_015);
            cardNoList.Add(EnumController.CardNo.LB_W02_003);
            FieldPower += 500 * m_MyMainCardsManager.GetNumFieldCardNo(cardNoList);
            if (cardNoList.Contains(m_BattleModeCard.cardNo))
            {
                // 他のキャラクターにパワーを＋するため。GetNumFieldCardNoはすべてのキャラクターを参照してしまう
                FieldPower = FieldPower - 500;
            }
        }
        // 美鶴＆ペンテシレアの効果
        // 【永】 相手のターン中、このカードのパワーを＋1000。
        if (!m_GameManager.isTurnPlayer && (m_BattleModeCard.cardNo == EnumController.CardNo.P3_S01_15T || m_BattleModeCard.cardNo == EnumController.CardNo.P3_S01_078))
        {
            FieldPower += 1000;
        }

        // アイギス＆パラディオンの効果
        //【永】 他の《メカ》のあなたのキャラが2枚以上いるなら、このカードのパワーを＋1000。
        if (m_BattleModeCard.cardNo == EnumController.CardNo.P3_S01_027)
        {
            List<EnumController.Attribute> attributeList = new List<EnumController.Attribute>();
            attributeList.Add(EnumController.Attribute.Mecha);
            if (m_MyMainCardsManager.GetNumFieldAttribute(PlaceNum, attributeList) >= 2)
            {
                FieldPower += 1000;
            }
        }

        // アイギスの効果
        // 【永】 あなたのレベル置場のカード1枚につき、このカードのパワーを＋1000。
        if (m_BattleModeCard.cardNo == EnumController.CardNo.P3_S01_029)
        {
            FieldPower += m_GameManager.myLevelList.Count * 1000;
        }

        // 風花＆ユノの効果
        // 【永】 アラーム このカードがクロックの１番上にあるなら、緑のあなたのキャラすべてに、パワーを＋1000。
        if(m_GameManager.myClockList.Count > 0 && m_BattleModeCard.color == EnumController.CardColor.GREEN && m_GameManager.myClockList[m_GameManager.myClockList.Count - 1].cardNo == EnumController.CardNo.P3_S01_030)
        {
            FieldPower += 1000;
        }

        if (m_GameManager.MyClimaxCard != null)
        {
            // 1000/1のクライマックスが使用されているかチェック
            if (m_ClimaxUtil.GetClimaxType(m_GameManager.MyClimaxCard.cardNo) == EnumController.ClimaxType.POWER_THOUSAND_AND_SOUL_ONE)
            {
                FieldPower += 1000;
            }
        }

        // 順平&ヘルメスの効果
        // 【永】 他のあなたの「チドリ」がいるなら、このカードのパワーを＋1000。
        if (m_BattleModeCard.cardNo == EnumController.CardNo.P3_S01_059 && m_MyMainCardsManager.isFieldName("チドリ"))
        {
            FieldPower += 1000;
        }

        // メティスの効果
        //【永】 他のあなたのカード名に「アイギス」を含むキャラがいるなら、このカードのパワーを＋1500。
        if (m_BattleModeCard.cardNo == EnumController.CardNo.P3_S01_034 && m_MyMainCardsManager.isContainFieldName("アイギス"))
        {
            FieldPower += 1500;
        }

        Power.SetActive(true);
        PowerText.text = FieldPower.ToString();
    }

    /// <summary>
    /// フィールド上でのソウル計算
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

        // 望月 綾時の効果
        //【永】 アラーム このカードがクロックの１番上にあり、あなたのレベルが1以下なら、黄のあなたのキャラすべてに、ソウルを＋1。
        if (m_GameManager.myClockList.Count > 0 
            && m_BattleModeCard.color == EnumController.CardColor.YELLOW 
            && m_GameManager.myClockList[m_GameManager.myClockList.Count - 1].cardNo == EnumController.CardNo.P3_S01_004
            && m_GameManager.myLevelList.Count < 2)
        {
            FieldSoul += 1;
        }

        if (m_GameManager.MyClimaxCard != null)
        {
            // 1000/1のクライマックスが使用されているかチェック
            if (m_ClimaxUtil.GetClimaxType(m_GameManager.MyClimaxCard.cardNo) == EnumController.ClimaxType.POWER_THOUSAND_AND_SOUL_ONE)
            {
                FieldSoul += 1;
            }
            // ソウル＋2が使用されているかチェック
            else if (m_ClimaxUtil.GetClimaxType(m_GameManager.MyClimaxCard.cardNo) == EnumController.ClimaxType.SOUL_PLUS_TWO)
            {
                FieldSoul += 2;
            }
        }
    }

    /// <summary>
    /// タカヤの効果を反映
    /// 【自】［(1)］ バトルしているこのカードが【リバース】した時、あなたはコストを払ってよい。そうしたら、このカードを手札に戻す。
    /// </summary>
    public void TakayaEffectUpdate()
    {
        Takaya = false;
        if(m_BattleModeCard == null || m_GameManager.myClockList.Count == 0)
        {
            return;
        }

        if (m_BattleModeCard.color == EnumController.CardColor.RED && m_GameManager.myClockList[m_GameManager.myClockList.Count - 1].cardNo == EnumController.CardNo.P3_S01_062)
        {
            Takaya = true;
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
    /// フィールド上で検索対象の特徴を持っているか調べる
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
    /// フィールド上で検索対象の特徴を持っているか調べる
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
    /// フィールドからデッキトップに置かれるときに呼ばれる
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
        m_LevelUpUntilTurnEnd = new LevelInstance.LevelUpUntilTurnEnd(0);
        setBattleModeCard(null, EnumController.State.STAND);

        // パワー、レベル、特徴、ソウルの計算
        m_MyMainCardsManager.FieldPowerAndLevelAndAttributeAndSoulReset();
        m_GameManager.Syncronize();
    }

    /// <summary>
    /// 控室から舞台に置かれるときに呼ばれる
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

        // パワー、レベル、特徴、ソウルの計算
        m_MyMainCardsManager.FieldPowerAndLevelAndAttributeAndSoulReset();
        m_GameManager.Syncronize();
    }

    /// <summary>
    /// 手札から舞台に置かれる時に呼ばれる
    /// </summary>
    public void PutFieldFromHand(int num, EnumController.State state)
    {
        BattleModeCard card = m_GameManager.myHandList[num];
        if (m_GameManager.myFieldList[PlaceNum] != null)
        {
            m_MyMainCardsManager.CallPutGraveYardFromField(PlaceNum);
        }
        m_GameManager.myFieldList[PlaceNum] = card;
        m_GameManager.myHandList.RemoveAt(num);
        m_PowerUpUntilTurnEnd = new PowerInstance.PowerUpUntilTurnEnd(0);
        m_SoulUpUntilTurnEnd = new SoulInstance.SoulUpUntilTurnEnd(0);
        m_LevelUpUntilTurnEnd = new LevelInstance.LevelUpUntilTurnEnd(0);
        setBattleModeCard(card, state);
        m_GameManager.Syncronize();

        // カードの登場時の効果起動
        m_Effect.BondForHandToFild(m_BattleModeCard);
        m_Effect.WhenPlaceCardEffect(m_BattleModeCard, PlaceNum);

        // パワー、レベル、特徴、ソウルの計算
        m_MyMainCardsManager.FieldPowerAndLevelAndAttributeAndSoulReset();

        // 手札アンコールの付与
        HandEncore = isHandEncore();

        // クロックアンコールの付与
        ClockEncore = isClockEncore();

        // 「【自】 他のあなたのキャラがプレイされて舞台に置かれた時」に発動する効果を持っているカードが場にないか確認する
        m_MyMainCardsManager.ConfirmEffectWhenMyCardPut(PlaceNum);
        m_GameManager.Syncronize();
    }

    /// <summary>
    /// 「あなたは自分の手札の「XXXXXXXX」を１枚選び、このカードがいた枠に置く。」の効果
    /// </summary>
    public void PutFieldFromHandForEffect(int num, EnumController.State state)
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
        m_LevelUpUntilTurnEnd = new LevelInstance.LevelUpUntilTurnEnd(0);
        setBattleModeCard(card, state);
        m_GameManager.Syncronize();

        // パワー、レベル、特徴、ソウルの計算
        m_MyMainCardsManager.FieldPowerAndLevelAndAttributeAndSoulReset();

        // 手札アンコールの付与
        HandEncore = isHandEncore();

        // クロックアンコールの付与
        ClockEncore = isClockEncore();
        m_GameManager.Syncronize();
    }

    /// <summary>
    /// フィールドから控室に置かれる時に呼ばれる
    /// </summary>
    public void PutGraveYardFromField()
    {
        BattleMyMainCardAvility m_BattleMyMainCardAvility = new BattleMyMainCardAvility(
            m_BattleModeCard, PlaceNum, FieldPower, FieldSoul,
            FieldLevel, HandEncore, TwoStockEncore, ClockEncore, m_AttributeUpUntilTurnEnd,
            AttributeList, state, isGreatPerformance, Takaya, m_Assist, m_AssistForHaveEncore,
            m_AllAssist, m_Gaul, m_LevelAssist, m_LevelUpUntilTurnEnd, m_PowerUpUntilTurnEnd, m_SoulUpUntilTurnEnd);
        m_Effect.PutGraveYardFromField(m_BattleMyMainCardAvility);

        m_GameManager.myFieldList[PlaceNum] = null;
        m_GameManager.GraveYardList.Add(m_BattleModeCard);
        m_GameManager.Syncronize();

        m_PowerUpUntilTurnEnd = new PowerInstance.PowerUpUntilTurnEnd(0);
        m_SoulUpUntilTurnEnd = new SoulInstance.SoulUpUntilTurnEnd(0);
        m_LevelUpUntilTurnEnd = new LevelInstance.LevelUpUntilTurnEnd(0);
        setBattleModeCard(null, EnumController.State.STAND);

        // パワー、レベル、特徴、ソウルの計算
        m_MyMainCardsManager.FieldPowerAndLevelAndAttributeAndSoulReset();
        m_GameManager.Syncronize();
    }

    /// <summary>
    /// フィールドから手札に戻す時に呼ばれる
    /// </summary>
    public void PutHandFromField()
    {
        m_GameManager.myHandList.Add(m_GameManager.myFieldList[PlaceNum]);
        m_GameManager.myFieldList[PlaceNum] = null;
        m_GameManager.Syncronize();

        m_PowerUpUntilTurnEnd = new PowerInstance.PowerUpUntilTurnEnd(0);
        m_SoulUpUntilTurnEnd = new SoulInstance.SoulUpUntilTurnEnd(0);
        m_LevelUpUntilTurnEnd = new LevelInstance.LevelUpUntilTurnEnd(0);
        setBattleModeCard(null, EnumController.State.STAND);

        // パワー、レベル、特徴、ソウルの計算
        m_MyMainCardsManager.FieldPowerAndLevelAndAttributeAndSoulReset();
        m_GameManager.Syncronize();
    }

    /// <summary>
    /// フィールドから思い出に置かれる時に呼ばれる
    /// </summary>
    public void PutMemoryFromField()
    {
        m_GameManager.myMemoryList.Add(m_GameManager.myFieldList[PlaceNum]);
        m_GameManager.myFieldList[PlaceNum] = null;
        m_GameManager.Syncronize();

        m_PowerUpUntilTurnEnd = new PowerInstance.PowerUpUntilTurnEnd(0);
        m_SoulUpUntilTurnEnd = new SoulInstance.SoulUpUntilTurnEnd(0);
        m_LevelUpUntilTurnEnd = new LevelInstance.LevelUpUntilTurnEnd(0);
        setBattleModeCard(null, EnumController.State.STAND);

        // パワー、レベル、特徴、ソウルの計算
        m_MyMainCardsManager.FieldPowerAndLevelAndAttributeAndSoulReset();
        m_GameManager.Syncronize();
    }

    /// <summary>
    /// 特定の文字列を含むか調べる
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    public bool isContainFieldName(string t)
    {
        if(m_BattleModeCard == null)
        {
            return false;
        }
        return m_BattleModeCard.name.Contains(t);
    }

    /// <summary>
    /// フィールドのキャラがそのカード名か調べる
    /// </summary>
    /// <returns></returns>
    public bool isFieldName(string t)
    {
        if (m_BattleModeCard == null)
        {
            return false;
        }

        if (m_BattleModeCard.name == t)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// 手札アンコールを持っているカードか調べる
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
            case EnumController.CardNo.P3_S01_002:
            case EnumController.CardNo.P3_S01_012:
            case EnumController.CardNo.P3_S01_027:
            case EnumController.CardNo.P3_S01_029:
            case EnumController.CardNo.P3_S01_056:
            case EnumController.CardNo.P3_S01_059:
            case EnumController.CardNo.P3_S01_078:
            case EnumController.CardNo.P3_S01_084:
            case EnumController.CardNo.LB_W02_004:
                return true;
            default:
                return false;
        }
    }

    /// <summary>
    /// クロックアンコールを持っているか調べる
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
