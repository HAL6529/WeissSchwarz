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
    /// フィールド上でのパワー
    /// </summary>
    private int FieldPower = 0;

    /// <summary>
    /// フィールド上でのステータス
    /// </summary>
    private EnumController.State state = EnumController.State.STAND;

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
        m_BattleModeGuide.showImage(m_BattleModeCard);
    }

    public void Rest()
    {
        this.gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 270.0f);
        state = EnumController.State.REST;
    }

    public void Stand()
    {
        this.gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);
        state = EnumController.State.STAND;
    }

    public void Reverse()
    {
        this.gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        state = EnumController.State.REVERSE;
    }

    public void SetFieldPower(int power)
    {
        FieldPower = power;
        PowerText.text = FieldPower.ToString();
    }

    public int GetFieldPower()
    {
        return FieldPower;
    }
}
