using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectActEffectDialog : MonoBehaviour
{
    [SerializeField] Text text1;
    [SerializeField] Text text2;
    [SerializeField] Text text3;
    List<SelectActEffectDialogContent> m_SelectActEffectDialogContentList = new List<SelectActEffectDialogContent>();

    int displayNum = 0;

    public void OKButton()
    {
        OffDialog();
        m_SelectActEffectDialogContentList[displayNum].Execute();
    }

    public void SetContent(List<SelectActEffectDialogContent> m_SelectActEffectDialogContentList)
    {
        this.m_SelectActEffectDialogContentList = m_SelectActEffectDialogContentList;

        if(m_SelectActEffectDialogContentList == null || m_SelectActEffectDialogContentList.Count == 0)
        {
            OffDialog();
        }
        else if(m_SelectActEffectDialogContentList.Count == 1)
        {
            m_SelectActEffectDialogContentList[0].Execute();
        }
        SetText();
        this.gameObject.SetActive(true);
    }

    public void LeftBtn()
    {
        if (displayNum == 0)
        {
            displayNum = m_SelectActEffectDialogContentList.Count - 1;
        }
        else
        {
            displayNum--;
        }
        SetText();
    }

    public void RightBtn()
    {
        if (displayNum == m_SelectActEffectDialogContentList.Count - 1)
        {
            displayNum = 0;
        }
        else
        {
            displayNum++;
        }
        SetText();
    }

    public void SetText()
    {
        text1.text = "";
        text2.text = "";
        text3.text = "";
        List<string> list = m_SelectActEffectDialogContentList[displayNum].GetText();
        if(list == null)
        {
            return;
        }

        text1.text = list[0];
        text2.text = list[1];
        text3.text = list[2];
        return;
    }

    public void OffDialog()
    {
        this.gameObject.SetActive(false);
    }
}
