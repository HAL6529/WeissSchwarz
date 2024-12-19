using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectActionDialog : MonoBehaviour
{
    [SerializeField] GameManager m_GameManager;
    [SerializeField] DialogManager m_DialogManager;
    [SerializeField] Text text1;
    [SerializeField] Text text2;
    [SerializeField] Text text3;

    List<Action> ActionList = new List<Action>();

    int displayNum = 0;

    public void OKButton()
    {
        ActionList[displayNum].Execute(displayNum);
        OffDialog();
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
        this.ActionList = actionList;
        if (ActionList.Count == 0)
        {
            OffDialog();
            return;
        }else if(ActionList.Count == 1)
        {
            ActionList[0].Execute(0);
            OffDialog();
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

        displayNum = 0;
        SetText(ActionList[displayNum].GetParamater());
        this.gameObject.SetActive(true);
    }

    public void SetText(EnumController.Action paramater)
    {
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
