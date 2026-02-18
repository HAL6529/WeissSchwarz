using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_LB_W02_19T : EffectAbstract
{
    public override void AutoExecute1()
    {
        // 【自】［(1)］ このカードとバトルしているレベル2以上のキャラが【リバース】した時、あなたはコストを払ってよい。そうしたら、あなたは1枚引く。
        PayCost(1);
        m_GameManager.Draw();
        m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
        m_GameManager.ExecuteActionList();
        return;
    }
}
