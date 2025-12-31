using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_LB_W02_037 : EffectAbstract
{
    public override void ActExecute1()
    {
        // 【起】［(1)］ 他のあなたのキャラすべてに、そのターン中、《動物》を与える。
        PayCost(1);
        for (int i = 0; i < m_GameManager.myFieldList.Count; i++)
        {
            if (m_GameManager.myFieldList[i] != null)
            {
                m_MyMainCardsManager.SetAttributeUpUntilTurnEnd(i, EnumController.Attribute.Animal);
            }
        }
        m_GameManager.Syncronize();
        m_GameManager.ExecuteActionList();
        return;
    }
}
