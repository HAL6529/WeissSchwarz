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
    [SerializeField] Text powerIndex;
    [SerializeField] Text Attribute1;
    [SerializeField] Text Attribute2;
    [SerializeField] Text Attribute3;

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

        if(info.power == -1)
        {
            powerIndex.text = "";
        }
        else
        {
            powerIndex.text = info.power.ToString();
        }

        if (info.attributeOne == EnumController.Attribute.VOID)
        {
            Attribute1.text = "";
        }
        else
        {
            Attribute1.text = "<" + extendUtil.AttributeConvertToString(info.attributeOne) + ">";
        }

        if (info.attributeTwo == EnumController.Attribute.VOID)
        {
            Attribute2.text = "";
        }
        else
        {
            Attribute2.text = "<" + extendUtil.AttributeConvertToString(info.attributeTwo) + ">";
        }

        if (info.attributeThree == EnumController.Attribute.VOID)
        {
            Attribute3.text = "";
        }
        else
        {
            Attribute3.text = "<" + extendUtil.AttributeConvertToString(info.attributeThree) + ">";
        }
    }
}
