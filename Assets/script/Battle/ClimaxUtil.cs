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
            case EnumController.CardNo.P3_S01_14T:
            case EnumController.CardNo.P3_S01_023:
            case EnumController.CardNo.P3_S01_025:
            case EnumController.CardNo.P3_S01_048:
            case EnumController.CardNo.P3_S01_049:
            case EnumController.CardNo.P3_S01_074:
            case EnumController.CardNo.P3_S01_075:
            case EnumController.CardNo.P3_S01_098:
            case EnumController.CardNo.P3_S01_100:
            case EnumController.CardNo.LB_W02_023:
            case EnumController.CardNo.LB_W02_024:
            case EnumController.CardNo.LB_W02_048:
            case EnumController.CardNo.LB_W02_049:
            case EnumController.CardNo.LB_W02_073:
            case EnumController.CardNo.LB_W02_074:
            case EnumController.CardNo.LB_W02_098:
            case EnumController.CardNo.LB_W02_100:
                return EnumController.ClimaxType.POWER_THOUSAND_AND_SOUL_ONE;
            case EnumController.CardNo.DC_W01_20T:
            case EnumController.CardNo.LB_W02_11T:
            case EnumController.CardNo.P3_S01_13T:
            case EnumController.CardNo.P3_S01_20T:
            case EnumController.CardNo.P3_S01_024:
            case EnumController.CardNo.P3_S01_050:
            case EnumController.CardNo.P3_S01_073:
            case EnumController.CardNo.P3_S01_099:
            case EnumController.CardNo.LB_W02_025:
            case EnumController.CardNo.LB_W02_050:
            case EnumController.CardNo.LB_W02_075:
            case EnumController.CardNo.LB_W02_099:
                return EnumController.ClimaxType.SOUL_PLUS_TWO;
            default:
                return EnumController.ClimaxType.VOID;
        }
    }
}
