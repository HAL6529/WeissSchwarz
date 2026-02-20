using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_AT_WX02_A10 : EffectAbstract
{
    private string sulvageCardName = "Marceline Party Crasher";

    public override void KizunaExecute1()
    {
        // ÅyAUTOÅz Bond/"Marceline: Party Crasher" [(1)] (When this card is played and placed on stage, you may pay the cost. If you do, choose 1 "Marceline: Party Crasher" in your waiting room, and return it to your hand)
        m_EffectBondForHandToField.BondForCost(sulvageCardName, 1);
        return;
    }
}
