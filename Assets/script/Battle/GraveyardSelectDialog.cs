using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraveyardSelectDialog : MonoBehaviour
{
    [SerializeField] BattleStrix m_BattleStrix;
    [SerializeField] EventAnimationManager m_EventAnimationManager;
    [SerializeField] GameManager m_GameManager;
    [SerializeField] DialogManager m_DialogManager;
    [SerializeField] Button OKBtn;

    public List<GraveyardSelectDialogBtnUtil> m_GraveyardSelectDialogBtnUtilList = new List<GraveyardSelectDialogBtnUtil>();

    private enum Mode
    {
        VOID,
        GraveYardSelect_Mine,
        GraveYardSelect_Enemy,
        MemorySelect_Mine,
        MemorySelect_Enemy,
    }

    private Mode mode = Mode.VOID;

    private int maxNum = -1;

    private int minNum = -1;

    private BattleModeCard m_BattleModeCard;

    public void SetParamater(BattleModeCard m_BattleModeCard)
    {
        this.m_BattleModeCard = m_BattleModeCard;
        switch (m_BattleModeCard.cardNo)
        {
            case EnumController.CardNo.P3_S01_057:
                mode = Mode.GraveYardSelect_Enemy;
                maxNum = 1;
                minNum = 0;
                break;
            default:
                mode = Mode.VOID;
                maxNum = -1;
                minNum = -1;
                break;
        }

        switch (mode)
        {
            case Mode.GraveYardSelect_Mine:
            case Mode.GraveYardSelect_Enemy:
                for(int i = 0; i < m_GraveyardSelectDialogBtnUtilList.Count; i++)
                {
                    if(i < m_GameManager.enemyGraveYardList.Count)
                    {
                        m_GraveyardSelectDialogBtnUtilList[i].SetBattleModeCard(m_GameManager.enemyGraveYardList[i]);
                    }
                    else
                    {
                        m_GraveyardSelectDialogBtnUtilList[i].SetBattleModeCard(null);
                    }

                }
                break;
            case Mode.MemorySelect_Mine:
            case Mode.MemorySelect_Enemy:
                break;
            case Mode.VOID:
            default:
                break;
        }

        switch (m_BattleModeCard.cardNo)
        {
            case EnumController.CardNo.P3_S01_057:
                for (int i = 0; i < m_GraveyardSelectDialogBtnUtilList.Count; i++)
                {
                    if(m_GraveyardSelectDialogBtnUtilList[i].m_BattleModeCard == null)
                    {
                        continue;
                    }

                    if (m_GraveyardSelectDialogBtnUtilList[i].m_BattleModeCard.type == EnumController.Type.EVENT)
                    {
                        m_GraveyardSelectDialogBtnUtilList[i].button.interactable = true;
                    }
                    else
                    {
                        m_GraveyardSelectDialogBtnUtilList[i].button.interactable = false;
                    }
                }
                break;
            default:
                break;
        }

        m_BattleStrix.RpcToAll("NotEraseDialog", true, m_GameManager.isFirstAttacker);
        this.gameObject.SetActive(true);
    }

    public void switchOKBtn()
    {
        int cnt = 0;
        for(int i = 0; i < m_GraveyardSelectDialogBtnUtilList.Count; i++)
        {
            if (m_GraveyardSelectDialogBtnUtilList[i].isSelected)
            {
                cnt++;
            }
        }
        if(cnt >= minNum && maxNum >= cnt)
        {
            OKBtn.interactable = true;
        }
        else
        {
            OKBtn.interactable = false;
        }
    }

    public void onOKBtn()
    {
        List<BattleModeCard> deckListTemp = new List<BattleModeCard>();
        List<BattleModeCard> memoryListTemp = new List<BattleModeCard>();
        List<BattleModeCard> stockListTemp = new List<BattleModeCard>();
        List<BattleModeCard> graveyardTemp = new List<BattleModeCard>();
        List<BattleModeCard> clockListTemp = new List<BattleModeCard>();
        List<BattleModeCard> handListTemp = new List<BattleModeCard>();
        List<BattleModeCard> tempList = new List<BattleModeCard>();

        List<BattleModeCardTemp> m_deckListTemp = new List<BattleModeCardTemp>();
        List<BattleModeCardTemp> m_memoryListTemp = new List<BattleModeCardTemp>();
        List<BattleModeCardTemp> m_stockListTemp = new List<BattleModeCardTemp>();
        List<BattleModeCardTemp> m_graveyardTemp = new List<BattleModeCardTemp>();
        List<BattleModeCardTemp> m_clockListTemp = new List<BattleModeCardTemp>();
        List<BattleModeCardTemp> m_handListTemp = new List<BattleModeCardTemp>();

        ExecuteActionTemp m_ExecuteActionTemp = new ExecuteActionTemp();

        EnumController.ConfirmSearchOrSulvageCardDialog ConfirmSearchOrSulvageCardDialogParamater = EnumController.ConfirmSearchOrSulvageCardDialog.VOID;

        switch (m_BattleModeCard.cardNo)
        {
            case EnumController.CardNo.P3_S01_057:
                memoryListTemp = m_GameManager.enemyMemoryList;
                stockListTemp = m_GameManager.enemyStockList;
                graveyardTemp = m_GameManager.enemyGraveYardList;
                clockListTemp = m_GameManager.enemyClockList;
                handListTemp = m_GameManager.enemyHandList;

                for (int i = 0; i < m_GraveyardSelectDialogBtnUtilList.Count; i++)
                {
                    if (m_GraveyardSelectDialogBtnUtilList[i].isSelected)
                    {
                        tempList.Add(m_GraveyardSelectDialogBtnUtilList[i].m_BattleModeCard);
                        memoryListTemp.Add(m_GraveyardSelectDialogBtnUtilList[i].m_BattleModeCard);
                        graveyardTemp.RemoveAt(i);
                    }
                }
                ConfirmSearchOrSulvageCardDialogParamater = EnumController.ConfirmSearchOrSulvageCardDialog.P3_S01_057;
                break;
            default:
                break;
        }

        for (int i = 0; i < memoryListTemp.Count; i++)
        {
            m_memoryListTemp.Add(new BattleModeCardTemp(memoryListTemp[i]));
        }
        for (int i = 0; i < stockListTemp.Count; i++)
        {
            m_stockListTemp.Add(new BattleModeCardTemp(stockListTemp[i]));
        }
        for (int i = 0; i < graveyardTemp.Count; i++)
        {
            m_graveyardTemp.Add(new BattleModeCardTemp(graveyardTemp[i]));
        }
        for (int i = 0; i < clockListTemp.Count; i++)
        {
            m_clockListTemp.Add(new BattleModeCardTemp(clockListTemp[i]));
        }
        for (int i = 0; i < handListTemp.Count; i++)
        {
            m_handListTemp.Add(new BattleModeCardTemp(handListTemp[i]));
        }

        m_ExecuteActionTemp.enemy_memoryList = m_memoryListTemp;
        m_ExecuteActionTemp.enemy_stockList = m_stockListTemp;
        m_ExecuteActionTemp.enemy_graveyardList = m_graveyardTemp;
        m_ExecuteActionTemp.enemy_memoryList = m_memoryListTemp;
        m_ExecuteActionTemp.enemy_clockList = m_clockListTemp;
        m_ExecuteActionTemp.enemy_handList = m_handListTemp;
        m_ExecuteActionTemp.isFirstAttacker = m_GameManager.isFirstAttacker;

        m_BattleStrix.SendConfirmSearchOrSulvageCardDialog(tempList, ConfirmSearchOrSulvageCardDialogParamater, m_ExecuteActionTemp, m_GameManager.isFirstAttacker);
        m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
        OffDialog();
    }

    public void OffDialog()
    {
        this.gameObject.SetActive(false);
    }
}
