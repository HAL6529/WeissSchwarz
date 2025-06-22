using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EnumController;
using System.Linq;

public class DeckListManager : MonoBehaviour
{
    public List<DeckListPanelUtil> panels;
    public List<BattleModeCard> cardInfoList = new List<BattleModeCard>();

    [SerializeField] Text cardName;
    [SerializeField] Image cardInfoImage;
    [SerializeField] Text explanation;
    [SerializeField] Text levelIndex;
    [SerializeField] Text costIndex;
    [SerializeField] Text powerIndex;
    [SerializeField] Text Attribute1;
    [SerializeField] Text Attribute2;
    [SerializeField] Text Attribute3;
    [SerializeField] GameObject Attribute1Obj;
    [SerializeField] GameObject Attribute2Obj;
    [SerializeField] GameObject Attribute3Obj;
    [SerializeField] GameObject cardInfoImageObject;
    [SerializeField] Image LevelSortBtnImage;
    [SerializeField] Image ColorSortBtnImage;
    [SerializeField] CardGuideUtil m_CardGuideUtil;

    RectTransform m_RectTransform;

    ExtendUtil.ExtendUtil extendUtil = new ExtendUtil.ExtendUtil();

    public bool isLevelSort = false;
    public bool isColorSort = false;

    // Start is called before the first frame update
    void Start()
    {
        this.cardInfoList = SaveData.cardInfoList;
        sortDeckList();
        updateDeckList();
        m_RectTransform = cardInfoImageObject.GetComponent<RectTransform>();
    }

    /// <summary>
    /// デッキ編集リストにカード情報を加える関数
    /// </summary>
    /// <param name="info">cardInfo型　カード情報</param>
    public void addCard(BattleModeCard info)
    {
        if (cardInfoList.Count >= 64)
        {
            return;
        }

        // 同名カードが4枚以上の場合処理は行わない。
        int index = cardInfoList.Count(obj => obj.cardNo == info.cardNo);
        if (index > 3)
        {
            return;
        }
        cardInfoList.Add(info);
        sortDeckList();
        if (isLevelSort)
        {
            LevelSortDeckList();
        }
        if (isColorSort)
        {
            ColorSortDeckList();
        }
        updateDeckList();
    }

    public void updateDeckList()
    {
        for (int i = 0; i < panels.Count; i++)
        {
            if(i < cardInfoList.Count)
            {
                panels[i].setInfo(cardInfoList[i].sprite);             
            }
            else
            {
                panels[i].setInfo(null);
            }            
        }
    }

    public void sortDeckList()
    {
        for (int i = 0; i < cardInfoList.Count; i++)
        {
           for(int k = i + 1; k < cardInfoList.Count; k++)
            {
                if ((int)cardInfoList[i].cardNo > (int)cardInfoList[k].cardNo)
                {
                    BattleModeCard temp = cardInfoList[i];
                    cardInfoList[i] = cardInfoList[k];
                    cardInfoList[k] = temp;
                }
            }
        }
    }

    public void ColorSortDeckList()
    {
        List<BattleModeCard> BlueList = new List<BattleModeCard>();
        List<BattleModeCard> GreenList = new List<BattleModeCard>();
        List<BattleModeCard> RedList = new List<BattleModeCard>();
        List<BattleModeCard> YellowList = new List<BattleModeCard>();
        List<BattleModeCard> PurpleList = new List<BattleModeCard>();
        for (int i = 0; i < cardInfoList.Count; i++)
        {
            switch (cardInfoList[i].color)
            {
                case EnumController.CardColor.BLUE:
                    BlueList.Add(cardInfoList[i]);
                    break;
                case EnumController.CardColor.GREEN:
                    GreenList.Add(cardInfoList[i]);
                    break;
                case EnumController.CardColor.RED:
                    RedList.Add(cardInfoList[i]);
                    break;
                case EnumController.CardColor.YELLOW:
                    YellowList.Add(cardInfoList[i]);
                    break;
                default:
                    PurpleList.Add(cardInfoList[i]);
                    break;
            }
        }
        cardInfoList = new List<BattleModeCard>();

        for (int i = 0; i < BlueList.Count; i++)
        {
            cardInfoList.Add(BlueList[i]);
        }
        for (int i = 0; i < GreenList.Count; i++)
        {
            cardInfoList.Add(GreenList[i]);
        }
        for (int i = 0; i < RedList.Count; i++)
        {
            cardInfoList.Add(RedList[i]);
        }
        for (int i = 0; i < YellowList.Count; i++)
        {
            cardInfoList.Add(YellowList[i]);
        }
        for (int i = 0; i < PurpleList.Count; i++)
        {
            cardInfoList.Add(PurpleList[i]);
        }
    }

    public void ColorSortBtn()
    {
        if (isColorSort)
        {
            isColorSort = false;
            ColorSortBtnImage.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 150f / 255f);
            return;
        }
        isColorSort = true;
        ColorSortBtnImage.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
        ColorSortDeckList();
        updateDeckList();
    }

    public void LevelSortDeckList()
    {
        List<BattleModeCard> Level0List = new List<BattleModeCard>();
        List<BattleModeCard> Level1List = new List<BattleModeCard>();
        List<BattleModeCard> Level2List = new List<BattleModeCard>();
        List<BattleModeCard> Level3List = new List<BattleModeCard>();
        List<BattleModeCard> ClimaxList = new List<BattleModeCard>();
        List<BattleModeCard> EventList = new List<BattleModeCard>();
        for (int i = 0; i < cardInfoList.Count; i++)
        {
            switch (cardInfoList[i].level)
            {
                case 0:
                    Level0List.Add(cardInfoList[i]);
                    break;
                case 1:
                    Level1List.Add(cardInfoList[i]);
                    break;
                case 2:
                    Level2List.Add(cardInfoList[i]);
                    break;
                case 3:
                    Level3List.Add(cardInfoList[i]);
                    break;
                default:
                    ClimaxList.Add(cardInfoList[i]);
                    break;
            }
        }
        cardInfoList = new List<BattleModeCard>();

        for(int i = 0; i < Level0List.Count; i++)
        {
            cardInfoList.Add(Level0List[i]);
        }
        for (int i = 0; i < Level1List.Count; i++)
        {
            cardInfoList.Add(Level1List[i]);
        }
        for (int i = 0; i < Level2List.Count; i++)
        {
            cardInfoList.Add(Level2List[i]);
        }
        for (int i = 0; i < Level3List.Count; i++)
        {
            cardInfoList.Add(Level3List[i]);
        }
        for (int i = 0; i < ClimaxList.Count; i++)
        {
            cardInfoList.Add(ClimaxList[i]);
        }
    }

    public void LevelSortBtn()
    {
        if (isLevelSort)
        {
            isLevelSort = false;
            LevelSortBtnImage.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 150f / 255f);
            return;
        }
        isLevelSort = true;
        LevelSortBtnImage.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
        LevelSortDeckList();
        updateDeckList();
    }

    public void onShowInfo(int index)
    {
        m_CardGuideUtil.onShowInfo(cardInfoList[index]);
    }

    public void removeCard(int index)
    {
        cardInfoList.RemoveAt(index);
        sortDeckList();
        if (isLevelSort)
        {
            LevelSortDeckList();
        }
        if (isColorSort)
        {
            ColorSortDeckList();
        }
        updateDeckList();
    }

    public List<EnumController.CardNo> GetDeckList()
    {
        List<EnumController.CardNo> list = new List<EnumController.CardNo>();
        
        for (int i = 0; i < cardInfoList.Count; i++)
        {
            list.Add(cardInfoList[i].cardNo);
        }

        return list;
    }

    public void Reset()
    {
        cardInfoList = new List<BattleModeCard>();
        updateDeckList();
    }
}
