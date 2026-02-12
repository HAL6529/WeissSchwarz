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

    private int place = -1;

    private BattleModeCard m_BattleModeCard;

    public void SetParamater(BattleModeCard m_BattleModeCard)
    {
        SetParamater(m_BattleModeCard, -1);
    }

    public void SetParamater(BattleModeCard m_BattleModeCard, int place)
    {
        this.m_BattleModeCard = m_BattleModeCard;
        this.place = place;
        switch (m_BattleModeCard.GetCardNo())
        {
            case EnumController.CardNo.P3_S01_057:
            case EnumController.CardNo.P3_S01_061:
                mode = Mode.GraveYardSelect_Enemy;
                maxNum = 1;
                minNum = 0;
                break;
            case EnumController.CardNo.P3_S01_080:
                mode = Mode.GraveYardSelect_Mine;
                maxNum = 1;
                minNum = 1;
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
                for (int i = 0; i < m_GraveyardSelectDialogBtnUtilList.Count; i++)
                {
                    if (i < m_GameManager.GraveYardList.Count)
                    {
                        m_GraveyardSelectDialogBtnUtilList[i].SetBattleModeCard(m_GameManager.GraveYardList[i]);
                    }
                    else
                    {
                        m_GraveyardSelectDialogBtnUtilList[i].SetBattleModeCard(null);
                    }

                }
                break;
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

        switch (m_BattleModeCard.GetCardNo())
        {
            case EnumController.CardNo.P3_S01_057:
                for (int i = 0; i < m_GraveyardSelectDialogBtnUtilList.Count; i++)
                {
                    if(m_GraveyardSelectDialogBtnUtilList[i].m_BattleModeCard == null)
                    {
                        continue;
                    }

                    if (m_GraveyardSelectDialogBtnUtilList[i].m_BattleModeCard.GetType() == EnumController.Type.EVENT)
                    {
                        m_GraveyardSelectDialogBtnUtilList[i].button.interactable = true;
                    }
                    else
                    {
                        m_GraveyardSelectDialogBtnUtilList[i].button.interactable = false;
                    }
                }
                break;
            case EnumController.CardNo.P3_S01_080:
                for (int i = 0; i < m_GraveyardSelectDialogBtnUtilList.Count; i++)
                {
                    if (m_GraveyardSelectDialogBtnUtilList[i].m_BattleModeCard == null)
                    {
                        continue;
                    }

                    if (m_GraveyardSelectDialogBtnUtilList[i].m_BattleModeCard.GetType() != EnumController.Type.CLIMAX)
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
        List<BattleModeCard> m_deckListTemp = new List<BattleModeCard>();
        List<BattleModeCard> m_memoryListTemp = new List<BattleModeCard>();
        List<BattleModeCard> m_stockListTemp = new List<BattleModeCard>();
        List<BattleModeCard> m_graveyardTemp = new List<BattleModeCard>();
        List<BattleModeCard> m_clockListTemp = new List<BattleModeCard>();
        List<BattleModeCard> m_handListTemp = new List<BattleModeCard>();
        List<BattleModeCard> m_myFieldListTemp = new List<BattleModeCard> { null, null, null, null, null };
        List<BattleModeCard> e_memoryListTemp = new List<BattleModeCard>();
        List<BattleModeCard> e_stockListTemp = new List<BattleModeCard>();
        List<BattleModeCard> e_graveyardTemp = new List<BattleModeCard>();
        List<BattleModeCard> e_clockListTemp = new List<BattleModeCard>();
        List<BattleModeCard> e_handListTemp = new List<BattleModeCard>();
        List<BattleModeCard> tempList = new List<BattleModeCard>();

        List<BattleModeCardTemp> mt_deckListTemp = new List<BattleModeCardTemp>();
        List<BattleModeCardTemp> mt_memoryListTemp = new List<BattleModeCardTemp>();
        List<BattleModeCardTemp> mt_stockListTemp = new List<BattleModeCardTemp>();
        List<BattleModeCardTemp> mt_graveyardTemp = new List<BattleModeCardTemp>();
        List<BattleModeCardTemp> mt_clockListTemp = new List<BattleModeCardTemp>();
        List<BattleModeCardTemp> mt_handListTemp = new List<BattleModeCardTemp>();
        List<BattleModeCardTemp> mt_myFieldListTemp = new List<BattleModeCardTemp> { null, null, null, null, null };
        List<BattleModeCardTemp> et_memoryListTemp = new List<BattleModeCardTemp>();
        List<BattleModeCardTemp> et_stockListTemp = new List<BattleModeCardTemp>();
        List<BattleModeCardTemp> et_graveyardTemp = new List<BattleModeCardTemp>();
        List<BattleModeCardTemp> et_clockListTemp = new List<BattleModeCardTemp>();
        List<BattleModeCardTemp> et_handListTemp = new List<BattleModeCardTemp>();

        ExecuteActionTemp m_ExecuteActionTemp = new ExecuteActionTemp();

        EnumController.ConfirmSearchOrSulvageCardDialog ConfirmSearchOrSulvageCardDialogParamater = EnumController.ConfirmSearchOrSulvageCardDialog.VOID;

        switch (m_BattleModeCard.GetCardNo())
        {
            case EnumController.CardNo.P3_S01_057:
                e_memoryListTemp = m_GameManager.enemyMemoryList;
                e_stockListTemp = m_GameManager.enemyStockList;
                e_graveyardTemp = m_GameManager.enemyGraveYardList;
                e_clockListTemp = m_GameManager.enemyClockList;
                e_handListTemp = m_GameManager.enemyHandList;

                for (int i = 0; i < m_GraveyardSelectDialogBtnUtilList.Count; i++)
                {
                    if (m_GraveyardSelectDialogBtnUtilList[i].isSelected)
                    {
                        tempList.Add(m_GraveyardSelectDialogBtnUtilList[i].m_BattleModeCard);
                        e_memoryListTemp.Add(m_GraveyardSelectDialogBtnUtilList[i].m_BattleModeCard);
                        e_graveyardTemp.RemoveAt(i);
                    }
                }
                ConfirmSearchOrSulvageCardDialogParamater = EnumController.ConfirmSearchOrSulvageCardDialog.P3_S01_057;
                break;
            case EnumController.CardNo.P3_S01_061:
                e_memoryListTemp = m_GameManager.enemyMemoryList;
                e_stockListTemp = m_GameManager.enemyStockList;
                e_graveyardTemp = m_GameManager.enemyGraveYardList;
                e_clockListTemp = m_GameManager.enemyClockList;
                e_handListTemp = m_GameManager.enemyHandList;
                for (int i = 0; i < m_GraveyardSelectDialogBtnUtilList.Count; i++)
                {
                    if (m_GraveyardSelectDialogBtnUtilList[i].isSelected)
                    {
                        tempList.Add(m_GraveyardSelectDialogBtnUtilList[i].m_BattleModeCard);
                        e_graveyardTemp.RemoveAt(i);
                    }
                }
                ConfirmSearchOrSulvageCardDialogParamater = EnumController.ConfirmSearchOrSulvageCardDialog.P3_S01_061;
                break;
            case EnumController.CardNo.P3_S01_080:
                m_deckListTemp = m_GameManager.myDeckList;
                m_memoryListTemp = m_GameManager.myMemoryList;
                m_stockListTemp = m_GameManager.myStockList;
                m_graveyardTemp = m_GameManager.GraveYardList;
                m_clockListTemp = m_GameManager.myClockList;
                m_handListTemp = m_GameManager.myHandList;
                m_myFieldListTemp = m_GameManager.myFieldList;

                for (int i = 0; i < m_GraveyardSelectDialogBtnUtilList.Count; i++)
                {
                    if (m_GraveyardSelectDialogBtnUtilList[i].isSelected)
                    {
                        tempList.Add(m_GraveyardSelectDialogBtnUtilList[i].m_BattleModeCard);
                        m_deckListTemp.Add(m_GraveyardSelectDialogBtnUtilList[i].m_BattleModeCard);
                        m_graveyardTemp.RemoveAt(i);
                    }
                }
                m_deckListTemp.Add(m_myFieldListTemp[place]);
                m_myFieldListTemp[place] = null;
                ConfirmSearchOrSulvageCardDialogParamater = EnumController.ConfirmSearchOrSulvageCardDialog.P3_S01_080;
                break;
            default:
                break;
        }

        for (int i = 0; i < m_myFieldListTemp.Count; i++)
        {
            mt_myFieldListTemp[i] = new BattleModeCardTemp(m_myFieldListTemp[i]);
        }
        for (int i = 0; i < m_deckListTemp.Count; i++)
        {
            mt_deckListTemp.Add(new BattleModeCardTemp(m_deckListTemp[i]));
        }
        for (int i = 0; i < m_memoryListTemp.Count; i++)
        {
            mt_memoryListTemp.Add(new BattleModeCardTemp(m_memoryListTemp[i]));
        }
        for (int i = 0; i < m_stockListTemp.Count; i++)
        {
            mt_stockListTemp.Add(new BattleModeCardTemp(m_stockListTemp[i]));
        }
        for (int i = 0; i < m_graveyardTemp.Count; i++)
        {
            mt_graveyardTemp.Add(new BattleModeCardTemp(m_graveyardTemp[i]));
        }
        for (int i = 0; i < m_clockListTemp.Count; i++)
        {
            mt_clockListTemp.Add(new BattleModeCardTemp(m_clockListTemp[i]));
        }
        for (int i = 0; i < m_handListTemp.Count; i++)
        {
            mt_handListTemp.Add(new BattleModeCardTemp(m_handListTemp[i]));
        }
        for (int i = 0; i < e_memoryListTemp.Count; i++)
        {
            et_memoryListTemp.Add(new BattleModeCardTemp(e_memoryListTemp[i]));
        }
        for (int i = 0; i < e_stockListTemp.Count; i++)
        {
            et_stockListTemp.Add(new BattleModeCardTemp(e_stockListTemp[i]));
        }
        for (int i = 0; i < e_graveyardTemp.Count; i++)
        {
            et_graveyardTemp.Add(new BattleModeCardTemp(e_graveyardTemp[i]));
        }
        for (int i = 0; i < e_clockListTemp.Count; i++)
        {
            et_clockListTemp.Add(new BattleModeCardTemp(e_clockListTemp[i]));
        }
        for (int i = 0; i < e_handListTemp.Count; i++)
        {
            et_handListTemp.Add(new BattleModeCardTemp(e_handListTemp[i]));
        }

        m_ExecuteActionTemp.deckList = mt_deckListTemp;
        m_ExecuteActionTemp.memoryList = mt_memoryListTemp;
        m_ExecuteActionTemp.stockList = mt_stockListTemp;
        m_ExecuteActionTemp.graveyardList = mt_graveyardTemp;
        m_ExecuteActionTemp.clockList = mt_clockListTemp;
        m_ExecuteActionTemp.handList = mt_handListTemp;
        m_ExecuteActionTemp.myFieldListTemp = mt_myFieldListTemp;
        m_ExecuteActionTemp.enemy_memoryList = et_memoryListTemp;
        m_ExecuteActionTemp.enemy_stockList = et_stockListTemp;
        m_ExecuteActionTemp.enemy_graveyardList = et_graveyardTemp;
        m_ExecuteActionTemp.enemy_clockList = et_clockListTemp;
        m_ExecuteActionTemp.enemy_handList = et_handListTemp;
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
