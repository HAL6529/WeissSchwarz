using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHaveActAvility
{
    /// <summary>
    /// 起動効果を持っているか。持っていなければ-1。持っている場合は、起動効果の最低コストを返す
    /// </summary>
    /// <param name="card">BattleCardMode.cardNo</param>
    /// <returns></returns>
    public int Check(EnumController.CardNo card, EnumController.State state)
    {
        switch (card)
        {
            case EnumController.CardNo.LB_W02_08T:
                return 0;
            case EnumController.CardNo.DC_W01_01T:
                if (state == EnumController.State.STAND)
                {
                    return 0;
                }
                return -1;
            case EnumController.CardNo.DC_W01_04T:
            case EnumController.CardNo.DC_W01_05T:
            case EnumController.CardNo.LB_W02_02T:
            case EnumController.CardNo.LB_W02_05T:
            case EnumController.CardNo.LB_W02_09T:
            case EnumController.CardNo.LB_W02_17T:
                return 1;
            case EnumController.CardNo.DC_W01_07T:
                return 3;
            case EnumController.CardNo.DC_W01_13T:
            case EnumController.CardNo.LB_W02_14T:
                if (state == EnumController.State.STAND)
                {
                    return 2;
                }
                return -1;
            case EnumController.CardNo.AT_WX02_A09:
                if(state == EnumController.State.STAND)
                {
                    return 1;
                }
                return -1;
            default:
                return -1;
        }
    }
}
