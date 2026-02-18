using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_002 : EffectAbstract
{
    public override void ActExecute1()
    {
        //【起】［(2) このカードを【レスト】する］ このカードを思い出にする。あなたは自分の手札の「主人公＆タナトス」を１枚選び、このカードがいた枠に置く。
        PayCost(2);
        m_MyMainCardsManager.CallOnRest(GetIntParamater1());
        m_MyMainCardsManager.CallPutMemoryFromField(GetIntParamater1());

        for (int i = 0; i < m_GameManager.myHandList.Count; i++)
        {
            if (m_GameManager.myHandList[i].name == "主人公＆タナトス")
            {
                m_MyMainCardsManager.CallPutFieldFromHandForEffect(GetIntParamater1(), i, EnumController.State.STAND);
                return;
            }
        }
        return;
    }
}
