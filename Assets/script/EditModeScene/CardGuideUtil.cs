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
    [SerializeField] GameObject PowerObj;
    [SerializeField] GameObject cardInfoImageObject;
    [SerializeField] GameObject LevelObj;
    [SerializeField] GameObject CostObj;
    [SerializeField] GameObject TriggerObj;
    [SerializeField] GameObject TriggerImageObj;
    [SerializeField] GameObject TriggerImageObj2;
    [SerializeField] Image trigger_image1;
    [SerializeField] Image trigger_image2;
    [SerializeField] GameObject TriggerObj2;
    [SerializeField] GameObject TriggerImageObj3;
    [SerializeField] GameObject TriggerImageObj4;
    [SerializeField] Image trigger_image3;
    [SerializeField] Image trigger_image4;
    [SerializeField] Image NameImage;
    [SerializeField] Image LevelImage;
    [SerializeField] Sprite name_b;
    [SerializeField] Sprite name_g;
    [SerializeField] Sprite name_r;
    [SerializeField] Sprite name_y;
    [SerializeField] Sprite lv_b;
    [SerializeField] Sprite lv_g;
    [SerializeField] Sprite lv_r;
    [SerializeField] Sprite lv_y;
    [SerializeField] Sprite lv_gray;
    [SerializeField] Sprite comeback;
    [SerializeField] Sprite soul;
    [SerializeField] Sprite pool;

    RectTransform m_RectTransform;

    void Start()
    {
        // âÊñ ÇêÆÇ¶ÇÈ
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
            TriggerObj.SetActive(false);
            TriggerObj2.SetActive(true);
        }
        else
        {
            m_RectTransform.sizeDelta = new Vector2(143f, 201.09f);
            TriggerObj.SetActive(true);
            TriggerObj2.SetActive(false);
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
            CostObj.SetActive(false);
        }
        else
        {
            costIndex.text = info.cost.ToString();
            CostObj.SetActive(true);
        }

        if(info.power == -1)
        {
            powerIndex.text = "";
            PowerObj.SetActive(false);
        }
        else
        {
            powerIndex.text = info.power.ToString();
            PowerObj.SetActive(true);
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

        if (info.level == 0)
        {
            LevelImage.sprite = lv_gray;
            LevelObj.SetActive(true);
        }
        else if(info.level == -1)
        {
            LevelObj.SetActive(false);
        }
        else
        {
            switch (info.color)
            {
                case EnumController.CardColor.BLUE:
                    LevelImage.sprite = lv_b;
                    break;
                case EnumController.CardColor.GREEN:
                    LevelImage.sprite = lv_g;
                    break;
                case EnumController.CardColor.RED:
                    LevelImage.sprite = lv_r;
                    break;
                case EnumController.CardColor.YELLOW:
                    LevelImage.sprite = lv_y;
                    break;
                default:
                    LevelImage.sprite = lv_gray;
                    break;
            }
            LevelObj.SetActive(true);
        }

        switch (info.color)
        {
            case EnumController.CardColor.BLUE:
                NameImage.sprite = name_b;
                break;
            case EnumController.CardColor.GREEN:
                NameImage.sprite = name_g;
                break;
            case EnumController.CardColor.RED:
                NameImage.sprite = name_r;
                break;
            case EnumController.CardColor.YELLOW:
                NameImage.sprite = name_y;
                break;
            default:
                break;
        }

        switch (info.trigger)
        {
            case EnumController.Trigger.NONE:
                TriggerImageObj.SetActive(false);
                TriggerImageObj2.SetActive(false);
                TriggerImageObj3.SetActive(false);
                TriggerImageObj4.SetActive(false);
                trigger_image1.sprite = null;
                trigger_image2.sprite = null;
                break;
            case EnumController.Trigger.COMEBACK:
                TriggerImageObj.SetActive(false);
                TriggerImageObj2.SetActive(false);
                TriggerImageObj3.SetActive(true);
                TriggerImageObj4.SetActive(false);
                trigger_image3.sprite = comeback;
                trigger_image4.sprite = null;
                break;
            case EnumController.Trigger.SOUL:
                TriggerImageObj.SetActive(true);
                TriggerImageObj2.SetActive(false);
                TriggerImageObj3.SetActive(false);
                TriggerImageObj4.SetActive(false);
                trigger_image1.sprite = soul;
                trigger_image2.sprite = null;
                break;
            case EnumController.Trigger.POOL:
                TriggerImageObj.SetActive(false);
                TriggerImageObj2.SetActive(false);
                TriggerImageObj3.SetActive(true);
                TriggerImageObj4.SetActive(false);
                trigger_image3.sprite = pool;
                trigger_image4.sprite = null;
                break;
            case EnumController.Trigger.DOUBLE_SOUL:
                TriggerImageObj.SetActive(false);
                TriggerImageObj2.SetActive(false);
                TriggerImageObj3.SetActive(true);
                TriggerImageObj4.SetActive(true);
                trigger_image3.sprite = soul;
                trigger_image4.sprite = soul;
                break;
            default:
                break;
        }
    }
}
