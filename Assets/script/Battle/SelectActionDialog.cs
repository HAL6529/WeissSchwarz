using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectActionDialog : MonoBehaviour
{
    [SerializeField] BattleStrix m_BattleStrix;
    [SerializeField] GameManager m_GameManager;
    [SerializeField] DialogManager m_DialogManager;
    [SerializeField] Text text1;
    [SerializeField] Text text2;
    [SerializeField] Text text3;

    List<Action> ActionList = new List<Action>();

    int displayNum = 0;

    public void OKButton()
    {
        OffDialog();
        ActionList[displayNum].Execute(displayNum);
    }

    public void LeftBtn()
    {
        if (displayNum == 0)
        {
            displayNum = ActionList.Count - 1;
        }
        else
        {
            displayNum--;
        }

        SetText(ActionList[displayNum].GetParamater());
    }

    public void RightBtn()
    {
        if(displayNum == ActionList.Count - 1)
        {
            displayNum = 0;
        }
        else
        {
            displayNum++;
        }

        SetText(ActionList[displayNum].GetParamater());
    }

    public void SetDialog(List<Action> actionList)
    {
        Debug.Log("ActionList.Count:" + ActionList.Count);
        this.ActionList = actionList;
        if (ActionList.Count == 0)
        {
            OffDialog();
            return;
        }else if(ActionList.Count == 1)
        {
            ActionList[0].Execute(0);
            // OffDialog();
            return;
        }

        // ���x���A�b�v�����A���o�[�X���������t�_�����D�悷��
        int haveDamageForFrontAttack2ForDamagedAction = HaveParamater(EnumController.Action.DamageForFrontAttack2ForDamaged);
        if (haveDamageForFrontAttack2ForDamagedAction != -1)
        {
            ActionList[haveDamageForFrontAttack2ForDamagedAction].Execute(haveDamageForFrontAttack2ForDamagedAction);
            OffDialog();
            return;
        }


        // ���t���b�V���_���[�W�̃A�N�V����������ΗD��I�ɏ�������
        int haveRefreshAction = HaveParamater(EnumController.Action.DamageRefresh);
        if(haveRefreshAction != -1)
        {
            ActionList[haveRefreshAction].Execute(haveRefreshAction);
            OffDialog();
            return;
        }

        // ���x���A�b�v�̃A�N�V����������ΗD��I�ɏ�������
        int havePowerCheckForLevelUpDialog = HaveParamater(EnumController.Action.PowerCheckForLevelUpDialog);
        if (havePowerCheckForLevelUpDialog != -1)
        {
            ActionList[havePowerCheckForLevelUpDialog].Execute(havePowerCheckForLevelUpDialog);
            // OffDialog();
            return;
        }

        // �N���b�N2�h���[������̃A�N�V����������ΗD��I�ɏ�������
        int haveClockAndTwoDraw = HaveParamater(EnumController.Action.ClockAndTwoDraw);
        if (haveClockAndTwoDraw != -1)
        {
            ActionList[haveClockAndTwoDraw].Execute(haveClockAndTwoDraw);
            // OffDialog();
            return;
        }

        // SulvageDialog�̃A�N�V����������ΗD��I�ɏ�������
        int haveSulvageDialog = HaveParamater(EnumController.Action.SulvageDialog);
        if (haveSulvageDialog != -1)
        {
            ActionList[haveSulvageDialog].Execute(haveSulvageDialog);
            return;
        }

        displayNum = 0;
        SetText(ActionList[displayNum].GetParamater());
        this.gameObject.SetActive(true);
    }

    public void SetText(EnumController.Action paramater)
    {
        // 25�������x�ŉ��s���邱��
        text1.text = "";
        text2.text = "";
        text3.text = "";
        switch (paramater)
        {
            // �N���b�N2�h���[������̏���
            case EnumController.Action.ClockAndTwoDraw:
                text1.text = "���̃��b�Z�[�W���\�������̂͂�������";
                text2.text = "ClockAndTwoDraw";
                break;
            case EnumController.Action.EventAnimationManager:
                text1.text = "���̃��b�Z�[�W���\�������̂͂�������";
                text2.text = "EventAnimationManager";
                break;
            case EnumController.Action.PowerCheckForLevelUpDialog:
                text1.text = "���̃��b�Z�[�W���\�������̂͂�������";
                text2.text = "PowerCheckForLevelUpDialog";
                break;
            case EnumController.Action.DamageForFrontAttack2ForCancel:
                text1.text = "���̃��b�Z�[�W���\�������̂͂�������"; ;
                text2.text = "DamageForFrontAttack2ForCancel";
                break;
            case EnumController.Action.DamageForFrontAttack2ForDamaged:
                text1.text = "���̃��b�Z�[�W���\�������̂͂�������";
                text2.text = "DamageForFrontAttack2ForDamaged";
                break;
            case EnumController.Action.DamageRefresh:
                text1.text = "���̃��b�Z�[�W���\�������̂͂�������";
                text2.text = "DamageRefresh";
                break;
            case EnumController.Action.SulvageDialog:
                text1.text = "���̃��b�Z�[�W���\�������̂͂�������";
                text2.text = "SulvageDialog";
                break;
            case EnumController.Action.DC_W01_07T:
                text1.text = "�y���z ���̃o�g�����Ă��邠�Ȃ��̃L�������y���o�[�X�z�������A";
                text2.text = "���Ȃ��͎����̃L������1���I�сA���̃^�[�����A�p���[���{1000�B";
                break;
            case EnumController.Action.DC_W01_10T:
                text1.text = "�y�y���z ���̃J�[�h�ƃo�g�����Ă���L�������y���o�[�X�z�������A";
                text2.text = "���Ȃ��͂��̃L�������R�D�̏�ɒu���Ă悢�B";
                break;
            case EnumController.Action.DC_W01_16T:
                text1.text = "�y���z ���̃J�[�h���y���o�[�X�z�������A";
                text2.text = "���̃J�[�h�ƃo�g�����Ă���L�����̃��x����1�ȉ��Ȃ�A";
                text3.text = "���Ȃ��͂��̃L�������y���o�[�X�z���Ă悢�B";
                break;
            case EnumController.Action.LB_W02_14T:
                text1.text = "�y�y���z ���Ȃ������x���A�b�v�������A";
                text2.text = "���Ȃ��͎����̎R�D���ォ��1���I�сA�X�g�b�N�u��ɒu���B";
                break;
            case EnumController.Action.P3_S01_01T:
                text1.text = "�y���z ���̃J�[�h���v���C����ĕ���ɒu���ꂽ���A";
                text2.text = "���̃^�[�����A���̃J�[�h�̃\�E�����{1�B";
                break;
            case EnumController.Action.P3_S01_04T:
                text1.text = "�y���z ���̃J�[�h���v���C����ĕ���ɒu���ꂽ���A";
                text2.text = "���Ȃ��͎����̃L������1���I�сA���̃^�[�����A";
                text3.text = "�p���[���{2000���A�\�E�����{1�B";
                break;
            case EnumController.Action.P3_S01_07T:
                text1.text = "�y���z ���̃J�[�h���v���C����ĕ���ɒu���ꂽ���A";
                text2.text = "���̃^�[�����A���̃J�[�h�̃p���[���{1500�B";
                break;
            case EnumController.Action.P3_S01_16T:
                text1.text = "�y���z���́s���k��t�̂��Ȃ��̃L������";
                text2.text = "�v���C����ĕ���ɒu���ꂽ���A���Ȃ���";
                text3.text = "�����̎R�D���ォ��1�����āA�R�D�̏ォ���ɒu���B";
                break;
            default:
                text2.text = "�G���[���b�Z�[�W";
                break;
        }
    }

    public void OffDialog()
    {
        this.gameObject.SetActive(false);
    }

    private int HaveParamater(EnumController.Action paramater)
    {
        for(int i = 0; i < ActionList.Count; i++)
        {
            if (ActionList[i].GetParamater() == paramater)
            {
                return i;
            }
        }
        return -1;
    }
}
