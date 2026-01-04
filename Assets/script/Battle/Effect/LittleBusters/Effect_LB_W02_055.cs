using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_LB_W02_055 : EffectAbstract
{
    public override void AutoExecute1()
    {
        //【自】［(1)］ このカードがアタックした時、クライマックス置場に「リトルバスターズ！」があるなら、あなたはコストを払ってよい。そうしたら、自分の控え室のキャラを1枚選び、手札に戻す。
        PayCost(1);
        m_DialogManager.SulvageDialog(m_BattleModeCard, m_GameManager.GraveYardList, EnumController.Type.CHARACTER, 0, 1);
        return;
    }
}
