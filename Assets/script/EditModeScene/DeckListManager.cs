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

    ExtendUtil.ExtendUtil extendUtil = new ExtendUtil.ExtendUtil();

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

    private void updateDeckList()
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

    private void sortDeckList()
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
        cardName.text = cardInfoList[index].name;
        explanation.text = extendUtil.Explanation(cardInfoList[index].cardNo);
        cardInfoImage.sprite = cardInfoList[index].sprite;
        levelIndex.text = cardInfoList[index].level.ToString();
        costIndex.text = cardInfoList[index].cost.ToString();
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
