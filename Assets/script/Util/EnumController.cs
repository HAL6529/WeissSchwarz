using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnumController
{
    public enum CardColor
    {
        RED,
        BLUE,
        YELLOW,
        GREEN,
        PURPLE,
        VOID,
    }

    public enum Trriger
    {
        COMEBACK,
        STANDBY,
        BOOK,
        GATE,
        BOUNCE,
        CHOICE,
        SHOT,
        TREASURE,
        POOL,
        SOUL,
        DOUBLE_SOUL,
        NONE,
        VOID,
    }

    public enum Type
    {
        CHARACTER,
        EVENT,
        CLIMAX,
        VOID,
    }

    public enum Zone
    {
        DECK,
        HAND,
        GRAVEYARD,
        MEMORY,
        CLOCK,
        LEVEL_ONE,
        LEVEL_TWO,
        LEVEL_THREE,
        STOCK,
        CLIMAX,
        FORWARD_LEFT,
        FORWARD_CENTER,
        FORWARD_RIGHT,
        BACKWARD_LEFT,
        BACKWARD_RIGHT,
        EVENT,
        VOID,
    }

    public enum Attribute
    {
        Ooo,
        Hero,
        NONE,
        VOID,
    }

    public enum Limit
    {
        NORMAL,
        VOID,
    }

    public enum CardNo
    {
        AT_WX02_A01,
        AT_WX02_A02,
        AT_WX02_A03,
        AT_WX02_A04,
        AT_WX02_A05,
        AT_WX02_A06,
        AT_WX02_A07,
        AT_WX02_A08,
        AT_WX02_A09,
        AT_WX02_A10,
        AT_WX02_A11,
        AT_WX02_A12,
        AT_WX02_A13,
        VOID,
    }

    public enum Turn
    {
        Player1_Draw,
        Player1_Clock,
        Player1_Main,
        Player1_Climax,
        Player1_Attack,
        Player1_Counter,
        Player1_Encore,
        Player2_Draw,
        Player2_Clock,
        Player2_Main,
        Player2_Climax,
        Player2_Attack,
        Player2_Counter,
        Player2_Encore,
        VOID,
    }
}

