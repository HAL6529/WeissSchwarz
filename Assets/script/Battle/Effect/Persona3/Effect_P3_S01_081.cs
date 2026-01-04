using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_081 : EffectAbstract
{
    public override void AutoExecute1()
    {
        //【自】 このカードがアタックした時、クライマックス置場に「最強なる者」があるなら、あなたは1枚引く。
        m_GameManager.Draw();
        m_GameManager.ExecuteActionList();
        return;
    }

    public override void ActExecute1()
    {
        //【起】［(4)］ あなたは自分のクロックを1枚選び、手札に戻す。
        PayCost(4);
        if (m_GameManager.myClockList.Count == 0)
        {
            m_GameManager.ExecuteActionList();
            return;
        }
        m_DialogManager.SearchDialog(EnumController.SearchDialogParamater.P3_S01_081);
        return;
    }
}
