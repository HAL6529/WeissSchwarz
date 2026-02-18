using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_043 : EffectAbstract
{
    public override void EventExecute1()
    {
        // ※イベント
        //【カウンター】 あなたは自分のキャラすべてに、そのターン中、パワーを＋1000。そうする時、相手の前列のキャラすべてが【レスト】しているなら、かわりにパワーを＋3000。
        PayCost(3);
        int count = 0;
        int power = 1000;
        for (int i = 0; i < 2; i++)
        {
            if (m_EnemyMainCardsManager.GetState(i) == EnumController.State.STAND || m_GameManager.enemyFieldList[i] == null)
            {
                count++;
            }
        }

        if (count >= 3)
        {
            power = 3000;
        }

        for (int i = 0; i < m_GameManager.myFieldList.Count; i++)
        {
            if (m_GameManager.myFieldList[i] != null)
            {
                m_MyMainCardsManager.AddPowerUpUntilTurnEnd(i, power);
            }
        }
        m_GameManager.GraveYardList.Add(m_GameManager.myHandList[GetIntParamater1()]);
        m_GameManager.myHandList.RemoveAt(GetIntParamater1());
        m_GameManager.Syncronize();
        m_GameManager.ExecuteActionList();
        return;
    }
}
