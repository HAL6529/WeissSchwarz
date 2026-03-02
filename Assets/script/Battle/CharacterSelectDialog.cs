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
    [SerializeField] BattleModeGuide m_BattleModeGuide;

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

    private bool isMine;

    private class BattleModeCardForGuide : BattleModeCard { }

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
                continue;
            }
            else
            {
                images[i].sprite = list[i].GetSprite();
                buttons[i].interactable = true;
            }

            if (m_EnemyMainCardsManager.GetUntouchable(i))
            {
                buttons[i].interactable = false;
                cnt++;
                continue;
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

    public void Open(BattleModeCard card, bool isMine, EnumController.CharacterSelectDialog paramater, int place, int minNum, int maxNum)
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
        this.isMine = isMine;
        int cnt = 0;

        // 最低選ばないといけないカードの枚数と最大選べるカードの枚数の定義設定
        this.minNum = minNum;
        this.maxNum = maxNum;

        for (int i = 0; i < images.Count; i++)
        {
            if (list[i] == null)
            {
                images[i].sprite = BackImage;
                buttons[i].interactable = false;
                cnt++;
            }
            else
            {
                images[i].sprite = list[i].GetSprite();
                if (i == place)
                {
                    buttons[i].interactable = false;
                    cnt++;
                    continue;
                }
                else
                {
                    buttons[i].interactable = true;
                }

                if (!isMine && m_EnemyMainCardsManager.GetUntouchable(i))
                {
                    buttons[i].interactable = false;
                    cnt++;
                    continue;
                }

                switch (paramater)
                {
                    // 前列のカードだけ対象
                    case EnumController.CharacterSelectDialog.OnlyFrontLine:
                        if (i >= 3)
                        {
                            buttons[i].interactable = false;
                            cnt++;
                        }
                        break;
                    // レベル2以下のキャラかつ前列のカードのみ対象
                    case EnumController.CharacterSelectDialog.OnlyFrontLineAndUnderLv2:
                        if (m_EnemyMainCardsManager.GetFieldLevel(i) > 2 || i >= 3)
                        {
                            buttons[i].interactable = false;
                            cnt++;
                        }
                        break;
                    // レベル1以下のキャラかつ前列のカードのみ対象
                    case EnumController.CharacterSelectDialog.OnlyFrontLineAndUnderLv1:
                        if (m_EnemyMainCardsManager.GetFieldLevel(i) > 1 || i >= 3)
                        {
                            buttons[i].interactable = false;
                            cnt++;
                        }
                        break;
                    // レベル0以下のキャラかつ前列のカードのみ対象
                    case EnumController.CharacterSelectDialog.OnlyFrontLineAndUnderLv0:
                        if (m_EnemyMainCardsManager.GetFieldLevel(i) > 0 || i >= 3)
                        {
                            buttons[i].interactable = false;
                            cnt++;
                        }
                        break;
                    // レベル1以下のキャラのみ対象
                    case EnumController.CharacterSelectDialog.UnderLv1:
                        if (m_EnemyMainCardsManager.GetFieldLevel(i) > 1)
                        {
                            buttons[i].interactable = false;
                            cnt++;
                        }
                        break;
                    // レベル0以下のキャラのみ対象
                    case EnumController.CharacterSelectDialog.UnderLv0:
                        if (m_EnemyMainCardsManager.GetFieldLevel(i) > 0)
                        {
                            buttons[i].interactable = false;
                            cnt++;
                        }
                        break;
                    // レベル1以上のキャラのみ対象
                    case EnumController.CharacterSelectDialog.Lv1orMore:
                        if (m_MyMainCardsManager.GetFieldLevel(i) < 1)
                        {
                            buttons[i].interactable = false;
                            cnt++;
                        }
                        break;
                    // 順平を含むキャラのみ対象
                    case EnumController.CharacterSelectDialog.ContainJunpei:
                        if (!m_MyMainCardsManager.isContainFieldName(i, "順平"))
                        {
                            buttons[i].interactable = false;
                            cnt++;
                        }
                        break;
                    // スタンドしているキャラのみ対象
                    case EnumController.CharacterSelectDialog.OnlyStand:
                        if (m_MyMainCardsManager.GetState(i) != EnumController.State.STAND)
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

        EffectAbstract m_EffectAbstract = m_BattleModeCard.m_EffectAbstract.Clone();
        m_EffectAbstract.m_GameManager = m_GameManager;
        m_EffectAbstract.m_BattleStrix = m_BattleStrix;
        m_EffectAbstract.m_BattleModeCard = m_BattleModeCard;
        m_EffectAbstract.m_DialogManager = m_GameManager.m_DialogManager;
        m_EffectAbstract.m_EnemyMainCardsManager = m_EnemyMainCardsManager;
        m_EffectAbstract.m_EventAnimationManager = m_GameManager.m_EventAnimationManager;
        m_EffectAbstract.m_MainPowerUpDialog = m_GameManager.m_DialogManager.m_MainPowerUpDialog;
        m_EffectAbstract.m_MyMainCardsManager = m_MyMainCardsManager;
        m_EffectAbstract.m_WinAndLose = m_GameManager.m_WinAndLose;
        m_EffectAbstract.SetExecuteParamater(1);

        if (cnt >= 5)
        {
            m_EffectAbstract.CharacterSelectDialogExecuteAfter();
            return;
        }
        this.gameObject.SetActive(true);
    }

    public void ButtonClick(int num)
    {
        if (isMine)
        {
            BattleModeCard t_BattleModeCard = new BattleModeCardForGuide();
            t_BattleModeCard.SetPower(m_MyMainCardsManager.GetFieldPower(num));
            t_BattleModeCard.SetSoul(m_MyMainCardsManager.GetFieldSoul(num));
            t_BattleModeCard.SetLevel(m_MyMainCardsManager.GetFieldLevel(num));
            t_BattleModeCard.SetAttribute(m_MyMainCardsManager.GetFieldAttributeList(num));

            m_BattleModeGuide.showImage(m_MyMainCardsManager.GetBattleModeCard(num), t_BattleModeCard);
        }
        else
        {
            BattleModeCard t_BattleModeCard = new BattleModeCardForGuide();
            t_BattleModeCard.SetPower(m_EnemyMainCardsManager.GetFieldPower(num));
            t_BattleModeCard.SetSoul(m_EnemyMainCardsManager.GetFieldSoul(num));
            t_BattleModeCard.SetLevel(m_EnemyMainCardsManager.GetFieldLevel(num));
            t_BattleModeCard.SetAttribute(m_EnemyMainCardsManager.GetFieldAttributeList(num));

            m_BattleModeGuide.showImage(m_EnemyMainCardsManager.GetBattleModeCard(num), t_BattleModeCard);
        }


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

        EffectAbstract m_EffectAbstract = m_BattleModeCard.m_EffectAbstract.Clone();
        m_EffectAbstract.m_GameManager = m_GameManager;
        m_EffectAbstract.m_BattleStrix = m_BattleStrix;
        m_EffectAbstract.m_BattleModeCard = m_BattleModeCard;
        m_EffectAbstract.m_DialogManager = m_GameManager.m_DialogManager;
        m_EffectAbstract.m_EnemyMainCardsManager = m_EnemyMainCardsManager;
        m_EffectAbstract.m_EventAnimationManager = m_GameManager.m_EventAnimationManager;
        m_EffectAbstract.m_MainPowerUpDialog = m_GameManager.m_DialogManager.m_MainPowerUpDialog;
        m_EffectAbstract.m_MyMainCardsManager = m_MyMainCardsManager;
        m_EffectAbstract.m_WinAndLose = m_GameManager.m_WinAndLose;
        m_EffectAbstract.SetExecuteParamater(1);

        if(m_EffectAbstract != null)
        {
            m_EffectAbstract.CharacterSelectDialogExecute(ButtonSelectedNumList);
            return;
        }
        OffDialog();
        return;
    }

    public void onMinimumBtn()
    {
        this.gameObject.SetActive(false);
        Dialog_Hide.SetActive(true);
    }
}