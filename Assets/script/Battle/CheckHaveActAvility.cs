using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHaveActAvility : MonoBehaviour
{
    /// <summary>
    /// �N�����ʂ������Ă��邩�B�����Ă��Ȃ����-1�B�����Ă���ꍇ�́A�N�����ʂ̍Œ�R�X�g��Ԃ�
    /// </summary>
    /// <param name="card">BattleCardMode.cardNo</param>
    /// <returns></returns>
    public int Check(EnumController.CardNo card)
    {
        switch (card)
        {
            case EnumController.CardNo.AT_WX02_A09:
                return 1;
            default:
                return -1;
        }
    }
}