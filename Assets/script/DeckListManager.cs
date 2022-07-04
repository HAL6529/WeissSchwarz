using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EnumController;
using System.Linq;

public class DeckListManager : MonoBehaviour
{
    public List<DeckListPanelUtil> panels;
    List<DeckListUtil> deckList = new List<DeckListUtil>();

    [SerializeField] Text cardName;
    [SerializeField] Image cardInfoImage;
    [SerializeField] Text explanation;
    [SerializeField] Text levelIndex;
    [SerializeField] Text costIndex;

    ExtendUtil.ExtendUtil extendUtil = new ExtendUtil.ExtendUtil();

    class DeckListUtil
    {
        public Sprite sprite;
        public EnumController.CardNo cardId;
        public string name;
        public string effect;
        public EnumController.Attribute attributeOne;
        public EnumController.Attribute attributeTwo;
        public EnumController.Attribute attributeThree;
        public int level;
        public int cost;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DeckListUtil()
        {
            this.sprite = null;
            this.cardId = EnumController.CardNo.VOID;
            this.name = null;
            this.effect = null;
            this.attributeOne = EnumController.Attribute.VOID;
            this.attributeTwo = EnumController.Attribute.VOID;
            this.attributeThree = EnumController.Attribute.VOID;
            this.level = -1;
            this.cost = -1;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="info">追加するカードの情報</param>
        public DeckListUtil(cardInfo info)
        {
            this.sprite = info.sprite;
            this.cardId = info.cardNo;
            this.name = info.cardName;
            this.attributeOne = info.attributeOne;
            this.attributeTwo = info.attributeTwo;
            this.attributeThree = info.attributeThree;
            this.level = info.level;
            this.cost = info.cost;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// デッキ編集リストにカード情報を加える関数
    /// </summary>
    /// <param name="info">cardInfo型　カード情報</param>
    public void addCard(cardInfo info)
    {
        if (deckList.Count >= 64)
        {
            return;
        }

        // 同名カードが4枚以上の場合処理は行わない。
        int index = deckList.Count(obj => obj.cardId == info.cardNo);
        if (info.limit == EnumController.Limit.NORMAL)
        {
            if(index > 3)
            {
                return;
            }
        }
        DeckListUtil deckListUtil = new DeckListUtil(info);
        deckList.Add(deckListUtil);
        sortDeckList();
        updateDeckList();
    }

    private void updateDeckList()
    {
        for (int i = 0; i < panels.Count; i++)
        {
            if(i < deckList.Count)
            {
                panels[i].setInfo(deckList[i].sprite);             
            }
            else
            {
                panels[i].setInfo(null);
            }            
        }
    }

    private void sortDeckList()
    {
        for (int i = 0; i < deckList.Count; i++)
        {
           for(int k = i + 1; k < deckList.Count; k++)
            {
                if ((int)deckList[i].cardId > (int)deckList[k].cardId)
                {
                    DeckListUtil temp = deckList[i];
                    deckList[i] = deckList[k];
                    deckList[k] = temp;
                }
            }
        }
    }

    public void onShowInfo(int index)
    {
        cardName.text = deckList[index].name;
        explanation.text = extendUtil.Explanation(deckList[index].cardId);
        cardInfoImage.sprite = deckList[index].sprite;
        levelIndex.text = deckList[index].level.ToString();
        costIndex.text = deckList[index].cost.ToString();
    }

    public void removeCard(int index)
    {
        deckList.RemoveAt(index);
        sortDeckList();
        updateDeckList();
    }
}
