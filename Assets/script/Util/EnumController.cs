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
        Animal,
        Book,
        Shadow,
        ShrineMaiden,
        Sports,
        Sweets,
        Magic,
        Music,
        Marble,
        Parasol,
        Comics,
        Glasses,
        Teacher,
        Banana,
        Mecha,
        JapaneseClothes,
        Pajamas,
        FairyTale,
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
        DC_W01_01T,
        DC_W01_02T,
        DC_W01_03T,
        DC_W01_04T,
        DC_W01_05T,
        DC_W01_06T,
        DC_W01_07T,
        DC_W01_08T,
        DC_W01_09T,
        DC_W01_10T,
        DC_W01_11T,
        DC_W01_12T,
        DC_W01_13T,
        DC_W01_14T,
        DC_W01_15T,
        DC_W01_16T,
        DC_W01_17T,
        DC_W01_18T,
        DC_W01_19T,
        DC_W01_20T,
        LB_W02_01T,
        LB_W02_02T,
        LB_W02_03T,
        LB_W02_04T,
        LB_W02_05T,
        LB_W02_06T,
        LB_W02_07T,
        LB_W02_08T,
        LB_W02_09T,
        LB_W02_10T,
        LB_W02_11T,
        LB_W02_12T,
        LB_W02_13T,
        LB_W02_14T,
        LB_W02_15T,
        LB_W02_16T,
        LB_W02_17T,
        LB_W02_18T,
        LB_W02_19T,
        LB_W02_20T,
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
        SOUL_PLUS_TWO,
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

    public enum Shot
    {
        SHOT,
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
        CONFIRM_POOL_TRIGGER_FRONT,
        CONFIRM_POOL_TRIGGER_SIDE,
        CONFIRM_POOL_TRIGGER_DIRECT,
        CLIMAX_PHASE,
        CLIMAX_PHASE_CONFIRM,
        EVENT_CONFIRM,
        COST_CONFIRM_HAND_TO_FIELD,
        COST_CONFIRM_BOND_FOR_HAND_TO_FIELD,
        COST_CONFIRM_BRAIN_STORM_FOR_DRAW,
        COST_CONFIRM_SEND_MEMORY,
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

