using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_P3_S01_055 : EffectAbstract
{
    public override void AutoExecute1()
    {
        //【自】 このカードがアタックした時、クライマックス置場に「ありがとう」があるなら、あなたは自分の控え室のキャラを1枚選び、手札に戻す。
        m_DialogManager.SulvageDialog(m_BattleModeCard, m_GameManager.GraveYardList, EnumController.Type.CHARACTER, 0, 1);
        return;
    }

    public override void AutoExecute2()
    {
        //【自】 他のバトルしているあなたのキャラが【リバース】した時、そのターン中、このカードのパワーを＋2000。
        m_MyMainCardsManager.AddPowerUpUntilTurnEnd(GetIntParamater1(), 2000);
        m_GameManager.Syncronize();
        m_GameManager.ExecuteActionList();
        return;
    }
}
