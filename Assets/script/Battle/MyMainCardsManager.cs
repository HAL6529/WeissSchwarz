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

    public void AddPowerUpUntilTurnEnd(int num, int power)
    {
        CardList[num].m_PowerUpUntilTurnEnd.AddUpPower(power);
    }

    public void AddSoulUpUntilTurnEnd(int num, int soul)
    {
        CardList[num].m_SoulUpUntilTurnEnd.AddUpSoul(soul);
    }

    public void ResetPowerUpUntilTurnEnd(int num)
    {
        CardList[num].m_PowerUpUntilTurnEnd.ResetUpPower();
    }

    public void ResetSoulUpUntilTurnEnd(int num)
    {
        CardList[num].m_SoulUpUntilTurnEnd.ResetUpSoul();
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
        CardList[num].onRest();
    }

    public void CallOnReverse(int num)
    {
        CardList[num].onReverse();
    }

    public void CallOnStand(int num)
    {
        CardList[num].Stand();
    }

    /// <summary>
    /// �t�B�[���h����T���ɒu����鎞�ɌĂ΂��
    /// </summary>
    public void CallPutGraveYardFromField(int place)
    {
        CardList[place].PutGraveYardFromField();
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
    /// ���������x���A�b�v�����Ƃ��ɔ����������
    /// </summary>
    public void CallLevelUp()
    {
        for(int i = 0; i < CardList.Count; i++)
        {
            CardList[i].WhenLevelUp();
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
        }
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
    /// �w��̏ꏊ�̃L�����̓������擾����
    /// </summary>
    /// <param name="place"></param>
    /// <returns></returns>
    public AttributeInstance.AttributeUpUntilTurnEnd GetAttributeUpUntilTurnEnd(int place)
    {
        return CardList[place].m_AttributeUpUntilTurnEnd;
    }

    /// <summary>
    /// �K�E�����ʂ̌v�Z�p
    /// </summary>
    /// <returns></returns>
    public int GetGaulPower(int num, List<EnumController.Attribute> attributeList)
    {
        if(attributeList == null)
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

    public int GetLevelAssistPower(int num, int FieldLevel)
    {
        return CardList[num].m_LevelAssist.getAssistPower(FieldLevel);
    }

    public EnumController.State GetState(int num)
    {
        return CardList[num].GetState();
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
        if(list.Count == 0)
        {
            return 0;
        }
        int num = 0;
        for(int i = 0; i < CardList.Count; i++)
        {
            for(int n = 0; n < list.Count; n++)
            {
                BattleModeCard temp = CardList[i].getBattleModeCard();
                if(temp == null)
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

    public List<List<EnumController.Attribute>> GetFieldAttributeList()
    {
        List<List<EnumController.Attribute>> list = new List<List<EnumController.Attribute>>();
        for (int i = 0; i < CardList.Count; i++)
        {
            list.Add(CardList[i].AttributeList);
        }
        return list;
    }

    public int GetFieldPower(int place)
    {
        return CardList[place].GetFieldPower();
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
        if(CardList[place].isGreatPerformance && CardList[place].GetState() != EnumController.State.REVERSE)
        {
            return true;
        }
        return false;
    }

    public int GetFieldSoul(int place)
    {
        return CardList[place].GetFieldSoul();
    }

    public PowerInstance.PowerUpUntilTurnEnd GetPowerUpUntilTurnEnd(int place)
    {
        return CardList[place].m_PowerUpUntilTurnEnd;
    }

    public SoulInstance.SoulUpUntilTurnEnd GetSoulUpUntilTurnEnd(int place)
    {
        return CardList[place].m_SoulUpUntilTurnEnd;
    }

    public bool HaveAttribute(int place, EnumController.Attribute paramater)
    {
        return CardList[place].HaveAttribute(paramater);
    }

    public void SetPowerUpUntilTurnEnd(int place, PowerInstance.PowerUpUntilTurnEnd paramater)
    {
        CardList[place].m_PowerUpUntilTurnEnd = paramater;
    }

    public void SetSoulUpUntilTurnEnd(int place, SoulInstance.SoulUpUntilTurnEnd paramater)
    {
        CardList[place].m_SoulUpUntilTurnEnd = paramater;
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
            CardList[i].EffectWhenMyOtherCardPut(PlaceNum);
        }
    }

    /// <summary>
    /// �u�y���z ���̃o�g�����Ă��邠�Ȃ��̃L�������y���o�[�X�z�������v�̌��ʂ������Ă���J�[�h����ɂȂ����m�F����
    /// </summary>
    public void ConfirmEffectWhenMyCardReversed(int PlaceNum)
    {
        for(int i = 0; i < CardList.Count; i++)
        {
            if(i == PlaceNum)
            {
                continue;
            }
            CardList[i].EffectWhenMyOtherCardReversed();
        }
    }
}
