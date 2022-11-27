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
    CardNoToExplanation m_CardNoToExplanation = new CardNoToExplanation();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showImage(BattleModeCard card)
    {
        image.sprite = card.sprite;
        name.text = card.name;
        cost.text = card.cost.ToString();
        level.text = card.level.ToString();
        explanation.text = m_CardNoToExplanation.Explanation(card.cardNo);
    }
}
