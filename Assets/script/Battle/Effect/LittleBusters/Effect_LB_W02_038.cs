using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_LB_W02_038 : EffectAbstract
{
    public override void ActExecute1()
    {
        //【起】［このカードを【レスト】する］ あなたは自分のキャラを1枚選び、ストック置場に置く
        m_MyMainCardsManager.CallOnRest(IntParamater1);
        m_GameManager.Syncronize();
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, -1);
        return;
    }
}
