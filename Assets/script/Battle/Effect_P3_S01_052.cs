using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_052 : EffectAbstract
{
    public override void AutoExecute1()
    {
        //【自】［(1)］ このカードがプレイされて舞台に置かれた時、あなたはコストを払ってよい。そうしたら、あなたは自分の控え室の「辰巳東交番」を1枚選び、手札に戻す。
        PayCost(1);
        for (int i = 0; i < m_GameManager.GraveYardList.Count; i++)
        {
            if (m_GameManager.GraveYardList[i].name == "辰巳東交番")
            {
                m_GameManager.myHandList.Add(m_GameManager.GraveYardList[i]);
                m_GameManager.GraveYardList.RemoveAt(i);
                m_GameManager.Syncronize();
                m_GameManager.ExecuteActionList();
                return;
            }
        }
        return;
    }

    public override void ActExecute1() 
    {
        // 【起】［(3)］ あなたはレベル1以下の相手の前列のキャラを1枚選び、控え室に置く。
        PayCost(3);
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, false, -1);
        return;
    }
}
