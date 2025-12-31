using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_DC_W01_03T : EffectAbstract
{
    public override void EventExecute1()
    {
        //※イベント
        // あなたは自分の山札を上から1枚選び、ストック置場に置く。あなたは自分のキャラを1枚選び、そのターン中、パワーを＋500。
        m_GameManager.myStockList.Add(m_GameManager.myDeckList[0]);
        m_GameManager.myDeckList.RemoveAt(0);
        m_GameManager.Syncronize();

        if (m_GameManager.myDeckList.Count == 0)
        {
            if (m_GameManager.GraveYardList.Count == 0)
            {
                // 控室が0枚なら負け扱い
                m_BattleStrix.RpcToAll("WinAndLose_Win", m_GameManager.isFirstAttacker);
                m_WinAndLose.Lose();
                return;
            }

            for (int n = 0; n < m_GameManager.GraveYardList.Count; n++)
            {
                m_GameManager.myDeckList.Add(m_GameManager.GraveYardList[n]);
            }
            m_GameManager.GraveYardList = new List<BattleModeCard>();
            m_GameManager.Shuffle();
            m_GameManager.Syncronize();
            Action action1 = new Action(m_GameManager, EnumController.Action.DamageRefresh);
            action1.SetParamaterBattleStrix(m_BattleStrix);
            action1.SetParamaterWinAndLose(m_WinAndLose);

            m_GameManager.ActionList.Add(action1);
        }
        Action action2 = new Action(m_GameManager, EnumController.Action.EventAnimationManager);
        action2.SetParamaterBattleModeCard(m_BattleModeCard);
        m_GameManager.ActionList.Add(action2);
        m_MainPowerUpDialog.SetBattleMordCard(m_BattleModeCard);
        return;
    }
}
