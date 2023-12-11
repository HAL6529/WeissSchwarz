using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandOverDialog : MonoBehaviour
{
    [SerializeField] MyHandCardsManager m_MyHandCardsManager;
    [SerializeField] GameObject button;
    [SerializeField] Text text;
    [SerializeField] GameManager m_GameManager;
    private bool isActive = false;

    public void SetParamater(EnumController.HandOverDialogParamater paramater)
    {
        switch (paramater)
        {
            case EnumController.HandOverDialogParamater.Active:
                Active();
                break;
            case EnumController.HandOverDialogParamater.Confirm:
                Confirm();
                break;
            default:
                break;
        }
    }

    public void Active()
    {
        text.text = "ŽèŽD‚ª7–‡‚É‚È‚é‚æ‚¤‚ÉŽÌ‚Ä‚Ä‚­‚¾‚³‚¢";
        this.gameObject.SetActive(true);
        button.SetActive(false);
        Confirm();
    }

    public void Confirm()
    {
        if(m_MyHandCardsManager.GetIsSelectedNum() == m_GameManager.myHandList.Count - m_GameManager.GetHAND_LIMIT_NUM())
        {
            button.SetActive(true);
            return;
        }
        button.SetActive(false);
    }

    public void OffDialog()
    {
        this.gameObject.SetActive(false);
    }

    public void onOKbutton()
    {
        this.gameObject.SetActive(false);
        button.SetActive(false);
        m_GameManager.HandOver();
    }
}
