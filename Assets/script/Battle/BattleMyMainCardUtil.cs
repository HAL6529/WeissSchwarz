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

    private bool isRest = false;
    private bool isReverse = false;
    private bool isMoveButton = false;

    public Effect m_Effect;

    // Start is called before the first frame update
    void Start()
    {
        changeSprite();
        m_Effect = new Effect(m_GameManager, m_BattleStrix);
    }

    public void setBattleModeCard(BattleModeCard card)
    {
        m_BattleModeCard = card;
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
        PowerText.text = m_BattleModeCard.power.ToString();
    }

    public void onClick()
    {
        if(m_BattleModeCard == null)
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

        if(m_GameManager.phase == EnumController.Turn.Main && m_GameManager.isTurnPlayer)
        {
            if (isMoveButton)
            {
                isMoveButton = false;
            }
            else
            {
                MoveButton.SetActive(true);
                ActButton.SetActive(true);
                isMoveButton = true;
            }
        }
        else if(m_GameManager.phase == EnumController.Turn.Attack && m_GameManager.isTurnPlayer)
        {
            if(PlaceNum > 2 || m_BattleModeCard == null || isRest || isReverse)
            {
                return;
            }

            if(PlaceNum == 0 && m_GameManager.enemyFieldList[2] == null ||
               PlaceNum == 1 && m_GameManager.enemyFieldList[1] == null ||
               PlaceNum == 2 && m_GameManager.enemyFieldList[0] == null )
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
        isRest = false;
        isReverse = false;
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
        this.gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
        DirectAttackButton.SetActive(false);
        isRest = true;
        m_BattleStrix.RpcToAll("CallEnemyRest", PlaceNum, m_GameManager.isTurnPlayer);
        m_BattleStrix.CallPlayEnemyTriggerAnimation(m_GameManager.myDeckList[0], m_GameManager.isTurnPlayer);
        m_TriggerCardAnimation.Play(EnumController.Attack.DIRECT_ATTACK, PlaceNum);
    }

    public void onFrontAttack()
    {
        this.gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
        NotShowFrontAndSideButton();
        isRest = true;
        m_BattleStrix.RpcToAll("CallEnemyRest", PlaceNum, m_GameManager.isTurnPlayer);
        m_BattleStrix.CallPlayEnemyTriggerAnimation(m_GameManager.myDeckList[0], m_GameManager.isTurnPlayer);
        m_TriggerCardAnimation.Play(EnumController.Attack.FRONT_ATTACK, PlaceNum);
    }

    public void onSideAttack()
    {
        this.gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
        NotShowFrontAndSideButton();
        isRest = true;
        m_BattleStrix.RpcToAll("CallEnemyRest", PlaceNum, m_GameManager.isTurnPlayer);
        m_BattleStrix.CallPlayEnemyTriggerAnimation(m_GameManager.myDeckList[0], m_GameManager.isTurnPlayer);
        m_TriggerCardAnimation.Play(EnumController.Attack.SIDE_ATTACK, PlaceNum);
    }

    public void onReverse()
    {
        isRest = false;
        isReverse = true;
        this.gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);
    }

    public bool GetIsReverse()
    {
        return isReverse;
    }

    public void onRest()
    {
        isRest = true;
        isReverse = false;
    }

    public void onActButton()
    {
        NotShowMoveButton();
        m_Effect.CheckEffectForAct(m_BattleModeCard, PlaceNum);
    }
}
