using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_061 : EffectAbstract
{
    public override void AutoExecute1()
    {
        // 【自】 このカードがプレイされて舞台に置かれた時、あなたは相手の控え室のカードを1枚選び、山札の上に置いてよい。
        m_DialogManager.GraveyardSelectDialog(m_BattleModeCard);
        return;
    }

    public override void AutoExecute2() 
    {
        //【自】 このカードがアタックした時、クライマックス置場に「ニュクス・アバター」があるなら、あなたは自分の控え室のキャラを1枚選び、手札に戻す。
        m_DialogManager.SulvageDialog(m_BattleModeCard, m_GameManager.GraveYardList, EnumController.Type.CHARACTER, 1, 1);
        return;
    }
}
