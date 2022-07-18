using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IPunObservable
{
    CardNoToCardInfo.CardNoToCardInfo info = new CardNoToCardInfo.CardNoToCardInfo();

    [SerializeField] TestBattleCardInfoList testList;
    public List<BattleCardInfo> myDeckList = new List<BattleCardInfo>();
    public List<BattleCardInfo> myHandList = new List<BattleCardInfo>();
    public List<BattleCardInfo> myGraveYardList = new List<BattleCardInfo>();
    // Start is called before the first frame update
    void Start()
    {
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

    private void setDeckList()
    {
        for(int i = 0; i < testList.cardNoList.Count; i++)
        {
            EnumController.CardNo temp = testList.cardNoList[i];
            myDeckList.Add(info.cardNoToCardInfo(temp));
        }
    }
}
