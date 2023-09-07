using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EnumController;
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
    [SerializeField] Image Trigger1;
    [SerializeField] Image Trigger2;

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
    CardNoToExplanation m_CardNoToExplanation = new CardNoToExplanation();


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
        cost.text = card.cost.ToString();
        level.text = card.level.ToString();
        power.text = card.power.ToString();
        soulIndex.text = card.soul.ToString();
        explanation.text = m_CardNoToExplanation.Explanation(card.cardNo);

        switch (card.trigger)
        {
            case EnumController.Trriger.COMEBACK:
                Trigger1.sprite = comeback;
                Trigger2.sprite = null;
                break;
            case EnumController.Trriger.STANDBY:
                Trigger1.sprite = soul;
                Trigger2.sprite = standby;
                break;
            case EnumController.Trriger.BOOK:
                Trigger1.sprite = draw;
                Trigger2.sprite = null;
                break;
            case EnumController.Trriger.GATE:
                Trigger1.sprite = soul;
                Trigger2.sprite = gate;
                break;
            case EnumController.Trriger.BOUNCE:
                Trigger1.sprite = soul;
                Trigger2.sprite = bounce;
                break;
            case EnumController.Trriger.CHOICE:
                Trigger1.sprite = choice;
                Trigger2.sprite = null;
                break;
            case EnumController.Trriger.SHOT:
                Trigger1.sprite = soul;
                Trigger2.sprite = shot;
                break;
            case EnumController.Trriger.TREASURE:
                Trigger1.sprite = treasure;
                Trigger2.sprite = null;
                break;
            case EnumController.Trriger.POOL:
                Trigger1.sprite = stock;
                Trigger2.sprite = null;
                break;
            case EnumController.Trriger.SOUL:
                Trigger1.sprite = soul;
                Trigger2.sprite = null;
                break;
            case EnumController.Trriger.DOUBLE_SOUL:
                Trigger1.sprite = soul;
                Trigger2.sprite = soul;
                break;
            case EnumController.Trriger.VOID:
            case EnumController.Trriger.NONE:
                Trigger1.sprite = null;
                Trigger2.sprite = null;
                break;
            default:
                Trigger1.sprite = null;
                Trigger2.sprite = null;
                break;
        }

        if(Trigger1.sprite == null)
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

        // âÊñ ÇêÆÇ¶ÇÈ
        //Canvas.ForceUpdateCanvases();
    }
}
