using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMyMainCardAvility
{
    public BattleModeCard m_BattleModeCard = null;

    /// <summary>
    /// �t�B�[���h�̏ꏊ
    /// </summary>
    public int PlaceNum = -1;

    /// <summary>
    /// �t�B�[���h��ł̃p���[
    /// </summary>
    public int FieldPower = 0;

    /// <summary>
    /// �t�B�[���h��ł̃\�E��
    /// </summary>
    public int FieldSoul = 0;

    /// <summary>
    /// �t�B�[���h��ł̃��x��
    /// </summary>
    public int FieldLevel = 0;

    /// <summary>
    /// �t�B�[���h��Ŏ�D�A���R�[���������Ă��邩
    /// </summary>
    public bool HandEncore = false;

    /// <summary>
    /// �t�B�[���h���2�X�g�b�N�A���R�[���������Ă��邩
    /// </summary>
    public bool TwoStockEncore = false;

    /// <summary>
    /// �t�B�[���h��ŃN���b�N�A���R�[���������Ă��邩
    /// </summary>
    public bool ClockEncore = false;

    /// <summary>
    /// �^�[���I�����܂Œǉ����������N���X
    /// </summary>
    public AttributeInstance.AttributeUpUntilTurnEnd m_AttributeUpUntilTurnEnd = new AttributeInstance.AttributeUpUntilTurnEnd();

    /// <summary>
    /// �t�B�[���h��ł̓���
    /// </summary>
    public List<EnumController.Attribute> AttributeList = new List<EnumController.Attribute>();

    /// <summary>
    /// �t�B�[���h��ł̃X�e�[�^�X
    /// </summary>
    private EnumController.State state = EnumController.State.STAND;

    /// <summary>
    /// �劈��������Ă��邩
    /// </summary>
    public bool isGreatPerformance = false;

    /// <summary>
    /// �^�J���̌��ʂ������Ă��邩
    /// �y���z�m(1)�n �o�g�����Ă��邱�̃J�[�h���y���o�[�X�z�������A���Ȃ��̓R�X�g�𕥂��Ă悢�B����������A���̃J�[�h����D�ɖ߂��B
    /// </summary>
    public bool Takaya = false;

    /// <summary>
    /// �����N���X
    /// </summary>
    public PowerInstance.Assist m_Assist = new PowerInstance.Assist(0);

    /// <summary>
    /// �A���R�[�� �m��D�̃L������1���T�����ɒu���n�����L�����ւ̉����N���X
    /// </summary>
    public PowerInstance.AssistForHaveEncore m_AssistForHaveEncore = new PowerInstance.AssistForHaveEncore(0);

    /// <summary>
    /// �S�̃p���[�A�b�v�N���X
    /// </summary>
    public PowerInstance.AllAssist m_AllAssist = new PowerInstance.AllAssist(0, null);

    /// <summary>
    /// �K�E�����ʃN���X
    /// </summary>
    public PowerInstance.Gaul m_Gaul = new PowerInstance.Gaul();

    /// <summary>
    /// ���x�������N���X
    /// </summary>
    public PowerInstance.LevelAssist m_LevelAssist = new PowerInstance.LevelAssist(0);

    /// <summary>
    /// �^�[���I�����܂ŃA�b�v���郌�x���N���X
    /// </summary>
    public LevelInstance.LevelUpUntilTurnEnd m_LevelUpUntilTurnEnd = new LevelInstance.LevelUpUntilTurnEnd(0);

    /// <summary>
    /// �^�[���I�����܂ŃA�b�v����p���[�N���X
    /// </summary>
    public PowerInstance.PowerUpUntilTurnEnd m_PowerUpUntilTurnEnd = new PowerInstance.PowerUpUntilTurnEnd(0);

    /// <summary>
    /// �^�[���I�����܂ŃA�b�v����\�E���N���X
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
