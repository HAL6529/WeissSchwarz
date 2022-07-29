using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Photon.MonoBehaviour, IPunObservable
{
    CardNoToCardInfo.CardNoToCardInfo info = new CardNoToCardInfo.CardNoToCardInfo();
    [SerializeField] SpriteList m_spriteList;
    [SerializeField] TestBattleCardInfoList testList;

    private GameController gameController;

    public List<BattleCardInfo> BackStageList = new List<BattleCardInfo>() {null, null};
    public List<BattleCardInfo> ClockList = new List<BattleCardInfo>();
    public List<BattleCardInfo> DeckList = new List<BattleCardInfo>();
    public List<BattleCardInfo> FrontStageList = new List<BattleCardInfo>() {null, null, null};
    public List<BattleCardInfo> GraveYardList = new List<BattleCardInfo>();
    public List<BattleCardInfo> HandList = new List<BattleCardInfo>();
    public List<BattleCardInfo> LevelList = new List<BattleCardInfo>();
    public List<BattleCardInfo> MemoryList = new List<BattleCardInfo>();
    public List<BattleCardInfo> StockList = new List<BattleCardInfo>();

    public BattleCardInfo climaxCard;

    static readonly int HAND_NUM = 5;
    // Start is called before the first frame update
    void Start()
    {
        PhotonView photonView = GetComponent<PhotonView>();
        gameController = GameObject.Find("GameManage").GetComponent<GameController>();
        if (!photonView.isMine)
        {
            gameController.setEnemyPlayer(this);
        }
        else
        {
            gameController.setMyPlayer(this);
        }

        setDeckList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        /* オーナーの場合
        if (stream.IsWriting)
        {
            stream.SendNext(this._text);
        }
        // オーナー以外の場合
        else
        {
            this._text = (string)stream.ReceiveNext();
        }*/
    }

    public void setDeckList()
    {
        for (int i = 0; i < testList.cardNoList.Count; i++)
        {
            EnumController.CardNo temp = testList.cardNoList[i];
            DeckList.Add(info.cardNoToCardInfo(temp, m_spriteList));
        }

        // 下の処理は場所が適切でないと思われる
        gameController.updateUI();
    }

    public void setUpHand()
    {
        for(int i = 0; i < HAND_NUM; i++)
        {
            HandList.Add(DeckList[0]);
            DeckList.RemoveAt(0);
        }
    }
}
