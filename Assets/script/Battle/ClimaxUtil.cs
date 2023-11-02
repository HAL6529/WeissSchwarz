using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimaxUtil
{
    public EnumController.ClimaxType GetClimaxType(EnumController.CardNo num)
    {
        switch (num)
        {
            case EnumController.CardNo.AT_WX02_A08:
            case EnumController.CardNo.AT_WX02_A13:
                return EnumController.ClimaxType.POWER_THOUSAND_AND_SOUL_ONE;
            default:
                return EnumController.ClimaxType.VOID;
        }
    }
}
