using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleEnemyMainCardUtil : MonoBehaviour
{
    private BattleModeCard m_BattleModeCard = null;
    [SerializeField] GameObject Power;
    [SerializeField] Text PowerText;
    [SerializeField] GameManager m_GameManager;
    [SerializeField] Image image;
    [SerializeField] BattleModeGuide m_BattleModeGuide;

    /// <summary>
    /// フィールド上でのステータス
    /// </summary>
    private EnumController.State state = EnumController.State.STAND;

    /// <summary>
    /// フィールド上でのパワー
    /// </summary>
    private int FieldPower = 0;

    /// <summary>
    /// フィールド上でのソウル
    /// </summary>
    public int FieldSoul = 0;

    /// <summary>
    /// フィールド上でのレベル
    /// </summary>
    public int FieldLevel = 0;

    /// <summary>
    /// フィールド上での特徴
    /// </summary>
    public List<EnumController.Attribute> AttributeList = new List<EnumController.Attribute>();

    /// <summary>
    /// 大活躍をもっているか
    /// </summary>
    public bool isGreatPerformance = false;

    // Start is called before the first frame update
    void Start()
    {
        changeSprite();
    }

    public void setBattleModeCard(BattleModeCard card)
    {
        m_BattleModeCard = card;
        changeSprite();
    }

    private void changeSprite()
    {
        if (m_BattleModeCard == null)
        {
            image.sprite = null;
            image.color = new Color(1, 1, 1, 0 / 255);
            Power.SetActive(false);
            return;
        }
        image.sprite = m_BattleModeCard.sprite;
        image.color = new Color(1, 1, 1, 255 / 255);

        Power.SetActive(true);
        PowerText.text = FieldPower.ToString();
    }

    public void onClick()
    {
        // ---ここからカードのガイド用---
        BattleModeCard t_BattleModeCard = new BattleModeCard();
        t_BattleModeCard.power = FieldPower;
        t_BattleModeCard.soul = FieldSoul;
        t_BattleModeCard.level = FieldLevel;

        m_BattleModeGuide.showImage(m_BattleModeCard, t_BattleModeCard);
        // ---ここまでカードのガイド用---
    }

    public void Rest()
    {
        state = EnumController.State.REST;
        this.gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 270.0f);
    }

    public void Stand()
    {
        state = EnumController.State.STAND;
        this.gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);
    }

    public void Reverse()
    {
        state = EnumController.State.REVERSE;
        this.gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
    }

    public int GetFieldPower()
    {
        return FieldPower;
    }

    public bool GetIsGreatPerformance()
    {
        return isGreatPerformance;
    }

    public EnumController.State GetState()
    {
        return state;
    }

    public void SetFieldLevel(int level)
    {
        FieldLevel = level;
    }

    public void SetFieldPower(int power)
    {
        FieldPower = power;
        PowerText.text = FieldPower.ToString();
    }

    public void SetFieldSoul(int soul)
    {
        FieldSoul = soul;
    }

    public void SetIsGreatProcess(bool b)
    {
        isGreatPerformance = b;
    }

    public void SetIsGreatPerformance(bool b)
    {
        isGreatPerformance = b;
    }
}
