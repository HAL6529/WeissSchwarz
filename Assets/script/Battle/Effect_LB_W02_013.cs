using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_LB_W02_013 : EffectAbstract
{
    public override void AutoExecute1()
    {
        //【自】 このカードがプレイされて舞台に置かれた時、あなたは【スタンド】している自分のキャラを1枚選び、【レスト】する。
        m_DialogManager.CharacterSelectDialog(m_BattleModeCard, true, -1);
        return;
    }
}
