using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EnumController;

public class YesOrNoDialog : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] BattleStrix m_BattleStrix;
    [SerializeField] GameManager m_GameManager;
    [SerializeField] MyHandCardsManager m_MyHandCardsManager;

    private BattleModeCard m_BattleModeCard = null;

    private EnumController.YesOrNoDialogParamater m_YesOrNoDialogParamater;

    public YesOrNoDialog()
    {
        m_YesOrNoDialogParamater = EnumController.YesOrNoDialogParamater.VOID;
    }

    public void SetParamater(EnumController.YesOrNoDialogParamater paramater)
    {
        this.gameObject.SetActive(true);
        m_YesOrNoDialogParamater = paramater;
        SetText();
    }

    public void SetParamater(EnumController.YesOrNoDialogParamater paramater, BattleModeCard card)
    {
        m_BattleModeCard = card;
        this.gameObject.SetActive(true);
        m_YesOrNoDialogParamater = paramater;
        SetText();
    }

    private void SetText()
    {
        string str = "";
        switch (m_YesOrNoDialogParamater)
        {
            case EnumController.YesOrNoDialogParamater.CLIMAX_PHASE:
                str = "クライマックスフェイズに移動しますか";
                break;
            case EnumController.YesOrNoDialogParamater.VOID:
                str = "無効メッセージ";
                break;
            default:
                str = "無効メッセージ";
                break;
        }
        text.text = str;
    }

    public void onYesClick()
    {
        switch (m_YesOrNoDialogParamater)
        {
            case EnumController.YesOrNoDialogParamater.CLIMAX_PHASE:
                m_GameManager.SendClimaxPhase(m_BattleModeCard);
                break;
            case EnumController.YesOrNoDialogParamater.VOID:
                break;
            default:
                break;
        }
        m_MyHandCardsManager.CallNotShowPlayButton();
        this.gameObject.SetActive(false);
    }

    public void onNoClick()
    {
        m_MyHandCardsManager.CallNotShowPlayButton();
        this.gameObject.SetActive(false);
    }

    public void OffDialog()
    {
        this.gameObject.SetActive(false);
    }
}
