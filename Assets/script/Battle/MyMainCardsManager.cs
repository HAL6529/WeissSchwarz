using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyMainCardsManager : MonoBehaviour
{
    private List<BattleModeCard> myFieldList = new List<BattleModeCard>();
    public List<BattleMyMainCardUtil> CardList = new List<BattleMyMainCardUtil>();
    [SerializeField] BattleStrix m_BattleStrix;
    [SerializeField] GameManager m_GameManager;

    public void AddAttributeUpUntilTurnEnd(int place, EnumController.Attribute attribute)
    {
        CardList[place].m_AttributeUpUntilTurnEnd.AddAttribute(attribute);
    }

    public void AddLevelUpUntilTurnEnd(int num, int level)
    {
        CardList[num].m_LevelUpUntilTurnEnd.AddUpLevel(level);
    }

    public void AddPowerUpUntilTurnEnd(int num, int power)
    {
        CardList[num].m_PowerUpUntilTurnEnd.AddUpPower(power);
    }

    public void AddSoulUpUntilTurnEnd(int num, int soul)
    {
        CardList[num].m_SoulUpUntilTurnEnd.AddUpSoul(soul);
    }

    /// <summary>
    /// ���������x���A�b�v�����Ƃ��ɔ����������
    /// </summary>
    public void CallLevelUp()
    {
        for (int i = 0; i < CardList.Count; i++)
        {
            CardList[i].WhenLevelUp();
        }
    }

    /// <summary>
    /// �t�B�[���h����f�b�L�g�b�v�ɒu�����Ƃ��ɌĂ΂��
    /// </summary>
    public void CallPutDeckTopFromField(int num)
    {
        CardList[num].PutDeckTopFromField();
    }

    /// <summary>
    /// �T�����畑��ɒu�����Ƃ��ɌĂ΂��
    /// </summary>
    public void CallPutFieldFromGraveYard(int place, BattleModeCard card, EnumController.State state)
    {
        CardList[place].PutFieldFromGraveYard(card, state);
    }

    /// <summary>
    /// ��D���畑��ɒu����鎞�ɌĂ΂��
    /// </summary>
    public void CallPutFieldFromHand(int place, int num, EnumController.State state)
    {
        CardList[place].PutFieldFromHand(num, state);
    }

    /// <summary>
    /// �u���Ȃ��͎����̎�D�́uXXXXXXXX�v���P���I�сA���̃J�[�h�������g�ɒu���B�v�̌���
    /// </summary>
    public void CallPutFieldFromHandForEffect(int place, int num, EnumController.State state)
    {
        CardList[place].PutFieldFromHandForEffect(num, state);
    }

    /// <summary>
    /// �t�B�[���h����T���ɒu����鎞�ɌĂ΂��
    /// </summary>
    public void CallPutGraveYardFromField(int place)
    {
        CardList[place].PutGraveYardFromField();
    }

    /// <summary>
    /// �t�B�[���h�����D�ɖ߂����ɌĂ΂��
    /// </summary>
    public void CallPutHandFromField(int place)
    {
        CardList[place].PutHandFromField();
    }

    /// <summary>
    /// �t�B�[���h����v���o�ɒu����鎞�ɌĂ΂��
    /// </summary>
    public void CallPutMemoryFromField(int place)
    {
        CardList[place].PutMemoryFromField();
    }

    public void CallNotShowDirectAttackButton()
    {
        for (int i = 0; i < CardList.Count; i++)
        {
            CardList[i].GetComponent<BattleMyMainCardUtil>().NotShowDirectAttackButton();
        }
    }

    public void CallNotShowFrontAndSideButton()
    {
        for (int i = 0; i < CardList.Count; i++)
        {
            CardList[i].GetComponent<BattleMyMainCardUtil>().NotShowFrontAndSideButton();
        }
    }

    public void CallNotShowMoveButton()
    {
        for (int i = 0; i < CardList.Count; i++)
        {
            CardList[i].GetComponent<BattleMyMainCardUtil>().NotShowMoveButton();
        }
    }

    public void CallOnRest(int num)
    {
        if (CardList[num].getBattleModeCard() == null)
        {
            return;
        }
        CardList[num].onRest();
    }

    public void CallOnReverse(int num)
    {
        if (CardList[num].getBattleModeCard() == null)
        {
            return;
        }
        CardList[num].onReverse();
    }

    public void CallOnStand(int num)
    {
        CardList[num].Stand();
    }

    public void CallStand()
    {
        for (int i = 0; i < CardList.Count; i++)
        {
            CardList[i].Stand();
        }
    }

    /// <summary>
    /// ��������o�[�X�����Ƃ��ɔ����������
    /// </summary>
    /// <param name="num">�����̃J�[�h�̏ꏊ</param>
    /// <param name="reversedCardPlace">���o�[�X�����L�����̏ꏊ(���o�[�X�����L�����̃R���g���[���[���_)</param>
    /// <param name="reversedCardLevel">���o�[�X�����L�����̃��x��</param>
    public void CallWhenReverseEnemyCard(int num, int reversedCardPlace, int reversedCardLevel)
    {
        CardList[num].WhenReverseEnemyCard(reversedCardPlace, reversedCardLevel);
    }

    /// <summary>
    /// �u�y���z ���̂��Ȃ��̃L�������v���C����ĕ���ɒu���ꂽ���v�ɔ���������ʂ������Ă���J�[�h����ɂȂ����m�F����
    /// </summary>
    public void ConfirmEffectWhenMyCardPut(int PlaceNum)
    {

        for (int i = 0; i < CardList.Count; i++)
        {
            if (i == PlaceNum)
            {
                continue;
            }
            CardList[i].EffectWhenMyOtherCardPut(PlaceNum, i);
        }
    }

    /// <summary>
    /// �u�y���z ���̃o�g�����Ă��邠�Ȃ��̃L�������y���o�[�X�z�������v�̌��ʂ������Ă���J�[�h����ɂȂ����m�F����
    /// </summary>
    public void ConfirmEffectWhenMyCardReversed(int PlaceNum)
    {
        for (int i = 0; i < CardList.Count; i++)
        {
            if (i == PlaceNum)
            {
                continue;
            }
            CardList[i].EffectWhenMyOtherCardReversed();
        }
    }

    public void ExecuteAttack2(int num, EnumController.Attack status)
    {
        CardList[num].Attack2(status);
    }

    public void ExecuteResetAttributeUpUntilTurnEnd()
    {
        for (int i = 0; i < CardList.Count; i++)
        {
            CardList[i].ResetAttributeUpUntilTurnEnd();
        }
    }

    public void ExecuteResetLevelUpUntilTurnEnd()
    {
        for (int i = 0; i < CardList.Count; i++)
        {
            CardList[i].ResetLevelUpUntilTurnEnd();
        }
    }

    public void ExecuteResetPowerUpUntilTurnEnd()
    {
        for (int i = 0; i < CardList.Count; i++)
        {
            CardList[i].ResetPowerUpUntilTurnEnd();
        }
    }

    public void ExecuteResetSoulUpUntilTurnEnd()
    {
        for (int i = 0; i < CardList.Count; i++)
        {
            CardList[i].ResetSoulUpUntilTurnEnd();
        }
    }

    public void FieldPowerAndLevelAndAttributeAndSoulReset()
    {
        for (int i = 0; i < CardList.Count; i++)
        {
            CardList[i].LevelUpdate();
            CardList[i].PowerUpdate();
            CardList[i].SoulUpdate();
            CardList[i].AttributeUpdate();
            CardList[i].TakayaEffectUpdate();
        }
    }

    /// <summary>
    /// �S�̉����̌v�Z�p
    /// </summary>
    /// <param name="num"></param>
    /// <param name="attribute"></param>
    /// <returns></returns>
    public int GetAllAssist(int num, List<EnumController.Attribute> attribute)
    {
        List<EnumController.Attribute> list = CardList[num].m_AllAssist.getAttributeList();
        for (int i = 0; i < attribute.Count; i++)
        {
            for(int n = 0; n < list.Count; n++)
            {
                if (attribute[i] == list[n])
                {
                    return CardList[num].m_AllAssist.getAssistPower();
                }
            }
        }
        return 0;
    }

    /// <summary>
    /// �����̌v�Z�p
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public int GetAssistPower(int num)
    {
        return CardList[num].m_Assist.getAssistPower();
    }

    /// <summary>
    /// �A���R�[�� �m��D�̃L������1���T�����ɒu���n�����L�����ւ̉����̌v�Z�p
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public int GetAssistForHaveEncorePower(int num)
    {
        return CardList[num].m_AssistForHaveEncore.getAssistPower();
    }

    /// <summary>
    /// �w��̏ꏊ�̃L�����̓������擾����
    /// </summary>
    /// <param name="place"></param>
    /// <returns></returns>
    public AttributeInstance.AttributeUpUntilTurnEnd GetAttributeUpUntilTurnEnd(int place)
    {
        return CardList[place].m_AttributeUpUntilTurnEnd;
    }

    public BattleModeCard GetBattleModeCard(int place)
    {
        return CardList[place].getBattleModeCard();
    }

    public List<List<EnumController.Attribute>> GetFieldAttributeList()
    {
        List<List<EnumController.Attribute>> list = new List<List<EnumController.Attribute>>();
        for (int i = 0; i < CardList.Count; i++)
        {
            list.Add(CardList[i].AttributeList);
        }
        return list;
    }

    public int GetFieldLevel(int place)
    {
        return CardList[place].GetFieldLevel();
    }

    public List<int> GetFieldLevel()
    {
        List<int> list = new List<int>();
        for (int i = 0; i < CardList.Count; i++)
        {
            list.Add(CardList[i].GetFieldLevel());
        }
        return list;
    }

    public int GetFieldPower(int place)
    {
        return CardList[place].GetFieldPower();
    }

    public List<int> GetFieldPower()
    {
        List<int> list = new List<int>();
        for (int i = 0; i < CardList.Count; i++)
        {
            list.Add(CardList[i].GetFieldPower());
        }
        return list;
    }

    public List<int> GetFieldSoul()
    {
        List<int> list = new List<int>();
        for (int i = 0; i < CardList.Count; i++)
        {
            list.Add(CardList[i].GetFieldSoul());
        }
        return list;
    }

    public int GetFieldSoul(int place)
    {
        return CardList[place].GetFieldSoul();
    }

    /// <summary>
    /// �K�E�����ʂ̌v�Z�p
    /// </summary>
    /// <returns></returns>
    public int GetGaulPower(int num, List<EnumController.Attribute> attributeList)
    {
        if (attributeList == null)
        {
            return 0;
        }

        int count = 0;
        for (int i = 0; i < CardList.Count; i++)
        {
            if (CardList[i].HaveAttribute(attributeList))
            {
                count++;
            }
        }

        return CardList[num].m_Gaul.GetAssistPower(count);
    }

    public List<bool> GetIsGreatPerformance()
    {
        List<bool> list = new List<bool>();
        for (int i = 0; i < CardList.Count; i++)
        {
            list.Add(CardList[i].isGreatPerformance);
        }
        return list;
    }

    public bool GetIsGreatPerformance(int place)
    {
        if (CardList[place].isGreatPerformance && CardList[place].GetState() != EnumController.State.REVERSE)
        {
            return true;
        }
        return false;
    }

    public int GetLevelAssistPower(int num, int FieldLevel)
    {
        return CardList[num].m_LevelAssist.getAssistPower(FieldLevel);
    }

    /// <summary>
    /// �t�B�[���h�̓���̓����������Ă���L�����̐��𒲂ׂ�֐�(�����͊܂߂Ȃ�)
    /// </summary>
    /// <param name="num"></param>
    /// <param name="attributeList"></param>
    /// <returns></returns>
    public int GetNumFieldAttribute(int num, List<EnumController.Attribute> attributeList)
    {
        if (attributeList == null)
        {
            return 0;
        }

        int count = 0;
        for (int i = 0; i < CardList.Count; i++)
        {
            if (CardList[i].HaveAttribute(attributeList) && i != num)
            {
                count++;
            }
        }

        return count;
    }

    public int GetNumFieldCardNo(List<EnumController.CardNo> list)
    {
        if (list.Count == 0)
        {
            return 0;
        }
        int num = 0;
        for (int i = 0; i < CardList.Count; i++)
        {
            for (int n = 0; n < list.Count; n++)
            {
                BattleModeCard temp = CardList[i].getBattleModeCard();
                if (temp == null)
                {
                    continue;
                }
                if (temp.cardNo == list[n])
                {
                    num++;
                }
            }
        }

        return num;
    }

    public PowerInstance.PowerUpUntilTurnEnd GetPowerUpUntilTurnEnd(int place)
    {
        return CardList[place].m_PowerUpUntilTurnEnd;
    }

    public SoulInstance.SoulUpUntilTurnEnd GetSoulUpUntilTurnEnd(int place)
    {
        return CardList[place].m_SoulUpUntilTurnEnd;
    }

    public EnumController.State GetState(int num)
    {
        return CardList[num].GetState();
    }

    public bool HaveAttribute(int place, EnumController.Attribute paramater)
    {
        return CardList[place].HaveAttribute(paramater);
    }

    /// <summary>
    /// ����̃J�[�h�������J�[�h���t�B�[���h�ɑ��݂��邩�m�F����
    /// </summary>
    /// <returns></returns>
    public bool isContainFieldName(string t)
    {
        for (int i = 0; i < CardList.Count; i++)
        {
            if (CardList[i].isContainFieldName(t))
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// ����̕�������܂ނ����ׂ�
    /// </summary>
    /// <returns></returns>
    public bool isContainFieldName(int num, string t)
    {
        return CardList[num].isContainFieldName(t);
    }

    /// <summary>
    /// ����̃L�������̃J�[�h���t�B�[���h�ɑ��݂��邩�m�F����
    /// </summary>
    /// <returns></returns>
    public bool isFieldName(string t)
    {
        for(int i = 0; i < CardList.Count; i++)
        {
            if (CardList[i].isFieldName(t))
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// �t�B�[���h�̃L���������̃J�[�h�������ׂ�
    /// </summary>
    /// <returns></returns>
    public bool isFieldName(int num, string t)
    {
        return CardList[num].isFieldName(t);
    }

    /// <summary>
    /// �t�B�[���h��ŃN���b�N�A���R�[���������Ă��邩
    /// </summary>
    public bool isClockEncore(int num)
    {
        return CardList[num].ClockEncore;
    }

    /// <summary>
    /// �t�B�[���h��Ŏ�D�A���R�[���������Ă��邩
    /// </summary>
    /// <returns></returns>
    public bool isHandEncore(int num)
    {
        return CardList[num].HandEncore;
    }

    /// <summary>
    /// �t�B�[���h���2�X�g�b�N�A���R�[���������Ă��邩
    /// </summary>
    public bool isTwoStockEncore(int num)
    {
        return CardList[num].TwoStockEncore;
    }

    public void NullCheck()
    {
        for(int i = 0; i < m_GameManager.myFieldList.Count; i++)
        {
            if (m_GameManager.myFieldList[i] == null)
            {
                CardList[i].m_PowerUpUntilTurnEnd = new PowerInstance.PowerUpUntilTurnEnd(0);
                CardList[i].m_SoulUpUntilTurnEnd = new SoulInstance.SoulUpUntilTurnEnd(0);
                CardList[i].m_LevelUpUntilTurnEnd = new LevelInstance.LevelUpUntilTurnEnd(0);
                CardList[i].setBattleModeCard(null, EnumController.State.STAND);

                // �p���[�A���x���A�����A�\�E���̌v�Z
                FieldPowerAndLevelAndAttributeAndSoulReset();
            }
        }
    }

    public void SetAttributeUpUntilTurnEnd(int place, AttributeInstance.AttributeUpUntilTurnEnd paramater)
    {
        CardList[place].m_AttributeUpUntilTurnEnd = paramater;
    }

    public void SetAttributeUpUntilTurnEnd(int place, EnumController.Attribute paramater)
    {
        CardList[place].m_AttributeUpUntilTurnEnd.AddAttribute(paramater);
    }

    public void setBattleModeCard(int num, BattleModeCard card, EnumController.State status)
    {
        CardList[num].setBattleModeCard(card, status);
    }

    public void SetClockEncore(int num, bool b)
    {
        CardList[num].ClockEncore = b;
    }

    public void SetHandEncore(int num, bool b)
    {
        CardList[num].HandEncore = b;
    }

    public void SetPowerUpUntilTurnEnd(int place, PowerInstance.PowerUpUntilTurnEnd paramater)
    {
        CardList[place].m_PowerUpUntilTurnEnd = paramater;
    }

    public void SetSoulUpUntilTurnEnd(int place, SoulInstance.SoulUpUntilTurnEnd paramater)
    {
        CardList[place].m_SoulUpUntilTurnEnd = paramater;
    }

    public void SetTwoStockEncore(int num, bool b)
    {
        CardList[num].TwoStockEncore = b;
    }
}
