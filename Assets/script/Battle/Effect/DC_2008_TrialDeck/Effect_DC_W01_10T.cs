using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_DC_W01_10T : EffectAbstract
{
    public override void AutoExecute1()
    {
        // 【自】 このカードとバトルしているキャラが【リバース】した時、あなたはそのキャラを山札の上に置いてよい。
        m_BattleStrix.RpcToAll("ToDeckTopFromField", GetIntParamater1(), m_GameManager.isTurnPlayer);
        m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
        m_GameManager.ExecuteActionList();
        return;
    }

    public override void AutoExecute2()
    {
        // 【自】［(1)］ このカードがアタックした時、クライマックス置場に「美春のオルゴール」があるなら、
        // あなたはコストを払ってよい。そうしたら、あなたは自分の控え室のキャラを1枚選び、手札に戻す。
        PayCost(1);
        m_DialogManager.SulvageDialog(m_BattleModeCard, m_GameManager.GraveYardList, EnumController.Type.CHARACTER, 1, 1);
        return;
    } 
}
