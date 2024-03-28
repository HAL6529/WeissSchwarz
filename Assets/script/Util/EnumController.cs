using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnumController
{
    public enum Attack
    {
        VOID,
        DIRECT_ATTACK,
        FRONT_ATTACK,
        SIDE_ATTACK,
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

    public enum CardColor
    {
        VOID,
        RED,
        BLUE,
        YELLOW,
        GREEN,
        PURPLE,
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

    public enum ConfirmSearchOrSulvageCardDialog
    {
        VOID,
        SEARCH,
        SULVAGE,
        COMEBACK,
    }

    public enum ClimaxType
    {
        VOID,
        POWER_THOUSAND_AND_SOUL_ONE,
    }

    public enum Damage
    {
        VOID,
        DIRECT_ATTACK,
        FRONT_ATTACK,
        SIDE_ATTACK,
        SHOT,
    }

    public enum DamageAnimation
    {
        VOID,
        CANCEL,
        DAMAGED,
    }

    public enum HandCardUtilStatus
    {
        VOID,
        HAND_OVER,
        MARIGAN_MODE,
        COUNTER_SELECT_MODE,
        HAND_ENCORE,
    }

    public enum HandOverDialogParamater
    {
        VOID,
        Active,
        Confirm,
    }

    public enum Language
    {
        VOID,
        Japanese,
        English,
    }

    public enum LevelUpDialogParamater
    {
        VOID,
        CLOCK_ANDTWO_DRAW,
        FRONT_ATTACK,
        REFRESH,
    }

    public enum Limit
    {
        NORMAL,
        VOID,
    }

    public enum OKDialogParamater
    {
        VOID,
        Marigan,
        CLOCK,
        HAND_ENCORE_SELECT_DISCARD_CONFIRM,
        Counter_Not_Exist,
        Counter_Confirm_Use_Card,
    }

    public enum SearchDialogParamater
    {
        VOID,
        Search,
        Sulvage,
    }

    public enum State
    {
        VOID,
        STAND,
        REST,
        REVERSE,
    }

    public enum Trigger
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

    public enum Turn
    {
        VOID,
        Stand,
        Draw,
        Clock,
        Main,
        Climax,
        Attack,
        Encore,
    }

    public enum Type
    {
        VOID,
        CHARACTER,
        EVENT,
        CLIMAX,
    }

    public enum YesOrNoDialogParamater
    {
        VOID,
        CONFIRM_USE_COUNTER,
        CONFIRM_CARD_EFFECT,
        CLIMAX_PHASE,
        CLIMAX_PHASE_CONFIRM,
        EVENT_CONFIRM,
        COST_CONFIRM_HAND_TO_FIELD,
        COST_CONFIRM_BOND_FOR_HAND_TO_FIELD,
        COST_CONFIRM_BRAIN_STORM_FOR_DRAW,
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
}

