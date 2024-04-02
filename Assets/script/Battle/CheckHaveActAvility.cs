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
