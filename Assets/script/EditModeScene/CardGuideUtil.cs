using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardGuideUtil : MonoBehaviour
{
    ExtendUtil.ExtendUtil extendUtil = new ExtendUtil.ExtendUtil();
    [SerializeField] Text cardName;
    [SerializeField] Image cardInfoImage;
    [SerializeField] Text explanation;
    [SerializeField] Text levelIndex;
    [SerializeField] Text costIndex;

    void Start()
    {
        // âÊñ ÇêÆÇ¶ÇÈ
        Canvas.ForceUpdateCanvases();
    }

    public void onShowInfo(cardInfo info)
    {
        cardName.text = info.cardName;
        explanation.text = extendUtil.Explanation(info.cardNo);
        cardInfoImage.sprite = info.sprite;

        if(info.level == -1)
        {
            levelIndex.text = "";
        }
        else
        {
            levelIndex.text = info.level.ToString();
        }

        if(info.cost == -1)
        {
            costIndex.text = "";
        }
        else
        {
            costIndex.text = info.cost.ToString();
        }

    }
}
