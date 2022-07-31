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

    [SerializeField] EnemyBackCardListUtil m_enemyBackCardUtil;
    [SerializeField] EnemyClockCardUtil m_enemyClockCardUtil;
    [SerializeField] EnemyClimaxCardUtil m_enemyClimaxCardUtil;
    [SerializeField] EnemyDeckListUtil m_enemyDeckListUtil;
    [SerializeField] EnemyFrontCardListUtil m_enemyFrontCardListUtil;
    [SerializeField] EnemyGraveYardListUtil m_enemyGraveYardListUtil;
    [SerializeField] EnemyHandCardUtil enemyHandCardUtil;
    [SerializeField] EnemyLevelCardUtil m_enemyLevelCardUtil;
    [SerializeField] EnemyMemoryListUtil m_enemyMemoryListUtil;
    [SerializeField] EnemyStockCardUtil m_enemyStockCardUtil;

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
        updateEnemyBackCardList();
        updateEnemyClockList();
        updateEnemyClimaxList();
        updateEnemyDeckList();
        updateEnemyFrontCardList();
        updateEnemyGraveYardList();
        updateEnemyHandList();
        updateEnemyLeveleList();
        updateEnemyMemoryList();
        updateEnemyStockList();
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
        int num = myPlayer.GraveYardList.Count;
        if (myPlayer.GraveYardList.Count > 0)
        {
            m_myGraveYardListUtil.updateSprite(myPlayer.GraveYardList[num - 1]);
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

    public void updateEnemyBackCardList()
    {
        if (enemyPlayer == null)
        {
            m_enemyBackCardUtil.updateEnemyBackList(null);
            return;
        }
        m_enemyBackCardUtil.updateEnemyBackList(enemyPlayer);
    }

    public void updateEnemyClockList()
    {
        if (enemyPlayer == null)
        {
            m_enemyClockCardUtil.updateEnemyClockList(null);
            return;
        }
        m_enemyClockCardUtil.updateEnemyClockList(enemyPlayer);
    }

    public void updateEnemyClimaxList()
    {
        if (enemyPlayer == null)
        {
            m_enemyClimaxCardUtil.updateSprite(null);
            return;
        }
        m_enemyClimaxCardUtil.updateSprite(enemyPlayer.climaxCard);
    }

    public void updateEnemyDeckList()
    {
        if (enemyPlayer == null)
        {
            m_enemyDeckListUtil.updateSprite(null);
            return;
        }

        if (enemyPlayer.DeckList.Count > 0)
        {
            m_enemyDeckListUtil.updateSprite(enemyPlayer.DeckList[0]);
        }
        else
        {
            m_enemyDeckListUtil.updateSprite(null);
        }
    }

    public void updateEnemyFrontCardList()
    {
        if (enemyPlayer == null)
        {
            m_enemyFrontCardListUtil.updateEnemyFrontList(null);
            return;
        }
        m_enemyFrontCardListUtil.updateEnemyFrontList(enemyPlayer);
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

    public void updateEnemyGraveYardList()
    {
        if (enemyPlayer == null)
        {
            m_enemyGraveYardListUtil.updateSprite(null);
            return;
        }

        int num = enemyPlayer.GraveYardList.Count;
        if (num > 0)
        {
            m_enemyGraveYardListUtil.updateSprite(enemyPlayer.GraveYardList[num - 1]);
        }
        else
        {
            m_enemyGraveYardListUtil.updateSprite(null);
        }
    }

    public void updateEnemyLeveleList()
    {
        if (enemyPlayer == null)
        {
            m_enemyLevelCardUtil.updateEnemyLevelList(null);
            return;
        }
        m_enemyLevelCardUtil.updateEnemyLevelList(enemyPlayer);
    }

    public void updateEnemyMemoryList()
    {
        if (enemyPlayer == null)
        {
            m_enemyMemoryListUtil.updateSprite(null);
            return;
        }
        int num = enemyPlayer.MemoryList.Count;
        if (enemyPlayer.MemoryList.Count > 0)
        {
            m_enemyMemoryListUtil.updateSprite(enemyPlayer.MemoryList[num - 1]);
        }
        else
        {
            m_enemyMemoryListUtil.updateSprite(null);
        }
    }

    public void updateEnemyStockList()
    {
        if (enemyPlayer == null)
        {
            m_enemyStockCardUtil.updateEnemyStockList(null);
            return;
        }
        m_enemyStockCardUtil.updateEnemyStockList(enemyPlayer);
    }

    public void setMyPlayer(Player player)
    {
        myPlayer = player;
    }

    public void setEnemyPlayer(Player player)
    {
        enemyPlayer = player;
    }

    private void checkIsAvailableInitialize()
    {
        if (enemyPlayer == null || myPlayer == null)
        {
            return;
        }
    }
}
