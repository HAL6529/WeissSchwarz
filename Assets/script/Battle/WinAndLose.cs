using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinAndLose : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] DialogManager m_DialogManager;
    [SerializeField] NotEraseDialog m_NotEraseDialog;
    [SerializeField] StrixManager m_StrixManager;
    bool flg = false;

    public void Win()
    {
        if (flg)
        {
            return;
        }
        flg = true;
        m_DialogManager.CloseAllDialog();
        m_NotEraseDialog.OffDialog();
        this.gameObject.SetActive(true);
        text.text = "Win";
    }

    public void Lose()
    {
        if (flg)
        {
            return;
        }
        flg = true;
        m_DialogManager.CloseAllDialog();
        m_NotEraseDialog.OffDialog();
        this.gameObject.SetActive(true);
        text.text = "Lose";
    }

    public void onHomeBtn()
    {
        if(m_StrixManager != null)
        {
            m_StrixManager.onExit();
        }
        SceneManager.LoadScene("RoomSelect");
    }
}
