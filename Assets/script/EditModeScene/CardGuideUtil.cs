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
        levelIndex.text = info.level.ToString();
        costIndex.text = info.cost.ToString();
    }
}
