using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockDialog : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] Image image;
    [SerializeField] GameManager m_GameManager;
    private BattleModeCard m_BattleModeCard = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setText(string text)
    {
        this.gameObject.SetActive(true);
        this.text.text = text;
        changeCardScript();
    }

    public void changeCardScript()
    {
        if(m_BattleModeCard == null)
        {
            image.sprite = null;
            image.color = new Color(1, 1, 1, 0 / 255);
            return;
        }
        else
        {
            image.sprite = m_BattleModeCard.sprite;
            image.color = new Color(1, 1, 1, 255 / 255);
            return;
        }
    }
    
    public void setBattleModeCard(BattleModeCard card)
    {
        m_BattleModeCard = card;
        changeCardScript();
    }

    public void ClockDialogEnd()
    {
        m_BattleModeCard = null;
        this.gameObject.SetActive(false);
    }

    public void onClick()
    {
        ClockDialogEnd();
    }
}
