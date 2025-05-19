using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EnumController;
using System.Linq;

public class DeckListManager : MonoBehaviour
{
    public List<DeckListPanelUtil> panels;
    public List<cardInfo> cardInfoList = new List<cardInfo>();

    [SerializeField] Text cardName;
    [SerializeField] Image cardInfoImage;
    [SerializeField] Text explanation;
    [SerializeField] Text levelIndex;
    [SerializeField] Text costIndex;
    [SerializeField] Text powerIndex;
    [SerializeField] Text Attribute1;
    [SerializeField] Text Attribute2;
    [SerializeField] Text Attribute3;
    [SerializeField] GameObject cardInfoImageObject;

    RectTransform m_RectTransform;

    ExtendUtil.ExtendUtil extendUtil = new ExtendUtil.ExtendUtil();

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
    public void addCard(cardInfo info)
    {
        if (cardInfoList.Count >= 64)
        {
            return;
        }

        // 同名カードが4枚以上の場合処理は行わない。
        int index = cardInfoList.Count(obj => obj.cardNo == info.cardNo);
        if (info.limit == EnumController.Limit.NORMAL)
        {
            if(index > 3)
            {
                return;
            }
        }
        cardInfoList.Add(info);
        sortDeckList();
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
                    cardInfo temp = cardInfoList[i];
                    cardInfoList[i] = cardInfoList[k];
                    cardInfoList[k] = temp;
                }
            }
        }
    }

    public void onShowInfo(int index)
    {
        cardName.text = cardInfoList[index].cardName;
        explanation.text = extendUtil.Explanation(cardInfoList[index].cardNo);
        cardInfoImage.sprite = cardInfoList[index].sprite;

        if (cardInfoList[index].type == EnumController.Type.CLIMAX)
        {
            m_RectTransform.sizeDelta = new Vector2(201.09f, 143f);
        }
        else
        {
            m_RectTransform.sizeDelta = new Vector2(143f, 201.09f);
        }
        if (cardInfoList[index].level == -1)
        {
            levelIndex.text = "";
        }
        else
        {
            levelIndex.text = cardInfoList[index].level.ToString();
        }

        if (cardInfoList[index].cost == -1)
        {
            costIndex.text = "";
        }
        else
        {
            costIndex.text = cardInfoList[index].cost.ToString();
        }

        if (cardInfoList[index].power == -1)
        {
            powerIndex.text = "";
        }
        else
        {
            powerIndex.text = cardInfoList[index].power.ToString();
        }

        if (cardInfoList[index].attributeOne == EnumController.Attribute.VOID)
        {
            Attribute1.text = "";
        }
        else
        {
            Attribute1.text = "<" + extendUtil.AttributeConvertToString(cardInfoList[index].attributeOne) + ">";
        }

        if (cardInfoList[index].attributeTwo == EnumController.Attribute.VOID)
        {
            Attribute2.text = "";
        }
        else
        {
            Attribute2.text = "<" + extendUtil.AttributeConvertToString(cardInfoList[index].attributeTwo) + ">";
        }

        if (cardInfoList[index].attributeThree == EnumController.Attribute.VOID)
        {
            Attribute3.text = "";
        }
        else
        {
            Attribute3.text = "<" + extendUtil.AttributeConvertToString(cardInfoList[index].attributeThree) + ">";
        }
    }

    public void removeCard(int index)
    {
        cardInfoList.RemoveAt(index);
        sortDeckList();
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
}
