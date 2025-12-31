using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_056 : EffectAbstract
{
    public override void AutoExecute1()
    {
        //【自】 このカードがアタックした時、クライマックス置場に「ありがとう」があるなら、あなたは自分の控え室のキャラを1枚選び、手札に戻す。
        m_DialogManager.SulvageDialog(m_BattleModeCard, m_GameManager.GraveYardList, EnumController.Type.CHARACTER, 0, 1);
        return;
    }
}
