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
    [SerializeField] GameObject Attribute1Obj;
    [SerializeField] GameObject Attribute2Obj;
    [SerializeField] GameObject Attribute3Obj;
    [SerializeField] GameObject cardInfoImageObject;

    RectTransform m_RectTransform;

    void Start()
    {
        // 画面を整える
        Canvas.ForceUpdateCanvases();
        m_RectTransform = cardInfoImageObject.GetComponent<RectTransform>();
    }

    public void onShowInfo(cardInfo info)
    {
        cardName.text = info.cardName;
        explanation.text = extendUtil.Explanation(info.cardNo);
        cardInfoImage.sprite = info.sprite;

        if(info.type == EnumController.Type.CLIMAX)
        {
            m_RectTransform.sizeDelta = new Vector2(201.09f, 143f);
        }
        else
        {
            m_RectTransform.sizeDelta = new Vector2(143f, 201.09f);
        }

        if (info.level == -1)
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
            Attribute1Obj.SetActive(false);
        }
        else
        {
            Attribute1.text = extendUtil.AttributeConvertToString(info.attributeOne);
            Attribute1Obj.SetActive(true);
        }

        if (info.attributeTwo == EnumController.Attribute.VOID)
        {
            Attribute2.text = "";
            Attribute2Obj.SetActive(false);
        }
        else
        {
            Attribute2.text = extendUtil.AttributeConvertToString(info.attributeTwo);
            Attribute2Obj.SetActive(true);
        }

        if (info.attributeThree == EnumController.Attribute.VOID)
        {
            Attribute3.text = "";
            Attribute3Obj.SetActive(false);
        }
        else
        {
            Attribute3.text = extendUtil.AttributeConvertToString(info.attributeThree);
            Attribute3Obj.SetActive(true);
        }
    }
}
