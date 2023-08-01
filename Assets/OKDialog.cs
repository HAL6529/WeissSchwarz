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

    private EnumController.DialogParamater m_DialogParamater;
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
        m_DialogParamater = EnumController.DialogParamater.VOID;
    }

    public void SetParamater(EnumController.DialogParamater paramater)
    {
        this.gameObject.SetActive(true);
        m_DialogParamater = paramater;
        SetText();
    }

    private void SetText()
    {
        string str = "";
        if (m_DialogParamater == EnumController.DialogParamater.Marigan)
        {
            str = "マリガンするカードを選択してください";
        }
        text.text = str;
    }

    public void onClick()
    {
        if(m_DialogParamater == EnumController.DialogParamater.Marigan)
        {
            m_GameManager.MariganEnd();
        }
        this.gameObject.SetActive(false);
    }
}
