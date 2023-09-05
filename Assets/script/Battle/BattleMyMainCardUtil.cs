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
    [SerializeField] GameObject MoveButton;
    [SerializeField] GameObject FrontAttackButton;
    [SerializeField] GameObject SideAttackButton;
    [SerializeField] GameObject DirectAttackButton;
    [SerializeField] MyHandCardsManager m_MyHandCardsManager;
    [SerializeField] MyMainCardsManager m_MyMainCardsManager;
    [SerializeField] DialogManager m_DialogManager;
    [SerializeField] BattleStrix m_BattleStrix;
    [SerializeField] int PlaceNum;

    private bool isRest = false;
    private bool isMoveButton = false;
    // Start is called before the first frame update
    void Start()
    {
        changeSprite();
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
            return;
        }
        image.sprite = m_BattleModeCard.sprite;
        image.color = new Color(1, 1, 1, 255 / 255);
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

        if(m_GameManager.phase == EnumController.Turn.Main)
        {
            if (isMoveButton)
            {
                isMoveButton = false;
            }
            else
            {
                MoveButton.SetActive(true);
                isMoveButton = true;
            }
        }
        else if(m_GameManager.phase == EnumController.Turn.Attack)
        {
            if(PlaceNum > 2 || m_BattleModeCard == null || isRest)
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
    }

    public void NotShowMoveButton()
    {
        MoveButton.SetActive(false);
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
        m_GameManager.onDirectAttack(PlaceNum);
    }

    public void onFrontAttack()
    {
        this.gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
        NotShowFrontAndSideButton();
        isRest = true;
        m_BattleStrix.RpcToAll("CallEnemyRest", PlaceNum, m_GameManager.isTurnPlayer);
        m_GameManager.onFrontAttack(PlaceNum);
    }

    public void onSideAttack()
    {
        this.gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
        NotShowFrontAndSideButton();
        isRest = true;
        m_BattleStrix.RpcToAll("CallEnemyRest", PlaceNum, m_GameManager.isTurnPlayer);
        m_GameManager.onSideAttack(PlaceNum);
    }
}
