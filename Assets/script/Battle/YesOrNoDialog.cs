using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EnumController;

public class YesOrNoDialog : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] BattleStrix m_BattleStrix;
    [SerializeField] GameManager m_GameManager;
    [SerializeField] MyHandCardsManager m_MyHandCardsManager;
    [SerializeField] MyMainCardsManager m_MyMainCardsManager;
    [SerializeField] DialogManager m_DialogManager;
    [SerializeField] EffectBondForHandToField m_EffectBondForHandToField;
    [SerializeField] EffectBrainStormForDraw m_EffectBrainStormForDraw;

    private BattleModeCard m_BattleModeCard = null;

    private EnumController.YesOrNoDialogParamater m_YesOrNoDialogParamater;

    private int numberParamater = -1;

    /// <summary>
    /// �J�[�h�̌��ʂ��g�p���邽�߂̃R�X�g
    /// </summary>
    private int cost = 0;

    /// <summary>
    /// �J���ʂŉ������J�[�h�̃i���o�[
    /// </summary>
    private EnumController.CardNo sulvageCardNo = EnumController.CardNo.VOID;

    public YesOrNoDialog()
    {
        m_YesOrNoDialogParamater = EnumController.YesOrNoDialogParamater.VOID;
    }

    public void SetParamater(EnumController.YesOrNoDialogParamater paramater)
    {
        numberParamater = -1;
        m_BattleModeCard = null;
        sulvageCardNo = EnumController.CardNo.VOID;
        cost = 0;
        this.gameObject.SetActive(true);
        m_YesOrNoDialogParamater = paramater;
        SetText();
    }

    public void SetParamater(EnumController.YesOrNoDialogParamater paramater, BattleModeCard card)
    {
        numberParamater = -1;
        m_BattleModeCard = card;
        sulvageCardNo = EnumController.CardNo.VOID;
        cost = 0;
        this.gameObject.SetActive(true);
        m_YesOrNoDialogParamater = paramater;
        SetText();
    }

    public void SetParamater(EnumController.YesOrNoDialogParamater paramater, BattleModeCard card, int num)
    {
        numberParamater = num;
        m_BattleModeCard = card;
        sulvageCardNo = EnumController.CardNo.VOID;
        cost = 0;
        this.gameObject.SetActive(true);
        m_YesOrNoDialogParamater = paramater;
        SetText();
    }

    private void SetText()
    {
        string str = "";
        switch (m_YesOrNoDialogParamater)
        {
            case EnumController.YesOrNoDialogParamater.CLIMAX_PHASE:
                str = "�N���C�}�b�N�X�t�F�C�Y�Ɉړ����܂���";
                break;
            case EnumController.YesOrNoDialogParamater.ENCORE_CONFIRM:
                str = m_BattleModeCard.name + "���A���R�[�����܂���";
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_HAND_TO_FIELD:
                str = "���̃J�[�h���v���C����ɂ̓R�X�g'" + m_BattleModeCard.cost + "'�K�v�ł�";
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_BOND_FOR_HAND_TO_FIELD:
                string bondName = "";
                switch (m_BattleModeCard.cardNo)
                {
                    case EnumController.CardNo.AT_WX02_A10:
                        sulvageCardNo = EnumController.CardNo.AT_WX02_A12;
                        bondName = "Marceline: Party Crasher";
                        cost = 1;
                        break;
                    default:
                        bondName = "";
                        cost = 0;
                        break;
                }
                str = "���̔\�͂��g�p���܂����B:"+"�y���z �J�^�u" + bondName + "�v �m(" + cost + ")�n �i���̃J�[�h���v���C����ĕ���ɒu���ꂽ���A���Ȃ��̓R�X�g�𕥂��Ă悢�B����������A���Ȃ��͎����̍T�����́u" + bondName + "�v��1���I�сA��D�ɖ߂��j";
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_BRAIN_STORM_FOR_DRAW:
                str = "���̔\�͂��g�p���܂����B:"+"�y�N�z �W�� �m(1) ���̃J�[�h���y���X�g�z����n ���Ȃ��͎����̎R�D�̏ォ��4�����߂���A�T�����ɒu���B�����̃J�[�h�̃N���C�}�b�N�X1���ɂ��A���Ȃ���1���܂ň����B";
                break;
            case EnumController.YesOrNoDialogParamater.VOID:
            default:
                str = "�������b�Z�[�W";
                break;
        }
        text.text = str;
    }

    public void onYesClick()
    {
        switch (m_YesOrNoDialogParamater)
        {
            case EnumController.YesOrNoDialogParamater.CLIMAX_PHASE:
                m_GameManager.SendClimaxPhase(m_BattleModeCard);
                // �p���[�A���x���A�����̌v�Z
                m_MyMainCardsManager.FieldPowerAndLevelAndAttributeReset();
                m_BattleStrix.SendUpdateMainCards(m_GameManager.myFieldList, m_MyMainCardsManager.GetFieldPower(), m_GameManager.isTurnPlayer);
                break;
            case EnumController.YesOrNoDialogParamater.ENCORE_CONFIRM:
                if(numberParamater == -1)
                {
                    break;
                }

                for(int i = 0; i < 3; i++)
                {
                    m_GameManager.GraveYardList.Add(m_GameManager.myStockList[0]);
                    m_GameManager.myStockList.RemoveAt(0);
                }
                m_GameManager.GraveYardList.Remove(m_BattleModeCard);
                m_GameManager.myFieldList[numberParamater] = m_BattleModeCard;
                m_MyMainCardsManager.CallOnStand(numberParamater);

                m_GameManager.UpdateMyMainCards();
                // �p���[�A���x���A�����̌v�Z
                m_MyMainCardsManager.FieldPowerAndLevelAndAttributeReset();
                m_BattleStrix.SendUpdateMainCards(m_GameManager.myFieldList, m_MyMainCardsManager.GetFieldPower(), m_GameManager.isTurnPlayer);

                m_GameManager.UpdateMyGraveYardCards();
                m_BattleStrix.SendUpdateEnemyGraveYard(m_GameManager.GraveYardList, m_GameManager.isFirstAttacker);

                m_GameManager.UpdateMyStockCards();
                m_BattleStrix.SendUpdateEnemyStockCards(m_GameManager.myStockList, m_GameManager.isTurnPlayer);
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_HAND_TO_FIELD:
                m_DialogManager.MainDialog(m_BattleModeCard);
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_BOND_FOR_HAND_TO_FIELD:
                m_EffectBondForHandToField.BondForCost(sulvageCardNo, cost);
                break;
            case EnumController.YesOrNoDialogParamater.COST_CONFIRM_BRAIN_STORM_FOR_DRAW:
                m_EffectBrainStormForDraw.BrainStormForDraw(numberParamater);
                break;
            case EnumController.YesOrNoDialogParamater.VOID:
            default:
                break;
        }
        m_MyHandCardsManager.CallNotShowPlayButton();
        this.gameObject.SetActive(false);

        switch (m_YesOrNoDialogParamater)
        {
            case EnumController.YesOrNoDialogParamater.CLIMAX_PHASE:
                return;
            case EnumController.YesOrNoDialogParamater.ENCORE_CONFIRM:
                m_DialogManager.EncoreDialog(m_GameManager.myFieldList);
                return;
            case EnumController.YesOrNoDialogParamater.VOID:
                return;
            default:
                return;
        }
    }

    public void onNoClick()
    {
        m_MyHandCardsManager.CallNotShowPlayButton();
        this.gameObject.SetActive(false);
        switch (m_YesOrNoDialogParamater)
        {
            case EnumController.YesOrNoDialogParamater.ENCORE_CONFIRM:
                m_DialogManager.EncoreDialog(m_GameManager.myFieldList);
                break;
            case EnumController.YesOrNoDialogParamater.VOID:
                break;
            default: 
                break;
        }
    }

    public void OffDialog()
    {
        this.gameObject.SetActive(false);
    }
}
