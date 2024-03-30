using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecuteAction
{
    public BattleStrix m_BattleStrix { get; set; }
    public ExecuteActionTemp m_ExecuteActionTemp { get; set; }
    public GameManager m_GameManager { get; set; }
    public BattleModeCardList m_BattleModeCardList { get; set; }

    public ExecuteAction()
    {
        m_BattleStrix = null; 
        m_ExecuteActionTemp = null;
        m_GameManager = null;
    }

    public ExecuteAction(ExecuteActionTemp m_ExecuteActionTemp)
    {
        m_BattleStrix = null;
        this.m_ExecuteActionTemp = m_ExecuteActionTemp;
        m_GameManager = null;
    }

    public void ComeBackActionAfterConfirmDialog()
    {
        if (m_GameManager == null || m_BattleModeCardList == null)
        {
            return;
        }
        if (m_ExecuteActionTemp.m_BattleModeCardTempList.Count == 0)
        {
            return;
        }
        List <BattleModeCard> BattleModeCardList = new List<BattleModeCard>();
        for (int i = 0; i < m_ExecuteActionTemp.m_BattleModeCardTempList.Count; i++)
        {
            BattleModeCard b = m_BattleModeCardList.ConvertCardNoToBattleModeCard(m_ExecuteActionTemp.m_BattleModeCardTempList[i].cardNo);
            BattleModeCardList.Add(b);
        }

        for (int i = 0; i < BattleModeCardList.Count; i++)
        {
            m_GameManager.myHandList.Add(BattleModeCardList[i]);
            m_GameManager.GraveYardList.Remove(BattleModeCardList[i]);
        }
        m_GameManager.Syncronize();


        if (m_ExecuteActionTemp.damageParamater == EnumController.Damage.FRONT_ATTACK)
        {
            m_BattleStrix.RpcToAll("CallOKDialogForCounter", m_ExecuteActionTemp.intParamater, m_ExecuteActionTemp.intParamater2, m_ExecuteActionTemp.isFirstAttacker, m_ExecuteActionTemp.SendShotList);
            return;
        }
        m_BattleStrix.RpcToAll("Damage", m_ExecuteActionTemp.intParamater, m_ExecuteActionTemp.isFirstAttacker, m_ExecuteActionTemp.damageParamater, m_ExecuteActionTemp.SendShotList);
    }
}
