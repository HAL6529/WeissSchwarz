using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_076 : EffectAbstract
{
    public override void AutoExecute1()
    {
        //【自】［(1) このカードを【レスト】する］ 他の《生徒会》のあなたのキャラがプレイされて舞台に置かれた時、あなたはコストを払ってよい。そうしたら、あなたは1枚引く。
        PayCost(1);
        m_MyMainCardsManager.CallOnRest(IntParamater1);
        m_GameManager.Draw();
        m_GameManager.Syncronize();
        m_GameManager.ExecuteActionList();
        m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
        return;
    }
}
