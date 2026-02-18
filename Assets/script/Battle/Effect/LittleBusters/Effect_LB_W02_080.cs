using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_LB_W02_080 : EffectAbstract
{
    public override void AutoExecute1()
    {
        //【自】［(1)］ このカードがアタックした時、クライマックス置場に「危機一髪！」があるなら、あなたはコストを払ってよい。そうしたら、あなたは1枚引く。
        PayCost(1);
        m_GameManager.Draw();
        m_GameManager.ExecuteActionList();
        return;
    }
}
