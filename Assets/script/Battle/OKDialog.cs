using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EnumController;

public class OKDialog : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] BattleStrix m_BattleStrix;
    [SerializeField] GameManager m_GameManager;

    private StringValues stringValues = new StringValues();
    private BattleModeCard m_BattleModeCard = null;

    private EnumController.OKDialogParamater m_DialogParamater;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public OKDialog()
    {
        m_DialogParamater = EnumController.OKDialogParamater.VOID;
    }

    public void SetBattleModeCard(BattleModeCard card)
    {
        m_BattleModeCard = card;
    }

    public void SetParamater(EnumController.OKDialogParamater paramater)
    {
        m_BattleModeCard = null;
        this.gameObject.SetActive(true);
        m_DialogParamater = paramater;
        SetText();
    }

    private void SetText()
    {
        string str = "";
        switch (m_DialogParamater)
        {
            case EnumController.OKDialogParamater.Marigan:
                str = stringValues.OKDialog_Marigan;
                break;
            case EnumController.OKDialogParamater.CLOCK:
                str = stringValues.OKDialog_Clock;
                break;
            default:
                str = "無効メッセージ";
                break;

        }
        text.text = str;
    }

    public void onClick()
    {
        switch (m_DialogParamater)
        {
            case EnumController.OKDialogParamater.Marigan:
                m_GameManager.MariganEnd();
                break;
            case EnumController.OKDialogParamater.CLOCK:
                m_GameManager.ClockAndTwoDraw(m_BattleModeCard);
                break;
            default:
                break;

        }
        this.gameObject.SetActive(false);
    }

    public void OffDialog()
    {
        this.gameObject.SetActive(false);
    }
}
