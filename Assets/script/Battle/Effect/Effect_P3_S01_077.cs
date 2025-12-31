using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_077 : EffectAbstract
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
        //【起】［(4)］ あなたは自分の山札を見てイベントを1枚まで選んで相手に見せ、手札に加える。その山札をシャッフルする。
        PayCost(4);
        m_DialogManager.SearchDialog(EnumController.SearchDialogParamater.P3_S01_077);
        return;
    }
}
