using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMyMainCardAvility
{
    public BattleModeCard m_BattleModeCard = null;

    /// <summary>
    /// フィールドの場所
    /// </summary>
    public int PlaceNum = -1;

    /// <summary>
    /// フィールド上でのパワー
    /// </summary>
    public int FieldPower = 0;

    /// <summary>
    /// フィールド上でのソウル
    /// </summary>
    public int FieldSoul = 0;

    /// <summary>
    /// フィールド上でのレベル
    /// </summary>
    public int FieldLevel = 0;

    /// <summary>
    /// フィールド上で手札アンコールを持っているか
    /// </summary>
    public bool HandEncore = false;

    /// <summary>
    /// フィールド上で2ストックアンコールを持っているか
    /// </summary>
    public bool TwoStockEncore = false;

    /// <summary>
    /// フィールド上でクロックアンコールを持っているか
    /// </summary>
    public bool ClockEncore = false;

    /// <summary>
    /// ターン終了時まで追加される特徴クラス
    /// </summary>
    public AttributeInstance.AttributeUpUntilTurnEnd m_AttributeUpUntilTurnEnd = new AttributeInstance.AttributeUpUntilTurnEnd();

    /// <summary>
    /// フィールド上での特徴
    /// </summary>
    public List<EnumController.Attribute> AttributeList = new List<EnumController.Attribute>();

    /// <summary>
    /// フィールド上でのステータス
    /// </summary>
    private EnumController.State state = EnumController.State.STAND;

    /// <summary>
    /// 大活躍をもっているか
    /// </summary>
    public bool isGreatPerformance = false;

    /// <summary>
    /// タカヤの効果を持っているか
    /// 【自】［(1)］ バトルしているこのカードが【リバース】した時、あなたはコストを払ってよい。そうしたら、このカードを手札に戻す。
    /// </summary>
    public bool Takaya = false;

    /// <summary>
    /// 応援クラス
    /// </summary>
    public PowerInstance.Assist m_Assist = new PowerInstance.Assist(0);

    /// <summary>
    /// アンコール ［手札のキャラを1枚控え室に置く］を持つキャラへの応援クラス
    /// </summary>
    public PowerInstance.AssistForHaveEncore m_AssistForHaveEncore = new PowerInstance.AssistForHaveEncore(0);

    /// <summary>
    /// 全体パワーアップクラス
    /// </summary>
    public PowerInstance.AllAssist m_AllAssist = new PowerInstance.AllAssist(0, null);

    /// <summary>
    /// ガウル効果クラス
    /// </summary>
    public PowerInstance.Gaul m_Gaul = new PowerInstance.Gaul();

    /// <summary>
    /// レベル応援クラス
    /// </summary>
    public PowerInstance.LevelAssist m_LevelAssist = new PowerInstance.LevelAssist(0);

    /// <summary>
    /// ターン終了時までアップするレベルクラス
    /// </summary>
    public LevelInstance.LevelUpUntilTurnEnd m_LevelUpUntilTurnEnd = new LevelInstance.LevelUpUntilTurnEnd(0);

    /// <summary>
    /// ターン終了時までアップするパワークラス
    /// </summary>
    public PowerInstance.PowerUpUntilTurnEnd m_PowerUpUntilTurnEnd = new PowerInstance.PowerUpUntilTurnEnd(0);

    /// <summary>
    /// ターン終了時までアップするソウルクラス
    /// </summary>
    public SoulInstance.SoulUpUntilTurnEnd m_SoulUpUntilTurnEnd = new SoulInstance.SoulUpUntilTurnEnd(0);

    public BattleMyMainCardAvility(
        BattleModeCard m_BattleModeCard,
        int PlaceNum,
        int FieldPower,
        int FieldSoul,
        int FieldLevel,
        bool HandEncore,
        bool TwoStockEncore,
        bool ClockEncore,
        AttributeInstance.AttributeUpUntilTurnEnd m_AttributeUpUntilTurnEnd,
        List<EnumController.Attribute> AttributeList,
        EnumController.State state,
        bool isGreatPerformance,
        bool Takaya,
        PowerInstance.Assist m_Assist,
        PowerInstance.AssistForHaveEncore m_AssistForHaveEncore,
        PowerInstance.AllAssist m_AllAssist,
        PowerInstance.Gaul m_Gaul,
        PowerInstance.LevelAssist m_LevelAssist,
        LevelInstance.LevelUpUntilTurnEnd m_LevelUpUntilTurnEnd,
        PowerInstance.PowerUpUntilTurnEnd m_PowerUpUntilTurnEnd,
        SoulInstance.SoulUpUntilTurnEnd m_SoulUpUntilTurnEnd)
    {
        this.m_BattleModeCard = m_BattleModeCard;
        this.PlaceNum = PlaceNum;
        this.FieldPower = FieldPower;
        this.FieldSoul = FieldSoul;
        this.FieldLevel = FieldLevel;
        this.HandEncore = HandEncore;
        this.TwoStockEncore = TwoStockEncore;
        this.ClockEncore = ClockEncore;
        this.m_AttributeUpUntilTurnEnd = m_AttributeUpUntilTurnEnd;
        this.AttributeList = AttributeList;
        this.state = state;
        this.isGreatPerformance = isGreatPerformance;
        this.Takaya = Takaya;
        this.m_Assist = m_Assist;
        this.m_AssistForHaveEncore = m_AssistForHaveEncore;
        this.m_AllAssist = m_AllAssist;
        this.m_Gaul = m_Gaul;
        this.m_LevelAssist = m_LevelAssist;
        this.m_LevelUpUntilTurnEnd = m_LevelUpUntilTurnEnd;
        this.m_PowerUpUntilTurnEnd = m_PowerUpUntilTurnEnd;
        this.m_SoulUpUntilTurnEnd = m_SoulUpUntilTurnEnd;
    }
}
