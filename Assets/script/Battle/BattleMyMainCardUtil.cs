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
    /// フィールド上での特徴
    /// </summary>
    public List<EnumController.Attribute> AttributeList = new List<EnumController.Attribute>();

    private bool isMoveButton = false;

    private EnumController.State state = EnumController.State.STAND;

    public Effect m_Effect;

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

    public void setBattleModeCard(BattleModeCard card)
    {
        onReset();
        m_BattleModeCard = card;

        AttributeList = new List<EnumController.Attribute>();
        if (card != null && card.attributeOne != null)
        {
            AttributeList.Add(card.attributeOne);
        }
        if (card != null && card.attributeTwo != null)
        {
            AttributeList.Add(card.attributeTwo);
        }
        if (card != null && card.attributeThree != null)
        {
            AttributeList.Add(card.attributeThree);
        }

        // 応援のカードなら能力付与
        m_Assist = m_Effect.CheckEffectForAssist(m_BattleModeCard);
        // ガウルのカードなら能力付与
        m_Gaul = m_Effect.CheckEffectForGaul(m_BattleModeCard);
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

        if (m_GameManager.isLevelUpProcess)
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
                MoveButton.SetActive(true);
                int minCost = m_CheckHaveActAvility.Check(m_BattleModeCard.cardNo);
                if (minCost > -1 && m_GameManager.myStockList.Count >= minCost)
                {
                    ActButton.SetActive(true);
                }
                isMoveButton = true;
            }
        }
        else if (m_GameManager.phase == EnumController.Turn.Attack && m_GameManager.isTurnPlayer)
        {
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
        isMoveButton = false;
    }

    public void onMoveButton()
    {
        m_DialogManager.MoveDialog(PlaceNum, m_BattleModeCard);
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
        onRest();
        m_BattleStrix.RpcToAll("CallEnemyRest", PlaceNum, m_GameManager.isTurnPlayer);
        m_BattleStrix.CallPlayEnemyTriggerAnimation(m_GameManager.myDeckList[0], m_GameManager.isTurnPlayer);
        m_TriggerCardAnimation.Play(EnumController.Attack.DIRECT_ATTACK, PlaceNum);
    }

    public void onFrontAttack()
    {
        onRest();
        m_BattleStrix.RpcToAll("CallEnemyRest", PlaceNum, m_GameManager.isTurnPlayer);
        m_BattleStrix.CallPlayEnemyTriggerAnimation(m_GameManager.myDeckList[0], m_GameManager.isTurnPlayer);
        m_TriggerCardAnimation.Play(EnumController.Attack.FRONT_ATTACK, PlaceNum);
    }

    public void onSideAttack()
    {
        onRest();
        m_BattleStrix.RpcToAll("CallEnemyRest", PlaceNum, m_GameManager.isTurnPlayer);
        m_BattleStrix.CallPlayEnemyTriggerAnimation(m_GameManager.myDeckList[0], m_GameManager.isTurnPlayer);
        m_TriggerCardAnimation.Play(EnumController.Attack.SIDE_ATTACK, PlaceNum);
    }

    public void onReverse()
    {
        state = EnumController.State.REVERSE;
        this.gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);
    }

    public void onRest()
    {
        state = EnumController.State.REST;
        this.gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
        NotShowFrontAndSideButton();
        NotShowDirectAttackButton();
    }

    public void onActButton()
    {
        NotShowMoveButton();
        m_Effect.CheckEffectForAct(m_BattleModeCard, PlaceNum);
    }

    public void onReset()
    {
        Stand();
        m_BattleModeCard = null;
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

        // ガウルの効果を持っているかチェック
        FieldPower += m_MyMainCardsManager.GetGaulPower(PlaceNum, m_Gaul.GetAttributeList());

        if (PlaceNum == 0)
        {
            // 応援の効果を受けられるかチェック
            FieldPower += m_MyMainCardsManager.GetAssistPower(3);
        }
        else if (PlaceNum == 1)
        {
            // 応援の効果を受けられるかチェック
            FieldPower += m_MyMainCardsManager.GetAssistPower(3);
            FieldPower += m_MyMainCardsManager.GetAssistPower(4);
        }
        else if (PlaceNum == 2)
        {
            // 応援の効果を受けられるかチェック
            FieldPower += m_MyMainCardsManager.GetAssistPower(4);
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

    public int GetFieldPower()
    {
        return FieldPower;
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
