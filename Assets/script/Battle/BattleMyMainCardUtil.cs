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
    /// フィールド上での特徴
    /// </summary>
    public List<EnumController.Attribute> AttributeList = new List<EnumController.Attribute>();

    /// <summary>
    /// フィールド上でのステータス
    /// </summary>
    private EnumController.State state = EnumController.State.STAND;

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
    /// ターン終了時までアップするパワークラス
    /// </summary>
    public PowerInstance.PowerUpUntilTurnEnd m_PowerUpUntilTurnEnd = new PowerInstance.PowerUpUntilTurnEnd(0);

    /// <summary>
    /// クライマックスUtil
    /// </summary>
    private ClimaxUtil m_ClimaxUtil = new ClimaxUtil();

    // Start is called before the first frame update
    void Start()
    {
        changeSprite();
        m_Effect = new Effect(m_GameManager, m_BattleStrix);
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

        m_BattleModeCard = card;

        AttributeList = new List<EnumController.Attribute>();
        if (card != null && card.attributeOne != EnumController.Attribute.NONE && card.attributeOne != EnumController.Attribute.VOID)
        {
            AttributeList.Add(card.attributeOne);
        }
        if (card != null && card.attributeTwo != EnumController.Attribute.NONE && card.attributeTwo != EnumController.Attribute.VOID)
        {
            AttributeList.Add(card.attributeTwo);
        }
        if (card != null && card.attributeThree != EnumController.Attribute.NONE && card.attributeThree != EnumController.Attribute.VOID)
        {
            AttributeList.Add(card.attributeThree);
        }

        // 応援のカードなら能力付与
        m_Assist = m_Effect.CheckEffectForAssist(m_BattleModeCard);
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
        m_MyMainCardsManager.CallNotShowMoveButton();
        m_MyMainCardsManager.CallNotShowDirectAttackButton();
        m_MyMainCardsManager.CallNotShowFrontAndSideButton();
        m_BattleModeGuide.showImage(m_BattleModeCard);
        m_DialogManager.CloseAllDialog();

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

        if (m_Effect.CheckWhenAttack(m_BattleModeCard, PlaceNum, EnumController.Attack.DIRECT_ATTACK))
        {
            return;
        }
        /*//テスト用
        Debug.Log(m_GameManager.myDeckList.Count);
        int c = m_GameManager.myDeckList.Count;
        for (int i = 0; i < c - 1; i++)
        {
            m_GameManager.GraveYardList.Add(m_GameManager.myDeckList[0]);
            m_GameManager.myDeckList.RemoveAt(0);
        }
        m_GameManager.myDeckList[0] = m_GameManager.test;
        m_GameManager.Syncronize();
        */
        m_BattleStrix.RpcToAll("SetIsAttackProcess", true);
        onRest();
        m_BattleStrix.RpcToAll("CallEnemyRest", PlaceNum, m_GameManager.isTurnPlayer);
        m_BattleStrix.CallPlayEnemyTriggerAnimation(m_GameManager.myDeckList[0], m_GameManager.isTurnPlayer);
        m_TriggerCardAnimation.Play(EnumController.Attack.DIRECT_ATTACK, PlaceNum);
    }

    public void onFrontAttack()
    {
        if (m_Effect.CheckWhenAttack(m_BattleModeCard, PlaceNum, EnumController.Attack.FRONT_ATTACK))
        {
            return;
        }
        /*//テスト用
        Debug.Log(m_GameManager.myDeckList.Count);
        int c = m_GameManager.myDeckList.Count;
        for (int i = 0; i < c - 1; i++)
        {
            m_GameManager.GraveYardList.Add(m_GameManager.myDeckList[0]);
            m_GameManager.myDeckList.RemoveAt(0);
        }
        m_GameManager.myDeckList[0] = m_GameManager.test;
        m_GameManager.Syncronize();
        */
        m_BattleStrix.RpcToAll("SetIsAttackProcess", true);
        onRest();
        m_BattleStrix.RpcToAll("CallEnemyRest", PlaceNum, m_GameManager.isTurnPlayer);
        m_BattleStrix.CallPlayEnemyTriggerAnimation(m_GameManager.myDeckList[0], m_GameManager.isTurnPlayer);
        m_TriggerCardAnimation.Play(EnumController.Attack.FRONT_ATTACK, PlaceNum);
    }

    public void onSideAttack()
    {
        if (m_Effect.CheckWhenAttack(m_BattleModeCard, PlaceNum, EnumController.Attack.SIDE_ATTACK))
        {
            return;
        }
        /*//テスト用
        Debug.Log(m_GameManager.myDeckList.Count);
        int c = m_GameManager.myDeckList.Count;
        for (int i = 0; i < c - 1; i++)
        {
            m_GameManager.GraveYardList.Add(m_GameManager.myDeckList[0]);
            m_GameManager.myDeckList.RemoveAt(0);
        }
        m_GameManager.myDeckList[0] = m_GameManager.test;
        m_GameManager.Syncronize();
        */
        m_BattleStrix.RpcToAll("SetIsAttackProcess", true);
        onRest();
        m_BattleStrix.RpcToAll("CallEnemyRest", PlaceNum, m_GameManager.isTurnPlayer);
        m_BattleStrix.CallPlayEnemyTriggerAnimation(m_GameManager.myDeckList[0], m_GameManager.isTurnPlayer);
        m_TriggerCardAnimation.Play(EnumController.Attack.SIDE_ATTACK, PlaceNum);
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
                m_TriggerCardAnimation.Play(EnumController.Attack.DIRECT_ATTACK, PlaceNum);
                break;
            case EnumController.Attack.FRONT_ATTACK:
                m_BattleStrix.RpcToAll("SetIsAttackProcess", true);
                onRest();
                m_BattleStrix.RpcToAll("CallEnemyRest", PlaceNum, m_GameManager.isTurnPlayer);
                m_BattleStrix.CallPlayEnemyTriggerAnimation(m_GameManager.myDeckList[0], m_GameManager.isTurnPlayer);
                m_TriggerCardAnimation.Play(EnumController.Attack.FRONT_ATTACK, PlaceNum);
                break;
            case EnumController.Attack.SIDE_ATTACK:
                m_BattleStrix.RpcToAll("SetIsAttackProcess", true);
                onRest();
                m_BattleStrix.RpcToAll("CallEnemyRest", PlaceNum, m_GameManager.isTurnPlayer);
                m_BattleStrix.CallPlayEnemyTriggerAnimation(m_GameManager.myDeckList[0], m_GameManager.isTurnPlayer);
                m_TriggerCardAnimation.Play(EnumController.Attack.SIDE_ATTACK, PlaceNum);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 相手をリバースしたときの効果
    /// </summary>
    public void WhenReverseEnemyCard()
    {
        m_Effect.WhenReverseEnemyCardEffect(m_BattleModeCard);
    }

    /// <summary>
    /// リバースしたときにカードの向きとステータスを変更
    /// </summary>
    public void onReverse()
    {
        state = EnumController.State.REVERSE;
        this.gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);
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

    public void ResetPowerUpUntilTurnEnd()
    {
        m_PowerUpUntilTurnEnd = new PowerInstance.PowerUpUntilTurnEnd(0);
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

        if(m_GameManager.MyClimaxCard != null)
        {
            // 1000/1のクライマックスが使用されているかチェック
            if (m_ClimaxUtil.GetClimaxType(m_GameManager.MyClimaxCard.cardNo) == EnumController.ClimaxType.POWER_THOUSAND_AND_SOUL_ONE)
            {
                FieldPower += 1000;
            }
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
}
