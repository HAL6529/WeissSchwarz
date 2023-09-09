using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnumController
{
    public enum CardColor
    {
        VOID,
        RED,
        BLUE,
        YELLOW,
        GREEN,
        PURPLE,
    }

    public enum Trriger
    {
        VOID,
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
    }

    public enum Type
    {
        VOID,
        CHARACTER,
        EVENT,
        CLIMAX,
    }

    public enum Zone
    {
        VOID,
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
    }

    public enum Attribute
    {
        VOID,
        NONE,
        Ooo,
        Hero,
        Royality,
        Vampire,
    }

    public enum Limit
    {
        NORMAL,
        VOID,
    }

    public enum CardNo
    {
        VOID,
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
    }

    public enum Turn
    {
        VOID,
        Stand,
        Draw,
        Clock,
        Main,
        Climax,
        Attack,
        Counter,
        Encore,
    }

    public enum OKDialogParamater
    {
        VOID,
        Marigan,
        CLOCK,
    }

    public enum YesOrNoDialogParamater
    {
        VOID,
        CLIMAX_PHASE,
        CLIMAX_PHASE_CONFIRM,
    }
}

