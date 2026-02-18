using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_07T : EffectAbstract
{
    public override void AutoExecute1()
    {
        //【自】 このカードがプレイされて舞台に置かれた時、そのターン中、このカードのパワーを＋1500。
        m_MyMainCardsManager.AddPowerUpUntilTurnEnd(GetIntParamater1(), 1500);
        m_GameManager.Syncronize();
        m_GameManager.ExecuteActionList();
        return;
    }
}
