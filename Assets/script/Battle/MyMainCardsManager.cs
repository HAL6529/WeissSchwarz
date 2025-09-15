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
    /// 自分がレベルアップしたときに発動する効果
    /// </summary>
    public void CallLevelUp()
    {
        for (int i = 0; i < CardList.Count; i++)
        {
            CardList[i].WhenLevelUp();
        }
    }

    /// <summary>
    /// フィールドからデッキトップに置かれるときに呼ばれる
    /// </summary>
    public void CallPutDeckTopFromField(int num)
    {
        CardList[num].PutDeckTopFromField();
    }

    /// <summary>
    /// 控室から舞台に置かれるときに呼ばれる
    /// </summary>
    public void CallPutFieldFromGraveYard(int place, BattleModeCard card, EnumController.State state)
    {
        CardList[place].PutFieldFromGraveYard(card, state);
    }

    /// <summary>
    /// 手札から舞台に置かれる時に呼ばれる
    /// </summary>
    public void CallPutFieldFromHand(int place, int num, EnumController.State state)
    {
        CardList[place].PutFieldFromHand(num, state);
    }

    /// <summary>
    /// 「あなたは自分の手札の「XXXXXXXX」を１枚選び、このカードがいた枠に置く。」の効果
    /// </summary>
    public void CallPutFieldFromHandForEffect(int place, int num, EnumController.State state)
    {
        CardList[place].PutFieldFromHandForEffect(num, state);
    }

    /// <summary>
    /// フィールドから控室に置かれる時に呼ばれる
    /// </summary>
    public void CallPutGraveYardFromField(int place)
    {
        CardList[place].PutGraveYardFromField();
    }

    /// <summary>
    /// フィールドから手札に戻す時に呼ばれる
    /// </summary>
    public void CallPutHandFromField(int place)
    {
        CardList[place].PutHandFromField();
    }

    /// <summary>
    /// フィールドから思い出に置かれる時に呼ばれる
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
    /// 相手をリバースしたときに発動する効果
    /// </summary>
    /// <param name="num">自分のカードの場所</param>
    /// <param name="reversedCardPlace">リバースしたキャラの場所(リバースしたキャラのコントローラー視点)</param>
    /// <param name="reversedCardLevel">リバースしたキャラのレベル</param>
    public void CallWhenReverseEnemyCard(int num, int reversedCardPlace, int reversedCardLevel)
    {
        CardList[num].WhenReverseEnemyCard(reversedCardPlace, reversedCardLevel);
    }

    /// <summary>
    /// 「【自】 他のあなたのキャラがプレイされて舞台に置かれた時」に発動する効果を持っているカードが場にないか確認する
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
    /// 「【自】 他のバトルしているあなたのキャラが【リバース】した時」の効果を持っているカードが場にないか確認する
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
    /// 全体応援の計算用
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
    /// 応援の計算用
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public int GetAssistPower(int num)
    {
        return CardList[num].m_Assist.getAssistPower();
    }

    /// <summary>
    /// アンコール ［手札のキャラを1枚控え室に置く］を持つキャラへの応援の計算用
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public int GetAssistForHaveEncorePower(int num)
    {
        return CardList[num].m_AssistForHaveEncore.getAssistPower();
    }

    /// <summary>
    /// 指定の場所のキャラの特徴を取得する
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
    /// ガウル効果の計算用
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
    /// フィールドの特定の特徴を持っているキャラの数を調べる関数(自分は含めない)
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
    /// 特定のカード名をもつカードがフィールドに存在するか確認する
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
    /// 特定の文字列を含むか調べる
    /// </summary>
    /// <returns></returns>
    public bool isContainFieldName(int num, string t)
    {
        return CardList[num].isContainFieldName(t);
    }

    /// <summary>
    /// 特定のキャラ名のカードがフィールドに存在するか確認する
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
    /// フィールドのキャラがそのカード名か調べる
    /// </summary>
    /// <returns></returns>
    public bool isFieldName(int num, string t)
    {
        return CardList[num].isFieldName(t);
    }

    /// <summary>
    /// フィールド上でクロックアンコールを持っているか
    /// </summary>
    public bool isClockEncore(int num)
    {
        return CardList[num].ClockEncore;
    }

    /// <summary>
    /// フィールド上で手札アンコールを持っているか
    /// </summary>
    /// <returns></returns>
    public bool isHandEncore(int num)
    {
        return CardList[num].HandEncore;
    }

    /// <summary>
    /// フィールド上で2ストックアンコールを持っているか
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

                // パワー、レベル、特徴、ソウルの計算
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
