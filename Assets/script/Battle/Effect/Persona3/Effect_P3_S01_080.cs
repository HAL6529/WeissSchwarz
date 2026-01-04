using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_080 : EffectAbstract
{
    public override void AutoExecute1()
    {
        //【自】 このカードがプレイされて舞台に置かれた時、あなたは1枚引いてよい。
        m_GameManager.Draw();
        m_GameManager.Syncronize();
        m_GameManager.ExecuteActionList();
        return;
    }

    public override void AutoExecute2()
    {
        //【自】［(1)］ このカードがプレイされて舞台に置かれた時、あなたはコストを払ってよい。そうしたら、あなたは自分の控え室の「ベルベットルーム」を1枚選び、手札に戻す。
        PayCost(1);
        for (int i = 0; i < m_GameManager.GraveYardList.Count; i++)
        {
            if (m_GameManager.GraveYardList[i].name == "ベルベットルーム")
            {
                m_GameManager.myHandList.Add(m_GameManager.GraveYardList[i]);
                m_GameManager.GraveYardList.RemoveAt(i);
                m_GameManager.Syncronize();
                m_GameManager.ExecuteActionList();
                return;
            }
        }
        m_GameManager.ExecuteActionList();
        return;
    }

    public override void ActExecute1()
    {
        //【起】［(2) このカードを【レスト】する］ あなたはクライマックス以外の自分の控え室のカードを1枚選び、そのカードとこのカードを山札に戻す。その山札をシャッフルする。あなたは1枚引く。
        PayCost(2);
        m_MyMainCardsManager.CallOnRest(IntParamater1);
        for (int i = 0; i < m_GameManager.myDeckList.Count; i++)
        {
            if (m_GameManager.myDeckList[i].GetType() != EnumController.Type.CLIMAX)
            {
                m_DialogManager.GraveyardSelectDialog(m_BattleModeCard, IntParamater1);
                return;
            }
        }
        return;
    }
}
