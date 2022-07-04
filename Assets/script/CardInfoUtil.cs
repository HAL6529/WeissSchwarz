using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EnumController;

public class CardInfoUtil : MonoBehaviour
{
    ExtendUtil.ExtendUtil extendUtil = new ExtendUtil.ExtendUtil();
    private cardInfo info;
    [SerializeField] CardGuideUtil m_CardGuideUtil;

    // デッキリストのGameObject
    [SerializeField] GameObject deckList;

    [SerializeField] Image image;
    [SerializeField] Text cardNoText;
    [SerializeField] Text cardNameText;
    [SerializeField] Text attributeOneText;
    [SerializeField] Text attributeTwoText;
    [SerializeField] Text attributeThreeText;
    [SerializeField] Text levelText;
    [SerializeField] Text costText;

    string cardName;

    // Start is called before the first frame update
    void Start()
    {
        info = GetComponent<cardInfo>();
        cardName = info.cardName;
        ChangeLayoutColor();
        ChangeText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeLayoutColor()
    {
        switch (info.color)
        {
            case EnumController.CardColor.RED:
                image.color = new Color(255f / 255f, 105f / 255f, 105f / 255f, 255f / 255f);
                break;
            case EnumController.CardColor.BLUE:
                image.color = new Color(0f / 255f, 130f / 255f, 255f / 255f, 255f / 255f);
                break;
            case EnumController.CardColor.YELLOW:
                image.color = new Color(255f / 255f, 255f / 255f, 0f / 255f, 255f / 255f);
                break;
            case EnumController.CardColor.GREEN:
                image.color = new Color(0f / 255f, 190f / 255f, 0f / 255f, 255f / 255f);
                break;
            case EnumController.CardColor.PURPLE:
                image.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
                break;
            case EnumController.CardColor.VOID:
                image.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
                break;
        }
    }

    void ChangeText()
    {
        cardNoText.text = extendUtil.CardNoConvertToString(info.cardNo);

        if (cardName != null)
        {
            cardNameText.text = cardName;
        }
        else
        {
            cardNameText.text = "";
        }
        attributeOneText.text = AttributeConvertToString(info.attributeOne);
        attributeTwoText.text = AttributeConvertToString(info.attributeTwo);
        attributeThreeText.text = AttributeConvertToString(info.attributeThree);
        levelText.text = info.level.ToString();
        costText.text = info.cost.ToString();
    }

    string AttributeConvertToString(EnumController.Attribute attribute)
    {
        switch (attribute)
        {
            case EnumController.Attribute.Ooo:
                return "Ooo";
            case EnumController.Attribute.Hero:
                return "Hero";
            case EnumController.Attribute.NONE:
                return null;
            default:
                break;
        }
        return null;
    }

    public void onAddListButton()
    {
        deckList.GetComponent<DeckListManager>().addCard(info);
    }

    public void isHitForKeyword(string[] searchWordArray)
    {
        for (int i = 0; i < searchWordArray.Length; i++)
        {
            Debug.Log(searchWordArray[i]);
            if (!name.Contains(searchWordArray[i]))
            {
                this.gameObject.SetActive(false);
                return;
            }
        }
        this.gameObject.SetActive(true);
        return;
    }

    public void onSearchCardListImageButton()
    {
        m_CardGuideUtil.onShowInfo(info);
    }
}
