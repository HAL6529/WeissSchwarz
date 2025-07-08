using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectDialog : MonoBehaviour
{
    [SerializeField] List<Image> images = new List<Image>();
    [SerializeField] List<Button> buttons = new List<Button>();
    [SerializeField] MyMainCardsManager m_MyMainCardsManager;
    [SerializeField] EnemyMainCardsManager m_EnemyMainCardsManager;
    [SerializeField] GameObject m_OKButton;
    [SerializeField] Sprite BackImage;
    [SerializeField] GameManager m_GameManager;
    [SerializeField] BattleStrix m_BattleStrix;
    [SerializeField] DialogManager m_DialogManager;
    [SerializeField] RectTransform m_RectTransform;
    [SerializeField] List<RectTransform> RectTransformList = new List<RectTransform>();
    [SerializeField] GameObject Dialog_Hide;
    private int place = -1;

    /// <summary>
    /// 最低選ばないといけない枚数、定義がなければ-1
    /// </summary>
    private int minNum = -1;

    /// <summary>
    /// 最大選べる枚数、定義がなければ-1
    /// </summary>
    private int maxNum = -1;

    private List<bool> ButtonSelectedNumList = new List<bool> { false, false, false, false, false, };
    private BattleModeCard m_BattleModeCard = null;
    
    private EnumController.YesOrNoDialogParamater m_YesOrNoDialogParamater;
    private int damage;

    /// <summary>
    /// バウンストリガー用
    /// </summary>
    /// <param name="isMine"></param>
    /// <param name="paramater"></param>
    public void Open(int damage, int place, EnumController.YesOrNoDialogParamater paramater)
    {
        m_YesOrNoDialogParamater = paramater;
        m_GameManager.isCharacterSelectDialogProcess = true;
        List<BattleModeCard> list = new List<BattleModeCard>();
        list = m_GameManager.enemyFieldList;
        m_RectTransform.rotation = Quaternion.Euler(0, 0, 180.0f);
        for (int i = 0; i < RectTransformList.Count; i++)
        {
            if (m_EnemyMainCardsManager.GetState(i) == EnumController.State.STAND)
            {
                RectTransformList[i].rotation = Quaternion.Euler(0, 0, 180.0f);
            }
            else if (m_EnemyMainCardsManager.GetState(i) == EnumController.State.REST)
            {
                RectTransformList[i].rotation = Quaternion.Euler(0, 0, 90.0f);
            }
            else
            {
                RectTransformList[i].rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        m_OKButton.SetActive(false);
        ButtonSelectedNumList = new List<bool> { false, false, false, false, false, };
        this.place = place;
        this.damage = damage;
        m_BattleModeCard = null;
        int cnt = 0;
        minNum = 0;
        maxNum = 1;

        for (int i = 0; i < images.Count; i++)
        {
            if (list[i] == null)
            {
                images[i].sprite = BackImage;
                cnt++;
                buttons[i].interactable = false;
            }
            else
            {
                images[i].sprite = list[i].sprite;
                buttons[i].interactable = true;
            }
        }
        if (cnt >= 5)
        {
            m_GameManager.Syncronize();

            switch (m_YesOrNoDialogParamater)
            {
                case EnumController.YesOrNoDialogParamater.CONFIRM_BOUNCE_TRIGGER_DIRECT:
                    m_BattleStrix.RpcToAll("Damage", damage, m_GameManager.isFirstAttacker, EnumController.Damage.DIRECT_ATTACK, m_GameManager.SendShotList);
                    break;
                case EnumController.YesOrNoDialogParamater.CONFIRM_BOUNCE_TRIGGER_SIDE:
                    m_BattleStrix.RpcToAll("Damage", damage, m_GameManager.isFirstAttacker, EnumController.Damage.SIDE_ATTACK, m_GameManager.SendShotList);
                    break;
                case EnumController.YesOrNoDialogParamater.CONFIRM_BOUNCE_TRIGGER_FRONT:
                    // ("CallOKDialogForCounter",int damage, int place, m_GameManager.isFirstAttacker,List<EnumController.Shot> ReceiveShotList)
                    m_BattleStrix.RpcToAll("CallOKDialogForCounter", damage, place, m_GameManager.isFirstAttacker, m_GameManager.SendShotList);
                    break;
                default:
                    break;
            }
            OffDialog();
            return;
        }
        this.gameObject.SetActive(true);
    }

    public void Open(BattleModeCard card, bool isMine, int place)
    {
        m_YesOrNoDialogParamater = EnumController.YesOrNoDialogParamater.VOID;
        m_GameManager.isCharacterSelectDialogProcess = true;
        List<BattleModeCard> list = new List<BattleModeCard>();
        if (isMine)
        {
            list = m_GameManager.myFieldList;
            m_RectTransform.rotation = Quaternion.Euler(0, 0, 0);
            for (int i = 0; i < RectTransformList.Count; i++)
            {
                if (m_MyMainCardsManager.GetState(i) == EnumController.State.STAND)
                {
                    RectTransformList[i].rotation = Quaternion.Euler(0, 0, 0);
                }
                else if (m_MyMainCardsManager.GetState(i) == EnumController.State.REST)
                {
                    RectTransformList[i].rotation = Quaternion.Euler(0, 0, 90.0f);
                }
                else
                {
                    RectTransformList[i].rotation = Quaternion.Euler(0, 0, 180.0f);
                }
            }
        }
        else
        {
            list = m_GameManager.enemyFieldList;
            m_RectTransform.rotation = Quaternion.Euler(0, 0, 180.0f);
            for (int i = 0; i < RectTransformList.Count; i++)
            {
                if (m_EnemyMainCardsManager.GetState(i) == EnumController.State.STAND)
                {
                    RectTransformList[i].rotation = Quaternion.Euler(0, 0, 180.0f);
                }
                else if (m_EnemyMainCardsManager.GetState(i) == EnumController.State.REST)
                {
                    RectTransformList[i].rotation = Quaternion.Euler(0, 0, 90.0f);
                }
                else
                {
                    RectTransformList[i].rotation = Quaternion.Euler(0, 0, 0);
                }
            }
        }
        m_OKButton.SetActive(false);
        ButtonSelectedNumList = new List<bool> { false, false, false, false, false, };
        this.place = place;
        m_BattleModeCard = card;
        int cnt = 0;

        // 最低選ばないといけないカードの枚数と最大選べるカードの枚数の定義設定
        switch (m_BattleModeCard.cardNo)
        {
            case EnumController.CardNo.AT_WX02_A02:
            case EnumController.CardNo.DC_W01_05T:
            case EnumController.CardNo.DC_W01_18T:
            case EnumController.CardNo.LB_W02_02T:
            case EnumController.CardNo.LB_W02_09T:
            case EnumController.CardNo.P3_S01_04T:
            case EnumController.CardNo.P3_S01_12T:
            case EnumController.CardNo.P3_S01_010:
                minNum = 1;
                maxNum = 1;
                break;
            case EnumController.CardNo.DC_W01_07T:
            case EnumController.CardNo.P3_S01_01T:
            case EnumController.CardNo.P3_S01_11T:
            case EnumController.CardNo.P3_S01_005:
            case EnumController.CardNo.P3_S01_017:
                minNum = 0;
                maxNum = 1;
                break;
            case EnumController.CardNo.LB_W02_04T:
                minNum = -1;
                maxNum = 2;
                break;
            default:
                break;
        }


        for (int i = 0; i < images.Count; i++)
        {
            if (list[i] == null)
            {
                images[i].sprite = BackImage;
                cnt++;
                buttons[i].interactable = false;
            }
            else
            {
                images[i].sprite = list[i].sprite;
                if (i == place)
                {
                    buttons[i].interactable = false;
                }
                else
                {
                    buttons[i].interactable = true;
                }

                switch (m_BattleModeCard.cardNo)
                {
                    // 前列のカードだけ対象
                    case EnumController.CardNo.DC_W01_05T:
                        if(i >= 3)
                        {
                            buttons[i].interactable = false;
                            cnt++;
                        }
                        break;
                    // レベル1以下のキャラのみ対象
                    case EnumController.CardNo.DC_W01_18T:
                        if (m_EnemyMainCardsManager.GetFieldLevel(i) > 1)
                        {
                            buttons[i].interactable = false;
                            cnt++;
                        }
                        break;
                    default:
                        break;
                }
            }
        }


        switch (m_BattleModeCard.cardNo)
        {
            // ほかにキャラクターがいなければreturnする
            case EnumController.CardNo.AT_WX02_A02:
                if (cnt >= 4)
                {
                    m_GameManager.Syncronize();
                    m_GameManager.ExecuteActionList();
                    OffDialog();
                    return;
                }
                break;
            // キャラクターがいなければreturnする
            case EnumController.CardNo.DC_W01_05T:
            case EnumController.CardNo.DC_W01_07T:
            case EnumController.CardNo.DC_W01_18T:
            case EnumController.CardNo.LB_W02_02T:
            case EnumController.CardNo.LB_W02_09T:
            case EnumController.CardNo.P3_S01_01T:
            case EnumController.CardNo.P3_S01_04T:
            case EnumController.CardNo.P3_S01_11T:
            case EnumController.CardNo.P3_S01_12T:
            case EnumController.CardNo.P3_S01_005:
            case EnumController.CardNo.P3_S01_010:
            case EnumController.CardNo.P3_S01_017:
                if (cnt >= 5)
                {
                    m_GameManager.Syncronize();
                    m_GameManager.ExecuteActionList();
                    OffDialog();
                    return;
                }
                break;
            default:
                break;
        }
        this.gameObject.SetActive(true);
    }

    public void ButtonClick(int num)
    {
        if (ButtonSelectedNumList[num])
        {
            images[num].color = new Color(1, 255 / 255, 255 / 255, 255 / 255);
            ButtonSelectedNumList[num] = false;
        }
        else
        {
            images[num].color = new Color(145f / 255f, 145f / 255f, 145f / 255f, 145f / 255f);
            ButtonSelectedNumList[num] = true;
        }

        //OKボタンをアクティブにするか判定
        int cnt = 0;
        for(int i = 0; i < ButtonSelectedNumList.Count; i++)
        {
            if (ButtonSelectedNumList[i])
            {
                cnt++;
            }
        }

        if(cnt < minNum || maxNum < cnt)
        {
            m_OKButton.SetActive(false);
        }
        else
        {
            m_OKButton.SetActive(true);
        }
    }

    public void OffDialog()
    {
        this.gameObject.SetActive(false);
        for (int i = 0; i < images.Count; i++)
        {
            images[i].color = new Color(1, 255 / 255, 255 / 255, 255 / 255);
        }
        place = -1;
        m_GameManager.isCharacterSelectDialogProcess = false;
    }

    public void OKButton()
    {
        if (m_YesOrNoDialogParamater == EnumController.YesOrNoDialogParamater.CONFIRM_BOUNCE_TRIGGER_FRONT || m_YesOrNoDialogParamater == EnumController.YesOrNoDialogParamater.CONFIRM_BOUNCE_TRIGGER_SIDE || m_YesOrNoDialogParamater == EnumController.YesOrNoDialogParamater.CONFIRM_BOUNCE_TRIGGER_DIRECT)
        {
            for (int i = 0; i < ButtonSelectedNumList.Count; i++)
            {
                if (ButtonSelectedNumList[i])
                {
                    // 相手のカードをバウンスする
                    m_BattleStrix.RpcToAll("ToHandFromField", i, m_GameManager.isTurnPlayer);
                }
            }
            m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
            m_GameManager.Syncronize();
            switch (m_YesOrNoDialogParamater)
            {
                case EnumController.YesOrNoDialogParamater.CONFIRM_BOUNCE_TRIGGER_DIRECT:
                    m_BattleStrix.RpcToAll("Damage", damage, m_GameManager.isFirstAttacker, EnumController.Damage.DIRECT_ATTACK, m_GameManager.SendShotList);
                    break;
                case EnumController.YesOrNoDialogParamater.CONFIRM_BOUNCE_TRIGGER_SIDE:
                    m_BattleStrix.RpcToAll("Damage", damage, m_GameManager.isFirstAttacker, EnumController.Damage.SIDE_ATTACK, m_GameManager.SendShotList);
                    break;
                case EnumController.YesOrNoDialogParamater.CONFIRM_BOUNCE_TRIGGER_FRONT:
                    // ("CallOKDialogForCounter",int damage, int place, m_GameManager.isFirstAttacker,List<EnumController.Shot> ReceiveShotList)
                    m_BattleStrix.RpcToAll("CallOKDialogForCounter", damage, place, m_GameManager.isFirstAttacker, m_GameManager.SendShotList);
                    break;
                default:
                    break;
            }
            OffDialog();
            return;
        }
        int power = 0;
        switch (m_BattleModeCard.cardNo)
        {
            case EnumController.CardNo.P3_S01_12T:
                power = 3000;
                break;
            case EnumController.CardNo.P3_S01_04T:
            case EnumController.CardNo.P3_S01_010:
                power = 2000;
                break;
            case EnumController.CardNo.AT_WX02_A02:
            case EnumController.CardNo.LB_W02_02T:
                power = 1500;
                break;
            case EnumController.CardNo.DC_W01_07T:
            case EnumController.CardNo.LB_W02_04T:
                power = 1000;
                break;
            case EnumController.CardNo.LB_W02_09T:
                power = -500;
                break;
            case EnumController.CardNo.DC_W01_05T:
                power = -1000;
                break;
            default:
                break;
        }

        for (int i = 0; i < ButtonSelectedNumList.Count; i++)
        {
            if (!ButtonSelectedNumList[i])
            {
                continue;
            }
            switch (m_BattleModeCard.cardNo)
            {
                case EnumController.CardNo.AT_WX02_A02:
                case EnumController.CardNo.DC_W01_07T:
                case EnumController.CardNo.LB_W02_02T:
                case EnumController.CardNo.LB_W02_04T:
                    // 自分のカードのパワーを操作する
                    if (ButtonSelectedNumList[i])
                    {
                        m_MyMainCardsManager.AddPowerUpUntilTurnEnd(i, power);
                    }
                    break;
                case EnumController.CardNo.DC_W01_05T:
                case EnumController.CardNo.LB_W02_09T:
                    // 相手のカードのパワーを操作する
                    if (ButtonSelectedNumList[i])
                    {
                        m_BattleStrix.RpcToAll("CallAddPowerUpUntilTurnEnd", m_GameManager.isTurnPlayer, i, power);
                    }
                    break;
                case EnumController.CardNo.DC_W01_18T:
                    // 相手のカードを控室に送る
                    if (ButtonSelectedNumList[i])
                    {
                        m_BattleStrix.RpcToAll("ToGraveYardFromField", i, m_GameManager.isTurnPlayer);
                    }
                    break;
                case EnumController.CardNo.P3_S01_01T:
                case EnumController.CardNo.P3_S01_11T:
                case EnumController.CardNo.P3_S01_005:
                case EnumController.CardNo.P3_S01_017:
                    // 相手のカードをバウンスする
                    if (ButtonSelectedNumList[i])
                    {
                        m_BattleStrix.RpcToAll("ToHandFromField", i, m_GameManager.isTurnPlayer);
                    }
                    break;
                case EnumController.CardNo.P3_S01_04T:
                case EnumController.CardNo.P3_S01_12T:
                case EnumController.CardNo.P3_S01_010:
                    // 自分のカードのパワーとソウルを操作する
                    m_MyMainCardsManager.AddSoulUpUntilTurnEnd(i, 1);
                    m_MyMainCardsManager.AddPowerUpUntilTurnEnd(i, power);
                    m_GameManager.Syncronize();
                    break;
                default:
                    break;
            }

        }

        switch (m_BattleModeCard.cardNo)
        {
            case EnumController.CardNo.DC_W01_05T:
            case EnumController.CardNo.LB_W02_09T:
                Action action = new Action(m_GameManager, EnumController.Action.EncoreCheck);
                action.SetParamaterDialogManager(m_DialogManager);

                m_GameManager.ActionList.Add(action);
                break;
            default:
                break;
        }

        // イベントカードの場合は処理後に控室にカードを追加
        switch (m_BattleModeCard.cardNo)
        {
            case EnumController.CardNo.DC_W01_18T:
            case EnumController.CardNo.LB_W02_04T:
            case EnumController.CardNo.P3_S01_12T:
                m_GameManager.myHandList.Remove(m_BattleModeCard);
                m_GameManager.GraveYardList.Add(m_BattleModeCard);
                break;
            default:
                break;
        }

        switch (m_BattleModeCard.cardNo)
        {
            case EnumController.CardNo.DC_W01_07T:
                m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
                break;
            default:
                break;
        }
        m_GameManager.Syncronize();

        m_GameManager.ExecuteActionList();
        OffDialog();
    }

    public void onMinimumBtn()
    {
        this.gameObject.SetActive(false);
        Dialog_Hide.SetActive(true);
    }
}