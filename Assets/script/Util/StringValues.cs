using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringValues
{
    private EnumController.Language paramater = EnumController.Language.Japanese;

    Japanese japanese = new Japanese();

    public string OKDialog_Clock;
    public string OKDialog_Marigan;
    public string OKDialog_Counter;
    public string OKDialog_Counter_Confirm_Use_Card;
    public string OKDialog_HAND_ENCORE_SELECT_DISCARD_CONFIRM;
    public string HandOverDialog;
    public string YesOrNoDialog_CONFIRM_USE_COUNTER;
    public string YesOrNoDialog_CONFIRM_POOL_TRIGGER;
    public string YesOrNoDialog_CLIMAX_PHASE;
    public string YesOrNoDialog_COST_CONFIRM_BRAIN_STORM_FOR_DRAW;
    public string YesOrNoDialog_COST_CONFIRM_DC_W01_01T;
    public string YesOrNoDialog_COST_CONFIRM_DC_W01_02T;
    public string YesOrNoDialog_COST_CONFIRM_DC_W01_04T;
    public string YesOrNoDialog_COST_CONFIRM_DC_W01_05T;
    public string YesOrNoDialog_COST_CONFIRM_DC_W01_10T;
    public string YesOrNoDialog_COST_CONFIRM_DC_W01_13T;
    public string YesOrNoDialog_COST_CONFIRM_LB_W02_03T;
    public string YesOrNoDialog_COST_CONFIRM_LB_W02_05T;
    public string YesOrNoDialog_COST_CONFIRM_LB_W02_09T;
    public string YesOrNoDialog_COST_CONFIRM_LB_W02_14T;
    public string YesOrNoDialog_COST_CONFIRM_LB_W02_17T;
    public string YesOrNoDialog_COST_CONFIRM_SEND_MEMORY;
    public string SearchDialog_SearchMessage;
    public string ConfirmSearchOrSulvageCardDialog_Search;
    public string ConfirmSearchOrSulvageCardDialog_Sulvage;
    public string ConfirmSearchOrSulvageCardDialog_Clock_Sulvage;
    public string ConfirmSearchOrSulvageCardDialog_DC_W01_12T;
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
    public string DC_W01_01T_Explanation;
    public string DC_W01_02T_Explanation;
    public string DC_W01_03T_Explanation;
    public string DC_W01_04T_Explanation;
    public string DC_W01_05T_Explanation;
    public string DC_W01_06T_Explanation;
    public string DC_W01_07T_Explanation;
    public string DC_W01_08T_Explanation;
    public string DC_W01_09T_Explanation;
    public string DC_W01_10T_Explanation;
    public string DC_W01_11T_Explanation;
    public string DC_W01_12T_Explanation;
    public string DC_W01_13T_Explanation;
    public string DC_W01_14T_Explanation;
    public string DC_W01_15T_Explanation;
    public string DC_W01_16T_Explanation;
    public string DC_W01_17T_Explanation;
    public string DC_W01_18T_Explanation;
    public string DC_W01_19T_Explanation;
    public string DC_W01_20T_Explanation;
    public string LB_W02_01T_Explanation;
    public string LB_W02_02T_Explanation;
    public string LB_W02_03T_Explanation;
    public string LB_W02_04T_Explanation;
    public string LB_W02_05T_Explanation;
    public string LB_W02_06T_Explanation;
    public string LB_W02_07T_Explanation;
    public string LB_W02_08T_Explanation;
    public string LB_W02_09T_Explanation;
    public string LB_W02_10T_Explanation;
    public string LB_W02_11T_Explanation;
    public string LB_W02_12T_Explanation;
    public string LB_W02_13T_Explanation;
    public string LB_W02_14T_Explanation;
    public string LB_W02_15T_Explanation;
    public string LB_W02_16T_Explanation;
    public string LB_W02_17T_Explanation;
    public string LB_W02_18T_Explanation;
    public string LB_W02_19T_Explanation;
    public string LB_W02_20T_Explanation;
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
    public string DC_W01_01T_CardNo = "DC_W01_01T";
    public string DC_W01_02T_CardNo = "DC_W01_02T";
    public string DC_W01_03T_CardNo = "DC_W01_03T";
    public string DC_W01_04T_CardNo = "DC_W01_04T";
    public string DC_W01_05T_CardNo = "DC_W01_05T";
    public string DC_W01_06T_CardNo = "DC_W01_06T";
    public string DC_W01_07T_CardNo = "DC_W01_07T";
    public string DC_W01_08T_CardNo = "DC_W01_08T";
    public string DC_W01_09T_CardNo = "DC_W01_09T";
    public string DC_W01_10T_CardNo = "DC_W01_10T";
    public string DC_W01_11T_CardNo = "DC_W01_11T";
    public string DC_W01_12T_CardNo = "DC_W01_12T";
    public string DC_W01_13T_CardNo = "DC_W01_13T";
    public string DC_W01_14T_CardNo = "DC_W01_14T";
    public string DC_W01_15T_CardNo = "DC_W01_15T";
    public string DC_W01_16T_CardNo = "DC_W01_16T";
    public string DC_W01_17T_CardNo = "DC_W01_17T";
    public string DC_W01_18T_CardNo = "DC_W01_18T";
    public string DC_W01_19T_CardNo = "DC_W01_19T";
    public string DC_W01_20T_CardNo = "DC_W01_20T";
    public string LB_W02_01T_CardNo = "LB_W02_01T";
    public string LB_W02_02T_CardNo = "LB_W02_02T";
    public string LB_W02_03T_CardNo = "LB_W02_03T";
    public string LB_W02_04T_CardNo = "LB_W02_04T";
    public string LB_W02_05T_CardNo = "LB_W02_05T";
    public string LB_W02_06T_CardNo = "LB_W02_06T";
    public string LB_W02_07T_CardNo = "LB_W02_07T";
    public string LB_W02_08T_CardNo = "LB_W02_08T";
    public string LB_W02_09T_CardNo = "LB_W02_09T";
    public string LB_W02_10T_CardNo = "LB_W02_10T";
    public string LB_W02_11T_CardNo = "LB_W02_11T";
    public string LB_W02_12T_CardNo = "LB_W02_12T";
    public string LB_W02_13T_CardNo = "LB_W02_13T";
    public string LB_W02_14T_CardNo = "LB_W02_14T";
    public string LB_W02_15T_CardNo = "LB_W02_15T";
    public string LB_W02_16T_CardNo = "LB_W02_16T";
    public string LB_W02_17T_CardNo = "LB_W02_17T";
    public string LB_W02_18T_CardNo = "LB_W02_18T";
    public string LB_W02_19T_CardNo = "LB_W02_19T";
    public string LB_W02_20T_CardNo = "LB_W02_20T";
    public string AT_WX02_A12_NAME = "Marceline: Party Crasher";
    public string DC_W01_10T_NAME = "���{���t";

    public StringValues() 
    {
        switch (paramater)
        {
            case EnumController.Language.Japanese:
                OKDialog_Clock = japanese.OKDialog_Clock;
                OKDialog_Marigan = japanese.OKDialog_Marigan;
                OKDialog_Counter = japanese.OKDialog_Counter;
                OKDialog_Counter_Confirm_Use_Card = japanese.OKDialog_Counter_Confirm_Use_Card;
                OKDialog_HAND_ENCORE_SELECT_DISCARD_CONFIRM = japanese.OKDialog_HAND_ENCORE_SELECT_DISCARD_CONFIRM;
                HandOverDialog = japanese.HandOverDialog;
                YesOrNoDialog_CONFIRM_USE_COUNTER = japanese.YesOrNoDialog_CONFIRM_USE_COUNTER;
                YesOrNoDialog_CONFIRM_POOL_TRIGGER = japanese.YesOrNoDialog_CONFIRM_POOL_TRIGGER;
                YesOrNoDialog_CLIMAX_PHASE = japanese.YesOrNoDialog_CLIMAX_PHASE;
                YesOrNoDialog_COST_CONFIRM_BRAIN_STORM_FOR_DRAW = japanese.YesOrNoDialog_COST_CONFIRM_BRAIN_STORM_FOR_DRAW;
                YesOrNoDialog_COST_CONFIRM_DC_W01_01T = japanese.YesOrNoDialog_COST_CONFIRM_DC_W01_01T;
                YesOrNoDialog_COST_CONFIRM_DC_W01_02T = japanese.YesOrNoDialog_COST_CONFIRM_DC_W01_02T;
                YesOrNoDialog_COST_CONFIRM_DC_W01_04T = japanese.YesOrNoDialog_COST_CONFIRM_DC_W01_04T;
                YesOrNoDialog_COST_CONFIRM_DC_W01_05T = japanese.YesOrNoDialog_COST_CONFIRM_DC_W01_05T;
                YesOrNoDialog_COST_CONFIRM_DC_W01_10T = japanese.YesOrNoDialog_COST_CONFIRM_DC_W01_10T;
                YesOrNoDialog_COST_CONFIRM_DC_W01_13T = japanese.YesOrNoDialog_COST_CONFIRM_DC_W01_13T;
                YesOrNoDialog_COST_CONFIRM_LB_W02_03T = japanese.YesOrNoDialog_COST_CONFIRM_LB_W02_03T;
                YesOrNoDialog_COST_CONFIRM_LB_W02_05T = japanese.YesOrNoDialog_COST_CONFIRM_LB_W02_05T;
                YesOrNoDialog_COST_CONFIRM_LB_W02_09T = japanese.YesOrNoDialog_COST_CONFIRM_LB_W02_09T;
                YesOrNoDialog_COST_CONFIRM_LB_W02_14T = japanese.YesOrNoDialog_COST_CONFIRM_LB_W02_14T;
                YesOrNoDialog_COST_CONFIRM_LB_W02_17T = japanese.YesOrNoDialog_COST_CONFIRM_LB_W02_17T;
                YesOrNoDialog_COST_CONFIRM_SEND_MEMORY = japanese.YesOrNoDialog_COST_CONFIRM_SEND_MEMORY;
                SearchDialog_SearchMessage = japanese.SearchDialog_SearchMessage;
                ConfirmSearchOrSulvageCardDialog_Search = japanese.ConfirmSearchOrSulvageCardDialog_Search;
                ConfirmSearchOrSulvageCardDialog_Sulvage = japanese.ConfirmSearchOrSulvageCardDialog_Sulvage;
                ConfirmSearchOrSulvageCardDialog_Clock_Sulvage = japanese.ConfirmSearchOrSulvageCardDialog_Clock_Sulvage;
                ConfirmSearchOrSulvageCardDialog_DC_W01_12T = japanese.ConfirmSearchOrSulvageCardDialog_DC_W01_12T;
                DC_W01_01T_Explanation = japanese.DC_W01_01T_Explanation;
                DC_W01_02T_Explanation = japanese.DC_W01_02T_Explanation;
                DC_W01_03T_Explanation = japanese.DC_W01_03T_Explanation;
                DC_W01_04T_Explanation = japanese.DC_W01_04T_Explanation;
                DC_W01_05T_Explanation = japanese.DC_W01_05T_Explanation;
                DC_W01_06T_Explanation = japanese.DC_W01_06T_Explanation;
                DC_W01_07T_Explanation = japanese.DC_W01_07T_Explanation;
                DC_W01_08T_Explanation = japanese.DC_W01_08T_Explanation;
                DC_W01_09T_Explanation = japanese.DC_W01_09T_Explanation;
                DC_W01_10T_Explanation = japanese.DC_W01_10T_Explanation;
                DC_W01_11T_Explanation = japanese.DC_W01_11T_Explanation;
                DC_W01_12T_Explanation = japanese.DC_W01_12T_Explanation;
                DC_W01_13T_Explanation = japanese.DC_W01_13T_Explanation;
                DC_W01_14T_Explanation = japanese.DC_W01_14T_Explanation;
                DC_W01_15T_Explanation = japanese.DC_W01_15T_Explanation;
                DC_W01_16T_Explanation = japanese.DC_W01_16T_Explanation;
                DC_W01_17T_Explanation = japanese.DC_W01_17T_Explanation;
                DC_W01_18T_Explanation = japanese.DC_W01_18T_Explanation;
                DC_W01_19T_Explanation = japanese.DC_W01_19T_Explanation;
                DC_W01_20T_Explanation = japanese.DC_W01_20T_Explanation;
                LB_W02_01T_Explanation = japanese.LB_W02_01T_Explanation;
                LB_W02_02T_Explanation = japanese.LB_W02_02T_Explanation;
                LB_W02_03T_Explanation = japanese.LB_W02_03T_Explanation;
                LB_W02_04T_Explanation = japanese.LB_W02_04T_Explanation;
                LB_W02_05T_Explanation = japanese.LB_W02_05T_Explanation;
                LB_W02_06T_Explanation = japanese.LB_W02_06T_Explanation;
                LB_W02_07T_Explanation = japanese.LB_W02_07T_Explanation;
                LB_W02_08T_Explanation = japanese.LB_W02_08T_Explanation;
                LB_W02_09T_Explanation = japanese.LB_W02_09T_Explanation;
                LB_W02_10T_Explanation = japanese.LB_W02_10T_Explanation;
                LB_W02_11T_Explanation = japanese.LB_W02_11T_Explanation;
                LB_W02_12T_Explanation = japanese.LB_W02_12T_Explanation;
                LB_W02_13T_Explanation = japanese.LB_W02_13T_Explanation;
                LB_W02_14T_Explanation = japanese.LB_W02_14T_Explanation;
                LB_W02_15T_Explanation = japanese.LB_W02_15T_Explanation;
                LB_W02_16T_Explanation = japanese.LB_W02_16T_Explanation;
                LB_W02_17T_Explanation = japanese.LB_W02_17T_Explanation;
                LB_W02_18T_Explanation = japanese.LB_W02_18T_Explanation;
                LB_W02_19T_Explanation = japanese.LB_W02_19T_Explanation;
                LB_W02_20T_Explanation = japanese.LB_W02_20T_Explanation;
                break;
            default:
                break;
        }
    }

    public class Japanese
    {
        public string OKDialog_Clock = "�N���b�N����J�[�h��I�����Ă�������";
        public string OKDialog_Marigan = "�}���K������J�[�h��I�����Ă�������";
        public string OKDialog_Counter = "�J�E���^�[�J�[�h������܂���B";
        public string OKDialog_Counter_Confirm_Use_Card = "�g�p����J�[�h��I�����Ă�������";
        public string OKDialog_HAND_ENCORE_SELECT_DISCARD_CONFIRM = "��D�A���R�[�������܂��B�̂Ă�J�[�h��I��ł��������B";
        public string HandOverDialog = "��D��7���ɂȂ�悤�Ɏ̂ĂĂ�������";
        public string YesOrNoDialog_CONFIRM_USE_COUNTER = "��D�̏������J�[�h���g�p���܂���";
        public string YesOrNoDialog_CLIMAX_PHASE = "�N���C�}�b�N�X�t�F�C�Y�Ɉړ����܂���";
        public string YesOrNoDialog_COST_CONFIRM_BRAIN_STORM_FOR_DRAW = "���̔\�͂��g�p���܂����B:" + "�y�N�z �W�� �m(1) ���̃J�[�h���y���X�g�z����n ���Ȃ��͎����̎R�D�̏ォ��4�����߂���A�T�����ɒu���B�����̃J�[�h�̃N���C�}�b�N�X1���ɂ��A���Ȃ���1���܂ň����B";
        public string YesOrNoDialog_COST_CONFIRM_DC_W01_01T = "���̔\�͂��g�p���܂����B:" + "�y�N�z�m���̃J�[�h���y���X�g�z����n ���Ȃ��͎����̃L������1���I�сA���̃^�[�����A�p���[���{1000�B";
        public string YesOrNoDialog_COST_CONFIRM_DC_W01_02T = "���̔\�͂��g�p���܂����B:" + "�y���z ���̃J�[�h���A�^�b�N�������A�N���C�}�b�N�X�u��Ɂu�������̉̕P�v������Ȃ�A���Ȃ��͎����̎R�D���ォ��1���I�сA�X�g�b�N�u��ɒu���A���̃^�[�����A���̃J�[�h�̃p���[���{3000�B";
        public string YesOrNoDialog_COST_CONFIRM_DC_W01_04T = "���̔\�͂��g�p���܂����B:" + "�y�N�z�m(1)�n ���̃^�[�����A���̃J�[�h�̃p���[���{2000�B";
        public string YesOrNoDialog_COST_CONFIRM_DC_W01_05T = "���̔\�͂��g�p���܂����B:" + "�y�N�z�m(1)�n ���Ȃ��͑���̑O��̃L������1���I�сA���̃^�[�����A�p���[���|1000�B";
        public string YesOrNoDialog_COST_CONFIRM_DC_W01_10T = "���̔\�͂��g�p���܂����B:" + "�y���z�m(1)�n ���̃J�[�h���A�^�b�N�������A�N���C�}�b�N�X�u��Ɂu���t�̃I���S�[���v������Ȃ�A���Ȃ��̓R�X�g�𕥂��Ă悢�B����������A���Ȃ��͎����̍T�����̃L������1���I�сA��D�ɖ߂��B";
        public string YesOrNoDialog_COST_CONFIRM_DC_W01_13T = "���̔\�͂��g�p���܂����B:" + "�y�N�z�m(2) ���̃J�[�h���y���X�g�z����n ���Ȃ��͎����̍T�����̃L������1���I�сA��D�ɖ߂��B";
        public string YesOrNoDialog_COST_CONFIRM_LB_W02_03T = "���̔\�͂��g�p���܂����B:" + "���̃J�[�h���A�^�b�N�������A�N���C�}�b�N�X�u��Ɂu���敗�̃n�~���O�v������Ȃ�A���Ȃ��͎����̎R�D���ォ��1���I�сA�X�g�b�N�u��ɒu���A���̃^�[�����A���̃J�[�h�̃p���[���{3000�B";
        public string YesOrNoDialog_COST_CONFIRM_LB_W02_05T = "���̔\�͂��g�p���܂����B:" + "�y�N�z�m(1)�n ���̂��Ȃ��̃L�������ׂĂɁA���̃^�[�����A�s�����t��^����B";
        public string YesOrNoDialog_COST_CONFIRM_LB_W02_09T = "���̔\�͂��g�p���܂����B:" + "�y�N�z�m(1)�n ���Ȃ��͑���̃L������1���I�сA���̃^�[�����A�p���[���|500�B";
        public string YesOrNoDialog_COST_CONFIRM_LB_W02_14T = "���̔\�͂��g�p���܂����B:" + "�y�N�z�m(2)�n���̃J�[�h���y���X�g�z����n ���Ȃ��͎����̃N���b�N���ォ��1���I�сA�T�����ɒu���B";
        public string YesOrNoDialog_COST_CONFIRM_LB_W02_17T = "���̔\�͂��g�p���܂����B:" + "�y�N�z�m(1)�n ���Ȃ��́s�����t�̎����̃L������1���I�сA���̃^�[�����A�p���[���{500�B";
        public string YesOrNoDialog_COST_CONFIRM_SEND_MEMORY = "���̔\�͂��g�p���܂����B:" + "�y�N�z�m(1)�n ���̃J�[�h���v���o�ɂ���B";
        public string YesOrNoDialog_CONFIRM_POOL_TRIGGER = "�v�[���A�C�R�����g���K�[���܂����B�f�b�L�g�b�v���X�g�b�N�ɒu���܂����B";
        public string SearchDialog_SearchMessage = "��D�ɉ�����J�[�h��I�����Ă�������";
        public string ConfirmSearchOrSulvageCardDialog_Search = "���肪�J�[�h���R�D��������悤�Ƃ��Ă��܂�";
        public string ConfirmSearchOrSulvageCardDialog_Sulvage = "���肪�J�[�h���T����������悤�Ƃ��Ă��܂�";
        public string ConfirmSearchOrSulvageCardDialog_Clock_Sulvage = "���肪�J�[�h���N���b�N��������悤�Ƃ��Ă��܂�";
        public string ConfirmSearchOrSulvageCardDialog_DC_W01_12T = "���肪�J�[�h���T����������悤�Ƃ��Ă��܂�";
        public string DC_W01_01T_Explanation = "�y�N�z�m���̃J�[�h���y���X�g�z����n ���Ȃ��͎����̃L������1���I�сA���̃^�[�����A�p���[���{1000�B";
        public string DC_W01_02T_Explanation = "�y�i�z �劈��y���z ���̃J�[�h���v���C����ĕ���ɒu���ꂽ���A���Ȃ��͑���̎�D������B�y���z ���̃J�[�h���A�^�b�N�������A�N���C�}�b�N�X�u��Ɂu�������̉̕P�v������Ȃ�A���Ȃ��͎����̎R�D���ォ��1���I�сA�X�g�b�N�u��ɒu���A���̃^�[�����A���̃J�[�h�̃p���[���{3000�B";
        public string DC_W01_03T_Explanation = "���Ȃ��͎����̎R�D���ォ��1���I�сA�X�g�b�N�u��ɒu���B���Ȃ��͎����̃L������1���I�сA���̃^�[�����A�p���[���{500�B";
        public string DC_W01_04T_Explanation = "�y�N�z�m(1)�n ���̃^�[�����A���̃J�[�h�̃p���[���{2000�B";
        public string DC_W01_05T_Explanation = "�y�N�z�m(1)�n ���Ȃ��͑���̑O��̃L������1���I�сA���̃^�[�����A�p���[���|1000�B";
        public string DC_W01_06T_Explanation = "�y�i�z ���Ȃ��̃L�������ׂĂɁA�p���[���{1000���A�\�E�����{1�B";
        public string DC_W01_07T_Explanation = "�y���z ���̃o�g�����Ă��邠�Ȃ��̃L�������y���o�[�X�z�������A���Ȃ��͎����̃L������1���I�сA���̃^�[�����A�p���[���{1000�B�y�N�z�m(3)�n ���Ȃ��͎����̍T�����̃L������1���I�сA��D�ɖ߂��B";
        public string DC_W01_08T_Explanation = "�y�i�z �A���[�� ���̃J�[�h���N���b�N��1�ԏ�ɂ���A���Ȃ��̃��x����2�ȏ�Ȃ�A�Ԃ̂��Ȃ��̃L�������ׂĂɁA���̔\�͂�^����B�w�y���z ���̃J�[�h���y���o�[�X�z�������A���̃J�[�h�ƃo�g�����Ă���L�����̃��x�������̃J�[�h�̃��x���ȉ��Ȃ�A���Ȃ��͂��̃L�������y���o�[�X�z���Ă悢�B�x";
        public string DC_W01_09T_Explanation = "�y�i�z ���̂��Ȃ��̃J�[�h���Ɂu���t�v���܂ރL�������ׂĂɁA�p���[���{500�B�y���z �J�^�u���{���t�v �m(1)�n �i���̃J�[�h���v���C����ĕ���ɒu���ꂽ���A���Ȃ��̓R�X�g�𕥂��Ă悢�B����������A���Ȃ��͎����̍T�����́u���{���t�v��1���I�сA��D�ɖ߂��j";
        public string DC_W01_10T_Explanation = "�y���z ���̃J�[�h�ƃo�g�����Ă���L�������y���o�[�X�z�������A���Ȃ��͂��̃L�������R�D�̏�ɒu���Ă悢�B�y���z�m(1)�n ���̃J�[�h���A�^�b�N�������A�N���C�}�b�N�X�u��Ɂu���t�̃I���S�[���v������Ȃ�A���Ȃ��̓R�X�g�𕥂��Ă悢�B����������A���Ȃ��͎����̍T�����̃L������1���I�сA��D�ɖ߂��B";
        public string DC_W01_11T_Explanation = "";
        public string DC_W01_12T_Explanation = "���Ȃ��͎����̍T�����̃L������2���܂őI�сA��D�ɖ߂��B";
        public string DC_W01_13T_Explanation = "�y�i�z ���́s�o�i�i�t�̂��Ȃ��̃L����������Ȃ�A���̃J�[�h�̃p���[���{1500�B�y�N�z�m(2) ���̃J�[�h���y���X�g�z����n ���Ȃ��͎����̍T�����̃L������1���I�сA��D�ɖ߂��B";
        public string DC_W01_14T_Explanation = "";
        public string DC_W01_15T_Explanation = "";
        public string DC_W01_16T_Explanation = "�y�i�z ���́s���y�t�̂��Ȃ��̃L������2���ȏア��Ȃ�A���̃J�[�h�̃p���[���{1000�B�y���z ���̃J�[�h���y���o�[�X�z�������A���̃J�[�h�ƃo�g�����Ă���L�����̃��x����1�ȉ��Ȃ�A���Ȃ��͂��̃L�������y���o�[�X�z���Ă悢�B";
        public string DC_W01_17T_Explanation = "�y�N�z�y�J�E���^�[�z ������3000 ���x��2 �m(1) ��D�̂��̃J�[�h���T�����ɒu���n �i���Ȃ��̓t�����g�A�^�b�N����Ă��鎩���̃L������1���I�сA���̃^�[�����A�p���[���{3000�j";
        public string DC_W01_18T_Explanation = "���Ȃ��̓��x��1�ȉ��̑���̃L������1���I�сA�T�����ɒu���B";
        public string DC_W01_19T_Explanation = "�y�i�z ���Ȃ��̃L�������ׂĂɁA�p���[���{1000���A�\�E�����{1�B�i���̃J�[�h���g���K�[�������A���Ȃ��͎����̍T�����̃L������1���I�сA��D�ɖ߂��Ă悢�j";
        public string DC_W01_20T_Explanation = "�y�i�z ���Ȃ��̃L�������ׂĂɁA�\�E�����{2�B";
        public string LB_W02_01T_Explanation = "";
        public string LB_W02_02T_Explanation = "�y�N�z�m(1)�n ���Ȃ��͎����̃L������1���I�сA���̃^�[�����A�p���[���{1500�B�y�N�z�m(1)�n ���̃J�[�h���v���o�ɂ���B";
        public string LB_W02_03T_Explanation = "�y�i�z �劈��y���z ���̃J�[�h���A�^�b�N�������A�N���C�}�b�N�X�u��Ɂu���敗�̃n�~���O�v������Ȃ�A���Ȃ��͎����̎R�D���ォ��1���I�сA�X�g�b�N�u��ɒu���A���̃^�[�����A���̃J�[�h�̃p���[���{3000�B�y���z �A���R�[�� �m��D�̃L������1���T�����ɒu���n �i���̃J�[�h�����䂩��T�����ɒu���ꂽ���A���Ȃ��̓R�X�g�𕥂��Ă悢�B����������A���̃J�[�h�������g�Ɂy���X�g�z���Ēu���j";
        public string LB_W02_04T_Explanation = "�y�J�E���^�[�z ���Ȃ��͎����̃L������2���܂őI�сA���̃^�[�����A�p���[���{1000�B";
        public string LB_W02_05T_Explanation = "�y�i�z ���� ���̃J�[�h�̑O�̂��Ȃ��̃L�������ׂĂɁA�p���[���{500�B�y�N�z�m(1)�n ���̂��Ȃ��̃L�������ׂĂɁA���̃^�[�����A�s�����t��^����B";
        public string LB_W02_06T_Explanation = "";
        public string LB_W02_07T_Explanation = "�y�i�z ���̂��Ȃ��́u�g�ŋ��̒j���h����v���ׂĂɁA�p���[���{1000�B�y�N�z�y�J�E���^�[�z ������2000 ���x��1 �m(1) ��D�̂��̃J�[�h���T�����ɒu���n �i���Ȃ��̓t�����g�A�^�b�N����Ă��鎩���̃L������1���I�сA���̃^�[�����A�p���[���{2000�j";
        public string LB_W02_08T_Explanation = "�y���z ���̃J�[�h���v���C����ĕ���ɒu���ꂽ���A���Ȃ��͎����̎R�D���ォ��1���I�сA���̃J�[�h�̉��Ƀ}�[�J�[�Ƃ��Ēu���B�y�N�z�m���̃J�[�h���y���X�g�z����n ���̃J�[�h�̉��̃}�[�J�[��1���ȉ��Ȃ�A���Ȃ��͎����̎R�D���ォ��1���I�сA���̃J�[�h�̉��Ƀ}�[�J�[�Ƃ��Ēu���B�y�N�z�m���̃J�[�h���y���X�g�z����n ���̃^�[�����A���Ȃ��������̗΂̃L�����̔\�͂��g�����A���̃J�[�h�̉��̃}�[�J�[���A�X�g�b�N�̂����ɕ����Ă悢�B";
        public string LB_W02_09T_Explanation = "�y�N�z�m(1)�n ���Ȃ��͑���̃L������1���I�сA���̃^�[�����A�p���[���|500�B";
        public string LB_W02_10T_Explanation = "�y�i�z ���Ȃ��̃L�������ׂĂɁA�p���[���{1000���A�\�E�����{1�B�i���̃J�[�h���g���K�[�������A���Ȃ��͎����̎R�D���ォ��1���I�сA�X�g�b�N�u��ɒu���Ă悢�j";
        public string LB_W02_11T_Explanation = "�y�i�z ���Ȃ��̃L�������ׂĂɁA�\�E�����{2�B";
        public string LB_W02_12T_Explanation = "���Ȃ��͎����̎R�D�����ās�����t�̃L������1���܂őI��ő���Ɍ����A��D�ɉ�����B���̎R�D���V���b�t������B";
        public string LB_W02_13T_Explanation = "�y���z�m���̃J�[�h���T�����ɒu���n ���̂��Ȃ��̃L���������䂩��T�����ɒu���ꂽ���A���ɂ��̃J�[�h������Ȃ�A���Ȃ��̓R�X�g�𕥂��Ă悢�B����������A���̃J�[�h�����̃J�[�h�������g�Ɂy���X�g�z���Ēu���B";
        public string LB_W02_14T_Explanation = "�y���z ���Ȃ������x���A�b�v�������A���Ȃ��͎����̎R�D���ォ��1���I�сA�X�g�b�N�u��ɒu���B�y�N�z�m(2) ���̃J�[�h���y���X�g�z����n ���Ȃ��͎����̃N���b�N���ォ��1���I�сA�T�����ɒu���B";
        public string LB_W02_15T_Explanation = "�y�i�z �A���[�� ���̃J�[�h���N���b�N��1�ԏ�ɂ���Ȃ�A�̂��Ȃ��̃L�������ׂĂɁA�w�y���z �A���R�[�� �m��D�̃L������1���T�����ɒu���n�x�Ƃ����\�͂�^����B";
        public string LB_W02_16T_Explanation = "���Ȃ��͎����̃N���b�N��1���I�сA��D�ɖ߂��B���̃J�[�h���v���o�ɂ���B";
        public string LB_W02_17T_Explanation = "�y�i�z ���� ���̃J�[�h�̑O�̂��Ȃ��̃L�������ׂĂɁA�p���[���{500�B�y�N�z�m(1)�n ���Ȃ��́s�����t�̎����̃L������1���I�сA���̃^�[�����A�p���[���{500�B";
        public string LB_W02_18T_Explanation = "";
        public string LB_W02_19T_Explanation = "�y���z�m(1)�n ���̃J�[�h�ƃo�g�����Ă��郌�x��2�ȏ�̃L�������y���o�[�X�z�������A���Ȃ��̓R�X�g�𕥂��Ă悢�B����������A���Ȃ���1�������B";
        public string LB_W02_20T_Explanation = "�y�i�z ���Ȃ��̃L�������ׂĂɁA�p���[���{1000���A�\�E�����{1�B";
    }

    public string YesOrNoDialog_COST_CONFIRM_HAND_TO_FIELD(int paramater1)
    {
        return "���̃J�[�h���v���C����ɂ̓R�X�g'" + paramater1 + "'�K�v�ł�";
    }

    public string YesOrNoDialog_COST_CONFIRM_BOND_FOR_HAND_TO_FIELD(string paramater1, int paramater2)
    {
        return "���̔\�͂��g�p���܂����B:" + "�y���z �J�^�u" + paramater1 + "�v �m(" + paramater2 + ")�n �i���̃J�[�h���v���C����ĕ���ɒu���ꂽ���A���Ȃ��̓R�X�g�𕥂��Ă悢�B����������A���Ȃ��͎����̍T�����́u" + paramater1 + "�v��1���I�сA��D�ɖ߂��j";
    }

    public string YesOrNoDialog_CONFIRM_CARD_EFFECT(string paramater1)
    {
        return paramater1 + "�̃J�[�h�̌��ʂ��g�p���܂���";
    }

    public string YesOrNoDialog_EVENT_CONFIRM(string paramater1)
    {
        return paramater1 + "���v���C���܂���";
    }
}
