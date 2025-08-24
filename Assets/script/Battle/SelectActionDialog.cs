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

        // レベルアップ処理、リバース処理をリフダメより優先する
        int haveDamageForFrontAttack2ForDamagedAction = HaveParamater(EnumController.Action.DamageForFrontAttack2ForDamaged);
        if (haveDamageForFrontAttack2ForDamagedAction != -1)
        {
            ActionList[haveDamageForFrontAttack2ForDamagedAction].Execute(haveDamageForFrontAttack2ForDamagedAction);
            OffDialog();
            return;
        }


        // リフレッシュダメージのアクションがあれば優先的に処理する
        int haveRefreshAction = HaveParamater(EnumController.Action.DamageRefresh);
        if(haveRefreshAction != -1)
        {
            ActionList[haveRefreshAction].Execute(haveRefreshAction);
            OffDialog();
            return;
        }

        // レベルアップのアクションがあれば優先的に処理する
        int havePowerCheckForLevelUpDialog = HaveParamater(EnumController.Action.PowerCheckForLevelUpDialog);
        if (havePowerCheckForLevelUpDialog != -1)
        {
            ActionList[havePowerCheckForLevelUpDialog].Execute(havePowerCheckForLevelUpDialog);
            // OffDialog();
            return;
        }

        // クロック2ドローの途中のアクションがあれば優先的に処理する
        int haveClockAndTwoDraw2 = HaveParamater(EnumController.Action.ClockAndTwoDraw2);
        if (haveClockAndTwoDraw2 != -1)
        {
            ActionList[haveClockAndTwoDraw2].Execute(haveClockAndTwoDraw2);
            // OffDialog();
            return;
        }

        // クロック2ドローした後のアクションがあれば優先的に処理する
        int haveClockAndTwoDraw = HaveParamater(EnumController.Action.ClockAndTwoDraw);
        if (haveClockAndTwoDraw != -1)
        {
            ActionList[haveClockAndTwoDraw].Execute(haveClockAndTwoDraw);
            // OffDialog();
            return;
        }

        // SulvageDialogのアクションがあれば優先的に処理する
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
        // 25文字程度で改行すること
        text1.text = "";
        text2.text = "";
        text3.text = "";
        switch (paramater)
        {
            // クロック2ドローした後の処理
            case EnumController.Action.ClockAndTwoDraw:
                text1.text = "このメッセージが表示されるのはおかしい";
                text2.text = "ClockAndTwoDraw";
                break;
            case EnumController.Action.EventAnimationManager:
                text1.text = "このメッセージが表示されるのはおかしい";
                text2.text = "EventAnimationManager";
                break;
            case EnumController.Action.PowerCheckForLevelUpDialog:
                text1.text = "このメッセージが表示されるのはおかしい";
                text2.text = "PowerCheckForLevelUpDialog";
                break;
            case EnumController.Action.DamageForFrontAttack2ForCancel:
                text1.text = "このメッセージが表示されるのはおかしい"; ;
                text2.text = "DamageForFrontAttack2ForCancel";
                break;
            case EnumController.Action.DamageForFrontAttack2ForDamaged:
                text1.text = "このメッセージが表示されるのはおかしい";
                text2.text = "DamageForFrontAttack2ForDamaged";
                break;
            case EnumController.Action.DamageRefresh:
                text1.text = "このメッセージが表示されるのはおかしい";
                text2.text = "DamageRefresh";
                break;
            case EnumController.Action.SulvageDialog:
                text1.text = "このメッセージが表示されるのはおかしい";
                text2.text = "SulvageDialog";
                break;
            case EnumController.Action.DC_W01_07T:
                text1.text = "【自】 他のバトルしているあなたのキャラが【リバース】した時、";
                text2.text = "あなたは自分のキャラを1枚選び、そのターン中、パワーを＋1000。";
                break;
            case EnumController.Action.DC_W01_10T:
                text1.text = "【【自】 このカードとバトルしているキャラが【リバース】した時、";
                text2.text = "あなたはそのキャラを山札の上に置いてよい。";
                break;
            case EnumController.Action.DC_W01_16T:
                text1.text = "【自】 このカードが【リバース】した時、";
                text2.text = "このカードとバトルしているキャラのレベルが1以下なら、";
                text3.text = "あなたはそのキャラを【リバース】してよい。";
                break;
            case EnumController.Action.LB_W02_14T:
                text1.text = "【【自】 あなたがレベルアップした時、";
                text2.text = "あなたは自分の山札を上から1枚選び、ストック置場に置く。";
                break;
            case EnumController.Action.P3_S01_01T:
                text1.text = "【自】 このカードがプレイされて舞台に置かれた時、";
                text2.text = "そのターン中、このカードのソウルを＋1。";
                break;
            case EnumController.Action.P3_S01_04T:
                text1.text = "【自】 このカードがプレイされて舞台に置かれた時、";
                text2.text = "あなたは自分のキャラを1枚選び、そのターン中、";
                text3.text = "パワーを＋2000し、ソウルを＋1。";
                break;
            case EnumController.Action.P3_S01_07T:
                text1.text = "【自】 このカードがプレイされて舞台に置かれた時、";
                text2.text = "そのターン中、このカードのパワーを＋1500。";
                break;
            case EnumController.Action.P3_S01_16T:
                text1.text = "【自】他の《生徒会》のあなたのキャラが";
                text2.text = "プレイされて舞台に置かれた時、あなたは";
                text3.text = "自分の山札を上から1枚見て、山札の上か下に置く。";
                break;
            case EnumController.Action.P3_S01_001:
                text1.text = "【自】 このカードがプレイされて舞台に置かれた時";
                text2.text = "あなたはレベル1以上の自分のキャラを1枚選び";
                text3.text = "そのターン中、ソウルを＋1。";
                break;
            case EnumController.Action.P3_S01_026:
                text1.text = "【自】 このカードがプレイされて舞台に置かれた時";
                text2.text = "あなたは自分のキャラを1枚選び";
                text3.text = "そのターン中、パワーを＋1000。";
                break;
            case EnumController.Action.P3_S01_040:
                text1.text = "【自】［このカードを【レスト】する］他の《スポーツ》のあなたのキャラが ";
                text2.text = "プレイされて舞台に置かれた時あなたはコストを払ってよい。そうしたら、";
                text3.text = "あなたは自分の山札の上から1枚を、ストック置場に置く。";
                break;
            case EnumController.Action.P3_S01_076:
                text1.text = "【自】［(1) このカードを【レスト】する］ ";
                text2.text = "他の《生徒会》のあなたのキャラがプレイされて舞台に置かれた時";
                text3.text = "あなたはコストを払ってよい。そうしたら、あなたは1枚引く。";
                break;
            case EnumController.Action.P3_S01_080_1:
                text1.text = "【自】 このカードがプレイされて舞台に置かれた時、";
                text2.text = "あなたは1枚引いてよい。";
                text3.text = "";
                break;
            case EnumController.Action.P3_S01_080_2:
                text1.text = "【自】［(1)］ このカードがプレイされて舞台に置かれた時";
                text2.text = "、あなたはコストを払ってよい。そうしたら、";
                text3.text = "あなたは自分の控え室の「ベルベットルーム」を1枚選び、手札に戻す。";
                break;
            case EnumController.Action.P3_S01_088:
                text1.text = "【自】［(2)］ このカードがプレイされて舞台に置かれた時";
                text2.text = "あなたはコストを払ってよい。そうしたら、";
                text3.text = "あなたは自分のクロックを上から1枚選び、控え室に置く。";
                break;
            default:
                text2.text = "エラーメッセージ";
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
