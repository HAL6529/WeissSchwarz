using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EnumController;

public class CardInfoUtil : MonoBehaviour
{

    private cardInfo info;

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

    // Start is called before the first frame update
    void Start()
    {
        info = GetComponent<cardInfo>();
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
        cardNoText.text = "";
        string name = info.cardName;

        if (name != null)
        {
            cardNameText.text = name;
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

    /// <summary>
    /// 検索する関数
    /// </summary>
    /// <param name="level">int型 レベル</param>
    /// <param name="cost">int型 コスト</param>
    /// <param name="power">int型　パワー</param>
    /// <param name="color">EnumController.CardColor型　色</param>
    /// <param name="trigger">EnumController.Trriger型　トリガー</param>
    public void Search(int level, int cost, int power, EnumController.CardColor color, EnumController.Trriger trigger)
    {
        /*if (this.level != level && level != -1)
        {
            return;
        }

        if (this.cost != cost && cost != -1)
        {
            return;
        }

        if (this.power != cost && power != -1)
        {
            return;
        }

        if (this.color != color)
        {
            return;
        }

        if (this.trigger != trigger)
        {
            return;
        }*/
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
}
