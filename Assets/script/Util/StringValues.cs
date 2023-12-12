using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringValues
{
    private EnumController.Language paramater = EnumController.Language.Japanese;

    Japanese japanese = new Japanese();

    public string OKDialog_Clock;
    public string OKDialog_Marigan;
    public string HandOverDialog;
    public string YesOrNoDialog_CLIMAX_PHASE;
    public string YesOrNoDialog_COST_CONFIRM_BRAIN_STORM_FOR_DRAW;
    public string AT_WX02_A01_Explanation = "";
    public string AT_WX02_A02_Explanation = "�yAUTO�z When this card attacks, choose 1 of your other characters, and that character gets +1500 power until end of turn.";
    public string AT_WX02_A03_Explanation = "�yAUTO�z �yCXCOMBO�z When this card's battle opponent becomes �yREVERSE�z, if [Memory of a Memory] is in your climax area, you may draw 1 card.";
    public string AT_WX02_A04_Explanation = "�yAUTO�z Encore [Put 1 character from your hand into your waiting room] (When this card is put into your waiting room from the stage, you may pay the cost. If you do, return this card to its previous stage position as �yREST�z)";
    public string AT_WX02_A05_Explanation = "�yACT�z �yCOUNTER�z Backup 2500, Level 1 [(1) Put this card from your hand into your waiting room] (Choose 1 of your characters that is being frontal attacked, and that character gets +2500 power until end of turn)";
    public string AT_WX02_A06_Explanation = "�yCONT�z Assist All of your characters in front of this card get +X power. X is equal to that character's level �~500.";
    public string AT_WX02_A07_Explanation = "Search your deck for up to 1 �sOoo�t character, reveal it to your opponent, put it into your hand, and shuffle your deck.";
    public string AT_WX02_A08_Explanation = "�yCONT�z All of your characters get +1000 power and +1 soul. During this turn, when the next damage dealt by the attacking character that triggered this card is canceled, deal 1 damage to your opponent)";
    public string AT_WX02_A09_Explanation = "�yACT�z Brainstorm [(1) �yREST�z this card] Flip over 4 cards from the top of your deck, and put them into your waiting room. For each climax revealed among those cards, draw up to 1 card.";
    public string AT_WX02_A10_Explanation = "�yAUTO�z Bond/[Marceline: Party Crasher] [(1)] (When this card is played and placed on stage, you may pay the cost. If you do, choose 1 [Marceline: Party Crasher] in your waiting room, and return it to your hand)";
    public string AT_WX02_A11_Explanation = "�yCONT�z Assist All of your characters in front of this card get +500 power.";
    public string AT_WX02_A12_Explanation = "�yCONT�z This card gets +500 power for each of your other �sOoo�t characters.";
    public string AT_WX02_A13_Explanation = "�yCONT�z All of your characters get +1000 power and +1 soul. When this card triggers, you may choose 1 character in your waiting room, and return it to your hand)";
    public string AT_WX02_A01_CardNo = "AT_WX02_A01";
    public string AT_WX02_A02_CardNo = "AT_WX02_A02";
    public string AT_WX02_A03_CardNo = "AT_WX02_A03";
    public string AT_WX02_A04_CardNo = "AT_WX02_A04";
    public string AT_WX02_A05_CardNo = "AT_WX02_A05";
    public string AT_WX02_A06_CardNo = "AT_WX02_A06";
    public string AT_WX02_A07_CardNo = "AT_WX02_A07";
    public string AT_WX02_A08_CardNo = "AT_WX02_A08";
    public string AT_WX02_A09_CardNo = "AT_WX02_A09";
    public string AT_WX02_A10_CardNo = "AT_WX02_A10";
    public string AT_WX02_A11_CardNo = "AT_WX02_A11";
    public string AT_WX02_A12_CardNo = "AT_WX02_A12";
    public string AT_WX02_A13_CardNo = "AT_WX02_A13";
    public string AT_WX02_A12_NAME = "Marceline: Party Crasher";

    public StringValues() 
    {
        switch (paramater)
        {
            case EnumController.Language.Japanese:
                OKDialog_Clock = japanese.OKDialog_Clock;
                OKDialog_Marigan = japanese.OKDialog_Marigan;
                HandOverDialog = japanese.HandOverDialog;
                YesOrNoDialog_CLIMAX_PHASE = japanese.YesOrNoDialog_CLIMAX_PHASE;
                YesOrNoDialog_COST_CONFIRM_BRAIN_STORM_FOR_DRAW = japanese.YesOrNoDialog_COST_CONFIRM_BRAIN_STORM_FOR_DRAW;
                break;
            default:
                break;
        }
    }

    public class Japanese
    {
        public string OKDialog_Clock = "�N���b�N����J�[�h��I�����Ă�������";
        public string OKDialog_Marigan = "�}���K������J�[�h��I�����Ă�������";
        public string HandOverDialog = "��D��7���ɂȂ�悤�Ɏ̂ĂĂ�������";
        public string YesOrNoDialog_CLIMAX_PHASE = "�N���C�}�b�N�X�t�F�C�Y�Ɉړ����܂���";
        public string YesOrNoDialog_COST_CONFIRM_BRAIN_STORM_FOR_DRAW = "���̔\�͂��g�p���܂����B:" + "�y�N�z �W�� �m(1) ���̃J�[�h���y���X�g�z����n ���Ȃ��͎����̎R�D�̏ォ��4�����߂���A�T�����ɒu���B�����̃J�[�h�̃N���C�}�b�N�X1���ɂ��A���Ȃ���1���܂ň����B";
    }

    public string YesOrNoDialog_ENCORE_CONFIRM(string paramater1)
    {
        return paramater1 + "���A���R�[�����܂���";
    }

    public string YesOrNoDialog_COST_CONFIRM_HAND_TO_FIELD(int paramater1)
    {
        return "���̃J�[�h���v���C����ɂ̓R�X�g'" + paramater1 + "'�K�v�ł�";
    }

    public string YesOrNoDialog_COST_CONFIRM_BOND_FOR_HAND_TO_FIELD(string paramater1, int paramater2)
    {
        return "���̔\�͂��g�p���܂����B:" + "�y���z �J�^�u" + paramater1 + "�v �m(" + paramater2 + ")�n �i���̃J�[�h���v���C����ĕ���ɒu���ꂽ���A���Ȃ��̓R�X�g�𕥂��Ă悢�B����������A���Ȃ��͎����̍T�����́u" + paramater1 + "�v��1���I�сA��D�ɖ߂��j";
    }
}
