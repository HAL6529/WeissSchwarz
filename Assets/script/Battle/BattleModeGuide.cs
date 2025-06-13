using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EnumController;
using ExtendUtil;
using CardNoToCardInfo;

public class BattleModeGuide : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] Text explanation;
    [SerializeField] Text name;
    [SerializeField] Text level;
    [SerializeField] Text cost;
    [SerializeField] Text power;
    [SerializeField] Text soulIndex;
    [SerializeField] List<Text> attributeList;
    [SerializeField] Image Name;
    [SerializeField] Image Lv;
    [SerializeField] Image Trigger1;
    [SerializeField] Image Trigger2;
    [SerializeField] GameObject LevelObj;
    [SerializeField] GameObject CostObj;
    [SerializeField] GameObject PowerObj;
    [SerializeField] List<GameObject> AttributeObj;

    [SerializeField] RectTransform m_RectTransformForText1;

    [SerializeField] Sprite bounce;
    [SerializeField] Sprite choice;
    [SerializeField] Sprite draw;
    [SerializeField] Sprite gate;
    [SerializeField] Sprite comeback;
    [SerializeField] Sprite standby;
    [SerializeField] Sprite shot;
    [SerializeField] Sprite soul;
    [SerializeField] Sprite stock;
    [SerializeField] Sprite treasure;
    [SerializeField] Sprite name_b;
    [SerializeField] Sprite name_g;
    [SerializeField] Sprite name_r;
    [SerializeField] Sprite name_y;
    [SerializeField] Sprite lv_b;
    [SerializeField] Sprite lv_g;
    [SerializeField] Sprite lv_r;
    [SerializeField] Sprite lv_y;
    CardNoToExplanation m_CardNoToExplanation = new CardNoToExplanation();
    ExtendUtil.ExtendUtil m_ExtendUtil = new ExtendUtil.ExtendUtil();

    // Start is called before the first frame update
    void Start()
    {
        name.text = null;
        cost.text = null;
        level.text = null;
        power.text = null;
        soulIndex.text = null;
        explanation.text = null;
        Trigger1.color = new Color(1, 1, 1, 0);
        Trigger2.color = new Color(1, 1, 1, 0);
    }

    public void showImage(BattleModeCard card)
    {
        if(card == null)
        {
            return;
        }
        image.sprite = card.sprite;
        name.text = card.name;

        for(int i = 0; i < attributeList.Count; i++)
        {
            attributeList[i].text = "";
        }

        for (int i = 0; i < AttributeObj.Count; i++)
        {
            AttributeObj[i].SetActive(false);
        }

        if (card.type == EnumController.Type.CHARACTER)
        {
            cost.text = card.cost.ToString();
            level.text = card.level.ToString();
            power.text = card.power.ToString();
            soulIndex.text = card.soul.ToString();
            LevelObj.SetActive(true);
            CostObj.SetActive(true);
            PowerObj.SetActive(true);
        }
        else if(card.type == EnumController.Type.EVENT)
        {
            cost.text = card.cost.ToString();
            level.text = card.level.ToString();
            power.text = null;
            soulIndex.text = null;
            LevelObj.SetActive(true);
            CostObj.SetActive(true);
            PowerObj.SetActive(false);
        }
        else
        {
            cost.text = null;
            level.text = null;
            power.text = null;
            soulIndex.text = null;
            LevelObj.SetActive(false);
            CostObj.SetActive(false);
            PowerObj.SetActive(false);
        }

        if (card.type == EnumController.Type.CHARACTER)
        {
            if (card.attribute.Count > 0)
            {
                for (int i = 0; i < card.attribute.Count; i++)
                {
                    attributeList[i].text = m_ExtendUtil.AttributeConvertToString(card.attribute[i]);
                    AttributeObj[i].SetActive(true);
                }
            }
            else
            {
                attributeList[0].text = "特徴なし";
                AttributeObj[0].SetActive(true);
            }
        }
        else
        {
            attributeList[0].text = "";
            AttributeObj[0].SetActive(false);
        }

 

        explanation.text = m_CardNoToExplanation.Explanation(card.cardNo);

        switch (card.trigger)
        {
            case EnumController.Trigger.COMEBACK:
                Trigger1.sprite = comeback;
                Trigger2.sprite = null;
                break;
            case EnumController.Trigger.STANDBY:
                Trigger1.sprite = soul;
                Trigger2.sprite = standby;
                break;
            case EnumController.Trigger.BOOK:
                Trigger1.sprite = draw;
                Trigger2.sprite = null;
                break;
            case EnumController.Trigger.GATE:
                Trigger1.sprite = soul;
                Trigger2.sprite = gate;
                break;
            case EnumController.Trigger.BOUNCE:
                Trigger1.sprite = soul;
                Trigger2.sprite = bounce;
                break;
            case EnumController.Trigger.CHOICE:
                Trigger1.sprite = choice;
                Trigger2.sprite = null;
                break;
            case EnumController.Trigger.SHOT:
                Trigger1.sprite = soul;
                Trigger2.sprite = shot;
                break;
            case EnumController.Trigger.TREASURE:
                Trigger1.sprite = treasure;
                Trigger2.sprite = null;
                break;
            case EnumController.Trigger.POOL:
                Trigger1.sprite = stock;
                Trigger2.sprite = null;
                break;
            case EnumController.Trigger.SOUL:
                Trigger1.sprite = soul;
                Trigger2.sprite = null;
                break;
            case EnumController.Trigger.DOUBLE_SOUL:
                Trigger1.sprite = soul;
                Trigger2.sprite = soul;
                break;
            case EnumController.Trigger.VOID:
            case EnumController.Trigger.NONE:
                Trigger1.sprite = null;
                Trigger2.sprite = null;
                break;
            default:
                Trigger1.sprite = null;
                Trigger2.sprite = null;
                break;
        }

        switch (card.color)
        {
            case EnumController.CardColor.BLUE:
                Name.sprite = name_b;
                Lv.sprite = lv_b;
                break;
            case EnumController.CardColor.GREEN:
                Name.sprite = name_g;
                Lv.sprite = lv_g;
                break;
            case EnumController.CardColor.RED:
                Name.sprite = name_r;
                Lv.sprite = lv_r;
                break;
            case EnumController.CardColor.YELLOW:
                Name.sprite = name_y;
                Lv.sprite = lv_y;
                break;
            default:
                Name.sprite = null;
                break;
        }

        if (Trigger1.sprite == null)
        {
            Trigger1.color = new Color(1, 1, 1, 0);
        }
        else
        {
            Trigger1.color = new Color(1, 1, 1, 1);
        }

        if (Trigger2.sprite == null)
        {
            Trigger2.color = new Color(1, 1, 1, 0);
        }
        else
        {
            Trigger2.color = new Color(1, 1, 1, 1);
        }

        level.color = new Color(1, 1, 1, 1);
        power.color = new Color(1, 1, 1, 1);
        soulIndex.color = new Color(0, 0, 0, 1);
        // 画面を整える
        Canvas.ForceUpdateCanvases();
    }

    /// <summary>
    /// 手札やフィールドでステータスが変わっている場合に利用
    /// </summary>
    /// <param name="card"></param>
    /// <param name="NowCard">手札やフィールドの現状のカード情報</param>
    public void showImage(BattleModeCard card, BattleModeCard NowCard)
    {
        if(card == null)
        {
            return;
        }
        showImage(card);

        // levelが元々と異なっていた場合
        if(card.level > NowCard.level)
        {
            level.color = new Color(1, 70f / 255f, 70f / 255f, 1);
        }
        else if(card.level == NowCard.level)
        {
            level.color = new Color(1, 1, 1, 1);
        }
        else
        {
            level.color = new Color(110f / 255f, 230f / 255f, 110f / 255f, 1);
        }

        // powerが元々と異なっていた場合
        if (card.power > NowCard.power)
        {
            power.color = new Color(1, 70f / 255f, 70f / 255f, 1);
        }
        else if (card.power == NowCard.power)
        {
            power.color = new Color(1, 1, 1, 1);
        }
        else
        {
            power.color = new Color(110f / 255f, 230f / 255f, 110f / 255f, 1);
        }

        // soulが元々と異なっていた場合
        if (card.soul > NowCard.soul)
        {
            soulIndex.color = new Color(1, 0, 0, 1);
        }
        else if (card.soul == NowCard.soul)
        {
            soulIndex.color = new Color(0, 0, 0, 1);
        }
        else
        {
            soulIndex.color = new Color(0, 140f / 255f, 0, 1);
        }

        level.text = NowCard.level.ToString();
        power.text = NowCard.power.ToString();
        soulIndex.text = NowCard.soul.ToString();

        if (card.type == EnumController.Type.CHARACTER)
        {
            if (NowCard.attribute.Count > 0)
            {
                for (int i = 0; i < NowCard.attribute.Count; i++)
                {
                    attributeList[i].text = m_ExtendUtil.AttributeConvertToString(NowCard.attribute[i]);
                    AttributeObj[i].SetActive(true);
                }
            }
            else
            {
                attributeList[0].text = "特徴なし";
                AttributeObj[0].SetActive(true);
            }
        }
        else
        {
            attributeList[0].text = "";
            AttributeObj[0].SetActive(false);
        }
        // 画面を整える
        Canvas.ForceUpdateCanvases();
    }
}
