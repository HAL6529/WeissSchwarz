using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_040 : EffectAbstract
{
    public override void AutoExecute1()
    {
        //【自】［このカードを【レスト】する］ 他の《スポーツ》のあなたのキャラがプレイされて舞台に置かれた時、あなたはコストを払ってよい。そうしたら、あなたは自分の山札の上から1枚を、ストック置場に置く。
        m_MyMainCardsManager.CallOnRest(GetIntParamater1());
        m_GameManager.myStockList.Add(m_GameManager.myDeckList[0]);
        m_GameManager.myDeckList.RemoveAt(0);
        m_GameManager.Syncronize();
        m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
        if (m_GameManager.myDeckList.Count == 0)
        {
            m_GameManager.Refresh();
        }
        else
        {
            m_GameManager.ExecuteActionList();
            return;
        }
        return;
    }
}
