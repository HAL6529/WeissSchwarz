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
            case EnumController.CardNo.DC_W01_06T:
            case EnumController.CardNo.DC_W01_19T:
            case EnumController.CardNo.LB_W02_10T:
            case EnumController.CardNo.LB_W02_20T:
                return EnumController.ClimaxType.POWER_THOUSAND_AND_SOUL_ONE;
            case EnumController.CardNo.DC_W01_20T:
            case EnumController.CardNo.LB_W02_11T:
                return EnumController.ClimaxType.SOUL_PLUS_TWO;
            default:
                return EnumController.ClimaxType.VOID;
        }
    }
}
