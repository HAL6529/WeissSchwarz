using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] List<HandCardUtil> handCardUtilList = new List<HandCardUtil>();
    [SerializeField] MyBackCardListUtil m_myBackCardUtil;
    [SerializeField] MyClockCardUtil m_myClockCardUtil;
    [SerializeField] MyClimaxCardUtil m_myClimaxCardUtil;
    [SerializeField] MyDeckListUtil m_myDeckListUtil;
    [SerializeField] MyFrontCardListUtil m_myFrontCardListUtil;
    [SerializeField] MyGraveYardListUtil m_myGraveYardListUtil;
    [SerializeField] MyHandCardUtil m_myHandCardUtil;
    [SerializeField] MyLevelCardUtil m_myLevelCardListUtil;
    [SerializeField] MyMemoryListUtil m_myMemoryListUtil;
    [SerializeField] MyStockCardUtil m_myStockCardUtil;

    [SerializeField] EnemyHandCardUtil enemyHandCardUtil;

    public Player myPlayer;
    public Player enemyPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateUI()
    {
        updateMyBackCardList();
        updateMyClimaxList();
        updateMyclockList();
        updateMyDeckList();
        updateMyFrontCardList();
        updateMyGraveYardList();
        updateMyHandList();
        updateMyLeveleList();
        updateMyMemoryList();
        updateMyStockList();
        updateEnemyHandList();
    }

    public void updateMyBackCardList()
    {
        m_myBackCardUtil.updateMyBackList(myPlayer);
    }

    public void updateMyClimaxList()
    {
        m_myClimaxCardUtil.updateSprite(myPlayer.climaxCard);
    }

    public void updateMyclockList()
    {
        m_myClockCardUtil.updateMyClockList(myPlayer);
    }

    public void updateMyDeckList()
    {
        if (myPlayer.DeckList.Count > 0)
        {
            m_myDeckListUtil.updateSprite(myPlayer.DeckList[0]);
        }
        else
        {
            m_myDeckListUtil.updateSprite(null);
        }
    }

    public void updateMyFrontCardList()
    {
        m_myFrontCardListUtil.updateMyFrontList(myPlayer);
    }

    public void updateMyGraveYardList()
    {
        if (myPlayer.GraveYardList.Count > 0)
        {
            m_myGraveYardListUtil.updateSprite(myPlayer.DeckList[0]);
        }
        else
        {
            m_myGraveYardListUtil.updateSprite(null);
        }
    }

    public void updateMyHandList()
    {
        m_myHandCardUtil.updateMyHandList(myPlayer);
    }

    public void updateMyLeveleList()
    {
        m_myLevelCardListUtil.updateMyLevelList(myPlayer);
    }

    public void updateMyMemoryList()
    {
        if (myPlayer.MemoryList.Count > 0)
        {
            m_myMemoryListUtil.updateSprite(myPlayer.MemoryList[0]);
        }
        else
        {
            m_myMemoryListUtil.updateSprite(null);
        }
    }

    public void updateMyStockList()
    {
        m_myStockCardUtil.updateMyStockList(myPlayer);
    }

    public void updateEnemyHandList()
    {
        if(enemyPlayer == null)
        {
            enemyHandCardUtil.updateEnemyHand(0);
            return;
        }
        enemyHandCardUtil.updateEnemyHand(enemyPlayer.HandList.Count);
    }

    public void setEnemyPlayer(Player player)
    {
        enemyPlayer = player;
    }

    public void setMyPlayer(Player player)
    {
        myPlayer = player;
    }

    private void checkIsAvailableInitialize()
    {
        if (enemyPlayer == null || myPlayer == null)
        {
            return;
        }
    }
}
