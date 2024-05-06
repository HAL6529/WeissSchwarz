using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinAndLose : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] DialogManager m_DialogManager;
    [SerializeField] NotEraseDialog m_NotEraseDialog;

    public void Win()
    {
        m_DialogManager.CloseAllDialog();
        m_NotEraseDialog.OffDialog();
        this.gameObject.SetActive(true);
        text.text = "Win";
    }

    public void Lose()
    {
        m_DialogManager.CloseAllDialog();
        m_NotEraseDialog.OffDialog();
        this.gameObject.SetActive(true);
        text.text = "Lose";
    }
}
