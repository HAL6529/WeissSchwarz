using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SulvageDialog : MonoBehaviour
{
    [SerializeField] Text m_Text;
    [SerializeField] List<SulvageDialogBtnUtil> SulvageDialogBtnUtilList = new List<SulvageDialogBtnUtil>();
    [SerializeField] GameObject OkButton;
    [SerializeField] BattleStrix m_BattleStrix;
    [SerializeField] GameManager m_GameManager;
    [SerializeField] EventAnimationManager m_EventAnimationManager;

    private List<BattleModeCard> BattleModeCardList = new List<BattleModeCard>();

    private BattleModeCard m_BattleModeCardForEvent = null;
    /// <summary>
    /// 回収するカードの最低枚数
    /// </summary>
    private int minSulvageCard = 0;

    /// <summary>
    /// 回収できる最大枚数
    /// </summary>
    private int maxSulvageCard = 0;

    public void SetBattleModeCard(BattleModeCard card, List<BattleModeCard> list, EnumController.Type type, int minSulvageCard, int maxSulvageCard)
    {
        m_BattleModeCardForEvent = card;
        BattleModeCardList = new List<BattleModeCard>();
        List<BattleModeCard> tempList = new List<BattleModeCard>();
        this.minSulvageCard = minSulvageCard;
        this.maxSulvageCard = maxSulvageCard;
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].type == type)
            {
                tempList.Add(list[i]);
            }
        }
        // 回収するカードがない場合
        if (tempList.Count == 0)
        {
            return;
        }
        this.gameObject.SetActive(true);

        for (int i = 0; i < SulvageDialogBtnUtilList.Count; i++)
        {
            if (i < tempList.Count)
            {
                SulvageDialogBtnUtilList[i].setBattleModeCard(tempList[i]);
            }
            else
            {
                SulvageDialogBtnUtilList[i].setBattleModeCard(null);
            }
        }

        if (BattleModeCardList.Count > maxSulvageCard || minSulvageCard > BattleModeCardList.Count)
        {
            OkButton.SetActive(false);
        }
        else
        {
            OkButton.SetActive(true);
        }
    }

    public void AddBattleModeCard(BattleModeCard card)
    {
        BattleModeCardList.Add(card);

        if(BattleModeCardList.Count > maxSulvageCard || minSulvageCard > BattleModeCardList.Count)
        {
            OkButton.SetActive(false);
        }
        else
        {
            OkButton.SetActive(true);
        }
    }

    private void ChangeText()
    {
        switch (m_BattleModeCardForEvent.cardNo)
        {
            case EnumController.CardNo.DC_W01_12T:
                m_Text.text = "手札に加えるカードを2枚まで選択してください";
                break;
            default:
                m_Text.text = "手札に加えるカードを選択してください";
                break;
        }
    }

    public void RemoveBattleModeCard(BattleModeCard card)
    {
        BattleModeCardList.Remove(card);

        if (BattleModeCardList.Count > maxSulvageCard || minSulvageCard > BattleModeCardList.Count)
        {
            OkButton.SetActive(false);
        }
        else
        {
            OkButton.SetActive(true);
        }
    }

    public void onOkDialog()
    {
        this.gameObject.SetActive(false);
        List<BattleModeCard> graveyardTemp = m_GameManager.GraveYardList;
        List<BattleModeCard> handListTemp = m_GameManager.myHandList;
        List<BattleModeCard> sulvageListTemp = new List<BattleModeCard>();
        sulvageListTemp = BattleModeCardList;

        for (int i = 0;i < sulvageListTemp.Count; i++)
        {
            graveyardTemp.Remove(sulvageListTemp[i]);
            handListTemp.Add(sulvageListTemp[i]);
        }
        handListTemp.Remove(m_BattleModeCardForEvent);
        graveyardTemp.Add(m_BattleModeCardForEvent);

        List<BattleModeCardTemp> m_graveyardTemp = new List<BattleModeCardTemp>();
        List<BattleModeCardTemp> m_handListTemp = new List<BattleModeCardTemp>();
        for (int i = 0; i < graveyardTemp.Count; i++)
        {
            m_graveyardTemp.Add(new BattleModeCardTemp(graveyardTemp[i]));
        }
        for (int i = 0; i < handListTemp.Count; i++)
        {
            m_handListTemp.Add(new BattleModeCardTemp(handListTemp[i]));
        }

        ExecuteActionTemp m_ExecuteActionTemp = new ExecuteActionTemp();
        m_ExecuteActionTemp.graveyardList = m_graveyardTemp;
        m_ExecuteActionTemp.handList = m_handListTemp;

        m_BattleStrix.SendConfirmSearchOrSulvageCardDialog(sulvageListTemp, EnumController.ConfirmSearchOrSulvageCardDialog.DC_W01_12T, m_ExecuteActionTemp, m_GameManager.isFirstAttacker);
    }

    public void onCloseButton()
    {
        this.gameObject.SetActive(false);
        return;
    }
}
