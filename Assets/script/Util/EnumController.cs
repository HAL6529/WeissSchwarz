using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnumController
{
    public enum Action
    {
        VOID,
        Bond,
        ClockAndTwoDraw,
        ClockAndTwoDraw2,
        DamageRefresh,
        DamageForFrontAttack,
        DamageForFrontAttack2ForCancel,
        DamageForFrontAttack2ForDamaged,
        EffectWhenAct,
        EventAnimationManager,
        ExecuteAttack2,
        PowerCheckForLevelUpDialog,
        SulvageDialog,
        TurnChange,
        AT_WX02_A08,
        DC_W01_02T,
        DC_W01_07T,
        DC_W01_10T,
        DC_W01_16T,
        LB_W02_14T,
        LB_W02_19T,
        P3_S01_01T,
        P3_S01_04T,
        P3_S01_07T,
        P3_S01_16T,
        P3_S01_001,
        P3_S01_026,
        P3_S01_040,
        P3_S01_052,
        P3_S01_055,
        P3_S01_057_1,
        P3_S01_057_2,
        P3_S01_060,
        P3_S01_061,
        P3_S01_062,
        P3_S01_065_1,
        P3_S01_065_Damage,
        P3_S01_065_2,
        P3_S01_076,
        P3_S01_080_1,
        P3_S01_080_2,
        P3_S01_088,
        LB_W02_003,
        LB_W02_031,
        LB_W02_062,
    }

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
        NONE, // 特徴なし
        Ooo,
        Hero,
        Royality,
        Vampire,
        Animal, // 動物
        Book, // 本
        Shadow, // 影
        ShrineMaiden, // 巫女
        Sports, // スポーツ
        Sweets, // お菓子
        Magic, // 魔法
        Music, // 音楽
        Marble, // ビー玉
        Parasol,　// 日傘
        Comics, // 漫画
        Glasses, // メガネ
        Teacher, // 先生
        Banana, // バナナ
        Mecha, // メカ
        JapaneseClothes, // 和服
        Pajamas, // パジャマ
        FairyTale, // 童話
        Fan, // 扇子
        God, // 神
        Ramen, // ラーメン
        SchoolBag, // ランドセル
        StudentCouncil, // 生徒会
        TVMailOrder, // テレビ通販
        Weapon, // 武器
        Will, // 遺言
        Death, // 死
        Illness, // 病気
        Swimsuit, // 水着
        Twins, // 双子
        Bullying, // いじめ
        Manager, // マネージャー
        OnlineGame, //ネトゲ
        Alcohol, // 酒
        Gourmet, // グルメ
        Zen, // 禅
        Devil, // 悪魔
        Gag, // だじゃれ
        Muscle, //筋肉
        Chairperson, //委員長
        Police, //警察
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
        P3_S01_01T,
        P3_S01_02T,
        P3_S01_03T,
        P3_S01_04T,
        P3_S01_05T,
        P3_S01_06T,
        P3_S01_07T,
        P3_S01_08T,
        P3_S01_09T,
        P3_S01_10T,
        P3_S01_11T,
        P3_S01_12T,
        P3_S01_13T,
        P3_S01_14T,
        P3_S01_15T,
        P3_S01_16T,
        P3_S01_17T,
        P3_S01_18T,
        P3_S01_19T,
        P3_S01_20T,
        P3_S01_001,
        P3_S01_002,
        P3_S01_003,
        P3_S01_004,
        P3_S01_005,
        P3_S01_006,
        P3_S01_007,
        P3_S01_008,
        P3_S01_009,
        P3_S01_010,
        P3_S01_011,
        P3_S01_012,
        P3_S01_013,
        P3_S01_014,
        P3_S01_015,
        P3_S01_016,
        P3_S01_017,
        P3_S01_018,
        P3_S01_019,
        P3_S01_020,
        P3_S01_021,
        P3_S01_022,
        P3_S01_023,
        P3_S01_024,
        P3_S01_025,
        P3_S01_026,
        P3_S01_027,
        P3_S01_028,
        P3_S01_029,
        P3_S01_030,
        P3_S01_031,
        P3_S01_032,
        P3_S01_033,
        P3_S01_034,
        P3_S01_035,
        P3_S01_036,
        P3_S01_037,
        P3_S01_038,
        P3_S01_039,
        P3_S01_040,
        P3_S01_041,
        P3_S01_042,
        P3_S01_043,
        P3_S01_044,
        P3_S01_045,
        P3_S01_046,
        P3_S01_047,
        P3_S01_048,
        P3_S01_049,
        P3_S01_050,
        P3_S01_051,
        P3_S01_052,
        P3_S01_053,
        P3_S01_054,
        P3_S01_055,
        P3_S01_056,
        P3_S01_057,
        P3_S01_058,
        P3_S01_059,
        P3_S01_060,
        P3_S01_061,
        P3_S01_062,
        P3_S01_063,
        P3_S01_064,
        P3_S01_065,
        P3_S01_066,
        P3_S01_067,
        P3_S01_068,
        P3_S01_069,
        P3_S01_070,
        P3_S01_071,
        P3_S01_072,
        P3_S01_073,
        P3_S01_074,
        P3_S01_075,
        P3_S01_076,
        P3_S01_077,
        P3_S01_078,
        P3_S01_079,
        P3_S01_080,
        P3_S01_081,
        P3_S01_082,
        P3_S01_083,
        P3_S01_084,
        P3_S01_085,
        P3_S01_086,
        P3_S01_087,
        P3_S01_088,
        P3_S01_089,
        P3_S01_090,
        P3_S01_091,
        P3_S01_092,
        P3_S01_093,
        P3_S01_094,
        P3_S01_095,
        P3_S01_096,
        P3_S01_097,
        P3_S01_098,
        P3_S01_099,
        P3_S01_100,
        LB_W02_001,
        LB_W02_002,
        LB_W02_003,
        LB_W02_004,
        LB_W02_005,
        LB_W02_006,
        LB_W02_007,
        LB_W02_008,
        LB_W02_009,
        LB_W02_010,
        LB_W02_011,
        LB_W02_012,
        LB_W02_013,
        LB_W02_014,
        LB_W02_015,
        LB_W02_016,
        LB_W02_017,
        LB_W02_018,
        LB_W02_019,
        LB_W02_020,
        LB_W02_021,
        LB_W02_022,
        LB_W02_023,
        LB_W02_024,
        LB_W02_025,
        LB_W02_026,
        LB_W02_027,
        LB_W02_028,
        LB_W02_029,
        LB_W02_030,
        LB_W02_031,
        LB_W02_032,
        LB_W02_033,
        LB_W02_034,
        LB_W02_035,
        LB_W02_036,
        LB_W02_037,
        LB_W02_038,
        LB_W02_039,
        LB_W02_040,
        LB_W02_041,
        LB_W02_042,
        LB_W02_043,
        LB_W02_044,
        LB_W02_045,
        LB_W02_046,
        LB_W02_047,
        LB_W02_048,
        LB_W02_049,
        LB_W02_050,
        LB_W02_051,
        LB_W02_052,
        LB_W02_053,
        LB_W02_054,
        LB_W02_055,
        LB_W02_056,
        LB_W02_057,
        LB_W02_058,
        LB_W02_059,
        LB_W02_060,
        LB_W02_061,
        LB_W02_062,
        LB_W02_063,
        LB_W02_064,
        LB_W02_065,
        LB_W02_066,
        LB_W02_067,
        LB_W02_068,
        LB_W02_069,
        LB_W02_070,
        LB_W02_071,
        LB_W02_072,
        LB_W02_073,
        LB_W02_074,
        LB_W02_075,
        LB_W02_076,
        LB_W02_077,
        LB_W02_078,
        LB_W02_079,
        LB_W02_080,
        LB_W02_081,
        LB_W02_082,
        LB_W02_083,
        LB_W02_084,
        LB_W02_085,
        LB_W02_086,
        LB_W02_087,
        LB_W02_088,
        LB_W02_089,
        LB_W02_090,
        LB_W02_091,
        LB_W02_092,
        LB_W02_093,
        LB_W02_094,
        LB_W02_095,
        LB_W02_096,
        LB_W02_097,
        LB_W02_098,
        LB_W02_099,
        LB_W02_100,
    }

    public enum ConfirmSearchOrSulvageCardDialog
    {
        VOID,
        SEARCH,
        SULVAGE,
        COMEBACK,
        CLOCK_SULVAGE,
        P3_S01_057, // 荒垣 真次郎
        P3_S01_061, // タカヤ＆ヒュプノス
        P3_S01_080, // イゴール
        DC_W01_12T, // かけ仲
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
        DAMAGE_ZERO,
        EFFECT,
        EFFECT_CANCEL,
    }

    public enum EncoreDialog
    {
        VOID,
        EncorePhase,
        EncoreCheck,
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

    public enum PowerCheck
    {
        DamageForFrontAttack,
        DamageForFrontAttack2ForCancel,
        DamageForFrontAttack2ForDamaged,
        PowerCheckForLevelUpDialog,
    }

    public enum SearchDialogParamater
    {
        VOID,
        AT_WX02_A07,
        LB_W02_16T,
        P3_S01_077,
        P3_S01_081,
        LB_W02_001,
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
        CONFIRM_CONTROL_DECKTOP,
        CONFIRM_BOOK_TRIGGER_FRONT,
        CONFIRM_BOOK_TRIGGER_SIDE,
        CONFIRM_BOOK_TRIGGER_DIRECT,
        CONFIRM_BOUNCE_TRIGGER_FRONT,
        CONFIRM_BOUNCE_TRIGGER_SIDE,
        CONFIRM_BOUNCE_TRIGGER_DIRECT,
        CONFIRM_COMEBACK_TRIGGER_FRONT,
        CONFIRM_COMEBACK_TRIGGER_SIDE,
        CONFIRM_COMEBACK_TRIGGER_DIRECT,
        CONFIRM_POOL_TRIGGER_FRONT,
        CONFIRM_POOL_TRIGGER_SIDE,
        CONFIRM_POOL_TRIGGER_DIRECT,
        CONFIRM_SEND_ENCORE_PHASE,
        CLIMAX_PHASE,
        CLIMAX_PHASE_CONFIRM,
        EVENT_CONFIRM,
        COST_CONFIRM_HAND_TO_FIELD,
        COST_CONFIRM_BOND_FOR_HAND_TO_FIELD,
        COST_CONFIRM_BRAIN_STORM_FOR_DRAW,
        COST_CONFIRM_DC_W01_01T,
        COST_CONFIRM_DC_W01_02T,
        COST_CONFIRM_DC_W01_04T,
        COST_CONFIRM_DC_W01_05T,
        COST_CONFIRM_DC_W01_10T,
        COST_CONFIRM_DC_W01_13T,
        COST_CONFIRM_LB_W02_02T_1,
        COST_CONFIRM_LB_W02_02T_2,
        COST_CONFIRM_LB_W02_03T,
        COST_CONFIRM_LB_W02_05T,
        COST_CONFIRM_LB_W02_09T,
        COST_CONFIRM_LB_W02_14T,
        COST_CONFIRM_LB_W02_17T,
        COST_CONFIRM_P3_S01_01T,
        COST_CONFIRM_P3_S01_04T,
        COST_CONFIRM_P3_S01_11T_1,
        COST_CONFIRM_P3_S01_11T_2,
        COST_CONFIRM_P3_S01_16T,
        COST_CONFIRM_P3_S01_002,
        COST_CONFIRM_P3_S01_004,
        COST_CONFIRM_P3_S01_028,
        COST_CONFIRM_P3_S01_030,
        COST_CONFIRM_P3_S01_034,
        COST_CONFIRM_P3_S01_051,
        COST_CONFIRM_P3_S01_052,
        COST_CONFIRM_P3_S01_055,
        COST_CONFIRM_P3_S01_056,
        COST_CONFIRM_P3_S01_062,
        COST_CONFIRM_P3_S01_077,
        COST_CONFIRM_P3_S01_080,
        COST_CONFIRM_P3_S01_081,
        COST_CONFIRM_P3_S01_091,
        COST_CONFIRM_LB_W02_001,
        COST_CONFIRM_LB_W02_002,
        COST_CONFIRM_LB_W02_004,
        COST_CONFIRM_LB_W02_031,
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

