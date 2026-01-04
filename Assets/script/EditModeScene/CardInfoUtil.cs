using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EnumController;

public class CardInfoUtil : MonoBehaviour
{
    ExtendUtil.ExtendUtil extendUtil = new ExtendUtil.ExtendUtil();
    [SerializeField] CardGuideUtil m_CardGuideUtil;
    [SerializeField] BattleModeCard m_BattleModeCard;

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
        cardName = m_BattleModeCard.name;
        ChangeLayoutColor();
        ChangeText();
    }

    void ChangeLayoutColor()
    {
        switch (m_BattleModeCard.GetCardColor())
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
        cardNoText.text = extendUtil.CardNoConvertToString(m_BattleModeCard.GetCardNo());

        if (cardName != null)
        {
            cardNameText.text = cardName;
        }
        else
        {
            cardNameText.text = "";
        }

        if(m_BattleModeCard.GetAttribute().Count > 0)
        {
            attributeOneText.text = extendUtil.AttributeConvertToString(m_BattleModeCard.GetAttribute(0));
        }
        else
        {
            attributeOneText.text = "";
        }

        if (m_BattleModeCard.GetAttribute().Count > 1)
        {
            attributeTwoText.text = extendUtil.AttributeConvertToString(m_BattleModeCard.GetAttribute(1));
        }
        else
        {
            attributeTwoText.text = "";
        }

        if (m_BattleModeCard.GetAttribute().Count > 2)
        {
            attributeThreeText.text = extendUtil.AttributeConvertToString(m_BattleModeCard.GetAttribute(2));
        }
        else
        {
            attributeThreeText.text = "";
        }
        
        levelText.text = m_BattleModeCard.GetLevel().ToString();
        costText.text = m_BattleModeCard.GetCost().ToString();
    }

    public void onAddListButton()
    {
        deckList.GetComponent<DeckListManager>().addCard(m_BattleModeCard);
    }

    public void isHitForKeyword(string[] searchWordArray, SearchFilter filter)
    {
        for (int i = 0; i < searchWordArray.Length; i++)
        {
            if (!cardName.Contains(searchWordArray[i]))
            {
                this.gameObject.SetActive(false);
                return;
            }
            if (!isSearchLevel(filter))
            {
                this.gameObject.SetActive(false);
                return;
            }
            if (!isSearchColor(filter))
            {
                this.gameObject.SetActive(false);
                return;
            }
            if (!isSearchType(filter))
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
        m_CardGuideUtil.onShowInfo(m_BattleModeCard);
    }

    private bool isSearchLevel(SearchFilter filter)
    {
        switch (m_BattleModeCard.GetLevel())
        {
            case 0:
                if (!filter.isLevelZero)
                {
                    return false;
                }
                break;
            case 1:
                if (!filter.isLevelOne)
                {
                    return false;
                }
                break;
            case 2:
                if (!filter.isLevelTwo)
                {
                    return false;
                }
                break;
            case 3:
                if (!filter.isLevelThree)
                {
                    return false;
                }
                break;
            default:
                if (!filter.isLevelZero || !filter.isLevelOne || !filter.isLevelTwo || !filter.isLevelThree)
                {
                    return false;
                }
                break;
        }
        return true;
    }

    private bool isSearchColor(SearchFilter filter)
    {
        switch (m_BattleModeCard.GetCardColor())
        {
            case EnumController.CardColor.RED:
                if (!filter.isColorRed)
                {
                    return false;
                }
                break;
            case EnumController.CardColor.BLUE:
                if (!filter.isColorBlue)
                {
                    return false;
                }
                break;
            case EnumController.CardColor.YELLOW:
                if (!filter.isColorYellow)
                {
                    return false;
                }
                break;
            case EnumController.CardColor.GREEN:
                if (!filter.isColorGreen)
                {
                    return false;
                }
                break;
            case EnumController.CardColor.PURPLE:
                if (!filter.isColorPurple)
                {
                    return false;
                }
                break;
            case EnumController.CardColor.VOID:
            default:
                if (!filter.isColorRed || !filter.isColorBlue || !filter.isColorGreen || !filter.isColorYellow || !filter.isColorPurple)
                {
                    return false;
                }
                break;
        }
        return true;
    }

    private bool isSearchType(SearchFilter filter)
    {
        switch (m_BattleModeCard.GetType())
        {
            case EnumController.Type.CHARACTER:
                if (!filter.isTypeCharacter)
                {
                    return false;
                }
                break;
            case EnumController.Type.EVENT:
                if (!filter.isTypeEvent)
                {
                    return false;
                }
                break;
            case EnumController.Type.CLIMAX:
                if (!filter.isTypeClimax)
                {
                    return false;
                }
                break;
            case EnumController.Type.VOID:
            default:
                if (!filter.isTypeCharacter || !filter.isTypeEvent || !filter.isTypeClimax)
                {
                    return false;
                }
                break;
        }
        return true;
    }
}
