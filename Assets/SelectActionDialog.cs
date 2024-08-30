using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectActionDialog : MonoBehaviour
{
    [SerializeField] DialogManager m_DialogManager;
    [SerializeField] Text text1;
    [SerializeField] Text text2;
    [SerializeField] Text text3;

    List<Action> ActionList = new List<Action>();

    int displayNum = 0;

    public void OKButton()
    {
        ActionList[displayNum].Execute();
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

    public void SetDialog(List<Action> ActionList)
    {
        if(ActionList.Count == 0)
        {
            OffDialog();
            return;
        }else if(ActionList.Count == 1)
        {
            ActionList[0].Execute();
            OffDialog();
            return;
        }

        this.ActionList = ActionList;

        // レベルアップのアクションがあれば優先的に処理する
        int havePowerCheckForLevelUpDialogAction = HaveParamater(EnumController.Action.PowerCheckForLevelUpDialog);
        if (havePowerCheckForLevelUpDialogAction != -1)
        {
            ActionList[havePowerCheckForLevelUpDialogAction].Execute();
            OffDialog();
            return;
        }

        // リフレッシュダメージのアクションがあれば優先的に処理する
        int haveRefreshAction = HaveParamater(EnumController.Action.DamageRefresh);
        if(haveRefreshAction != -1)
        {
            ActionList[haveRefreshAction].Execute();
            OffDialog();
            return;
        }

        displayNum = 0;
        SetText(ActionList[displayNum].GetParamater());
        this.gameObject.SetActive(true);
    }

    public void SetText(EnumController.Action paramater)
    {
        switch (paramater)
        {
            // クロック2ドローした後の処理
            case EnumController.Action.ClockAndTwoDraw:
                text1.text = "このメッセージが表示されるのはおかしい";
                text2.text = "ClockAndTwoDraw";
                text3.text = "";
                break;
            case EnumController.Action.PowerCheckForLevelUpDialog:
                text1.text = "このメッセージが表示されるのはおかしい";
                text2.text = "PowerCheckForLevelUpDialog";
                text3.text = "";
                break;
            case EnumController.Action.DamageForFrontAttack2ForCancel:
                text1.text = "このメッセージが表示されるのはおかしい"; ;
                text2.text = "DamageForFrontAttack2ForCancel";
                text3.text = "";
                break;
            case EnumController.Action.DamageForFrontAttack2ForDamaged:
                text1.text = "このメッセージが表示されるのはおかしい";
                text2.text = "DamageForFrontAttack2ForDamaged";
                text3.text = "";
                break;
            case EnumController.Action.DamageRefresh:
                text1.text = "このメッセージが表示されるのはおかしい";
                text2.text = "DamageRefresh";
                text3.text = "";
                break;
            default:
                text1.text = "";
                text2.text = "エラーメッセージ";
                text3.text = "";
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
